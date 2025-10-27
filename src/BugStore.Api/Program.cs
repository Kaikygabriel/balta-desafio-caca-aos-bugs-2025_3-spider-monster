using System.Reflection;
using BugStore.Api.Extesions;
using BugStore.Api.Repository.Interfaces;
using BugStore.Data;
using BugStore.Models;
using BugStore.Repository;
using BugStore.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Create = BugStore.Responses.Customers.Create;
using Get = BugStore.Api.Requests.Products.Get;
using GetById = BugStore.Requests.Products.GetById;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x=>
    x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(x=>
        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseMapCustomers();

app.UseMapOrder();

app.UseMapProducts();

app.Run();
