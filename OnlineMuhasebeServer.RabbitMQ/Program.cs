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

            IList<UniformChartOfAccount> uniformChartOfAccount=companyDbContext.Set<UniformChartOfAccount>().OrderBy(p=>p.Code).ToList();

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Hesap Planı");
                
            }
        }
    }
}