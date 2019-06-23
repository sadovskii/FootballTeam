﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.BLL.Implementation;
using Backend.BLL.Interfaces;
using Backend.DAL.EF;
using Backend.DAL.Entities;
using Backend.DAL.Interfaces.Repositories;
using Backend.DAL.Interfaces.Repositories.Other.GeneralInformation;
using Backend.DAL.Interfaces.Repositories.Other.InjuriesDiseases;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using Backend.DAL.Repositories;
using Backend.DAL.Repositories.Other.GeneralInformation;
using Backend.DAL.Repositories.Other.InjuriesDiseases;
using Backend.DAL.Repositories.Other.MedicalExamination;
using Backend.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Backend
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
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");

            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IGeneralInformationRepository, GeneralInformationRepository>();
            services.AddScoped<IInjuriesDiseasesRepository, InjuriesDiseasesRepository>();
            services.AddScoped<IMedicalExaminationRepository, MedicalExaminationRepository>();
            services.AddScoped<IFluorographyRepository, FluorographyRepository>();
            services.AddScoped<ISurgicalInterventionRepository, SurgicalInterventionRepository>();
            services.AddScoped<IVaccinationStatusRepository, VaccinationStatusRepository>();
            services.AddScoped<IHeartUltrasoundRepository, HeartUltrasoundRepository>();
            services.AddScoped<IMRIRepository, MRIRepository>();
            services.AddScoped<IBloodChemistryAnalysisRepository, BloodChemistryAnalysisRepository>();
            services.AddScoped<IDoctorsDiagnosisRepository, DoctorsDiagnosisRepository>();
            services.AddScoped<IElectrocardiogramRepository, ElectrocardiogramRepository>();
            services.AddScoped<IGeneralBloodAnalysisRepository, GeneralBloodAnalysisRepository>();
            services.AddScoped<IGeneralUrineAnalysisRepository, GeneralUrineAnalysisRepository>();

            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                await next();

                if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
