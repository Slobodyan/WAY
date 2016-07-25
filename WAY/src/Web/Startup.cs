using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Authentication;
using Web.AutoMapper;
using Web.Manager;
using Web.Models;
using Web.Repositories;
using Web.UnitOfWork;
using Web.ViewModels;

namespace Web {
	public class Startup {
		public Startup(IHostingEnvironment env) {
			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			// Add framework services.
			services.AddEntityFramework()
				.AddSqlServer()
				.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
			services.AddCors();
			services.AddMvc();
			services.AddAuthentication();
			services.AddDataProtection();

			//Add application services
			services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

			services.AddTransient<IAuthManager, AuthManager>();
			services.AddTransient<ICryptographyManager, CryptographyManager>();

			services.AddTransient<IArticleRepository, ArticleRepository>();
			services.AddTransient<IAuthRepository, AuthRepository>();
			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<IContentRepository, ContentRepository>();

			//Configure AutoMapper
			Mapper.Initialize(config => config.AddProfile(new AutoMapperProfile()));
			Mapper.AssertConfigurationIsValid();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAuthManager authManager) {
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if(env.IsDevelopment()) {
				app.UseBrowserLink();
				//app.UseDeveloperExceptionPage();
				//app.UseExceptionHandler("/Base/ErrorResult");
			} else {
				app.UseExceptionHandler("/Base/ErrorResult");
			}

			app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
			app.UseCors(builder => {
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
			});

			//for web api
			app.UseBearerAuthentication(options => {
				options.Events = new BearerAuthenticationEvents {
					OnSigningIn = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Signing in...");
						});
					},
					OnSignedIn = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Signed in...");
						});
					},
					OnValidatePrincipal = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Validate principal...");
							var emailClaim = context.Principal.FindFirst(x => x.Type == ClaimTypes.Email);
							BloggerInfo bloggerInfo;
							if(string.IsNullOrWhiteSpace(emailClaim?.Value) || (bloggerInfo = authManager.GetBlogger(emailClaim.Value)) == null || !bloggerInfo.IsActive)
								context.RejectPrincipal();
						});
					},
					OnSigningOut = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Signing out...");
						});
					},
					OnUnauthorized = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Unauthorized...");
						});
					},
					OnForbidden = async context => {
						await Task.Run(() => {
							Debug.WriteLine("Forbidden...");
						});
					}
				};
			});

			//for mvc 6
			app.UseCookieAuthentication(new CookieAuthenticationOptions {
				LoginPath = new PathString("/blogger/login"),
				AccessDeniedPath = new PathString("/blogger/login/"),
				AuthenticationScheme = CookiesAuthenticationDefaults.AuthenticationScheme,
				AutomaticAuthenticate = true,
				AutomaticChallenge = true
			});

			app.UseStaticFiles();
			app.UseMvc(routes => {
				//for redirection to content api actions
				routes.MapRoute(
					name: "Photo",
					template: "{guid}/photo_{width}.png",
					defaults: new {
						controller = "Content",
						action = "Photo"
					});

				//routes.MapRoute(
				//	name: "DefaultApi",
				//	template: "api/{controller=Home}/{action=Index}/{id?}");

				routes.MapRoute(
					name: "DefaultWeb",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}
