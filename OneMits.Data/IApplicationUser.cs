using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        ApplicationUser GetByUserName(string userName);
        IEnumerable<ApplicationUser> GetSearchUserName(string userName);
        IEnumerable<ApplicationUser> GetAll();
        OtpTable GetByEnrollment(string EnrollmentNumber);
        IEnumerable<OtpTable> GetAllStudents();

        Task UpdateUserRating(string id, Type type);
        Task AddLoginTime(LoginTime loginTime);
        Task AddVisit(Visits visits);
        Task Delete(string id);
        Task UnDelete(string id);
    }
}
