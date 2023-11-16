using HouseApp.Backend.FormulaOne.JobRunners;
using Quartz;
using Quartz.AspNetCore;

namespace HouseApp.Backend.FormulaOne.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddBackgroundJobs(this WebApplicationBuilder builder)
    {
        builder.Services.AddQuartzServer(options =>
        {
            options.WaitForJobsToComplete = true;
        });
        
        builder.Services.AddQuartz(q =>
        {
            var jobKey = new JobKey(nameof(DriversImporter));
            q.AddJob<DriversImporter>(opts => opts.WithIdentity(jobKey));
    
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("SendEmailJob-trigger")
                .WithCronSchedule("0 5 * * * *")
            );
        });
    }
}