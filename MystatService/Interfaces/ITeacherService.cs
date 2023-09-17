using Mystat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystatService.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task AddNewTeacherAsync(Teacher teacher);
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
        Task DeleteManyTeachersAsync(params int[] ids);
    }
}
