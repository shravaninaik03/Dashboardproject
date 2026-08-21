using projectdashboard.Interface;
using projectdashboard.Service;
using Npgsql;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
namespace projectdashboard.Repository;


public class ProjectRepository : IRepository
{
    private readonly string _connectionstring;
    public ProjectRepository(IConfiguration configuration)   //from configuration system
    {
        _connectionstring= configuration.GetConnectionString("DefaultConnection")!;
    }

    //By functions
    public async Task<int> GetAllProjectsByFunctionAsync()
    {
        await using var connection = new NpgsqlConnection(_connectionstring);   //creates a pgsql connection

        await connection.OpenAsync();                       //to open connection

        await using var command = connection.CreateCommand(); 
        command.CommandText= "Select public.get_total_projects();";

        var result = await command.ExecuteScalarAsync();      //executes and returns a single value

        return Convert.ToInt32(result);
    }
    public async Task<int>GetAllTasksByFunctionAsync()
    {
        await using var connection= new NpgsqlConnection(_connectionstring);
        await connection.OpenAsync();

        await using var command= connection.CreateCommand();
        command.CommandText= "Select TF.get_total_tasks();";

        var result = await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }


        //by Raw sql query
        public async Task<int> GetAllProjectsAsync()
    {
        await using var connection= new NpgsqlConnection(_connectionstring);
        await connection.OpenAsync();

        await using var command= connection.CreateCommand();
        command.CommandText="SELECT COUNT(*) FROM public.Projects;";

        var result= await command.ExecuteScalarAsync();
        return Convert.ToInt32(result);
    }

    public async Task<int> GetAllTasksAsync()
    {
        await using var connection = new NpgsqlConnection(_connectionstring);
        await connection.OpenAsync();

        await using var command= connection.CreateCommand();
        command.CommandText = """
        SELECT COUNT(*)
        FROM "TF"."Tasks" t
        INNER JOIN public."Projects" p
            ON t."EntityId" = p."Id"::text
        WHERE t."Entity" = 'PROJECT'
        AND t."IsDeleted" = false
        AND t."IsSystemTask" = false;
        """;

        var result= await command.ExecuteScalarAsync();

        return Convert.ToInt32(result);
    }


}

