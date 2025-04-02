
using Microsoft.EntityFrameworkCore;
using money_management_service.Data;
using money_management_service.Respository;
using money_management_service.Respository.Interfaces;
using money_management_service.Services;
using money_management_service.Services.Interfaces;

namespace money_management_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MoneyManagementDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            builder.Services.AddScoped<IExpenseTypeService, ExpenseTypeService>();

            builder.Services.AddScoped<IMoneyStorageRepository, MoneyStorageRepository>();
            builder.Services.AddScoped<IMoneyStorageService, MoneyStorageService>();

            builder.Services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();

            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();

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
        }
    }
}
