using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWepAPI.Model;

namespace CoreWepAPI.Infrastructure
{
   public interface IDropDown
    {
        // IEnumerable<State> GetStates();

        Task<IEnumerable<State>> GetStates();

        Task<IEnumerable<District>> GetDistrict(int StateId);

        Task<IEnumerable<Category>> GetCategories();

        Task<IEnumerable<StudentClass>> GetStudentClasses();


        Task<IEnumerable<ApplicationRole>> GetApplicationRoles();

      //  District GetById(int id);

    }
}
