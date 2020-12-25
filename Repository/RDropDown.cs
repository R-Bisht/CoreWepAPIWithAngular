using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWepAPI.Infrastructure;
using CoreWepAPI.Model;
using Microsoft.EntityFrameworkCore;



namespace CoreWepAPI.Repository
{
    public class RDropDown : IDropDown
    {
        private readonly AuthenticationContext _Context;

        public RDropDown(AuthenticationContext Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            return await _Context.States.ToListAsync();
        }

        public async Task<IEnumerable<District>> GetDistrict(int StateId)
        {
            // return await _Context.Districts.FirstOrDefaultAsync(a => a.DST_STATEID == StateId);

            return await _Context.Districts.Where(a => a.DST_STATEID == StateId).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await  _Context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<StudentClass>> GetStudentClasses()
        {
            return await _Context.studentClasses.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationRole>> GetApplicationRoles()
        {
            return await _Context.applicationRoles.ToListAsync();
        }
        


    }
}
