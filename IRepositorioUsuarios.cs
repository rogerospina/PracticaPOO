using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaPOO
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuario>> ObtenerUsuarios();
    }
}