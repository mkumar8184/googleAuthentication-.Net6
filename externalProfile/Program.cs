using AuthenticationLibrary.Extensions;
using Google.Apis.Auth.AspNetCore3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IGoogleAuthProvider, GoogleAuthProvider>();
builder.Services.
    AddAuthService(
    builder.Configuration["googleConfig:ClientId"],
    builder.Configuration["googleConfig:ClientSecret"]
    ).
    InjectOtherSerives();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
HttpContextHandler.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
app.UseAuthorization();
app.MapControllers();
app.Run();
