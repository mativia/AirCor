using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.InterfacesDeUsuario;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;
using tp_pav1_grupo10.InterfacesDeUsuario.TransaccionReservaVuelo;
using System.Security.Cryptography;
using System.Windows;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace tp_pav1_grupo10.Servicios
{
    public class GestorReserva
    {
        private AsientoRepositorio asientoRepositorio;
        private ReservaRepositorio reservaRepositorio;
        private FrmConsultarVuelos ventanaSeleccionVuelo;
        private FrmRegistrarReserva ventanaSeleccionPasajeros;
        private FrmSeleccionAsiento ventanaSeleccionAsiento;
        private FrmResumen ventanaResumenTransaccion;
        private List<Asiento> listaAsientosOcupados;
        private Avion asientosDelAvion;

        public DefinicionDeVuelo vueloSeleccionado { get; set; }
        public List<DetalleReserva> listaPasajeros { get; set; }
        public List<DetalleReserva> listaAsientos { get; set; }
        public List<DetalleReserva> listaDetalles { get; set; }

        public GestorReserva()
        {
            asientoRepositorio = new AsientoRepositorio();
            this.ventanaSeleccionVuelo = new FrmConsultarVuelos(this);
            this.reservaRepositorio = new ReservaRepositorio();
        }

        public void SeleccionDeVuelo()
        {
            this.ventanaSeleccionVuelo.Show();
        }

        public void SeleccionDePasajeros()
        {
            ventanaSeleccionPasajeros = new FrmRegistrarReserva(this);
            ventanaSeleccionPasajeros.Show();
        }

        public void SeleccionDeAsientos()
        {
            listaAsientosOcupados = asientoRepositorio.getListadoDeAsientosOcupados(vueloSeleccionado.ListaVuelos[0].IdVuelo);
            asientosDelAvion = asientoRepositorio.getAsientosTotalesDeAvion(vueloSeleccionado.NroVuelo);
            ventanaSeleccionAsiento = new FrmSeleccionAsiento(this, listaPasajeros, listaAsientosOcupados, asientosDelAvion);
            ventanaSeleccionAsiento.Show();
        }

        public void ResumenTransaccion()
        {
            CrearListaDetalles();
            ventanaResumenTransaccion = new FrmResumen(this, listaDetalles, vueloSeleccionado);
            ventanaResumenTransaccion.Show();
        }

        private void CrearListaDetalles()
        {
            // crear la lista de detalles a partir de la lista de pasajeros, la lista de asientos y los importes de cada detalle
            var lista = new List<DetalleReserva>();

            foreach (var detalle in listaPasajeros)
            {
                var nuevo = new DetalleReserva();
                nuevo.EsTitular = detalle.EsTitular;
                nuevo.ObjPasajero = detalle.ObjPasajero;
                foreach (var detalleAsiento in listaAsientos)
                {
                    if (detalle.ObjPasajero.ObjTipoDocumento.IdTipoDocumento == detalleAsiento.ObjPasajero.ObjTipoDocumento.IdTipoDocumento && detalle.ObjPasajero.NroDocumento == detalleAsiento.ObjPasajero.NroDocumento)
                    {
                        nuevo.ObjAsiento = new Asiento();
                        nuevo.ObjAsiento.Letra = detalleAsiento.ObjAsiento.Letra;
                        nuevo.ObjAsiento.Numero = detalleAsiento.ObjAsiento.Numero;
                        nuevo.ObjAsiento.TipoClase = new TipoClase()
                        {
                            IdTipoClase = detalleAsiento.ObjAsiento.TipoClase.IdTipoClase,
                            Nombre = detalleAsiento.ObjAsiento.TipoClase.Nombre
                        };

                    }
                }
                if (nuevo.ObjAsiento.TipoClase.IdTipoClase == 1)
                {
                    // clase turista
                    foreach (var t in vueloSeleccionado.ListaTarifas)
                    {
                        if (t.ObjTipoClase.IdTipoClase == 1)
                        {
                            nuevo.Importe = t.Importe;
                        }
                    }
                }
                if (nuevo.ObjAsiento.TipoClase.IdTipoClase == 2)
                {
                    // clase business
                    foreach (var t in vueloSeleccionado.ListaTarifas)
                    {
                        if (t.ObjTipoClase.IdTipoClase == 2)
                        {
                            nuevo.Importe = t.Importe;
                        }
                    }
                }
                if (nuevo.ObjAsiento.TipoClase.IdTipoClase == 3)
                {
                    // primera clase
                    foreach (var t in vueloSeleccionado.ListaTarifas)
                    {
                        if (t.ObjTipoClase.IdTipoClase == 3)
                        {
                            nuevo.Importe = t.Importe;
                        }
                    }
                }
                lista.Add(nuevo);
            }

            listaDetalles = lista;
        }

        public void InsertReserva()
        {
            try
            {
                var reserva = new Reserva();
                reserva.ListaDetalles = listaDetalles;
                reservaRepositorio.InsertReserva(reserva, vueloSeleccionado.ListaVuelos[0].IdVuelo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void CerrarVentanas()
        {
            ventanaSeleccionPasajeros.Dispose();
            ventanaSeleccionVuelo.Dispose();
            ventanaSeleccionAsiento.Dispose();
            ventanaResumenTransaccion.Dispose();
            EnviarEmail();
        }

        public void CancelarTransaccion()
        {
            if (this.ventanaSeleccionVuelo != null)
            {
                this.ventanaSeleccionVuelo.Dispose();
            }
            if (this.ventanaSeleccionPasajeros != null)
            {
                this.ventanaSeleccionPasajeros.Dispose();
            }
            if(this.ventanaSeleccionAsiento != null)
            {
                this.ventanaSeleccionAsiento.Dispose();
            }
            if (this.ventanaResumenTransaccion != null)
            {
                this.ventanaResumenTransaccion.Dispose();
            }
        }

        private void EnviarEmail()
        {
            var email = "";
            var nombreCompleto = "";
            foreach (var d in listaDetalles)
            {
                if (d.EsTitular)
                {
                    email = d.ObjPasajero.Email;
                    nombreCompleto = d.ObjPasajero.Nombre + " " + d.ObjPasajero.Apellido;
                }
            }

            // Crear cuepo del mensaje
            BodyBuilder cuerpoMensaje = new BodyBuilder();
            string c = CorreoServicio.GetInicioCorreo();

            c += $"<table class=\"table text-center\"> <tr> <td class=\" font-weight-bold\"> <p>Nro de Vuelo</p> </td> <td> <p>{vueloSeleccionado.NroVuelo}</p> </p></td> </tr> <tr> <td class=\" font-weight-bold\"><p>Ciudad Origen</p> </td> <td ><p>{vueloSeleccionado.ObjAeropuertoOrigen.ObjCiudad.Nombre}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Ciudad Destino</p> </td> <td><p>{vueloSeleccionado.ObjAeropuertoDestino.ObjCiudad.Nombre}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Aeropuerto de Origen</p> </td> <td><p>{vueloSeleccionado.ObjAeropuertoOrigen.CodigoAeropuerto}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Aeropuerto de Destino</p> </td> <td><p>{vueloSeleccionado.ObjAeropuertoDestino.CodigoAeropuerto}</p> </td> </tr> <tr> <td class=\"font-weight-bold\"><p>Fecha</p> </td> <td><p>{vueloSeleccionado.ListaVuelos[0].FechaPartida.ToString("dd/MM/yyyy")}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Horario de Embarque</p> </td> <td><p>{vueloSeleccionado.HorarioEmbarque}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Horario de Partida</p> </td> <td><p>{vueloSeleccionado.HorarioPartida}</p> </td> </tr> <tr> <td class=\" font-weight-bold\"><p>Horario de Llegada</p> </td> <td><p>{vueloSeleccionado.HorarioLlegada}</p> </td> </tr> </table> ";
            c += "<table class=\"table text-center\"> <tr class=\"table-secondary font-weight-bold\"> <td> <p>Nombre</p> </td> <td> <p>Apellido</p> </p></td> <td> <p>Asiento</p> </td> <td> <p>Tipo de Clase</p></td> <td> <p>Importe</p></td> </tr>";
            foreach (var d in listaDetalles)
            {
                c += $"<tr> <td> <p>{d.ObjPasajero.Nombre}</p> </td> <td> <p>{d.ObjPasajero.Apellido} </p></td> <td> <p>{d.ObjAsiento.Numero}{d.ObjAsiento.Letra}</p> </td> <td> <p>{d.ObjAsiento.TipoClase.Nombre}</p></td> <td> <p>{d.Importe}</p></td> </tr>";
            }
            // final del html
            c += CorreoServicio.GetFinalCorreo();
            cuerpoMensaje.HtmlBody = c;


            // delcaramos servidor, puerto y la cuenta a utilizar para enviar los correos
            //string servidor = "smtp.gmail.com";
            //int puerto = 587;
            string gmailUser = "softwaretesttom@gmail.com";
            string gmailPass = "ytplhdpmkjgonovo";

            // servidor local
            string servidor = "localhost";
            int puerto = 25;

            // creamos el mensaje
            MimeMessage mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("Aerolinea AIRCOR", gmailUser)); // emisor
            mensaje.To.Add(new MailboxAddress(nombreCompleto, email)); // receptor
            mensaje.Subject = "AIRCOR - Confirmacion de Reserva";
            mensaje.Body = cuerpoMensaje.ToMessageBody();

            // enviamos el correo
            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.CheckCertificateRevocation = false;
            //clienteSmtp.Connect(servidor, puerto, MailKit.Security.SecureSocketOptions.StartTls);
            clienteSmtp.Connect(servidor, puerto);

            //clienteSmtp.Authenticate(gmailUser, gmailPass);
            clienteSmtp.Send(mensaje);
            clienteSmtp.Disconnect(true);
        }

    }
}
