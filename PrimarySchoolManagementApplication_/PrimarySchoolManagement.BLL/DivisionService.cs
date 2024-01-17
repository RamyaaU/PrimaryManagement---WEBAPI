using PrimarySchoolManagement.BLL.Exceptions;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL
{
    public class DivisionService
    {
        public IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public Task AddDivisionAsync(Division division)
        {
            return _divisionRepository.GetAllAsync();
        }

        public async Task<Division> GetDivisionAsync(int id)
        {
            var division = await _divisionRepository.GetByIdAsync(id);

            if (division == null)

                throw new NotFoundException("Division not found.");
            return division;
        }

        public Task<List<Division>> GetDivisionAsync()
        {
            return _divisionRepository.GetAllAsync();
        }

        public Task UpdateDivisionAsync(Division division)
        {
            return _divisionRepository.UpdateAsync(division);
        }

        public async Task<List<Division>> FilterDivisionAsyncByName(string name)
        {
            var divisions = await _divisionRepository.GetAllAsync();
            return divisions.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
