using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Context;
using Data.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using WebUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
	// -------------------------------------------------------------------------------
	builder.Services.AddDbContext<BlogyContext>();
	builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogyContext>().AddErrorDescriber<CustomIdentityValidator>();

	builder.Services.AddScoped<IAboutDal, EfAboutDal>();
	builder.Services.AddScoped<IAddressDal, EfAddressDal>();
	builder.Services.AddScoped<IArticleDal, EfArticleDal>();
	builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
	builder.Services.AddScoped<IChatDal, EfChatDal>();
	builder.Services.AddScoped<IChatLineDal, EfChatLineDal>();
	builder.Services.AddScoped<ICommentDal, EfCommentDal>();
	builder.Services.AddScoped<IMessageDal, EfMessageDal>();
	builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
	builder.Services.AddScoped<ITagDal, EfTagDal>();

	builder.Services.AddScoped<IAboutService, AboutManager>();
	builder.Services.AddScoped<IAddressService, AddressManager>();
	builder.Services.AddScoped<IArticleService, ArticleManager>();
	builder.Services.AddScoped<ICategoryService, CategoryManager>();
	builder.Services.AddScoped<IChatService, ChatManager>();
	builder.Services.AddScoped<IChatLineService, ChatLineManager>();
	builder.Services.AddScoped<ICommentService, CommentManager>();
	builder.Services.AddScoped<IMessageService, MessageManager>();
	builder.Services.AddScoped<INotificationService, NotificationManager>();
	builder.Services.AddScoped<ITagService, TagManager>();

	// -------------------------------------------------------------------------------

    builder.Services.Configure<IdentityOptions>(options => {
        options.Password.RequireNonAlphanumeric = false;
    });

	builder.Services.ConfigureApplicationCookie(options => {
		options.LoginPath = "/User/UserLogin";
	});

builder.Services.AddLocalization(opt =>
{
	opt.ResourcesPath = "Resources";
});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
	// ------------------------------------------------------------------------------
	app.UseAuthentication();

app.UseAuthorization();

var supportedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
