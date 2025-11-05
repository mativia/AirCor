using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmConsultarVuelos : Form
    {
        private readonly CiudadServicios ciudadServicios;
        private readonly AeropuertoServicios aeropuertoServicios;
        private readonly VueloServicios vueloServicios;
        private int idVueloSeleccionado;
        private List<Ciudad> listadoCiudadesOrigen;
        private List<Ciudad> listadoCiudadesDestino;
        private GestorReserva gestorReserva;

        public FrmConsultarVuelos(GestorReserva gestor)
        {
            ciudadServicios = new CiudadServicios();
            aeropuertoServicios = new AeropuertoServicios();
            vueloServicios = new VueloServicios();
            idVueloSeleccionado = 0;
            gestorReserva = gestor;
            InitializeComponent();
        }

        private void FrmConsultarVuelos_Load(object sender, EventArgs e)
        {
            cmbAeropuertoOrigen.SelectedIndex = -1;
            cmbAeropuertoDestino.SelectedIndex = -1;
            dtpFechaViaje.Enabled = false;
            dtpFechaViaje.MaxDate = DateTime.Today.AddYears(1);
            dtpFechaViaje.Format = DateTimePickerFormat.Custom;
            dtpFechaViaje.CustomFormat = "dd 'd'e MMMM, yyyy";
            
            CargarCombosCiudad();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string codAeropuertoOrigen = "";
            string codAeropuertoDestino = "";
            DateTime fechaViaje = dtpFechaViaje.Value;

            if (cmbAeropuertoOrigen.SelectedIndex != -1)
            {
                codAeropuertoOrigen = cmbAeropuertoOrigen.SelectedValue.ToString();
            }
            if (cmbAeropuertoDestino.SelectedIndex != -1)
            {
                codAeropuertoDestino = cmbAeropuertoDestino.SelectedValue.ToString();
            }

            var listaVuelos = new List<DefinicionDeVuelo>();
            if (chkHabilitarFecha.Checked == false)
            {
                fechaViaje = DateTime.Today.AddDays(-1);
                listaVuelos = vueloServicios.GetListaDeVuelosDisponibles(codAeropuertoOrigen, codAeropuertoDestino, fechaViaje);
            }
            else
            {
                listaVuelos = vueloServicios.GetListaDeVuelosDisponibles(codAeropuertoOrigen, codAeropuertoDestino, fechaViaje);
            }

            dgvVuelos.Rows.Clear();

            foreach (var v in listaVuelos)
            {
                var fila = new string[]
                {
                    v.ListaVuelos[0].IdVuelo.ToString(),
                    v.NroVuelo,
                    v.ObjAeropuertoOrigen.ObjCiudad.Nombre,
                    v.ObjAeropuertoOrigen.CodigoAeropuerto,
                    v.ObjAeropuertoOrigen.Nombre,
                    v.ObjAeropuertoDestino.ObjCiudad.Nombre,
                    v.ObjAeropuertoDestino.CodigoAeropuerto,
                    v.ObjAeropuertoDestino.Nombre,
                    v.ListaVuelos[0].FechaPartida.ToString("dd/MM/yyyy"),
                    v.HorarioEmbarque.ToString("HH:mm"),
                    v.HorarioPartida.ToString("HH:mm"),
                    v.HorarioLlegada.ToString("HH:mm"),
                    "-",
                    "-",
                    "-"
                };
                foreach (var t in v.ListaTarifas)
                {
                    if (t.ObjTipoClase.IdTipoClase == 1)
                    {
                        fila[12] = "$" + t.Importe.ToString("N2");
                    }
                    if (t.ObjTipoClase.IdTipoClase == 2)
                    {
                        fila[13] = "$" + t.Importe.ToString("N2");
                    }
                    if (t.ObjTipoClase.IdTipoClase == 3)
                    {
                        fila[14] = "$" + t.Importe.ToString("N2");
                    }
                }
                dgvVuelos.Rows.Add(fila);
            }
            dgvVuelos.ClearSelection();
        }

        private void CargarCombosCiudad()
        {
            Ciudad ciudadPorDefecto = new Ciudad()
            {
                Nombre = "Seleccionar",
                CodigoCiudad = ""
            };

            // Combo ciudad origen
            listadoCiudadesOrigen = ciudadServicios.GetCiudadesProvinciaPais();
            listadoCiudadesOrigen.Add(ciudadPorDefecto);
            cmbCiudadOrigen.DataSource = listadoCiudadesOrigen;
            cmbCiudadOrigen.DisplayMember = "Nombre";
            cmbCiudadOrigen.ValueMember = "CodigoCiudad";
            cmbCiudadOrigen.SelectedValue = "";

            // Combo ciudad destino
            listadoCiudadesDestino = ciudadServicios.GetCiudadesProvinciaPais();
            listadoCiudadesDestino.Add(ciudadPorDefecto);
            cmbCiudadDestino.DataSource = listadoCiudadesDestino;
            cmbCiudadDestino.DisplayMember = "Nombre";
            cmbCiudadDestino.ValueMember = "CodigoCiudad";
            cmbCiudadDestino.SelectedValue = "";
        }

        // ------------------------------------
        // Combos ciudad y aeropuerto de origen
        private void cmbCiudadOrigen_TextUpdate(object sender, EventArgs e)
        {
            string filtro = cmbCiudadOrigen.Text;
            List<Ciudad> itemsFiltrados = listadoCiudadesOrigen.FindAll(X => X.Nombre.ToLower().Contains(filtro.ToLower()));
            cmbCiudadOrigen.DataSource = itemsFiltrados;

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

        // ------------------------------------
        // Combos ciudad y aeropuerto de destino
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void chkHabilitarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFecha.Checked)
            {
                dtpFechaViaje.Enabled = true;
            }
            else
            {
                dtpFechaViaje.Enabled = false;
            }
        }

        private void btnConfirmarVuelo_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.SelectedRows.Count > 0)
            {
                // hay algo seleccionado
                // llamar al gestor y pasarle los datos
                var seleccionado = new DefinicionDeVuelo();

                var vuelo = new Vuelo();
                vuelo.IdVuelo = Convert.ToInt32(dgvVuelos.SelectedRows[0].Cells["IdVuelo"].Value);
                vuelo.FechaPartida = Convert.ToDateTime(dgvVuelos.SelectedRows[0].Cells["FechaPartida"].Value);
                seleccionado.ListaVuelos = new List<Vuelo>();
                seleccionado.ListaVuelos.Add(vuelo);

                seleccionado.NroVuelo = dgvVuelos.SelectedRows[0].Cells["NroVuelo"].Value.ToString();

                var ciudadOrigen = new Ciudad()
                {
                    Nombre = dgvVuelos.SelectedRows[0].Cells["CiudadOrigen"].Value.ToString()
                };
                var aeropuertoOrigen = new Aeropuerto()
                {
                    ObjCiudad = ciudadOrigen,
                    CodigoAeropuerto = dgvVuelos.SelectedRows[0].Cells["CodAeropuertoOrigen"].Value.ToString(),
                    Nombre = dgvVuelos.SelectedRows[0].Cells["NombreAeropuertoOrigen"].Value.ToString()
                };
                seleccionado.ObjAeropuertoOrigen = aeropuertoOrigen;

                var ciudadDestino = new Ciudad()
                {
                    Nombre = dgvVuelos.SelectedRows[0].Cells["CiudadDestino"].Value.ToString()
                };
                var aeropuertoDestino = new Aeropuerto()
                {
                    ObjCiudad = ciudadDestino,
                    CodigoAeropuerto = dgvVuelos.SelectedRows[0].Cells["CodAeropuertoDestino"].Value.ToString(),
                    Nombre = dgvVuelos.SelectedRows[0].Cells["NombreAeropuertoDestino"].Value.ToString()
                };
                seleccionado.ObjAeropuertoDestino = aeropuertoDestino;

                seleccionado.HorarioEmbarque = Convert.ToDateTime(dgvVuelos.SelectedRows[0].Cells["HorarioEmbarque"].Value);
                seleccionado.HorarioPartida = Convert.ToDateTime(dgvVuelos.SelectedRows[0].Cells["HorarioPartida"].Value);
                seleccionado.HorarioLlegada = Convert.ToDateTime(dgvVuelos.SelectedRows[0].Cells["HorarioLlegada"].Value);

                var tarifas = new List<Tarifa>();
                var precioCT = dgvVuelos.SelectedRows[0].Cells["PrecioClaseTurista"].Value.ToString();
                if (precioCT != "-")
                {
                    var t = new Tarifa();
                    t.ObjTipoClase = new TipoClase() { IdTipoClase = 1};
                    t.Importe = float.Parse(precioCT.Replace("$", ""));
                    tarifas.Add(t);
                }
                var precioCB = dgvVuelos.SelectedRows[0].Cells["PrecioClaseBusiness"].Value.ToString();
                if (precioCB != "-")
                {
                    var t = new Tarifa();
                    t.ObjTipoClase = new TipoClase() { IdTipoClase = 2 };
                    t.Importe = float.Parse(precioCB.Replace("$", ""));
                    tarifas.Add(t);
                }
                var precioPC = dgvVuelos.SelectedRows[0].Cells["PrecioPrimeraClase"].Value.ToString();
                if (precioPC != "-")
                {
                    var t = new Tarifa();
                    t.ObjTipoClase = new TipoClase() { IdTipoClase = 3 };
                    t.Importe = float.Parse(precioPC.Replace("$", ""));
                    tarifas.Add(t);
                }
                seleccionado.ListaTarifas = tarifas;

                this.Hide();
                gestorReserva.vueloSeleccionado = seleccionado;
                gestorReserva.SeleccionDePasajeros();
            }
            else
            {
                // no hay nada seleccionado
                MessageBox.Show("Debe seleccionar un vuelo previamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVuelos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvVuelos.SelectedRows.Count > 0)
            {
                this.idVueloSeleccionado = Convert.ToInt32(dgvVuelos.SelectedRows[0].Cells["IdVuelo"].Value);
            }
        }

        private void FrmConsultarVuelos_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestorReserva.CancelarTransaccion();
        }
    }
}
