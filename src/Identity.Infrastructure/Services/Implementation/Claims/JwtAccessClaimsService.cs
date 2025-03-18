﻿using Identity.Application.Models;
using Identity.Infrastructure.Services.Abstract;
using Identity.Infrastructure.Services.Abstract.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services.Implementation.Claims
{
    public class JwtAccessClaimsService(IRolesClaimService rolesClaimService)
        : IClaimsService<JwtAccessTokenDto>
    {
        public IEnumerable<Claim> Create(JwtAccessTokenDto details)
        {
            Claim jti = new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            Claim iat = new(JwtRegisteredClaimNames.Iat,
                EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),
                ClaimValueTypes.Integer64);
            Claim id = new(ClaimTypes.NameIdentifier, details.UserId);
            Claim sessionId = new(ClaimTypes.Sid, details.SessionId);
            
            List<Claim> claims =
            [
                jti,
                iat,
                id,
                sessionId
            ];

            if (details.ServiceAuthInfo is not null)
            {
                Claim categoryId = new("providerType", details.ServiceAuthInfo.ProviderType.ToString());
                Claim providerId = new("providerId", details.ServiceAuthInfo.ProviderId.ToString());
                Claim providerPermissions = new("providerPermissions",
                    JsonSerializer.Serialize(details.ServiceAuthInfo.ClaimTypeAndValuePairs));

                claims.Add(categoryId);
                claims.Add(providerId);
                claims.Add(providerPermissions);
            }

            IEnumerable<Claim> roles = rolesClaimService.Create(details.Roles);
            claims.AddRange(roles);

            return claims;
        }
    }
}
