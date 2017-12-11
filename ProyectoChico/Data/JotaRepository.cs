using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoChico.Data.Entities;
namespace ProyectoChico.Data
{
    public class JotaRepository : IJotaRepository
    {
        private readonly JotaContext context;

        public JotaRepository(JotaContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> obtenerTodo()
        {
            return context.Products
                .OrderBy(p => p.Title)
                .ToList();
        }

        public IEnumerable<Product> obtenerTodoPorCategoria()
        {
            return context.Products
                .OrderBy(p => p.Category)
                .ToList();
        }

        public bool guardarTodo()
        {
            return context.SaveChanges() > 0;
        }
    }
}
