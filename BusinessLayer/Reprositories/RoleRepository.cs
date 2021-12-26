
using Data_access_Layer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Reprositories
{
    public class RoleRepository
    {
        ApplicationRoleManager manager;
        public RoleRepository(DbContext db)
        {
            manager = new ApplicationRoleManager(db);
        }

        public IdentityResult Create(string role)
        {
            return manager.CreateAsync(new IdentityRole(role)).Result;
        }

    }
}
