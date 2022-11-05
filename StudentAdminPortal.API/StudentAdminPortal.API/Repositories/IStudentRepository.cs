using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentAdminPortal.API.Data_Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentID);
        Task<List<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentsId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);    
    }
}
