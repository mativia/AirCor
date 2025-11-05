using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class ModeloServicios
    {
        private readonly ModeloRepositorio modeloRepositorio;

        public ModeloServicios()
        {
            modeloRepositorio = new ModeloRepositorio();
        }

        public DataTable GetModelos()
        {
            return modeloRepositorio.GetModelos();
        }
    }
}
