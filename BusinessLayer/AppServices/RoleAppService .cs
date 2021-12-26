using Business_layer.Bases;
using Business_layer.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.AppServices
{
    public class RoleAppService : BaseAppService
    {
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }
    }
}
