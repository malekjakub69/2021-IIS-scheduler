using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppEntities.Entities;
using App.Facades;
using App.Repositories;
using App.Migrations;
using AppModels.Models.Competences;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag.AspNetCore;
using System.Text;
using App.Seeds;
using AppModels.Models.Courses;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("https://localhost:5001", "http://localhost:5002").AllowAnyHeader().AllowAnyMethod();
                });
            });

            /*services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));*/

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
                // document.ApiGroupNames = new[] { "1.0" };
            });

            services.AddDbContextPool<AppDbContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("AppDbContextConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddScoped<CompetenceRepository>();
            services.AddScoped<CourseRepository>();
            services.AddScoped<CourseLeaderRepository>();
            services.AddScoped<CourseParticipantRepository>();
            services.AddScoped<DoneRepository>();
            services.AddScoped<LeaderRepository>();
            services.AddScoped<ParticipantRepository>();
            services.AddScoped<ScheduleDataRepository>();
            services.AddScoped<ScheduleRepository>();
            services.AddScoped<TimeBlockRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<VerificationRepository>();

            services.AddTransient<CompetenceFacade>();
            services.AddTransient<CourseFacade>();
            services.AddTransient<CourseLeaderFacade>();
            services.AddTransient<CourseParticipantFacade>();
            services.AddTransient<DoneFacade>();
            services.AddTransient<LeaderFacade>();
            services.AddTransient<ParticipantFacade>();
            services.AddTransient<ScheduleDataFacade>();
            services.AddTransient<ScheduleFacade>();
            services.AddTransient<TimeBlockFacade>();
            services.AddTransient<UserFacade>();
            services.AddTransient<VerificationFacade>();

            services.AddAutoMapper(typeof(EntityBase), typeof(CourseFacade), typeof(CourseDetailModel));

            services.AddControllers();

            RoleManager<IdentityRole> roleManager = services.BuildServiceProvider().GetService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = services.BuildServiceProvider().GetService<UserManager<IdentityUser>>();
            SeedAdministratorRoleAndUser.Seed(roleManager, userManager);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (true)
            { 

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.SwaggerRoutes.Add(new SwaggerUi3Route("version_1", "swagger/v1/swagger.json"));
            });
        }
    }
}
