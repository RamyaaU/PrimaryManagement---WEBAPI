using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL
{
    public class DivisionRepository
    {
        private readonly List<Division> _division = new List<Division>
        {
            new Division {Id=1, Capacity=100, Name="Div-A"},
            new Division {Id=2, Capacity=70, Name="Div-B"},
            new Division {Id=3, Capacity=90, Name="Div-C"},
        };

        public async Task<List<Division>> GetAllAsync()
        {
            return await Task.FromResult(_division);
        }

        public async Task<Division?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_division.FirstOrDefault(d => d.Id == id));
        }

        public async Task AddAsync(Division division)
        {
            _division.Add(division);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Division division)
        {
            var existingDiv = _division.FirstOrDefault(d => d.Id == division.Id);

            if (existingDiv != null)
            {
                existingDiv.Name = division.Name;
                existingDiv.Capacity = division.Capacity;
            }
            await Task.CompletedTask;
        }

        public async Task<List<Division>> FilterDivisionByName(string name)
        {
            return await Task.FromResult(_division.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}
