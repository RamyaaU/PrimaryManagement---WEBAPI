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
    public class ClassRepository : IClassRepository
    {
        private readonly List<Class> _class = new List<Class>
        {
            new Class { Id = 1, ClassTeacher = "Teacher-A", GradeLevel="1B", Name="ClassA"},
            new Class { Id = 2, ClassTeacher = "Teacher-B", GradeLevel="1C", Name="ClassB"},
            new Class { Id = 3, ClassTeacher = "Teacher-C", GradeLevel="2C", Name="ClassC"}
        };

        public async Task<List<Class>> GetAllAsync()
        {
            return await Task.FromResult(_class);
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_class.FirstOrDefault(s => s.Id == id));
        }

        public async Task AddAsync(Class @class)
        {
            _class.Add(@class);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Class @class)
        {
            var existingClass = _class.FirstOrDefault(c => c.Id == @class.Id);

            if (existingClass != null)
            {
                existingClass.Name = @class.Name;
                existingClass.ClassTeacher = @class.ClassTeacher;
                existingClass.GradeLevel = @class.GradeLevel;
            }
            await Task.CompletedTask;
        }

        public async Task<List<Class>> FilterClassByName(string name)
        {
            return await Task.FromResult(_class.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}

