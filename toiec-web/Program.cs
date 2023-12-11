using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using toiec_web.Controllers;
using toiec_web.Infrastructure;
using toiec_web.Models;

namespace toiec_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var corsPolicyName = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services
                    .AddRepository()
                    .AddService();
                builder.Services.Configure<CloudinaryModel>(builder.Configuration.GetSection("CloudinarySettings"));
            }

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: corsPolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });
            builder.Services.AddControllers().AddControllersAsServices();
            //add DBContext
            builder.Services.AddDbContext<ToiecDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
            });
            //add Identity
            builder.Services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<ToiecDbContext>()
                .AddDefaultTokenProviders();

            //Add Authentication
            builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Add Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])
                    )
                };
            });
            // Add Momo Payment Option
            builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));

            // Add auto mapper
            builder.Services.AddAutoMapper(typeof(Program));
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Add email config
            var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);

            //Add Config for Required Email
            builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //Add Swagger
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    },
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/index.html", "API V1");
                //});
            }

            //app.UseHttpsRedirection();

            // Configure CORS
            app.UseCors(corsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}