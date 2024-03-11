using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Core.Entities.Identity;
using Manufacture.Infrastructure.Data;
using Manufacture.Infrastructure.Services;
using Manufacture.WebApp.Components;
using Manufacture.WebApp.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;

namespace Manufacture.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
            builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DbConnection")
                                   ?? throw new InvalidOperationException(
                                       "Connection string 'DbConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<User>(o =>
                {
                    o.SignIn.RequireConfirmedAccount = true;
                    o.User.RequireUniqueEmail = true;
                })
                .AddRoles<Role>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddAuthorization(options =>
            {
                // options.AddPolicy("Permissions10", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions9", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions8", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions7", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions6", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions5", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions4", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions23", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions2", policy =>
                //     policy.RequireRole("Administrator", "Moderator"));
                // options.AddPolicy("Permissions1", policy =>
                //     policy.RequireRole("Administrator", "Moderator", "User"));
            });
            
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5); 
                options.LoginPath = "/Identity/Account/Login"; 
                options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
            });


            builder.Services.AddRazorPages(options =>
            {

                // options.Conventions.AuthorizePage("/Login", "Permissions1"); // обяз к политике 
                // docs https://learn.microsoft.com/ru-ru/aspnet/core/security/authorization/razor-pages-authorization?view=aspnetcore-8.0
            });
            
            builder.Services.AddRadzenComponents();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery(); 
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}