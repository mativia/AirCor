using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class DiaSemanaRepositorio
    {
        public List<DiaSemana> GetDiasSemanaDeVuelo(string nroVuelo)
        {
            var lista = new List<DiaSemana>();
            var sql = $"SELECT * FROM DEFINICION_DE_VUELO_X_DIAS WHERE NroVuelo = '{nroVuelo}' AND Activo = 1";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var dia = MapearDia(fila);
                lista.Add(dia);
            }
            return lista;
        }

        private DiaSemana MapearDia(DataRow fila)
        {
            DiaSemana dia = new DiaSemana()
            {
                IdDiaSemana = (int)fila["IdDiaSemana"]
            };
            return dia;
        }
    }
}

