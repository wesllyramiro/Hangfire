using AtualizarEstoqueAutomatico.Jobs;
using Hangfire;
using System;

namespace AtualizarEstoqueAutomatico
{
    public class JobsSchedule
    {
        public static void Schedule() 
        {
            RecurringJob
                .AddOrUpdate<IAtualizarEstoqueJob>(
                    recurringJobId:  "AtualizarEstoque",
                    methodCall:      job => job.Run(),
                    cronExpression:  Cron.Monthly(14)
                    //cronExpression:  "0 0 0/1 ? * SUN,SAT *" 
                    //timeZone:        TimeZoneInfo.FindSystemTimeZoneById("America/Fortaleza")
                );
        }
    }
}
