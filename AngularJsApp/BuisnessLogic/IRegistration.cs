using AngularJsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsApp.BuisnessLogic
{
    public interface IRegistration
    {
        ICollection<tbl_registration> GetRegistrations();
        tbl_registration GetRegistration(int Id);
        bool CreateUser(tbl_registration registration);
        bool UpdateUser(tbl_registration registration);
        bool DeleteUser(int Id);
        bool Save();
    }
}
