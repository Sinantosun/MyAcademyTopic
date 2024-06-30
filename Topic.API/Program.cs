using Microsoft.AspNetCore.WebSockets;
using System.Reflection;
using System.Text.Json.Serialization;
using Topic.BusinnesLayer.Abstract;
using Topic.BusinnesLayer.Concrete;
using Topic.DataAccsesLayer.Abstract;
using Topic.DataAccsesLayer.Concrete;
using Topic.DataAccsesLayer.Context;
using Topic.DataAccsesLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBlogDal, EFBlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IManuelDal, EFManuelDal>();
builder.Services.AddScoped<IManuelService, ManuelManager>();

builder.Services.AddScoped<IQuestionDal, EFQuestionDal>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IGenericDal<>),typeof(GenericRepository<>));
// Add services to the container.
builder.Services.AddDbContext<TopicContext>();
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
