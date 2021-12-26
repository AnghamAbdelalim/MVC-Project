using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.AppServices
{
    public class AccountAppService : BaseAppService
    {
        //Login
        public ApplicationUserIdentity Find(string name, string passworg)
        {
            return TheUnitOfWork.Account.Find(name, passworg);
        }
        public IdentityResult Register(RegisterViewodel user)
        {
            ApplicationUserIdentity identityUser =
                Mapper.Map<RegisterViewodel, ApplicationUserIdentity>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }
    }
}
