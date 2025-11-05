using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class AsientoRepositorio
    {
        public Avion getAsientosTotalesDeAvion(string nroVuelo)
        {
            try
            {
                var avion = new Avion();
                var sql = $"SELECT A.Matricula, FilasCT, AsientosCT, FilasCB, AsientosCB, FilasPC, AsientosPC " +
                    $"FROM DEFINICION_DE_VUELO DV JOIN AVION A ON DV.MatriculaAvion = A.Matricula " +
                    $"WHERE NroVuelo = '{nroVuelo}'";
                var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                if (tablaResultado.Rows.Count > 0)
                {
                    avion.Matricula = tablaResultado.Rows[0]["Matricula"].ToString();
                    avion.FilasPC = Convert.ToInt32(tablaResultado.Rows[0]["FilasPC"]);
                    avion.AsientosPC = Convert.ToInt32(tablaResultado.Rows[0]["AsientosPC"]);
                    avion.FilasCB = Convert.ToInt32(tablaResultado.Rows[0]["FilasCB"]);
                    avion.AsientosCB = Convert.ToInt32(tablaResultado.Rows[0]["AsientosCB"]);
                    avion.FilasCT = Convert.ToInt32(tablaResultado.Rows[0]["FilasCT"]);
                    avion.AsientosCT = Convert.ToInt32(tablaResultado.Rows[0]["AsientosCT"]);
                }
                return avion;
            }
            catch (Exception)
            {
                throw new ApplicationException("Hubo un error en el almacenamiento de datos");
            }

        }

        public List<Asiento> getListadoDeAsientosOcupados(int idVuelo)
        {
            try
            {
                List<Asiento> lista = new List<Asiento>();
                var sql = $"SELECT * FROM VUELO V JOIN ASIENTO A ON V.IdVuelo = A.IdVuelo WHERE V.IdVuelo = {idVuelo} AND A.Estado = 1";
                var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    var a = MapearAsiento(fila);
                    lista.Add(a);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new ApplicationException("Hubo un error en el almacenamiento de datos");
            }
        }

        private Asiento MapearAsiento(DataRow fila)
        {
            var a = new Asiento();
            var tc = new TipoClase()
            {
                IdTipoClase = Convert.ToInt32(fila["IdTipoClase"])
            };
            a.TipoClase = tc;
            a.Letra = Convert.ToChar(fila["Letra"].ToString());
            a.Numero = Convert.ToInt32(fila["Numero"].ToString());
            return a;
        }




    }
}
