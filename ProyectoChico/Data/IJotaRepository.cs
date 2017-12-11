using System.Collections.Generic;
using ProyectoChico.Data.Entities;

namespace ProyectoChico.Data
{
    public interface IJotaRepository
    {
        IEnumerable<Product> obtenerTodo();
        IEnumerable<Product> obtenerTodoPorCategoria();
         bool guardarTodo();
    }
}