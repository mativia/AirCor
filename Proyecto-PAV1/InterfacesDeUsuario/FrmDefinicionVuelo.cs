using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using tp_pav1_grupo10.Servicios;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmDefinicionVuelo : Form
    {
        private readonly CiudadServicios ciudadServicios;
        private readonly AeropuertoServicios aeropuertoServicios;
        private readonly AvionServicios avionServicios;
        private readonly DefinicionDeVueloServicios definicionDeVueloServicios;
        private List<Ciudad> listadoCiudadesOrigen;
        private List<Ciudad> listadoCiudadesDestino;
        private string nroVueloSeleccionado;
        private List<Ciudad> listadoFiltroCiudadOrigen;
        private List<Ciudad> listadoFiltroCiudadDestino;

        public FrmDefinicionVuelo()
        {
            ciudadServicios = new CiudadServicios();
            aeropuertoServicios = new AeropuertoServicios();
            avionServicios = new AvionServicios();
            definicionDeVueloServicios = new DefinicionDeVueloServicios();
            nroVueloSeleccionado = "";
            InitializeComponent();
        }

        private void FrmDefinicionVuelo_Load(object sender, EventArgs e)
        {
            CargarCombosCiudad();
            CargarComboFiltroAvion();
            CargarGrilla();

            //Modificar propiedades de los dateTimePickers
            dtpFechaVigenteDesde.MinDate = DateTime.Today;
            dtpFechaVigenteDesde.MaxDate = DateTime.Today.AddYears(1);
            dtpFechaVigenteHasta.MinDate = DateTime.Today;
            dtpFechaVigenteHasta.MaxDate = DateTime.Today.AddYears(1);

            dtpFechaVigenteHasta.Value = DateTime.Today.AddDays(1);

            //Setear valores 0 a los mask text box de tarifas
            txtTarifaPC.Text = "0,00";
            txtTarifaCT.Text = "0,00";
            txtTarifaCB.Text = "0,00";

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvDefVuelo.ColumnCount; i++)
            {
                dgvDefVuelo.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarComboAvion()
        {
            List<Avion> listaAviones = avionServicios.GetAvionesDisponibles();
            
            cmbAvion.DataSource = listaAviones;
            cmbAvion.DisplayMember = "MatriculaXModelo";
            cmbAvion.ValueMember = "Matricula";
            cmbAvion.SelectedIndex = -1;
        }

        private void CargarComboFiltroAvion()
        {
            List<Avion> listaAviones = avionServicios.GetAvionesDisponibles();

            cmbFiltroAvion.DataSource = listaAviones;
            cmbFiltroAvion.DisplayMember = "MatriculaXModelo";
            cmbFiltroAvion.ValueMember = "Matricula";
            cmbFiltroAvion.SelectedIndex = -1;
        }

        private void CargarCombosCiudad()
        {
            Ciudad ciudadPorDefecto = new Ciudad()
            {
                Nombre = "Seleccionar",
                CodigoCiudad = ""
            };

            listadoCiudadesOrigen = ciudadServicios.GetCiudadesProvinciaPais();
            listadoCiudadesOrigen.Add(ciudadPorDefecto);
            cmbCiudadOrigen.DataSource = listadoCiudadesOrigen;
            cmbCiudadOrigen.DisplayMember = "Nombre";
            cmbCiudadOrigen.ValueMember = "CodigoCiudad";
            cmbCiudadOrigen.SelectedValue = "";

            listadoCiudadesDestino = ciudadServicios.GetCiudadesProvinciaPais();
            listadoCiudadesDestino.Add(ciudadPorDefecto);
            cmbCiudadDestino.DataSource = listadoCiudadesDestino;
            cmbCiudadDestino.DisplayMember = "Nombre";
            cmbCiudadDestino.ValueMember = "CodigoCiudad";
            cmbCiudadDestino.SelectedValue = "";

            // Cargar combos de filtros de ciudad
            listadoFiltroCiudadOrigen = ciudadServicios.GetCiudadesProvinciaPais();
            listadoFiltroCiudadOrigen.Add(ciudadPorDefecto);
            cmbFiltroCiudadOrigen.DataSource = listadoFiltroCiudadOrigen;
            cmbFiltroCiudadOrigen.DisplayMember = "Nombre";
            cmbFiltroCiudadOrigen.ValueMember = "CodigoCiudad";
            cmbFiltroCiudadOrigen.SelectedValue = "";

            listadoFiltroCiudadDestino = ciudadServicios.GetCiudadesProvinciaPais();
            listadoFiltroCiudadDestino.Add(ciudadPorDefecto);
            cmbFiltroCiudadDestino.DataSource = listadoFiltroCiudadDestino;
            cmbFiltroCiudadDestino.DisplayMember = "Nombre";
            cmbFiltroCiudadDestino.ValueMember = "CodigoCiudad";
            cmbFiltroCiudadDestino.SelectedValue = "";
        }
        
        // -----------------------------------------------------------------------------------------------------------------
        // Filtrado de ciudades origen en combo mediante texto escrito
        private void cmbCiudad_TextUpdate(object sender, EventArgs e)
        {
            string filtro = cmbCiudadOrigen.Text;
            List<Ciudad> itemsFiltrados = listadoCiudadesOrigen.FindAll(X => X.Nombre.ToLower().Contains(filtro.ToLower()));

            if (itemsFiltrados.Count != 0)
            {
                cmbCiudadOrigen.DataSource = itemsFiltrados;
            }
            else
            {
                var lista = new List<Ciudad>();
                var c = new Ciudad()
                {
                    Nombre = "Seleccionar",
                    CodigoCiudad = ""
                };
                lista.Add(c);
                cmbCiudadOrigen.DataSource = lista;
                cmbCiudadOrigen.SelectedIndex = 0;
            }

            // Mantener el combo extendido
            cmbCiudadOrigen.DroppedDown = true;
            // Mantener la altura del combo cte.
            cmbCiudadOrigen.IntegralHeight = true;
            // Para que se muestre el texto que se va escribiendo
            cmbCiudadOrigen.Text = filtro;
            // Cambiar la posicion del cursor
            cmbCiudadOrigen.SelectionStart = filtro.Length;
            cmbCiudadOrigen.SelectionLength = 0;
        }

        private void cmbCiudadOrigen_DropDownClosed(object sender, EventArgs e)
        {
            cmbAeropuertoOrigen.Enabled = false;
            if (cmbCiudadOrigen.SelectedValue != null)
            {
                if (cmbCiudadOrigen.SelectedValue.ToString() != "")
                {
                    cmbAeropuertoOrigen.Enabled = true;
                    bool resultado = CargarComboAeropuertoOrigen();

                    if (!resultado && cmbCiudadOrigen.Text != "")
                    {
                        //cmbAeropuertoOrigen.Enabled = false;
                        MessageBox.Show("No se encontraron aeropuertos para la ciudad seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbAeropuertoOrigen.SelectedIndex = -1;
                        cmbCiudadOrigen.SelectedValue = "";
                    }

                    //Validar que un vuelo no se realize de una ciudad hacia si misma
                    if (cmbCiudadOrigen.SelectedValue.ToString() == cmbCiudadDestino.SelectedValue.ToString())
                    {
                        MessageBox.Show("No se puede realizar un vuelo de una ciudad hacia si misma", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbAeropuertoOrigen.SelectedIndex = -1;
                        cmbCiudadOrigen.SelectedValue = "";
                    }

                }
            }
        }

        private bool CargarComboAeropuertoOrigen()
        {
            string codCiudad = "";
            if (cmbCiudadOrigen.SelectedValue != null)
            {
                codCiudad = cmbCiudadOrigen.SelectedValue.ToString();
            }

            if (codCiudad == "")
            {
                return false;
            }
            else
            {
                List<Aeropuerto> listaAeropuertos = aeropuertoServicios.GetAeropuertosDeCiudad(codCiudad);
                if (listaAeropuertos.Count > 0)
                {
                    cmbAeropuertoOrigen.DataSource = listaAeropuertos;
                    cmbAeropuertoOrigen.DisplayMember = "Nombre";
                    cmbAeropuertoOrigen.ValueMember = "CodigoAeropuerto";
                    cmbAeropuertoOrigen.SelectedIndex = -1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void cmbCiudadOrigen_TextChanged(object sender, EventArgs e)
        {
            if (cmbCiudadOrigen.Text == "Seleccionar" || cmbCiudadOrigen.SelectedValue == null || cmbCiudadOrigen.Text == "")
            {
                // limpiar combo aeropuerto
                cmbAeropuertoOrigen.SelectedIndex = -1;
                cmbAeropuertoOrigen.Enabled = false;
            }
        }

        // -----------------------------------------------------------------------------------------------
        // COMBO AEROPUERTO Y CIUDAD DESTINO
        private void cmbCiudadDestino_TextUpdate(object sender, EventArgs e)
        {
            string filtro = cmbCiudadDestino.Text;
            List<Ciudad> itemsFiltrados = listadoCiudadesDestino.FindAll(X => X.Nombre.ToLower().Contains(filtro.ToLower()));

            if (itemsFiltrados.Count != 0)
            {
                cmbCiudadDestino.DataSource = itemsFiltrados;
            }
            else
            {
                var lista = new List<Ciudad>();
                var c = new Ciudad()
                {
                    Nombre = "Seleccionar",
                    CodigoCiudad = ""
                };
                lista.Add(c);
                cmbCiudadDestino.DataSource = lista;
                cmbCiudadDestino.SelectedIndex = 0;
            }

            // Mantener el combo extendido
            cmbCiudadDestino.DroppedDown = true;
            // Mantener la altura del combo cte.
            cmbCiudadDestino.IntegralHeight = true;
            // Para que se muestre el texto que se va escribiendo
            cmbCiudadDestino.Text = filtro;
            // Cambiar la posicion del cursor
            cmbCiudadDestino.SelectionStart = filtro.Length;
            cmbCiudadDestino.SelectionLength = 0;
        }

        private void cmbCiudadDestino_DropDownClosed(object sender, EventArgs e)
        {
            cmbAeropuertoDestino.Enabled = false;
            if (cmbCiudadDestino.SelectedValue != null)
            {
                if (cmbCiudadDestino.SelectedValue.ToString() != "")
                {
                    cmbAeropuertoDestino.Enabled = true;
                    bool resultado = CargarComboAeropuertoDestino();

                    if (!resultado && cmbCiudadDestino.Text != "")
                    {
                        //cmbAeropuertoOrigen.Enabled = false;
                        MessageBox.Show("No se encontraron aeropuertos para la ciudad seleccionada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbAeropuertoDestino.SelectedIndex = -1;
                        cmbCiudadDestino.SelectedValue = "";
                    }

                    //Validar que un vuelo no se realize de una ciudad hacia si misma
                    if (cmbCiudadOrigen.SelectedValue.ToString() == cmbCiudadDestino.SelectedValue.ToString())
                    {
                        MessageBox.Show("No se puede realizar un vuelo de una ciudad hacia si misma", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbAeropuertoDestino.SelectedIndex = -1;
                        cmbCiudadDestino.SelectedValue = "";
                    }
                }
            }
        }

        private bool CargarComboAeropuertoDestino()
        {
            string codCiudad = "";
            if (cmbCiudadDestino.SelectedValue != null)
            {
                codCiudad = cmbCiudadDestino.SelectedValue.ToString();
            }

            if (codCiudad == "")
            {
                return false;
            }
            else
            {
                List<Aeropuerto> listaAeropuertos = aeropuertoServicios.GetAeropuertosDeCiudad(codCiudad);
                if (listaAeropuertos.Count > 0)
                {
                    cmbAeropuertoDestino.DataSource = listaAeropuertos;
                    cmbAeropuertoDestino.DisplayMember = "Nombre";
                    cmbAeropuertoDestino.ValueMember = "CodigoAeropuerto";
                    cmbAeropuertoDestino.SelectedIndex = -1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void cmbCiudadDestino_TextChanged(object sender, EventArgs e)
        {
            if (cmbCiudadDestino.Text == "Seleccionar" || cmbCiudadDestino.SelectedValue == null || cmbCiudadDestino.Text == "")
            {
                // limpiar combo aeropuerto
                cmbAeropuertoDestino.SelectedIndex = -1;
                cmbAeropuertoDestino.Enabled = false;
            }
        }

        private DefinicionDeVuelo ObtenerDefincionDeVuelo()
        {
            List<DiaSemana> diasSemana= new List<DiaSemana>();
            if (chkLunes.Checked)
            {
                DiaSemana lunes = new DiaSemana { IdDiaSemana = 1, Nombre = "Monday" };
                diasSemana.Add(lunes);
            }
            if (chkMartes.Checked)
            {
                DiaSemana martes = new DiaSemana { IdDiaSemana = 2, Nombre = "Tuesday" };
                diasSemana.Add(martes);
            }
            if (chkMiercoles.Checked)
            {
                DiaSemana miercoles = new DiaSemana { IdDiaSemana = 3, Nombre = "Wednesday" };
                diasSemana.Add(miercoles);
            }
            if (chkJueves.Checked)
            {
                DiaSemana jueves = new DiaSemana { IdDiaSemana = 4, Nombre = "Thursday" };
                diasSemana.Add(jueves);
            }
            if (chkViernes.Checked)
            {
                DiaSemana viernes = new DiaSemana { IdDiaSemana = 5, Nombre = "Friday" };
                diasSemana.Add(viernes);
            }
            if (chkSabado.Checked)
            {
                DiaSemana sabado = new DiaSemana { IdDiaSemana = 6, Nombre = "Saturday" };
                diasSemana.Add(sabado);
            }
            if (chkDomingo.Checked)
            {
                DiaSemana domingo = new DiaSemana { IdDiaSemana = 7, Nombre = "Sunday" };
                diasSemana.Add(domingo);
            }

            // asignado de tarifas
            List<Tarifa> listaTarifas = new List<Tarifa>();

            if (txtTarifaPC.Enabled)
            {
                if (!string.IsNullOrEmpty(txtTarifaPC.Text) && ValidarTarifa(txtTarifaPC.Text))
                {
                    Tarifa tarifaPC = new Tarifa()
                    {
                        Importe = float.Parse(txtTarifaPC.Text),
                        ObjTipoClase = new TipoClase() { Nombre = "Primera Clase", IdTipoClase = 3 }
                    };
                    listaTarifas.Add(tarifaPC);
                }
                else
                {
                    Tarifa tarifaPC = new Tarifa()
                    {
                        Importe = (float)0,
                        ObjTipoClase = new TipoClase() { Nombre = "Primera Clase", IdTipoClase = 3 }
                    };
                    listaTarifas.Add(tarifaPC);
                }               
            }

            if (txtTarifaCB.Enabled)
            {
                if (!string.IsNullOrEmpty(txtTarifaCB.Text) && ValidarTarifa(txtTarifaCB.Text))
                {
                    Tarifa tarifaBC = new Tarifa()
                    {
                        Importe = float.Parse(txtTarifaCB.Text),
                        ObjTipoClase = new TipoClase() { Nombre = "Business", IdTipoClase = 2 }
                    };
                    listaTarifas.Add(tarifaBC);
                }
                else
                {
                    Tarifa tarifaBC = new Tarifa()
                    {
                        Importe = (float)0,
                        ObjTipoClase = new TipoClase() { Nombre = "Business", IdTipoClase = 2 }
                    };
                    listaTarifas.Add(tarifaBC);
                }
            }
            

            if (txtTarifaCT.Enabled)
            {
                if (!string.IsNullOrEmpty(txtTarifaCT.Text) && ValidarTarifa(txtTarifaCT.Text))
                {
                    Tarifa tarifaCT = new Tarifa()
                    {
                        Importe = float.Parse(txtTarifaCT.Text),
                        ObjTipoClase = new TipoClase() { Nombre = "Turista", IdTipoClase = 1 }
                    };
                    listaTarifas.Add(tarifaCT);
                }
                else
                {
                    Tarifa tarifaCT = new Tarifa()
                    {
                        Importe = (float)0,
                        ObjTipoClase = new TipoClase() { Nombre = "Turista", IdTipoClase = 1 }
                    };
                    listaTarifas.Add(tarifaCT);
                }
            }

            DefinicionDeVuelo defVuelo = new DefinicionDeVuelo()
            {
                NroVuelo = txtNroVuelo.Text.ToString(),
                HorarioEmbarque = dtpHorarioEmbarque.Value,
                HorarioPartida = dtpHorarioPartida.Value,
                HorarioLlegada = dtpHorarioLlegada.Value,
                Distancia = txtDistancia.Text.ToString(),
                FechaVigenteDesde = dtpFechaVigenteDesde.Value,
                FechaVigenteHasta = dtpFechaVigenteHasta.Value,
                ListaDiasSemana = diasSemana,
                ListaTarifas = listaTarifas,
                ObjAeropuertoOrigen = new Aeropuerto() { CodigoAeropuerto = "" },
                ObjAeropuertoDestino = new Aeropuerto() { CodigoAeropuerto = "" },
                ObjAvion = cmbAvion.SelectedIndex == -1 ? new Avion { Matricula = "" } : new Avion() { Matricula = cmbAvion.SelectedValue.ToString() }
            };
            if (cmbAeropuertoOrigen.SelectedValue != null)
            {
                defVuelo.ObjAeropuertoOrigen = cmbAeropuertoOrigen.SelectedValue.ToString() == "" ? new Aeropuerto() { CodigoAeropuerto = "" } : new Aeropuerto() { CodigoAeropuerto = cmbAeropuertoOrigen.SelectedValue.ToString() };
            }
            if (cmbAeropuertoDestino.SelectedValue != null)
            {
                defVuelo.ObjAeropuertoDestino = cmbAeropuertoDestino.SelectedValue.ToString() == "" ? new Aeropuerto() { CodigoAeropuerto = "" } : new Aeropuerto() { CodigoAeropuerto = cmbAeropuertoDestino.SelectedValue.ToString() };
            }

            return defVuelo;
        }


        // Valida que la tarifa ingresada sea un valor numerico que se pueda convertir en float
        private bool ValidarTarifa(string tarifa)
        {
            float numero;
            bool resultado = float.TryParse(tarifa, out numero);
            return resultado;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var defVuelo = ObtenerDefincionDeVuelo();

            if (nroVueloSeleccionado == "")
            {
                try
                {
                    // Insertar una definicion de vuelo
                    string mensaje = definicionDeVueloServicios.InsertDefinicionVuelo(defVuelo);
                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se ha generado la definicion de vuelo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarGrilla();
                    }
                }
                catch (Exception aex)
                {
                    MessageBox.Show(aex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Modificado de una definicion de vuelo
                try
                {
                    string mensaje = definicionDeVueloServicios.UpdateDefinicionVuelo(defVuelo);
                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se ha actualizado la definicion de vuelo correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarGrilla();
                    }
                }
                catch (Exception aex)
                {

                    MessageBox.Show(aex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
}

        private void cmbAvion_MouseClick(object sender, MouseEventArgs e)
        {
            CargarComboAvion();

            txtTarifaPC.Enabled = false;
            txtTarifaCB.Enabled = false;
            txtTarifaCT.Enabled = false;
        }

        // Cada vez que se selecciona un avion se deben habilitar los txt de tarifas segun las clases disponibles en ese avion
        private void cmbAvion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTarifaPC.Enabled = false;
            txtTarifaCB.Enabled = false;
            txtTarifaCT.Enabled = false;

            txtTarifaPC.Text = "0,00";
            txtTarifaCB.Text = "0,00";
            txtTarifaCT.Text = "0,00";

            Avion a = (Avion)cmbAvion.SelectedItem;
            if (a.FilasPC != 0 && a.AsientosPC != 0)
            {
                txtTarifaPC.Enabled = true;
            }
            if (a.FilasCT != 0 && a.AsientosCT != 0)
            {
                txtTarifaCT.Enabled = true;
            }
            if (a.FilasCB != 0 && a.AsientosCB != 0)
            {
                txtTarifaCB.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            // Modificar propiedades de los dateTimePickers
            dtpFechaVigenteDesde.MinDate = DateTime.Today;
            dtpFechaVigenteDesde.MaxDate = DateTime.Today.AddYears(1);
            dtpFechaVigenteHasta.MinDate = DateTime.Today;
            dtpFechaVigenteHasta.MaxDate = DateTime.Today.AddYears(1);
            dtpFechaVigenteHasta.Value = DateTime.Today.AddDays(1);

            // Limpiar campos y colocar valores por default
            txtNroVuelo.Clear();
            txtDistancia.Clear();
            cmbCiudadOrigen.SelectedIndex = -1;
            cmbAeropuertoOrigen.SelectedIndex = -1;
            cmbCiudadDestino.SelectedIndex = -1;
            cmbAeropuertoDestino.SelectedIndex = -1;
            dtpFechaVigenteDesde.Value = DateTime.Today;
            dtpFechaVigenteHasta.Value = DateTime.Today.AddDays(1);
            dtpHorarioPartida.Value = DateTime.Now;
            dtpHorarioLlegada.Value = DateTime.Now;
            dtpHorarioEmbarque.Value = DateTime.Now;
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            cmbAvion.SelectedIndex = -1;
            txtTarifaPC.Text = "0,00";
            txtTarifaCT.Text = "0,00";
            txtTarifaCB.Text = "0,00";

            // Desabilitar los txt de tarifas hasta que se seleccione un avion
            txtTarifaPC.Enabled = false;
            txtTarifaCT.Enabled = false;
            txtTarifaCB.Enabled = false;
            nroVueloSeleccionado = "";

            // Habilitar los campos cuando se limpia la seleccion
            txtNroVuelo.Enabled = true;
            txtDistancia.Enabled = true;
            cmbAeropuertoOrigen.Enabled = false;
            cmbCiudadOrigen.Enabled = true;
            cmbAeropuertoDestino.Enabled = false;
            cmbCiudadDestino.Enabled = true;
            dtpFechaVigenteDesde.Enabled = true;
            dtpFechaVigenteHasta.Enabled = true;
            dtpHorarioEmbarque.Enabled = true;
            dtpHorarioPartida.Enabled = true;
            dtpHorarioLlegada.Enabled = true;
            panDiasSemana.Enabled = true;
            cmbAvion.Enabled = true;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.nroVueloSeleccionado = "";
            dgvDefVuelo.ClearSelection();
            txtNroVuelo.Enabled = true;


            for (int i = 0; i < dgvDefVuelo.RowCount; i++)
            {
                dgvDefVuelo.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void CargarGrilla()
        {
            var listaDefVuelo = new List<DefinicionDeVuelo>();
            listaDefVuelo = definicionDeVueloServicios.GetDefinicionVuelo();
            dgvDefVuelo.Rows.Clear();

            foreach (var defVuelo in listaDefVuelo)
            {
                var fila = new object[]
                {
                    null, // esta es la columna de la imagen
                    defVuelo.NroVuelo,
                    defVuelo.Distancia,
                    defVuelo.ObjAeropuertoOrigen.ObjCiudad.CodigoCiudad,
                    defVuelo.ObjAeropuertoOrigen.CodigoAeropuerto,
                    defVuelo.ObjAeropuertoDestino.ObjCiudad.CodigoCiudad,
                    defVuelo.ObjAeropuertoDestino.CodigoAeropuerto,
                    defVuelo.FechaCreacion.ToString("dd/MM/yyyy"),
                    defVuelo.FechaVigenteDesde.ToString("dd/MM/yyyy"),
                    defVuelo.FechaVigenteHasta.ToString("dd/MM/yyyy"),
                    defVuelo.HorarioEmbarque.ToString("HH:mm"),
                    defVuelo.HorarioPartida.ToString("HH:mm"),
                    defVuelo.HorarioLlegada.ToString("HH:mm"),
                    defVuelo.ObjAvion.Matricula.ToString(),
                    defVuelo.ListaDiasSemana,
                    defVuelo.ListaTarifas
                };


                dgvDefVuelo.Rows.Add(fila);
            }

            // Limpiar la imagen en la columna de imagenes
            for (int i = 0; i < dgvDefVuelo.RowCount; i++)
            {
                dgvDefVuelo.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void dgvDefVuelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (nroVueloSeleccionado != "")
            {
                for (int i = 0; i < dgvDefVuelo.RowCount; i++)
                {
                    string valor = dgvDefVuelo.Rows[i].Cells["NroVuelo"].Value.ToString();
                    if (valor == nroVueloSeleccionado)
                    {
                        dgvDefVuelo.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            int indice = e.RowIndex;
            if (indice >= 0)
            {
                LimpiarCampos();
                txtNroVuelo.Text = dgvDefVuelo.Rows[indice].Cells["NroVuelo"].Value.ToString();
                txtNroVuelo.Enabled = false;
                txtDistancia.Text = dgvDefVuelo.Rows[indice].Cells["Distancia"].Value.ToString();
                cmbCiudadOrigen.SelectedValue = dgvDefVuelo.Rows[indice].Cells["CiudadOrigen"].Value.ToString();
                CargarComboAeropuertoOrigen();
                cmbAeropuertoOrigen.SelectedValue = dgvDefVuelo.Rows[indice].Cells["CodAeropuertoOrigen"].Value.ToString();
                cmbCiudadDestino.SelectedValue = dgvDefVuelo.Rows[indice].Cells["CiudadDestino"].Value.ToString();
                CargarComboAeropuertoDestino();
                cmbAeropuertoDestino.SelectedValue = dgvDefVuelo.Rows[indice].Cells["CodAeropuertoDestino"].Value.ToString();

                //Modificar propiedades de los dateTimePickers
                dtpFechaVigenteDesde.MinDate = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteDesde"].Value);
                dtpFechaVigenteDesde.MaxDate = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteHasta"].Value).AddYears(1);
                dtpFechaVigenteHasta.MinDate = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteDesde"].Value);
                dtpFechaVigenteHasta.MaxDate = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteHasta"].Value).AddYears(1);

                dtpFechaVigenteDesde.Value = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteDesde"].Value);
                dtpFechaVigenteHasta.Value = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["FechaVigenteHasta"].Value);
                dtpHorarioEmbarque.Value = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["HorarioEmbarque"].Value);
                dtpHorarioPartida.Value = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["HorarioPartida"].Value);
                dtpHorarioLlegada.Value = Convert.ToDateTime(dgvDefVuelo.Rows[indice].Cells["HorarioLlegada"].Value);
                
                // Cargar combo avion y habilitar los textbox
                CargarComboAvion();
                cmbAvion.SelectedValue = dgvDefVuelo.Rows[indice].Cells["MatriculaAvion"].Value.ToString();

                Avion a = (Avion)cmbAvion.SelectedItem;
                if (a.FilasPC != 0 && a.AsientosPC != 0)
                {
                    txtTarifaPC.Enabled = true;
                }
                if (a.FilasCT != 0 && a.AsientosCT != 0)
                {
                    txtTarifaCT.Enabled = true;
                }
                if (a.FilasCB != 0 && a.AsientosCB != 0)
                {
                    txtTarifaCB.Enabled = true;
                }


                List<DiaSemana> listaDias = (List<DiaSemana>)dgvDefVuelo.Rows[indice].Cells["Dias"].Value;
                foreach (var d in listaDias)
                {
                    switch (d.IdDiaSemana)
                    {
                        case 1:
                            chkLunes.Checked = true;
                            break;
                        case 2:
                            chkMartes.Checked = true;
                            break;
                        case 3:
                            chkMiercoles.Checked = true;
                            break;
                        case 4:
                            chkJueves.Checked = true;
                            break;
                        case 5:
                            chkViernes.Checked = true;
                            break;
                        case 6:
                            chkSabado.Checked = true;
                            break;
                        case 7:
                            chkMartes.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
                List<Tarifa> listaTarifas = (List<Tarifa>)dgvDefVuelo.Rows[indice].Cells["Tarifas"].Value;
                foreach (var t in listaTarifas)
                {
                    switch (t.ObjTipoClase.IdTipoClase)
                    {
                        case 1:
                            txtTarifaCT.Text = t.Importe.ToString();
                            break;
                        case 2:
                            txtTarifaCB.Text = t.Importe.ToString(); ;
                            break;
                        case 3:
                            txtTarifaPC.Text = t.Importe.ToString(); ;
                            break;
                        default:
                            break;
                    }
                }

                // Deshabilitar los campos que no son modificables
                txtNroVuelo.Enabled = false;
                txtDistancia.Enabled = false;
                cmbAeropuertoOrigen.Enabled = false;
                cmbCiudadOrigen.Enabled = false;
                cmbAeropuertoDestino.Enabled = false;
                cmbCiudadDestino.Enabled = false;
                dtpFechaVigenteDesde.Enabled = false;
                dtpFechaVigenteHasta.Enabled = false;
                dtpHorarioEmbarque.Enabled = false;
                dtpHorarioPartida.Enabled = false;
                dtpHorarioLlegada.Enabled = false;
                panDiasSemana.Enabled = false;
                cmbAvion.Enabled = false;

                nroVueloSeleccionado = txtNroVuelo.Text;
                dgvDefVuelo.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
            }
        }

        private void dgvDefVuelo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDefVuelo.SelectedRows[0].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (nroVueloSeleccionado != "")
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere cancelar la definición de vuelo? \nTodos los vuelos no realizados pasaran a estar cancelados.", "Cancelar Definicion de vuelo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {                    
                    try
                    {
                        definicionDeVueloServicios.DeleteDefinicionDeVuelo(nroVueloSeleccionado);
                        MessageBox.Show("La definicion de vuelo ha sido eliminada", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarCampos();
                        
                    }
                    catch (ApplicationException aex)
                    {
                        MessageBox.Show(aex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar primero una definicion de vuelo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroNroVuelo.Clear();
            cmbFiltroAvion.SelectedIndex = -1;
            cmbFiltroCiudadOrigen.SelectedIndex = listadoFiltroCiudadOrigen.Count -1;
            cmbFiltroCiudadDestino.SelectedIndex = listadoFiltroCiudadDestino.Count - 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtro = new DefinicionVueloFiltro();
            filtro.nroVuelo = txtFiltroNroVuelo.Text.Trim();

            if (cmbFiltroCiudadOrigen.Text != "Seleccionar" && cmbFiltroCiudadOrigen.Text != "") // Hay filtro seleccionado
            {
                if (cmbFiltroCiudadOrigen.SelectedValue.ToString() == "") // El value member es vacio porque no selecciono nada de la lista, solo escribio texto
                {
                    filtro.codCiudadOrigen = cmbFiltroCiudadOrigen.Text;
                }
                else // El value member tiene valor porque se selecciono una ciudad
                {
                    filtro.codCiudadOrigen = cmbFiltroCiudadOrigen.SelectedValue.ToString();
                }
            }
            else // No hay filtro seleccionado
            {
                filtro.codCiudadOrigen = "";
            }

            if (cmbFiltroCiudadDestino.Text != "Seleccionar" && cmbFiltroCiudadDestino.Text != "")
            {
                if (cmbFiltroCiudadDestino.SelectedValue.ToString() == "")
                {
                    filtro.codCiudadDestino = cmbFiltroCiudadDestino.Text;
                }
                else
                {
                    filtro.codCiudadDestino = cmbFiltroCiudadDestino.SelectedValue.ToString();
                }
            }
            else
            {
                filtro.codCiudadDestino = "";
            }

            if (cmbFiltroAvion.SelectedIndex != -1)
            {
                filtro.matriculaAvion = cmbFiltroAvion.SelectedValue.ToString();
            }
            else
            {
                filtro.matriculaAvion = "";
            }

            var listaDefVuelo = new List<DefinicionDeVuelo>();
            listaDefVuelo = definicionDeVueloServicios.GetDefinicionVuelo(filtro);
            dgvDefVuelo.Rows.Clear();

            foreach (var defVuelo in listaDefVuelo)
            {
                var fila = new object[]
                {
                    null, // esta es la columna de la imagen
                    defVuelo.NroVuelo,
                    defVuelo.Distancia,
                    defVuelo.ObjAeropuertoOrigen.ObjCiudad.CodigoCiudad,
                    defVuelo.ObjAeropuertoOrigen.CodigoAeropuerto,
                    defVuelo.ObjAeropuertoDestino.ObjCiudad.CodigoCiudad,
                    defVuelo.ObjAeropuertoDestino.CodigoAeropuerto,
                    defVuelo.FechaCreacion.ToString("dd/MM/yyyy"),
                    defVuelo.FechaVigenteDesde.ToString("dd/MM/yyyy"),
                    defVuelo.FechaVigenteHasta.ToString("dd/MM/yyyy"),
                    defVuelo.HorarioEmbarque.ToString("HH:mm"),
                    defVuelo.HorarioPartida.ToString("HH:mm"),
                    defVuelo.HorarioLlegada.ToString("HH:mm"),
                    defVuelo.ObjAvion.Matricula.ToString(),
                    defVuelo.ListaDiasSemana,
                    defVuelo.ListaTarifas
                };


                dgvDefVuelo.Rows.Add(fila);
            }

            // Limpiar la imagen en la columna de imagenes
            for (int i = 0; i < dgvDefVuelo.RowCount; i++)
            {
                dgvDefVuelo.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void cmbFiltroCiudadOrigen_TextUpdate(object sender, EventArgs e)
        {
            string filtro = cmbFiltroCiudadOrigen.Text;
            List<Ciudad> itemsFiltrados = listadoFiltroCiudadOrigen.FindAll(X => X.Nombre.ToLower().Contains(filtro.ToLower()));

            if (itemsFiltrados.Count != 0)
            {
                cmbFiltroCiudadOrigen.DataSource = itemsFiltrados;
            }
            else
            {
                var lista = new List<Ciudad>();
                var c = new Ciudad()
                {
                    Nombre = "Seleccionar",
                    CodigoCiudad = ""
                };
                lista.Add(c);

                cmbFiltroCiudadOrigen.DataSource = lista;
                cmbFiltroCiudadOrigen.SelectedIndex = 0;
            }

            // Mantener el combo extendido
            cmbFiltroCiudadOrigen.DroppedDown = true;
            // Mantener la altura del combo cte.
            cmbFiltroCiudadOrigen.IntegralHeight = true;
            // Para que se muestre el texto que se va escribiendo
            cmbFiltroCiudadOrigen.Text = filtro;

            // Cambiar la posicion del cursor
            cmbFiltroCiudadOrigen.SelectionStart = filtro.Length;
            cmbFiltroCiudadOrigen.SelectionLength = 0;
        }

        private void cmbFiltroCiudadDestino_TextUpdate(object sender, EventArgs e)
        {
            string filtro = cmbFiltroCiudadDestino.Text;
            List<Ciudad> itemsFiltrados = listadoFiltroCiudadDestino.FindAll(X => X.Nombre.ToLower().Contains(filtro.ToLower()));

            if (itemsFiltrados.Count != 0)
            {
                cmbFiltroCiudadDestino.DataSource = itemsFiltrados;
            }
            else
            {
                var lista = new List<Ciudad>();
                var c = new Ciudad()
                {
                    Nombre = "Seleccionar",
                    CodigoCiudad = ""
                };
                lista.Add(c);
                cmbFiltroCiudadDestino.DataSource = lista;
                cmbFiltroCiudadDestino.SelectedIndex = 0;
            }

            // Mantener el combo extendido
            cmbFiltroCiudadDestino.DroppedDown = true;
            // Mantener la altura del combo cte.
            cmbFiltroCiudadDestino.IntegralHeight = true;
            // Para que se muestre el texto que se va escribiendo
            cmbFiltroCiudadDestino.Text = filtro;

            // Cambiar la posicion del cursor
            cmbFiltroCiudadDestino.SelectionStart = filtro.Length;
            cmbFiltroCiudadDestino.SelectionLength = 0;
        }
    }
}