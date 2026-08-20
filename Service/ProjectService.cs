using Microsoft.AspNetCore.DataProtection.Repositories;
using projectdashboard.Interface;

namespace projectdashboard.Service;

public class ProjectService: IProjectService
{
    private readonly IRepository _repository;
    public ProjectService(IRepository repository)
    {
        _repository=repository;
    }

    public async Task<int> GetTotalProjects()
    {
        return await _repository.GetAllProjectsByFunctionAsync();
    }

    public async Task<int> GetTotalTasks()
    {
        return await _repository.GetAllTasksByFunctionAsync();
    }
}