using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticaPOO
{
    public class RepositorioResultadoTareasViewModel
    {
        public void Guardar(List<TareaViewModel> tareas)
        {
            using (StreamWriter writetext = new StreamWriter($@"{Directory.GetCurrentDirectory()}\tareas pendientes.txt"))
            {
                foreach (var tarea in tareas)
                {
                    writetext.WriteLine($"{DateTime.Now.ToString().PadRight(25)}{tarea.Id.ToString().PadRight(10)}{tarea.NombreUsuario.PadRight(30)}{tarea.Title}");
                }
            }
        }
    }
}
