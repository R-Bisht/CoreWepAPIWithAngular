using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWepAPI.Model;

namespace CoreWepAPI.Infrastructure
{
    public interface IAddStudentDetail
    {
        Task<AddStudentDetail> AddStudentDetail(AddStudentDetail Student);

        // Task<IEnumerable<AddStudentDetail>> GetStudentList();

        IQueryable<Object> GetStudentList(int IdentityUserRole, int IdentityUserId);
    }
}
