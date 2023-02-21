using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Plugins.DataStore.InMemory;
using SupermarketManagementSystemWebApp.Data;
using UseCases;
using UseCases.CategoriesUseCase;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductUseCase;
using UseCases.UseCaseInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Dependency Injection for the In-Memory Data Store
builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

//Dependency Injection for Use Cases and Repositories
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>(); 
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIDUseCase, GetCategoryByIDUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IGetProductByIDUseCase, GetProductByIDUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryID, ViewProductsByCategoryID>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<IRecordTransactionsUseCase, RecordTransactionsUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
