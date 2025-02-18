using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class StudentService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl = "http://localhost:7071/api";

    public StudentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Get students by school
    public async Task<List<Student>> GetStudentsBySchoolAsync(string school)
    {
        return await _httpClient.GetFromJsonAsync<List<Student>>($"{_apiBaseUrl}/students/school/{school}");
    }

    // Get student count by school
    public async Task<List<SchoolCount>> GetStudentCountBySchoolAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SchoolCount>>($"{_apiBaseUrl}/students/schools/count");
    }
}

// Student model
public class Student
{
    public int StudentId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? School { get; set; }
}

// School count model
public class SchoolCount
{
    public string School { get; set; }
    public int Count { get; set; }
}
