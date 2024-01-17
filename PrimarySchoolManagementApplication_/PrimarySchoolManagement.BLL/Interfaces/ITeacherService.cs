using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacherAsync(int id);
        Task AddTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
        //Task<List<Teacher>> GetFilteredTeacherAsync(Func<Teacher, bool> filter);

        Task<List<Teacher>> FilterTeacherAsyncByName(string name);
    }
}
