using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Totp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using TPort.Domain.UserManagement;
using TPort.Infrastructure.DataAccess;
using TPort.Infrastructure.WorkingWithApi;
using TPort.Services;
using TPortApi.Filters;
using TPortApi.Security;

namespace TPortApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
                options.Filters.Add(typeof(ModelValidationFilter));
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            IAccountRepository accountRepository = new InMemoryAccountRepository(new Dictionary<string, Account>());
            var accountManager = new AccountManager(accountRepository);

            var totpManager = new TotpManager(new TotpGenerator(),
                Configuration["TotpSettings:totpSecretKey"],
                Configuration.GetValue<int>("TotpSettings:totpTokenLifetimeInSeconds"),
                new InMemoryTotpTokenRepository(new Dictionary<string, int>()));

            var smsManager = new SmsManager();
            
            var routeManager = new RouteManager(new AirTicketManager(new AirTicketsApi(
                Configuration["AirApiSettings:token"],
                Configuration["AirApiSettings:url"])));
                        
            services.AddSingleton(ConfigureSecurity(services));
            services.AddSingleton(routeManager);
            services.AddSingleton(accountManager);
            services.AddSingleton(totpManager);
            services.AddSingleton(smsManager);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        
        private IJwtIssuer ConfigureSecurity(IServiceCollection services)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["securitySettings:tokenKey"]));
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = key
                    });
            services
                .AddAuthorization(options =>
                {
                    options.DefaultPolicy =
                        new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser().Build();
                });

            var jwtIssuer = new JwtIssuer(key,
                TimeSpan.FromMinutes(Configuration.GetValue<int>("securitySettings:tokenLifeMinutes")));

            
            return jwtIssuer;
        }
    }
}