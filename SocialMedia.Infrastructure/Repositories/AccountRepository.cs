using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new IdentityUser()
            {
                UserName=signUpModel.UserName,
                Email=signUpModel.Email,
            };
          return await _userManager.CreateAsync(user,signUpModel.Password);
        }
    }
}
