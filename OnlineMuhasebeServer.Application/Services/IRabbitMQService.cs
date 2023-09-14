using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services
{
    public interface IRabbitMQService
    {
        void SendQueue(Report report, string companyId);
    }
}
