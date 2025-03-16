using BankBlazor.ServiceLibrary.Extensions;
using BankBlazor.ServiceLibrary.Services;
using BankBlazor.ServiceLibrary.Services.Interfaces;


namespace BankBlazor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.WithOrigins("https://localhost:7249")  
                          .AllowAnyMethod()                     
                          .AllowAnyHeader();                    
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("BankBlazorConnection")!;
            builder.Services.AddBankBlazorContext(connectionString);
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            var app = builder.Build();

            app.UseCors("AllowBlazorClient");

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
        }
    }
}
