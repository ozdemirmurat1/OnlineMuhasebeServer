using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using RabbitMQ.Client;

namespace OnlineMuhasebeServer.Infrastructure.Services
{
    public sealed class RabbitMQService : IRabbitMQService
    {
        public void SendQueue(ReportDto reportDto)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zfggoqfw:HYInPHO_PbN61Ib7ZwQM8jkbAd0M6I3B@codfish.rmq.cloudamqp.com/zfggoqfw");

            using var connection=factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Reports", true, false, false);

            var body = "";
        }
    }
}
