using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Avion
    {
        public string Matricula { get; set; }
        public Modelo ObjModelo { get; set; }
        public string CantidadSalidasEmergencias { get; set; }
        public string Longitud { get; set; }
        public string AlcanceVuelo { get; set; }

        //public List<CapacidadXClase> ListaCapacidades { get; set; } ya no existe

        public int FilasPC { get; set; }
        public int AsientosPC { get; set; }
        public int FilasCB { get; set; }
        public int AsientosCB { get; set; }
        public int FilasCT { get; set; }
        public int AsientosCT { get; set; }

        public string MatriculaXModelo
        {
            get
            {
                return Matricula + ", " + ObjModelo.Nombre;
            }
        }
    }
}
