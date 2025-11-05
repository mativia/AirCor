using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmSeleccionAsiento : Form
    {
        private GestorReserva gestorReserva;
        private List<DetalleReserva> listaDetalles;
        private List<Asiento> listaAsientosOcupados;
        private Avion asientosDelAvion;

        public FrmSeleccionAsiento(GestorReserva gestor, List<DetalleReserva> listaDetalles, List<Asiento> listaAsientosOcupados, Avion asientosDelAvion)
        {
            gestorReserva = gestor;
            this.listaDetalles = listaDetalles;
            this.listaAsientosOcupados = listaAsientosOcupados;
            this.asientosDelAvion = asientosDelAvion;
            InitializeComponent();
        }

        private void FrmSeleccionAsiento_Load(object sender, EventArgs e)
        {
            // --------------------
            // GRILLA DETALLE
            CargarGrillaDetalle(listaDetalles);
            dgvDetalles.ClearSelection();

            // --------------------
            // GRILLA CLASE TURISTA
            var tablaAsientosCT = ObtenerTablaDeAsientos(asientosDelAvion.FilasCT, asientosDelAvion.AsientosCT);
            // Cargar valores 0 en la tabla
            foreach (DataRow fila in tablaAsientosCT.Rows)
            {
                for (int i = 1; i < fila.ItemArray.Length; i++)
                {
                    fila[i] = 0.ToString();
                }
            }
            // Cargar valores 1 para cada asiento ocupado
            foreach (Asiento asiento in listaAsientosOcupados)
            {
                if (asiento.TipoClase.IdTipoClase == 1)
                {
                    int numeroFila = Encoding.ASCII.GetBytes(asiento.Letra.ToString())[0] - 97; // Convierto en ASCII y como la a es 97 le resto eso para que me de 0
                    tablaAsientosCT.Rows[numeroFila][asiento.Numero] = 1;
                }
            }
            dgvTurista.DataSource = tablaAsientosCT;
            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvTurista.ColumnCount; i++)
            {
                dgvTurista.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            ColocarTamañoFilasYColumnas(ref dgvTurista);

            // --------------------
            // GRILLA CLASE BUSINESS
            var tablaAsientosCB = ObtenerTablaDeAsientos(asientosDelAvion.FilasCB, asientosDelAvion.AsientosCB);
            // Cargar valores 0 en la tabla
            foreach (DataRow fila in tablaAsientosCB.Rows)
            {
                for (int i = 1; i < fila.ItemArray.Length; i++)
                {
                    fila[i] = 0.ToString();
                }
            }
            // Cargar valores 1 para cada asiento ocupado
            foreach (Asiento asiento in listaAsientosOcupados)
            {
                if (asiento.TipoClase.IdTipoClase == 2)
                {
                    int numeroFila = Encoding.ASCII.GetBytes(asiento.Letra.ToString())[0] - 97; // Convierto en ASCII y como la a es 97 le resto eso para que me de 0
                    tablaAsientosCB.Rows[numeroFila][asiento.Numero] = 1;
                }
            }
            dgvBusiness.DataSource = tablaAsientosCB;
            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvBusiness.ColumnCount; i++)
            {
                dgvBusiness.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            // --------------------
            // GRILLA PRIMERA CLASE
            var tablaAsientosPC = ObtenerTablaDeAsientos(asientosDelAvion.FilasPC, asientosDelAvion.AsientosPC);
            // Cargar valores 0 en la tabla
            foreach (DataRow fila in tablaAsientosPC.Rows)
            {
                for (int i = 1; i < fila.ItemArray.Length; i++)
                {
                    fila[i] = 0.ToString();
                }
            }
            // Cargar valores 1 para cada asiento ocupado
            foreach (Asiento asiento in listaAsientosOcupados)
            {
                if (asiento.TipoClase.IdTipoClase == 3)
                {
                    int numeroFila = Encoding.ASCII.GetBytes(asiento.Letra.ToString())[0] - 97; // Convierto en ASCII y como la a es 97 le resto eso para que me de 0
                    tablaAsientosPC.Rows[numeroFila][asiento.Numero] = 1;
                }
            }
            dgvPrimera.DataSource = tablaAsientosPC;
            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvPrimera.ColumnCount; i++)
            {
                dgvPrimera.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarGrillaDetalle(List<DetalleReserva> listaDetalles)
        {
            foreach (var d in listaDetalles)
            {
                var fila = new string[]
                {
                    d.ObjPasajero.Nombre,
                    d.ObjPasajero.Apellido,
                    "",
                    d.ObjPasajero.ObjTipoDocumento.IdTipoDocumento.ToString(),
                    d.ObjPasajero.NroDocumento

                };
                dgvDetalles.Rows.Add(fila);
            }
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btn";
            btn.HeaderText = "Limpiar";
            btn.Text = "Limpiar";
            btn.UseColumnTextForButtonValue = true;
            dgvDetalles.Columns.Add(btn);
        }

        private DataTable ObtenerTablaDeAsientos(int cantidadFilas, int cantidadButacasXFila)
        {
            DataTable tablaAsientos = new DataTable();
            DataColumn col;
            DataRow fil;

            for (int i = 0; i <= cantidadFilas; i++)
            {
                if (i == 0) // si es la primera columna -> no lleva caption
                {
                    col = new DataColumn();
                    col.ColumnName = "butaca / fila";
                    col.Caption = "butaca";
                    tablaAsientos.Columns.Add(col);
                    continue;
                }
                col = new DataColumn();
                col.ColumnName = i.ToString();
                col.Caption = i.ToString();
                tablaAsientos.Columns.Add(col);
            }

            // Cargar filas en la tabla
            List<char> listaLetrasButacas = CrearListaLetras(cantidadButacasXFila);
            foreach (char letra in listaLetrasButacas)
            {
                fil = tablaAsientos.NewRow();
                fil[0] = letra;
                tablaAsientos.Rows.Add(fil);
            }

            return tablaAsientos;
        }

        // Almaceno como dato la cantidad de butacas por fila pero necesito una lista de letras
        // donde cada letra representa una butaca de la fila
        private List<char> CrearListaLetras(int cantidadButacasXFila)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < cantidadButacasXFila; i++)
            {
                char caracter = Convert.ToChar(i + 97);
                list.Add(caracter);
            }
            return list;
        }

        private void ColocarTamañoFilasYColumnas(ref DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = 50;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 50;
            }
            dgv.Columns[0].Width = 95;
        }

        private void dgvTurista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // damos formato a la celda segun su valor
            // pintamos las celdas segun su estado

            if (e.Value.GetType() != typeof(System.DBNull)) // si el valor de la celda es null tira error, por eso debemos validarlo
            {
                if (char.IsLetter(Convert.ToChar(e.Value))) // debo validar que no sea una letra
                {
                    e.CellStyle.BackColor = Color.White;
                }
                else
                {
                    if (Convert.ToInt32(e.Value) == 1)
                    {
                        e.CellStyle.BackColor = Color.Firebrick;
                    }
                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        e.CellStyle.BackColor = Color.ForestGreen;
                    }
                    if (Convert.ToUInt32(e.Value) == 2)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void dgvTurista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // pintar icno png de asiento en cada celda cuyo indice sea mayor a 0
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // paso los limites de la celda y le digo que pinte todo

                var width = Properties.Resources.silla.Width; // ancho de la imagen
                var height = Properties.Resources.silla.Height; // alto de la imagen
                var x = e.CellBounds.Left + (e.CellBounds.Width - width) / 2; // le digo en que posicion pintar en el eje x
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2; // le digo en que posicion pintar en el eje y

                e.Graphics.DrawImage(Properties.Resources.silla, new Rectangle(x, y, width, height)); // Pintar la imagen
                e.Handled = true;
            }
        }

        private void dgvTurista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0) // si existe un pasajero seleccionado
            {
                if (dgvDetalles.SelectedRows[0].Cells[2].Value.ToString() == "") // si el pasajero seleccionado no tiene asiento asignado
                {
                    // asigno un asiento
                    if (e.RowIndex > -1 && e.ColumnIndex > 0) // si el valor dentro de la grilla es válido
                    {
                        int filaSeleccionada = e.RowIndex;
                        int columnaSeleccionada = e.ColumnIndex;
                        // obtener la celda seleccionada
                        DataGridViewCell cell = dgvTurista.Rows[filaSeleccionada].Cells[columnaSeleccionada];

                        // validar que el valor de la celda no sea 1
                        // es decir, que no este ocupado el asiento
                        if (Convert.ToInt32(cell.Value) == 1)
                        {
                            MessageBox.Show("Este asiento ya se encuentra ocupado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 2) // esta seleccionado (en amarillo)
                        {
                            // si es de otro pasajero la seleccion, entonces no se puede asignar
                            MessageBox.Show("No puede asignar este asiento, porque lo asigno previamente a otro pasajero. Primero debe quitar la asignacion de ese pasajero.", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 0)
                        {
                            MessageBox.Show("Selecciono el asiento " + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cell.Value = 2;
                            dgvTurista.ClearSelection();
                            dgvDetalles.SelectedRows[0].Cells["Asiento"].Value = "" + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97);
                            dgvDetalles.SelectedRows[0].Cells["IdTipoClase"].Value = 1;
                            dgvDetalles.SelectedRows[0].Cells["TipoClase"].Value = "Clase Turista";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Este pasajero ya tiene un asiento asignado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un pasajero", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        // Este método se ejecuta cuando se hace click en el boton limpiar de una fila de la grilla de detalles
        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 7) // si apreto el btn
            {
                // obtengo la clase, numero y letra del asiento para despintarlo
                DataGridViewCell cellAsiento = dgvDetalles.Rows[e.RowIndex].Cells[2];
                DataGridViewCell cellIdTipoClase = dgvDetalles.Rows[e.RowIndex].Cells[5];
                DataGridViewCell cellTipoClase = dgvDetalles.Rows[e.RowIndex].Cells[6];
                if (cellAsiento.Value.ToString() != "")
                {
                    // hay algo seleccionado
                    // despintar grilla correspondiente
               
                    var numeroDeLaGrilla = cellAsiento.Value.ToString();
                    string numero = new String(numeroDeLaGrilla.Where(Char.IsDigit).ToArray());

                    int posicionLetra = cellAsiento.Value.ToString().Length - 1;
                    var letra = cellAsiento.Value.ToString()[posicionLetra];

                    var nroColumna = Convert.ToInt32(numero);
                    var nroFila = Encoding.ASCII.GetBytes(letra.ToString())[0] - 97; // Convierto en ASCII y como la a es 97 le resto eso para que me de 0

                    if (Convert.ToInt32(cellIdTipoClase.Value) == 1)
                    {
                        // grilla turista
                        dgvTurista.Rows[nroFila].Cells[nroColumna].Value = 0;
                        dgvTurista.ClearSelection();
                    }
                    if (Convert.ToInt32(cellIdTipoClase.Value) == 2)
                    {
                        // grilla business
                        dgvBusiness.Rows[nroFila].Cells[nroColumna].Value = 0;
                        dgvBusiness.ClearSelection();
                    }
                    if (Convert.ToInt32(cellIdTipoClase.Value) == 3)
                    {
                        // grilla primera clase
                        dgvPrimera.Rows[nroFila].Cells[nroColumna].Value = 0;
                        dgvPrimera.ClearSelection();
                    }

                    //limpiar
                    cellAsiento.Value = "";
                    cellIdTipoClase.Value = "";
                    cellTipoClase.Value = "";
                }
            }
        }

        private void tcSeleccionAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Esto es para evitar que las girllas se bugueen, si no las oculto estas se 
            // superponer cuando cambia la pesataña del tab control
            dgvTurista.ClearSelection();
            dgvBusiness.ClearSelection();
            dgvPrimera.ClearSelection();
            var indice = tcSeleccionAsiento.SelectedIndex;
            if (indice == 0)
            {
                dgvTurista.Visible = true;
                // oculto grilla de business y la de primera clase
                dgvBusiness.Visible = false;
                dgvPrimera.Visible = false;
            }
            if (indice == 1)
            {
                dgvBusiness.Visible = true;
                ColocarTamañoFilasYColumnas(ref dgvBusiness);
                // oculto grilla de turista y la de primera clase
                dgvTurista.Visible = false;
                dgvPrimera.Visible = false;
            }
            if (indice == 2)
            {
                dgvPrimera.Visible = true;
                ColocarTamañoFilasYColumnas(ref dgvPrimera);
                // oculto grilla de turista y la de business
                dgvTurista.Visible = false;
                dgvBusiness.Visible = false;
            }
        }

        private void dgvBusiness_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // damos formato a la celda segun su valor
            // pintamos las celdas segun su estado

            if (e.Value.GetType() != typeof(System.DBNull)) // si el valor de la celda es null tira error, por eso debemos validarlo
            {
                if (char.IsLetter(Convert.ToChar(e.Value))) // debo validar que no sea una letra
                {
                    e.CellStyle.BackColor = Color.White;
                }
                else
                {
                    if (Convert.ToInt32(e.Value) == 1)
                    {
                        e.CellStyle.BackColor = Color.Firebrick;
                    }
                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        e.CellStyle.BackColor = Color.ForestGreen;
                    }
                    if (Convert.ToUInt32(e.Value) == 2)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void dgvPrimera_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // damos formato a la celda segun su valor
            // pintamos las celdas segun su estado

            if (e.Value.GetType() != typeof(System.DBNull)) // si el valor de la celda es null tira error, por eso debemos validarlo
            {
                if (char.IsLetter(Convert.ToChar(e.Value))) // debo validar que no sea una letra
                {
                    e.CellStyle.BackColor = Color.White;
                }
                else
                {
                    if (Convert.ToInt32(e.Value) == 1)
                    {
                        e.CellStyle.BackColor = Color.Firebrick;
                    }
                    if (Convert.ToInt32(e.Value) == 0)
                    {
                        e.CellStyle.BackColor = Color.ForestGreen;
                    }
                    if (Convert.ToUInt32(e.Value) == 2)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void dgvBusiness_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // pintar icno png de asiento en cada celda cuyo indice sea mayor a 0
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // paso los limites de la celda y le digo que pinte todo

                var width = Properties.Resources.silla.Width; // ancho de la imagen
                var height = Properties.Resources.silla.Height; // alto de la imagen
                var x = e.CellBounds.Left + (e.CellBounds.Width - width) / 2; // le digo en que posicion pintar en el eje x
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2; // le digo en que posicion pintar en el eje y

                e.Graphics.DrawImage(Properties.Resources.silla, new Rectangle(x, y, width, height)); // Pintar la imagen
                e.Handled = true;
            }
        }

        private void dgvPrimera_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // pintar icno png de asiento en cada celda cuyo indice sea mayor a 0
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // paso los limites de la celda y le digo que pinte todo

                var width = Properties.Resources.silla.Width; // ancho de la imagen
                var height = Properties.Resources.silla.Height; // alto de la imagen
                var x = e.CellBounds.Left + (e.CellBounds.Width - width) / 2; // le digo en que posicion pintar en el eje x
                var y = e.CellBounds.Top + (e.CellBounds.Height - height) / 2; // le digo en que posicion pintar en el eje y

                e.Graphics.DrawImage(Properties.Resources.silla, new Rectangle(x, y, width, height)); // Pintar la imagen
                e.Handled = true;
            }
        }

        private void dgvBusiness_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0) // si existe un pasajero seleccionado
            {
                if (dgvDetalles.SelectedRows[0].Cells[2].Value.ToString() == "") // si el pasajero seleccionado no tiene asiento asignado
                {
                    // asigno un asiento
                    if (e.RowIndex > -1 && e.ColumnIndex > 0) // si el valor dentro de la grilla es válido
                    {
                        int filaSeleccionada = e.RowIndex;
                        int columnaSeleccionada = e.ColumnIndex;
                        // obtener la celda seleccionada
                        DataGridViewCell cell = dgvBusiness.Rows[filaSeleccionada].Cells[columnaSeleccionada];

                        // validar que el valor de la celda no sea 1
                        // es decir, que no este ocupado el asiento
                        if (Convert.ToInt32(cell.Value) == 1)
                        {
                            MessageBox.Show("Este asiento ya se encuentra ocupado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 2) // esta seleccionado (en amarillo)
                        {
                            // si es de otro pasajero la seleccion, entonces no se puede asignar
                            MessageBox.Show("No puede asignar este asiento, porque lo asigno previamente a otro pasajero. Primero debe quitar la asignacion de ese pasajero.", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 0)
                        {
                            MessageBox.Show("Selecciono el asiento " + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cell.Value = 2;
                            dgvBusiness.ClearSelection();
                            dgvDetalles.SelectedRows[0].Cells["Asiento"].Value = "" + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97);
                            dgvDetalles.SelectedRows[0].Cells["IdTipoClase"].Value = 2;
                            dgvDetalles.SelectedRows[0].Cells["TipoClase"].Value = "Clase Business";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Este pasajero ya tiene un asiento asignado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un pasajero", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvPrimera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0) // si existe un pasajero seleccionado
            {
                if (dgvDetalles.SelectedRows[0].Cells[2].Value.ToString() == "") // si el pasajero seleccionado no tiene asiento asignado
                {
                    // asigno un asiento
                    if (e.RowIndex > -1 && e.ColumnIndex > 0) // si el valor dentro de la grilla es válido
                    {
                        int filaSeleccionada = e.RowIndex;
                        int columnaSeleccionada = e.ColumnIndex;
                        // obtener la celda seleccionada
                        DataGridViewCell cell = dgvPrimera.Rows[filaSeleccionada].Cells[columnaSeleccionada];

                        // validar que el valor de la celda no sea 1
                        // es decir, que no este ocupado el asiento
                        if (Convert.ToInt32(cell.Value) == 1)
                        {
                            MessageBox.Show("Este asiento ya se encuentra ocupado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 2) // esta seleccionado (en amarillo)
                        {
                            // si es de otro pasajero la seleccion, entonces no se puede asignar
                            MessageBox.Show("No puede asignar este asiento, porque lo asigno previamente a otro pasajero. Primero debe quitar la asignacion de ese pasajero.", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        if (Convert.ToInt32(cell.Value) == 0)
                        {
                            MessageBox.Show("Selecciono el asiento " + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cell.Value = 2;
                            dgvPrimera.ClearSelection();
                            dgvDetalles.SelectedRows[0].Cells["Asiento"].Value = "" + columnaSeleccionada + Convert.ToChar(filaSeleccionada + 97);
                            dgvDetalles.SelectedRows[0].Cells["IdTipoClase"].Value = 3;
                            dgvDetalles.SelectedRows[0].Cells["TipoClase"].Value = "Primera Clase";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Este pasajero ya tiene un asiento asignado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un pasajero", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // validar que todos los pasajeros tengan asiento asignado
            bool tienenAsiento = true;
            for (int i = 0; i < dgvDetalles.RowCount; i++)
            {
                if (dgvDetalles.Rows[i].Cells["Asiento"].Value.ToString() == "")
                {
                    tienenAsiento = false;
                    break;
                }
            }

            if (tienenAsiento)
            {
                List<DetalleReserva> lista = ObtenerAsientosSeleccionados();
                gestorReserva.listaAsientos = lista;
                this.Hide();
                gestorReserva.ResumenTransaccion();
            }
            else
            {
                MessageBox.Show("Todos los pasajeros deben tener un asiento asignado", "¡Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private List<DetalleReserva> ObtenerAsientosSeleccionados()
        {
            var lista = new List<DetalleReserva>();
            for (int i = 0; i < dgvDetalles.RowCount; i++)
            {
                // obtengo el asiento
                var numeroDeLaGrilla = dgvDetalles.Rows[i].Cells["Asiento"].Value.ToString();
                string numero = new String(numeroDeLaGrilla.Where(Char.IsDigit).ToArray());

                int posicionLetra = dgvDetalles.Rows[i].Cells["Asiento"].Value.ToString().Length - 1;
                var letra = dgvDetalles.Rows[i].Cells["Asiento"].Value.ToString()[posicionLetra];
                var asiento = new Asiento();
                asiento.Letra = letra;
                asiento.Numero = Convert.ToInt32(numero);
                var idTipoClase = Convert.ToInt32(dgvDetalles.Rows[i].Cells["IdTipoClase"].Value);
                var nombre = dgvDetalles.Rows[i].Cells["TipoClase"].Value.ToString();
                asiento.TipoClase = new TipoClase { IdTipoClase = idTipoClase, Nombre = nombre };

                // obtengo el nro y tipo de docuemto del pasajero
                var pasajero = new Pasajero();
                pasajero.NroDocumento = dgvDetalles.Rows[i].Cells["NroDocumento"].Value.ToString();
                var idTipoDocumento = Convert.ToInt32(dgvDetalles.Rows[i].Cells["TipoDocumento"].Value);
                var tipoDoc = new TipoDocumento { IdTipoDocumento = idTipoDocumento };
                pasajero.ObjTipoDocumento = tipoDoc;

                var d = new DetalleReserva();
                d.ObjAsiento = asiento;
                d.ObjPasajero = pasajero;
                lista.Add(d);
            }
            return lista;
        }

        private void FrmSeleccionAsiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestorReserva.CancelarTransaccion();
        }
    }
}
