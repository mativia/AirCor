using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.InterfacesDeUsuario.Reportes.EstadisticoDestinoPorClase;
using tp_pav1_grupo10.InterfacesDeUsuario.Reportes.ListadoVuelos;
using tp_pav1_grupo10.Servicios;
using System.Drawing.Drawing2D;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class MenuPrincipal : Form
    {
        private Login frmLogin;
        private readonly PermisoServicios permisoServicios;

        // Theme state
        private bool isDarkTheme = true;
        private Color menuTextColor;
        private Color hoverColor;
        private Font menuFont;

        private ToolStripControlHost userInfoHost;

        public MenuPrincipal(Login login)
        {
            frmLogin = login;
            permisoServicios = new PermisoServicios();
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Font: Segoe UI Semibold (fall back to Bold if not available)
            try
            {
                menuFont = new Font("Segoe UI Semibold", 9F);
            }
            catch
            {
                menuFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            this.menuStrip1.Font = menuFont;

            // Aplicar renderer personalizado para colores oscuros inicialmente.
            ApplyDarkTheme();

            // Forzar color de texto a todos los ToolStripItems y subscribir hover
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = menuTextColor;
                item.Font = menuFont;
                SubscribeHover(item);

                if (item is ToolStripMenuItem tmi)
                {
                    foreach (ToolStripItem sub in tmi.DropDownItems)
                    {
                        sub.ForeColor = menuTextColor;
                        sub.Font = menuFont;
                        SubscribeHover(sub);
                    }
                    // ensure dropdown background matches theme
                    tmi.DropDown.BackColor = menuStrip1.BackColor;
                    tmi.DropDown.ForeColor = menuTextColor;
                }
            }

            // Remove any programmatic theme menu item if existed (we now use btnTema)
            var old = menuStrip1.Items.Find("imiTema", false);
            if (old != null && old.Length > 0)
                menuStrip1.Items.Remove(old[0]);

            // Theme toggle will be created as a small menu item below

            // Add theme toggle as a small menu item on the right
            var imiTema = new IconMenuItem()
            {
                Name = "imiTema",
                Text = "",
                IconChar = IconChar.Moon,
                IconColor = menuTextColor,
                IconFont = IconFont.Auto,
                IconSize = 24,
                ImageScaling = ToolStripItemImageScaling.None,
                Padding = new Padding(10, 8, 10, 8),
                AutoSize = false,
                Size = new System.Drawing.Size(60, 74), // make it wider to be more visible
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            imiTema.Click += (s, ev) => ToggleTheme(imiTema);
            menuStrip1.Items.Add(imiTema);
            SubscribeHover(imiTema);

            HabilitarMenus();
            lblUsuLogueado.Text = $"Usuario: {UsuarioServicios.UsuarioLogueado.Nombre}";
            lblPerfil.Text = $"Perfil: {UsuarioServicios.UsuarioLogueado.ObjPerfil.Nombre}";
            imiInformeDetalladoVuelo.Visible = false;
            imiConsultarEstados.Visible = false;
            imiConsultarReserva.Visible = false;

            // Ensure avatar background transparent, but panel will use menu background
            this.picUserAvatar.BackColor = Color.Transparent;

            // Make panel background match the menu so user slot blends with menu
            try
            {
                panelUserInfo.BackColor = menuStrip1.BackColor;
                lblUsuLogueado.BackColor = panelUserInfo.BackColor;
                lblPerfil.BackColor = panelUserInfo.BackColor;
                // Ensure high contrast text colors depending on theme
                lblUsuLogueado.ForeColor = isDarkTheme ? Color.White : Color.FromArgb(34, 34, 34);
                lblPerfil.ForeColor = isDarkTheme ? Color.FromArgb(235, 235, 235) : Color.Gray;
                // Slightly increase font for readability
                lblUsuLogueado.Font = new Font(lblUsuLogueado.Font.FontFamily, 9F, FontStyle.Bold);
                lblPerfil.Font = new Font(lblPerfil.Font.FontFamily, 8F, FontStyle.Regular);
            }
            catch { }

            AddUserInfoToMenu();
        }

        private void SubscribeHover(ToolStripItem item)
        {
            // store original forecolor in Tag (only if not set)
            if (item.Tag == null)
                item.Tag = item.ForeColor;

            item.MouseEnter += (s, e) =>
            {
                try
                {
                    // Much more subtle hover: slight color tint and tiny icon size change
                    item.ForeColor = BlendColor(item.ForeColor, hoverColor, 0.35f);
                    if (item is IconMenuItem imi)
                    {
                        imi.IconColor = BlendColor(imi.IconColor, hoverColor, 0.35f);
                        imi.IconSize = Math.Min(48, imi.IconSize + 2);
                    }
                }
                catch { }
            };

            item.MouseLeave += (s, e) =>
            {
                try
                {
                    item.ForeColor = menuTextColor;
                    if (item is IconMenuItem imi)
                    {
                        imi.IconColor = menuTextColor;
                        imi.IconSize = Math.Max(12, imi.IconSize - 2);
                    }
                }
                catch { }
            };
        }

        // Blend two colors by t (0..1)
        private Color BlendColor(Color a, Color b, float t)
        {
            t = Math.Max(0, Math.Min(1, t));
            int r = (int)(a.R + (b.R - a.R) * t);
            int g = (int)(a.G + (b.G - a.G) * t);
            int bl = (int)(a.B + (b.B - a.B) * t);
            int alpha = (int)(a.A + (b.A - a.A) * t);
            return Color.FromArgb(alpha, r, g, bl);
        }

        private void ToggleTheme(IconMenuItem imiTema)
        {
            // toggle theme and update small button icon
            if (isDarkTheme)
            {
                ApplyLightTheme();
                imiTema.IconChar = IconChar.Sun;
                imiTema.IconColor = menuTextColor;
                imiTema.Text = "";
            }
            else
            {
                ApplyDarkTheme();
                imiTema.IconChar = IconChar.Moon;
                imiTema.IconColor = menuTextColor;
                imiTema.Text = "";
            }

            // refresh menu items colors and icon colors
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = menuTextColor;
                if (item is IconMenuItem imiRoot)
                {
                    imiRoot.IconColor = menuTextColor;
                }
                if (item is ToolStripMenuItem tmi)
                {
                    tmi.DropDown.BackColor = menuStrip1.BackColor;
                    tmi.DropDown.ForeColor = menuTextColor;
                    foreach (ToolStripItem sub in tmi.DropDownItems)
                    {
                        sub.ForeColor = menuTextColor;
                        sub.BackColor = menuStrip1.BackColor;
                        if (sub is IconMenuItem imiSub)
                        {
                            imiSub.IconColor = menuTextColor;
                        }
                    }
                }
            }

            // Update panel background to match menu and label colors immediately
            try
            {
                panelUserInfo.BackColor = menuStrip1.BackColor;
                lblUsuLogueado.BackColor = panelUserInfo.BackColor;
                lblPerfil.BackColor = panelUserInfo.BackColor;
                // set contrasting colors explicitly
                lblUsuLogueado.ForeColor = isDarkTheme ? Color.White : Color.FromArgb(34, 34, 34);
                lblPerfil.ForeColor = isDarkTheme ? Color.FromArgb(235, 235, 235) : Color.Gray;
                lblPerfil.BackColor = panelUserInfo.BackColor;
            }
            catch { }

            try
            {
                menuStrip1.Invalidate();
                menuStrip1.Refresh();
            }
            catch { }
        }

        private void ApplyDarkTheme()
        {
            isDarkTheme = true;
            menuTextColor = Color.White;
            hoverColor = Color.FromArgb(255, 245, 230); // very subtle warm tint

            // renderer
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorTable());
            this.menuStrip1.BackColor = Color.FromArgb(13, 71, 161);
            this.menuStrip1.ForeColor = menuTextColor;
            this.BackColor = Color.White; // keep main background as before

            // update panel background to match menu
            try { panelUserInfo.BackColor = menuStrip1.BackColor; } catch { }
            try
            {
                lblUsuLogueado.ForeColor = Color.White;
                lblPerfil.ForeColor = Color.FromArgb(235,235,235);
                lblUsuLogueado.BackColor = panelUserInfo.BackColor;
                lblPerfil.BackColor = panelUserInfo.BackColor;
            }
            catch { }
        }
 
         private void ApplyLightTheme()
         {
            isDarkTheme = false;
            menuTextColor = Color.FromArgb(34, 34, 34);
            hoverColor = Color.FromArgb(200, 200, 220); // subtle darker tint for hover

            // light color table
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new LightProfessionalColorTable());
            this.menuStrip1.BackColor = Color.WhiteSmoke;
            this.menuStrip1.ForeColor = menuTextColor;
            this.BackColor = Color.White;

            // Ensure dropdowns are readable: set their back/fore explicitly
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem tmi)
                {
                    tmi.DropDown.BackColor = Color.White;
                    tmi.DropDown.ForeColor = menuTextColor;
                    tmi.DropDown.RenderMode = ToolStripRenderMode.Professional;
                    foreach (ToolStripItem sub in tmi.DropDownItems)
                    {
                        sub.BackColor = Color.White;
                        sub.ForeColor = menuTextColor;
                        // also set image margin area
                        if (tmi.DropDown is ToolStripDropDownMenu ddm)
                        {
                            ddm.ShowImageMargin = true;
                        }
                    }
                }
            }

            // update panel background to match menu
            try { panelUserInfo.BackColor = menuStrip1.BackColor; } catch { }
            try
            {
                lblUsuLogueado.ForeColor = Color.FromArgb(34,34,34);
                lblPerfil.ForeColor = Color.Gray;
                lblUsuLogueado.BackColor = panelUserInfo.BackColor;
                lblPerfil.BackColor = panelUserInfo.BackColor;
            }
            catch { }
         }

        private void HabilitarMenus()
        {
            int idPerfil = UsuarioServicios.UsuarioLogueado.ObjPerfil.IdPerfil;
            List <Permiso> listaPermisos = permisoServicios.GetListaPermisos(idPerfil);
            foreach (var permiso in listaPermisos)
            {
                switch (permiso.NombreMenuHabilitado)
                {
                    case "Seguridad":
                        imiSeguridad.Enabled = true;
                        break;
                    case "Reportes":
                        imiReportes.Enabled = true;
                        break;
                    case "PlanificarVuelos":
                        imiVuelos.Enabled = true;
                        imiPlanificarVuelos.Enabled = true;
                        break;
                    case "EstadoVuelos":
                        imiVuelos.Enabled = true;
                        imiConsultarEstados.Enabled = true;
                        break;
                    case "Registros":
                        imiRegistros.Enabled = true;
                        break;
                    case "Reservas":
                        imiReservas.Enabled = true;
                        break;
                    default:
                        break;
                }
            }

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void imiReportes_Click(object sender, EventArgs e)
        {

        }

        private void imiVuelos_Click(object sender, EventArgs e)
        {

        }

        private void imiPlanificarVuelos_Click(object sender, EventArgs e)
        {
            FrmDefinicionVuelo ventana = new FrmDefinicionVuelo();
            ventana.ShowDialog();
        }

        private void imiConsultarEstados_Click(object sender, EventArgs e)
        {

        }

        private void imiPerfiles_Click(object sender, EventArgs e)
        {

        }

        private void imiSeguridad_Click(object sender, EventArgs e)
        {

        }

        private void imiRegistros_Click(object sender, EventArgs e)
        {

        }

        private void imiPaises_Click(object sender, EventArgs e)
        {
            FrmPais ventana = new FrmPais();
            ventana.ShowDialog();
        }

        private void imiCiudades_Click(object sender, EventArgs e)
        {
            FrmCiudad ventana = new FrmCiudad();
            ventana.ShowDialog();
        }

        private void imiProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincia ventana = new FrmProvincia();
            ventana.ShowDialog();
        }

        private void imiAeropuertos_Click(object sender, EventArgs e)
        {
            FrmAeropuertos ventana = new FrmAeropuertos();
            ventana.ShowDialog();
        }

        private void imiAviones_Click(object sender, EventArgs e)
        {
            FrmAvion ventana = new FrmAvion();
            ventana.ShowDialog();
        }

        private void imiEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados ventana = new FrmEmpleados();
            ventana.ShowDialog();
           
        }

        private void imiUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void imiReservas_Click(object sender, EventArgs e)
        {

        }

        private void imiRegistrarReserva_Click(object sender, EventArgs e)
        {
            GestorReserva gestorReserva = new GestorReserva();
            gestorReserva.SeleccionDeVuelo();
        }

        private void imiConsultarReserva_Click(object sender, EventArgs e)
        {

        }

        private void imiEstadisticaPasajes_Click(object sender, EventArgs e)
        {
            FrmDestinoPorClase ventana = new FrmDestinoPorClase();
            ventana.ShowDialog();

        }

        private void imiInformeVuelos_Click(object sender, EventArgs e)
        {
            FrmInformeVuelos ventana = new FrmInformeVuelos();
            ventana.ShowDialog();
        }

        private void imiInformeDetalladoVuelo_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            frmLogin.LimpiarCampos();
            this.Dispose();

        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            FrmUsuarios ventana = new FrmUsuarios();
            ventana.ShowDialog();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin.Close();
        }

        private void imiPasajeros_Click(object sender, EventArgs e)
        {
            FrmPasajeros ventana = new FrmPasajeros();
            ventana.ShowDialog();
        }

        private void iconMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmPerfiles ventana = new FrmPerfiles();
            ventana.ShowDialog();
        }

        private void panelUserInfo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = panelUserInfo.ClientRectangle;
            rect.Inflate(-2, -2);

            // Use the panel background (same as menu) for fill so it's not transparent
            Color bg = panelUserInfo.BackColor;
            Color border = isDarkTheme ? Color.FromArgb(220, 255, 255, 255) : Color.FromArgb(100, 0, 0, 0);

            int radius = 10;
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                using (var brush = new SolidBrush(bg))
                {
                    g.FillPath(brush, path);
                }
                using (var pen = new Pen(border, 1.2f))
                {
                    g.DrawPath(pen, path);
                }
            }

            // draw circular border around avatar for contrast
            try
            {
                var avatarRect = new Rectangle(picUserAvatar.Left - 1, picUserAvatar.Top - 1, picUserAvatar.Width + 2, picUserAvatar.Height + 2);
                using (var pen = new Pen(isDarkTheme ? Color.WhiteSmoke : Color.Gray, 2f))
                {
                    g.DrawEllipse(pen, avatarRect);
                }
            }
            catch { }
        }

        private void panelUserInfo_Click(object sender, EventArgs e)
        {
            // Optional: show profile menu or actions. Currently no action required.
        }

        private void AddUserInfoToMenu()
        {
            // Host the panel into a ToolStripControlHost so it is part of the menu strip and visible
            try
            {
                // Ensure panel background matches menu and labels contrast
                panelUserInfo.BackColor = menuStrip1.BackColor;
                lblUsuLogueado.BackColor = panelUserInfo.BackColor;
                lblPerfil.BackColor = panelUserInfo.BackColor;
                lblUsuLogueado.ForeColor = isDarkTheme ? Color.White : Color.FromArgb(34, 34, 34);
                lblPerfil.ForeColor = isDarkTheme ? Color.FromArgb(235, 235, 235) : Color.Gray;

                // Ensure panel size fits inside the menu strip height
                int hostHeight = Math.Max(menuStrip1.Height - 8, panelUserInfo.Height);
                panelUserInfo.Size = new Size(220, hostHeight);

                userInfoHost = new ToolStripControlHost(panelUserInfo)
                {
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    Alignment = ToolStripItemAlignment.Right,
                    AutoSize = false,
                    Size = new Size(panelUserInfo.Width, panelUserInfo.Height)
                };

                // Add as last item so it appears on the right side
                menuStrip1.Items.Add(userInfoHost);

                // Bring to front inside the toolstrip
                userInfoHost.Owner?.Invalidate();
            }
            catch { }
        }
    }
}
