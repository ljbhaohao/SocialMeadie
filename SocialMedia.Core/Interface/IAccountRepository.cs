﻿using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
 public   interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel  signUpModel);
    }
}
