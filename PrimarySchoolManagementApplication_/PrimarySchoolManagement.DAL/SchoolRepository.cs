using PrimarySchoolManagement.DAL.Exceptions;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly List<School> _schools = new List<School>
        {
            new School {Id = 1, Name = "Test", Address = "Test001"},
            new School {Id = 2, Name = "Test", Address = "Test002"},
            new School {Id = 3, Name = "Test", Address = "Test003"},
        };

        public async Task<List<School>> GetAllAsync()
        {
            return await Task.FromResult(_schools);
        }

        public async Task<School?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_schools.FirstOrDefault(s => s.Id == id));
        }

        public async Task AddAsync(School school)
        {
            _schools.Add(school);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(School school)
        {
            var existingSchool = _schools.FirstOrDefault(s => s.Id == school.Id);

            if (existingSchool != null)
            {
                existingSchool.Name = school.Name;
                existingSchool.Address = school.Address;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var school = _schools.FirstOrDefault(s => s.Id == id);

            if (school != null)
            {
                school.IsDeleted = true;
            }
            else
            {
                throw new SchoolNotFound("School not found.");
            }
            await Task.CompletedTask;
        }

        //public async Task<List<School>> GetFilteredSchoolsAsync(Func<School, bool> filter)
        //{
        //    return await Task.FromResult(_schools.Where(filter).ToList());
        //}

        public async Task<List<School>> FilterSchoolByName(string name)
        {
            return await Task.FromResult(_schools.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}