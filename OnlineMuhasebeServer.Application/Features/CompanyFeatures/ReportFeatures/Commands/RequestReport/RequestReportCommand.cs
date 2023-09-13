using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport
{
    public sealed record RequestReportCommand(
        string Type,
        string CompanyId) : ICommand<RequestReportCommandResponse>;
}
