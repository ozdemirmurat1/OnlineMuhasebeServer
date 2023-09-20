using ClosedXML.Excel;
using Newtonsoft.Json;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Persistence.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OnlineMuhasebeServer.RabbitMQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadQueue();
            Console.ReadLine();
        }

        static void ReadQueue()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zfggoqfw:HYInPHO_PbN61Ib7ZwQM8jkbAd0M6I3B@codfish.rmq.cloudamqp.com/zfggoqfw");

            using var connection=factory.CreateConnection();

            var channel=connection.CreateModel();

            channel.QueueDeclare("Reports", true, false, false);

            var consumer=new EventingBasicConsumer(channel);
            channel.BasicConsume("Reports", true, consumer);

            consumer.Received += Consumer_Received;

        }

        private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            string reportString=Encoding.UTF8.GetString(e.Body.ToArray());

            ReportDto reportDto=JsonConvert.DeserializeObject<ReportDto>(reportString)!;

            if (reportDto.Name=="Hesap Planı")
            {
                CreateUCAFExcel(reportDto);
            }
        }

        public static void CreateUCAFExcel(ReportDto reportDto)
        {
            Context.AppDbContext appDbContext = new();
            Company company= appDbContext.Set<Company>().Find(reportDto.CompanyId);

            CompanyDbContext companyDbContext=new(company);

            IList<UniformChartOfAccount> ucafs=companyDbContext.Set<UniformChartOfAccount>().OrderBy(p=>p.Code).ToList();

            string fileName = "";

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Hesap Planı");
                ws.Range("A1").Value = company.Name + "Hesap Planı";

                ws.Range("A3").Value = "Kod";
                ws.Range("B3").Value = "Tip";
                ws.Range("C3").Value = "Adı";

                int rowCount = 4;

                for (int i = 0; i < ucafs.Count(); i++)
                {
                    ws.Range("A" + rowCount).Value = ucafs[i].Code;
                    ws.Range("B" + rowCount).Value = ucafs[i].Type;
                    ws.Range("C" + rowCount).Value = ucafs[i].Name;
                    rowCount++;
                }

                fileName = ($"HesapPlani.{company.Id}.{DateTime.Now}.xlsx").Replace(":", ".");
                string filePath = $"C:/Users/Murat Özdemir/Desktop/Alıştırmalar/OnlineMuhasebe/OnlineMuhasebeClient/src/assets/reports/{fileName}";

                workbook.SaveAs(filePath);
                
            }

            Report report = companyDbContext.Set<Report>().Find(reportDto.Id);
            report.FileUrl = fileName;
            report.Status = true;
            report.UpdatedDate = DateTime.Now;

            companyDbContext.Update(report);
            companyDbContext.SaveChanges();

            Console.WriteLine("Excel başarıyla oluşturuldu!");
        }
    }
}