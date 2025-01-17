namespace ShoppingListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodajemy us�ugi CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()   // Zezwala na po��czenia z dowolnego �r�d�a
                          .AllowAnyMethod()   // Zezwala na dowolne metody HTTP (GET, POST, PUT, DELETE, itd.)
                          .AllowAnyHeader();  // Zezwala na dowolne nag��wki
                });
            });

            // Dodajemy inne us�ugi
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Konfiguracja �cie�ki API i CORS
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Dodajemy u�ycie CORS przed autoryzacj� i innymi middleware
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
