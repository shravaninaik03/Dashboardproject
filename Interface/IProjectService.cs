namespace projectdashboard.Interface;

public interface IProjectService
{
    public  Task<int> GetTotalProjects();

    public Task<int> GetTotalTasks();
}