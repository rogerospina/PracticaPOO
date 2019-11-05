﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOO
{
    public class ProcesadorDeTareas
    {
        private readonly ILog logger;
        private readonly RepositorioTareas repositorioTareas;
        private readonly RepositorioUsuarios repositorioUsuarios;
        private readonly Mapeador mapeador;
        private readonly RepositorioResultadoTareasViewModel repositorioResultadoTareasViewModel;

        public ProcesadorDeTareas(ILog logger,
            RepositorioTareas repositorioTareas,
            RepositorioUsuarios repositorioUsuarios,
            Mapeador mapeador,
            RepositorioResultadoTareasViewModel repositorioResultadoTareasViewModel)
        {
            this.logger = logger;
            this.repositorioTareas = repositorioTareas;
            this.repositorioUsuarios = repositorioUsuarios;
            this.mapeador = mapeador;
            this.repositorioResultadoTareasViewModel = repositorioResultadoTareasViewModel;
        }

        public async Task Procesar()
        {
            try
            {
                logger.Log("Inicio de procesamiento");

                var tareas = await repositorioTareas.ObtenerTareas();
                var tareasNORealizadas = tareas.Where(x => !x.Completed).ToList();

                var usuarios = await repositorioUsuarios.ObtenerUsuarios();

                logger.Log("Inicio transformación ViewModels");
                var tareasViewModel = mapeador.Mapear(tareasNORealizadas, usuarios);

                logger.Log("Inicio escritura de tareas en archivo");
                repositorioResultadoTareasViewModel.Guardar(tareasViewModel);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
    }
}