using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        public Random rnd = new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTimeInMS = rnd.Next(1, 300);

            if (responseTimeInMS < 100)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"The response time looks good ({responseTimeInMS}).")
                   );
            }
            else if (responseTimeInMS < 200)
            {
                return Task.FromResult(
                    HealthCheckResult.Degraded($"The response time is a bit slow ({responseTimeInMS}).")
                   );
            }
            else
            {
                return Task.FromResult(
                      HealthCheckResult.Unhealthy($"The response time is unacceptable ({responseTimeInMS}).")
                     );
            }


        }
    }

}
