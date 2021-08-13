using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Todo.Application.Authentication;
using Todo.Application.Authentication.Interfaces;
using Todo.Application.AutoMapper;
using Todo.Application.TodoItems;
using Todo.Application.TodoItems.Interfaces;
using Todo.Application.Users;
using Todo.Application.Users.Interfaces;
using Todo.Infrastructure;

namespace Todo.API
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
            var securityKey = SignHandle.GetSecurityKey("mysecuritykeymysecuritykeymysecuritykeyahmet");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {

                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "www.todo.com",
                    ValidAudience = "www.todo.com",
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero

                };
            });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext(Configuration);
            services.AddRepositories();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITaskItemService, TaskItemService>();
            services.AddSingleton(typeof(IAuthenticationService), typeof(AuthenticationService));
            services.AddSingleton(typeof(ITokenHandle), typeof(TokenHandle));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
