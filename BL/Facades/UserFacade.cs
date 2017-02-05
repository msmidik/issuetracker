using AutoMapper;
using BL.DTOs;
using BL.Repositories;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;

namespace BL.Facades
{
    public class UserFacade : AppFacadeBase
    {
        public UserRepository Repository { get; set; }
        public Func<AppUserManager> UserManagerFactory { get; set; }

        public void Register(UserDTO user)
        {
            using (UnitOfWorkProvider.Create())
            {
                var userManager = UserManagerFactory.Invoke();

                var appUser = Mapper.Map<AppUser>(user);

                userManager.Create(appUser, user.Password);
            }
        }

        public ClaimsIdentity Login(string email, string password)
        {
            using (UnitOfWorkProvider.Create())
            {
                using (var userManager = UserManagerFactory.Invoke())
                {
                    var wantedUser = userManager.FindByEmail(email);

                    if (wantedUser == null)
                    {
                        return null;
                    }

                    var user = userManager.Find(wantedUser.UserName, password);

                    if (user == null)
                    {
                        return null;
                    }

                    return userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                }

            }
        }

        public UserDTO GetUserById(int id)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appUser = Repository.GetById(id);
                return Mapper.Map<UserDTO>(appUser);
            }
        }

    }
}