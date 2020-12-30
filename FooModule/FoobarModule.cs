using FooModule.AuditLogging;
using FooModule.Authorization;
using FooModule.DataAccess;
using FooModule.DataAccess.MemoryDb;
using FooModule.DynamicProxy;
using FooModule.EntityFramework;
using FooModule.Features;
using FooModule.Localization;
using FooModule.MultiTenancy;
using FooModule.Services;
using FooModule.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Volo.Abp;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AspNetCore.VirtualFileSystem;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Dapper;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.MemoryDb;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;
using Volo.Abp.MultiTenancy.ConfigurationStore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.Localization;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Specifications;

namespace FooModule
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpVirtualFileSystemModule))]
    [DependsOn(typeof(AbpLocalizationModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreSqlServerModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreMySQLModule))]
    [DependsOn(typeof(AbpDapperModule))]
    [DependsOn(typeof(AbpMongoDbModule))]
    [DependsOn(typeof(AbpMemoryDbModule))]
    [DependsOn(typeof(AbpPermissionManagementWebModule), typeof(AbpPermissionManagementApplicationModule), typeof(AbpPermissionManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiBasicThemeModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpAuditLoggingEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpSettingManagementWebModule), typeof(AbpSettingManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpFeatureManagementWebModule), typeof(AbpFeatureManagementApplicationModule), typeof(AbpFeatureManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpTenantManagementWebModule), typeof(AbpTenantManagementApplicationModule), typeof(AbpTenantManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpSpecificationsModule))]
    public class FoobarModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            base.PreConfigureServices(context);

            context.Services.OnRegistred(register =>
            {
                if (register.ImplementationType == typeof(HelloWorldService))
                {
                    register.Interceptors.Add<CustomAbpInterceptor>();
                }
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<FoobarModule>();
            });

            Configure<AbpAspNetCoreContentOptions>(options =>
            {
                options.AllowedExtraWebContentFileExtensions.Add(".json");
                options.AllowedExtraWebContentFolders.Add("/FooModule");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.DefaultResourceType = typeof(TestResource);

                options.Resources.Add<TestResource>("zh-Hans")
                .AddVirtualJson("/FooModule/MyResources/Localization")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddBaseTypes(typeof(AbpPermissionManagementResource));

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Foo", typeof(TestResource));
            });

            Configure<AbpExceptionHttpStatusCodeOptions>(options =>
            {
                options.Map("Foo:001", HttpStatusCode.OK);
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(FoobarModule).Assembly);
            });

            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.HideErrors = false;
                options.GlobalCacheEntryOptions.SlidingExpiration = TimeSpan.FromMinutes(10);
                options.KeyPrefix = "CutomAppName";
            });

            context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            context.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MyPolicy1", policy => policy.RequireAuthenticatedUser());
                options.AddPolicy("MyPolicy2", policy => policy.RequireClaim(AbpClaimTypes.TenantId));
            });

            Configure<AbpPermissionOptions>(options =>
            {
                options.ValueProviders.Add<TenantPermissionValueProvider>();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddAbpDbContext<SettingManagementDbContext>(options =>
            {
                options.ReplaceDbContext<ISettingManagementDbContext>();
            });

            context.Services.AddAbpDbContext<HelloWorldDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            context.Services.AddMemoryDbContext<DogMemoryDbContext>(options =>
            {
                options.AddDefaultRepositories<DogMemoryDbContext>(includeAllEntities: true);
                options.AddRepository<Dog, DogMemoryDbRepository>();
                options.SetDefaultRepositoryClasses(typeof(MyMemoryDbRepositoryBase<,>), typeof(MyMemoryDbRepositoryBase<>));
            });

            Configure<PermissionManagementOptions>(options =>
            {
                options.ManagementProviders.Add<MyUserPermissionManagementProvider>();
                options.ManagementProviders.Add<MyRolePermissionManagementProvider>();

                options.ProviderPolicies.Add(UserPermissionValueProvider.ProviderName, MyPermissions.Cats.Default);
                options.ProviderPolicies.Add(RolePermissionValueProvider.ProviderName, MyPermissions.Cats.Default);
            });

            Configure<AbpAspNetCoreSerilogOptions>(options =>
            {
                options.EnricherPropertyNames.UserId = "UserID";
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<FoobarModule>();
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabled = true; //Disables the auditing system
                options.IsEnabledForGetRequests = true;
                options.EntityHistorySelectors.AddAllEntities();

                options.Contributors.Add(new MyAuditLogContributor());
            });

            Configure<AbpSettingOptions>(options =>
            {
                options.ValueProviders.Add<CustomSettingValueProvider>();
            });

            Configure<SettingManagementPageOptions>(options =>
            {
                options.Contributors.Add(new MySettingPageContributor());
            });

            Configure<AbpFeatureOptions>(options =>
            {
                options.ValueProviders.Add<UserFeatureValueProvider>();
            });

            Configure<FeatureManagementOptions>(options =>
            {
                options.Providers.Add<UserFeatureManagementProvider>();
                options.ProviderPolicies.Add(UserFeatureValueProvider.ProviderName, MyPermissions.Cats.Default);
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = true;
            });

            Configure<AbpAspNetCoreMultiTenancyOptions>(options =>
            {
                options.TenantKey = "tenant";
            });

            Configure<AbpTenantResolveOptions>(options =>
            {
                options.TenantResolvers.Add(new MyTenantResolveContributor());
                options.AddDomainTenantResolver("{0}.xcode.me");
            });

            Configure<AbpDefaultTenantStoreOptions>(options =>
            {
                options.Tenants = new[]
                {
                    new TenantConfiguration(Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae901"),"tenant1")
                    {
                        ConnectionStrings ={
                            {ConnectionStrings.DefaultConnectionStringName, @"Server=(LocalDb)\MSSQLLocalDB;Database=HelloWorld;Trusted_Connection=True"},
                            {AbpAuditLoggingDbProperties.ConnectionStringName,@"Server=(LocalDb)\MSSQLLocalDB;Database=Logging1;Trusted_Connection=True"}
                        }
                    },
                    new TenantConfiguration(Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae902"),"tenant2")
                    {
                        ConnectionStrings ={
                            {AbpAuditLoggingDbProperties.ConnectionStringName,@"Server=(LocalDb)\MSSQLLocalDB;Database=Logging2;Trusted_Connection=True"}
                        }
                    },
                    new TenantConfiguration(Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae903"),"tenant3")
                };
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.ServiceProvider.GetRequiredService<IDataSeeder>().SeedAsync().Wait();

            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseVirtualFiles();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAbpRequestLocalization();

            app.UseAuthentication().UseAuthorization();

            app.UseMultiTenancy();

            app.UseAbpSerilogEnrichers();

            app.UseAuditing();

            app.UseConfiguredEndpoints(options =>
            {
                options.MapControllerRoute("app1", "{controller=home}/{action=Index}/{id?}");
            });
        }
    }
}