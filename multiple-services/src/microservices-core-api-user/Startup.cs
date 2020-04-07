using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace microservices_core_api_user {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            string secureKey = $"Hey-this-is-so-secure-key";
            services.AddAuthentication (_ => {
                    _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (options => {

                    options.TokenValidationParameters = new TokenValidationParameters () {
                    ValidateIssuer = true,
                    ValidIssuer = "someone",
                    ValidateAudience = true,
                    ValidAudience = "readers",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (secureKey))

                    };
                });
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthentication ();
            app.UseAuthorization ();

            app.Map ("/token", HandelTokenGeneration);
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
        private static void HandelTokenGeneration (IApplicationBuilder app) {
            app.Run (async context => {
                string secureKey = $"Hey-this-is-so-secure-key";

                var symmetricKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (secureKey));
                var signingKey = new SigningCredentials (symmetricKey, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken (
                    issuer: "someone",
                    audience: "readers",
                    expires : DateTime.Now.AddMinutes (2),
                    signingCredentials : signingKey
                );

                string mostSecureKey = new JwtSecurityTokenHandler ().WriteToken (token);
                await context.Response.WriteAsync (mostSecureKey);
            });
        }
    }
}