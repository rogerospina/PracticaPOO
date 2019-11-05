using System.Collections.Generic;

namespace PracticaPOO
{
    public interface IRepositorioResultadoTareasViewModel
    {
        void Guardar(List<TareaViewModel> tareas);
    }
}