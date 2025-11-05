using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class TarifaRepositorio
    {
        public List<Tarifa> GetTarifasDeVuelo(string nroVuelo)
        {
            var lista = new List<Tarifa>();
            var sql = $"SELECT IdTipoClase, Importe FROM TARIFA WHERE NroVuelo = '{nroVuelo}' AND Activo = 1";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tarifa = MapearTarifa(fila);
                lista.Add(tarifa);
            }
            return lista;
        }
    
        private Tarifa MapearTarifa(DataRow fila)
        {
            Tarifa tarifa = new Tarifa()
            {
                Importe = (float)Convert.ToDouble(fila["Importe"]),
                ObjTipoClase = new TipoClase() { IdTipoClase = Convert.ToInt32(fila["IdTipoClase"]) }
            };
            return tarifa;
        }
    }
}
