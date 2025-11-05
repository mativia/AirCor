using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class DefinicionDeVuelo
    {
        public string NroVuelo { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioPartida { get; set; }
        public DateTime HorarioLlegada { get; set; }
        public string Distancia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVigenteDesde { get; set; }
        public DateTime FechaVigenteHasta { get; set; }
        public bool Activo { get; set; }
        public Aeropuerto ObjAeropuertoOrigen { get; set; }
        public Aeropuerto ObjAeropuertoDestino { get; set; }
        public Avion ObjAvion { get; set; }
        public List<Vuelo> ListaVuelos { get; set; }
        public List<DiaSemana> ListaDiasSemana { get; set; }
        public List<Tarifa> ListaTarifas  { get; set; }
    }
}
