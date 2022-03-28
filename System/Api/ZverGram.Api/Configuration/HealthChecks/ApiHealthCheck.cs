using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace ZverGram.Api.Configuration
{
    public class ApiHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken) )
        {
            var assembly = Assembly.Load("ZverGram.Api");
            var versionNumber = assembly.GetName().Version;
            return HealthCheckResult.Healthy(description: $"Build {versionNumber}");
        }
    }
}
