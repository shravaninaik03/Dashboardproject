namespace projectdashboard.Interface;

public interface IRepository
{
    public Task<int>GetAllProjectsByFunctionAsync();
     public Task<int> GetAllTasksByFunctionAsync();
    public Task<int> GetAllProjectsAsync();
    public Task<int> GetAllTasksAsync();
}