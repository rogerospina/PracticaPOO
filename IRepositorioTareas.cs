using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaPOO
{
    public interface IRepositorioTareas
    {
        Task<List<Tarea>> ObtenerTareas();
    }
}