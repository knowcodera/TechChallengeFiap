using Domain.Entities;
using Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context == null)
                {
                    Console.WriteLine("Erro ao obter o contexto da aplicação.");
                    return;
                }

                SeedData(context);
            }
        }

        public static void SeedData(ApplicationDbContext context)
        {
            Console.WriteLine("Aplicando Migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao aplicar migrations: {ex.Message}");
                return;
            }

            Console.WriteLine("Populando dados...");

            if (context.Clients.Any() || context.Categories.Any() || context.Products.Any())
            {
                Console.WriteLine("Dados já populados.");
                return;
            }

            var clients = new[] {
                new Client("Halro", "56954409049", "Halro@email.com"),
                new Client("Raifo", "21654611034", "Raifo@email.com"),
                new Client("Firul", "95055185015", "Firul@email.com")};

            var categories = new[] {
                new Category("Lanche"),
                new Category("Acompanhamento"),
                new Category("Bebida"),
                new Category("Sobremesa")};

            var products = new[] {
                new Product("Hambúrguer", 10.50m, 1),
                new Product("Cheeseburger", 12.00m, 1),
                new Product("Hot Dog", 8.50m, 1),
                new Product("Chicken Sandwich", 11.00m, 1),
                new Product("Veggie Burger", 9.50m, 1),

                new Product("Batata Frita", 5.00m, 2),
                new Product("Onion Rings", 4.50m, 2),
                new Product("Salada", 6.00m, 2),
                new Product("Mozzarella Sticks", 5.50m, 2),
                new Product("Chicken Nuggets", 7.00m, 2),

                new Product("Coca-Cola", 3.00m, 3),
                new Product("Pepsi", 3.00m, 3),
                new Product("Fanta", 3.00m, 3),
                new Product("Sprite", 3.00m, 3),
                new Product("Água", 2.00m, 3),

                new Product("Sorvete", 4.00m, 4),
                new Product("Brownie", 3.50m, 4),
                new Product("Torta de Maçã", 4.00m, 4),
                new Product("Milkshake", 5.00m, 4),
                new Product("Cookie", 2.50m, 4)};

            try
            {
                context.Clients.AddRange(clients);
                context.Categories.AddRange(categories);
                context.Products.AddRange(products);
                context.SaveChanges();
                Console.WriteLine("Dados adicionados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar dados: {ex.Message}");
            }
        }

    }
}
