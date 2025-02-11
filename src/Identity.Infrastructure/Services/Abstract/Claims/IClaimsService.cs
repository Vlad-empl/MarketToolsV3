﻿using Identity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services.Abstract.Claims
{
    public interface IClaimsService<in T> where T : IToken
    {
        IEnumerable<Claim> Create(T details);
    }
}
