using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Repositorios;
using tp_pav1_grupo10.Entidades;
using System.Windows.Forms;

namespace tp_pav1_grupo10.Servicios
{
    public class DefinicionDeVueloServicios
    {
        private readonly DefinicionDeVueloRepositorio definicionDeVueloRepositorio;
        private readonly AvionRepositorio avionRepositorio;

        public DefinicionDeVueloServicios()
        {
            definicionDeVueloRepositorio = new DefinicionDeVueloRepositorio();
            avionRepositorio = new AvionRepositorio();
        }

        private List<Vuelo> GenerarVuelos(DefinicionDeVuelo defVuelo)
        {
            List<Vuelo> listaVuelos = new List<Vuelo>();

            int dias = (defVuelo.FechaVigenteHasta - defVuelo.FechaVigenteDesde).Days;

            // concatenar la fecha desde con los horarios seleccionados de partida
            TimeSpan ts = new TimeSpan(defVuelo.HorarioPartida.Hour, defVuelo.HorarioPartida.Minute, 0);
            defVuelo.FechaVigenteDesde = defVuelo.FechaVigenteDesde.Date + ts;

            // Obtener la hora actual
            DateTime horaActual = Convert.ToDateTime(DateTime.Now.ToString("HH:mm"));

            for (int i = 0; i <= dias+1; i++)
            {
                DateTime fechaSumada = defVuelo.FechaVigenteDesde.AddDays(i);

                if (fechaSumada.Date == DateTime.Today && defVuelo.HorarioPartida < horaActual)
                {
                    // si la fecha es igual a la actual y el horario de partida es menor al actual entonces
                    // no se deberia generar un vuelo para hoy mismo
                    continue;
                }

                foreach (DiaSemana dia in defVuelo.ListaDiasSemana)
                {
                    if (dia.Nombre == fechaSumada.DayOfWeek.ToString())
                    {
                        Vuelo nuevoVuelo = new Vuelo()
                        {
                            FechaPartida = fechaSumada,
                        };
                        listaVuelos.Add(nuevoVuelo);
                        break;
                    }
                }
            }
            return listaVuelos;
        }

        public string InsertDefinicionVuelo(DefinicionDeVuelo defVuelo)
        {

            string mensaje = "";
            mensaje = ValidarDefinicionVuelo(defVuelo);

            if (mensaje == "")
            {
                defVuelo.ListaVuelos = GenerarVuelos(defVuelo);
                
                // VALIDAR DISPONIBILIDAD AVION
                //if (ValidarAvionDisponible(defVuelo))
                //{
                //    mensaje += "El avion seleccionado se encuentra en uso en alguno de los vuelos generados\n";
                //}
                //else
                //{
                    definicionDeVueloRepositorio.InsertDefinicionVuelo(defVuelo);
                //}
            }

            return mensaje;
        }

        private bool ValidarAvionDisponible(DefinicionDeVuelo defVuelo)
        {
            return avionRepositorio.ValidarDisponibilidadAvion(defVuelo);
        }

        private string ValidarDefinicionVuelo(DefinicionDeVuelo defVuelo)
        {
            string mensaje = "";
            if (defVuelo.NroVuelo == "")
            {
                mensaje += "Es necesario el número de vuelo\n";
            }
            if (defVuelo.Distancia == "")
            {
                mensaje += "Es necesario la distancia\n";
            }
            if (defVuelo.ObjAeropuertoDestino.CodigoAeropuerto == "")
            {
                mensaje += "Es necesario el aeropuerto de destino\n";
            }
            if (defVuelo.ObjAeropuertoOrigen.CodigoAeropuerto == "")
            {
                mensaje += "Es necesario el aeropuerto de origen\n";
            }
            if (defVuelo.ObjAvion.Matricula == "")
            {
                mensaje += "Debe seleccionar un avion\n";
            }
            if (defVuelo.ListaDiasSemana.Count == 0)
            {
                mensaje += "Debe seleccionar al menos un dia\n";
            }
            if (defVuelo.HorarioPartida <= defVuelo.HorarioEmbarque)
            {
                mensaje += "El horario de embarque debe ser anterior al horario de partida\n";
            }

            // Validacion de tarifas
            foreach (Tarifa Tarifa in defVuelo.ListaTarifas)
            {
                if (Tarifa.Importe == 0)
                {
                    mensaje += $"Debe cargar correctamente la tarifa de la clase {Tarifa.ObjTipoClase.Nombre}. El formato debe ser del tipo '0,00'\n";
                }
            }

            return mensaje;
        }

        public List<DefinicionDeVuelo> GetDefinicionVuelo()
        {
            return definicionDeVueloRepositorio.GetDefinicionVuelo();
        }

        public void DeleteDefinicionDeVuelo(string nroVuelo)
        {
            definicionDeVueloRepositorio.DeleteDefinicionDeVuelo(nroVuelo);
        }

        public string UpdateDefinicionVuelo(DefinicionDeVuelo defVuelo)
        {
            string mensaje = "";
            mensaje = ValidarDefinicionVuelo(defVuelo);
            if (mensaje == "")
            {
                definicionDeVueloRepositorio.UpdateDefinicionVuelo(defVuelo.NroVuelo, defVuelo.ListaTarifas);
            }
            return mensaje;
        }

        public List<DefinicionDeVuelo> GetDefinicionVuelo(DefinicionVueloFiltro filtro)
        {
            return definicionDeVueloRepositorio.GetDefinicionVuelo(filtro);
        }
    }
}
