﻿using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PracticaPOO
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILog>(x => new FactoriaLoggers().ObtenerLogger("consola"))
                .AddTransient<RepositorioTareas>()
                .AddTransient<RepositorioUsuarios>()
                .AddTransient<Mapeador>()
                .AddTransient<RepositorioResultadoTareasViewModel>()
                .AddTransient<ProcesadorDeTareas>()
                .BuildServiceProvider();

            var procesadorTareas = serviceProvider.GetService<ProcesadorDeTareas>();
            await procesadorTareas.Procesar();
        }
    }
}
