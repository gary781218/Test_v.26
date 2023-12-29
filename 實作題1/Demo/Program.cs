using Demo.Interfaces;
using Demo.Services;
using Modules.Utilities;

var builder = WebApplication.CreateBuilder(args);

try
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    ConfigurationManager configurationManager = builder.Configuration;

    // Service DI
    builder.Services.AddScoped<IQry10001Service, Qry10001Service>();

    // Authorization DI
    builder.Services.AddAuthorization();

    // Swagger DI;
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "NEC API", Version = "v2.6" });
        c.OperationFilter<SwaggerHeaderFilter>();
        c.IncludeBaseDirXmlComments();
        c.AddSecurityDefinition();
        c.AddSecurityRequirement();
    });

    builder.Services.AddHttpClient();

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

    // app.UseEndpoints(endpoints =>
    // {
    //     endpoints.MapControllers();
    // });

    app.Run();
}
catch (System.Exception)
{

}
