using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using ProyectoChico.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoChico.Data
{
    public class JotaSeeder
    {
        private readonly JotaContext context;
        private readonly IHostingEnvironment hosting;

        public JotaSeeder(JotaContext context,IHostingEnvironment hosting)
        {
            this.context = context;
            this.hosting = hosting;
        }

        public void Agregar()
        {
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                var ruta = Path.Combine(hosting.ContentRootPath, "Data/art.json");
                var JSON = File.ReadAllText(ruta);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(JSON);
                context.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "1",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem{
                        Product=products.First(),
                        Quantity=3,
                        UnitPrice=products.First().Price
                        }
                    }
                };

                context.Orders.Add(order);
                context.SaveChanges();


            }
        }
    }
}
