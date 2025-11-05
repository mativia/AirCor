using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class VueloServicios
    {
        private readonly VueloRepositorio vueloRepositorio;

        public VueloServicios()
        {
            vueloRepositorio = new VueloRepositorio();
        }

        public List<DefinicionDeVuelo> GetListaDeVuelosDisponibles(string codAeropuertoOrigen, string codAeropuertoDestino, DateTime FechaPartida)
        {
            return vueloRepositorio.GetListaDeVuelosDisponibles(codAeropuertoOrigen, codAeropuertoDestino, FechaPartida);
        }

    }
}
