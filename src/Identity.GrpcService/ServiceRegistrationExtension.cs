﻿using MarketToolsV3.ConfigurationManager.Models;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.GrpcService
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection collection, MessageBrokerConfig messageBrokerConfig)
        {
            collection.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(messageBrokerConfig.RabbitMqConnection,
                        "/",
                        h =>
                        {
                            h.Username(messageBrokerConfig.RabbitMqLogin);
                            h.Password(messageBrokerConfig.RabbitMqPassword);
                        });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return collection;
        }

        public static void AddServiceAuthentication(this IServiceCollection collection, AuthConfig authConfig)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(authConfig.AuthSecret);

            collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    {
                        opt.IncludeErrorDetails = false;
                        opt.SaveToken = true;
                        opt.RequireHttpsMetadata = false;
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = authConfig.IsCheckValidIssuer,
                            ValidateAudience = authConfig.IsCheckValidAudience,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidAudience = authConfig.ValidAudience,
                            ValidIssuer = authConfig.ValidIssuer,
                            IssuerSigningKey = new SymmetricSecurityKey(secretBytes)
                        };
                    }
                });
        }
    }
}
