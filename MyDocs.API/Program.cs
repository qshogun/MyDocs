using Microsoft.EntityFrameworkCore;
using MyDocs.Application.Mapping;
using MyDocs.Application.Services;
using MyDocs.Domain.Repositories;
using MyDocs.Infrastructure.DB;
using MyDocs.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
//builder.Services.AddScoped<IDocumentService, DocumentService>();
//builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7045") });
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<MyDocsDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:7104") // Add your Blazor app's URL here
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add support for controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowSpecificOrigins");

app.UseRouting();

// Configure endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
