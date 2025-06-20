
using BookstoreAPI.Data;
using BookstoreAPI.Repository;
using BookstoreAPI.Repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BookstoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

        
                builder.Services.AddDbContext<BookStoreContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB")));
                builder.Services.AddScoped<IBookRepository, BookRepository>();

                builder.Services.AddControllers();
           

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
