using Quartz;

namespace HouseApp.Backend.FormulaOne.JobRunners;

public class DriversImporter : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        
        
        return Task.FromResult(true);
    }
}