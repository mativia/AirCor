using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.Repositorios
{
    public class AvionRepositorio
    {
        public DataTable GetAviones()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT A.Matricula, A.IdModelo, M.Nombre, A.CantidadSalidasEmergencia, A.longitud, " +
                        "A.alcanceVuelo, A.FilasPC, A.AsientosPC, A.FilasCB, A.AsientosCB, A.FilasCT, A.AsientosCT " +
                        "FROM AVION A JOIN MODELO M ON A.IdModelo = M.IdModelo " +
                        "WHERE A.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }


        // FILTRO: CONSISTE EN VER PARA CADA AVION SUS VUELOS (join defvuelo con vuelo y join con avion + LAS FECHAS DE VIGENCIA CON LAS HORAS)
        public List<Avion> GetAvionesDisponibles()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT A.*, M.Nombre AS 'Modelo' FROM AVION A JOIN MODELO M ON A.IdModelo = M.IdModelo WHERE A.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            List <Avion> listaAviones = new List<Avion>();
            foreach (DataRow fila in tablaResultado.Rows)
            {
                Avion a = MapearAvion(fila);
                listaAviones.Add(a);
            }
            return listaAviones;
        }

        public bool ValidarDisponibilidadAvion(DefinicionDeVuelo definicionDeVuelo)
        {
            try
            {
                foreach (Vuelo v in definicionDeVuelo.ListaVuelos)
                {
                    string sql = $"SELECT DISTINCT D.NroVuelo" +
                        $"FROM AVION A " +
                        $"JOIN DEFINICION_DE_VUELO D ON A.Matricula = D.MatriculaAvion " +
                        $"JOIN VUELO V ON V.NroVuelo = D.NroVuelo " +
                        $"JOIN CAMBIO_ESTADO_VUELO C ON C.IdVuelo = V.IdVuelo " +
                        $"WHERE {v.FechaPartida} BETWEEN CONVERT(datetime, '{definicionDeVuelo.FechaVigenteDesde}', 103) AND CONVERT(datetime, '{definicionDeVuelo.FechaVigenteHasta}', 103) " +
                        $"AND V.FechaPartida = '{v.FechaPartida}'" +
                        $"AND '{definicionDeVuelo.HorarioPartida}' BETWEEN CONVERT(time, D.HorarioPartida,8) AND CONVERT(time, D.HorarioLlegada,8) " +
                        $"AND '{definicionDeVuelo.HorarioLlegada}' BETWEEN CONVERT(time, D.HorarioPartida,8) AND CONVERT(time, D.HorarioLlegada,8) " +
                        $"AND A.Matricula = '{definicionDeVuelo.ObjAvion.Matricula}' " +
                        $"AND C.IdEstadoVuelo != 2 " +
                        $"AND D.Activo = 1";

                    var tabla = DBHelper.GetDBHelper().ConsultaSQL(sql);
                    if (tabla.Rows.Count > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw new ApplicationException("No se pudo consultar el almacenamiento de datos, contanctese con el administrador del sistema");
            }
        }        

        private Avion MapearAvion(DataRow fila)
        {
            Avion avion = new Avion()
            {
                Matricula = fila["Matricula"].ToString(),
                ObjModelo = new Modelo()
                {
                    IdModelo = Convert.ToInt32(fila["IdModelo"]),
                    Nombre = fila["Modelo"].ToString()
                },
                CantidadSalidasEmergencias = fila["CantidadSalidasEmergencia"].ToString(),
                Longitud = fila["longitud"].ToString(),
                AlcanceVuelo = fila["alcanceVuelo"].ToString(),
                FilasPC = Convert.ToInt32(fila["FilasPC"]),
                AsientosPC = Convert.ToInt32(fila["AsientosPC"]),
                FilasCB = Convert.ToInt32(fila["FilasCB"]),
                AsientosCB = Convert.ToInt32(fila["AsientosCB"]),
                FilasCT = Convert.ToInt32(fila["FilasCT"]),
                AsientosCT = Convert.ToInt32(fila["AsientosCT"]),
                //MatriculaXModelo = fila["Matricula"].ToString() + ", " + fila["Modelo"].ToString()
            };
            return avion;
        }

        public int InsertAviones(Avion avion)
        {
            int filasAfectadas = 0;
            string sql = $"INSERT INTO AVION VALUES ('{avion.Matricula}', {avion.ObjModelo.IdModelo}, " +
                $"{avion.CantidadSalidasEmergencias}, '{avion.Longitud}', '{avion.AlcanceVuelo}', {avion.FilasPC}, " +
                $"{avion.AsientosPC}, {avion.FilasCB}, {avion.AsientosCB}, {avion.FilasCT}, {avion.AsientosCT}, 1)";
            filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeleteAviones(string matricula)
        {
            string sql = $"UPDATE Avion SET Activo = 0 WHERE Matricula = '{matricula}'";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateAviones(Avion avion)
        {
            string sql = $"UPDATE AVION SET IdModelo = {avion.ObjModelo.IdModelo}, CantidadSalidasEmergencia =" +
                $" {avion.CantidadSalidasEmergencias}, longitud = '{avion.Longitud}', alcanceVuelo = '{avion.AlcanceVuelo}'," +
                $" FilasPC = {avion.FilasPC}, AsientosPC = {avion.AsientosPC}, FilasCB = {avion.FilasCB}, AsientosCB = " +
                $"{avion.AsientosCB}, FilasCT = {avion.FilasCT}, AsientosCT = {avion.AsientosCT} " +
                $"WHERE Matricula = '{avion.Matricula}'";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

    }
}
