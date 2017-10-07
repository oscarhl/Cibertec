﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using FluentValidation.AspNetCore;
using Cibertec.WebApi.Validators;
using Cibertec.Models;
using FluentValidation;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Cibertec.WebApi.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Cibertec.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork>
          (
              option => new NorthwindUniOftWork
              (
                  Configuration.GetConnectionString("Northwind")
               )
          );

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Customer>, CustomerValidator>();

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            options.Level = CompressionLevel.Optimal);


            //authentication

            var tokenProvider = new RsaJwtTokenProvider("issuer", "audience", "token_cibertec_2017");

            services.AddSingleton<ITokenProvider>(tokenProvider);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters =
                    tokenProvider.GetValidationParameters();
                });

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
