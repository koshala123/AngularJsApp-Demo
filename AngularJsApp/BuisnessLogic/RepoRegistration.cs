using AngularJsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJsApp.BuisnessLogic
{
    public class RepoRegistration : IRegistration
    {
        public Entities _entities;
        public RepoRegistration(Entities dbContext)
        {
            _entities = dbContext;
        }
        public bool CreateUser(tbl_registration registration)
        {
           _entities.tbl_registration.Add(registration);
           return Save();
        }

        public bool DeleteUser(int Id)
        {
            var deleteUser = _entities.tbl_registration.Where(a=>a.Id == Id).FirstOrDefault();
            _entities.tbl_registration.Remove(deleteUser);
            return Save();
        }

        public tbl_registration GetRegistration(int Id)
        {
            return _entities.tbl_registration.Where(a => a.Id == Id).FirstOrDefault();
        }

        public ICollection<tbl_registration> GetRegistrations()
        {
            return _entities.tbl_registration.OrderBy(a => a.Id).ToList();
        }

        public bool Save()
        {
            var save = _entities.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateUser(tbl_registration registration)
        {
           
            _entities.Entry(registration).State = EntityState.Modified;
            return Save();
        }
    }
}