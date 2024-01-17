using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL.Interfaces
{
    public interface IDivisionService
    {
        Task<List<Division>> GetDivisionAsync();
        Task<Division> GetDivisionAsync(int id);
        Task AddDivisionAsync(Division division);
        Task UpdateDivisionAsync(Division division);
        Task<List<Division>> FilterDivisionAsyncByName(string name);
    }
}
