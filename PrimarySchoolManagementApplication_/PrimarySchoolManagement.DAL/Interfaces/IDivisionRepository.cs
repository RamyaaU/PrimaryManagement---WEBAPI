using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL.Interfaces
{
    public interface IDivisionRepository
    {
        Task<List<Division>> GetAllAsync();

        Task<Division?> GetByIdAsync(int id);

        Task AddAsync(Division division);

        Task UpdateAsync(Division division);

        Task<List<Division>> FilterClassByName(string name);
    }
}
