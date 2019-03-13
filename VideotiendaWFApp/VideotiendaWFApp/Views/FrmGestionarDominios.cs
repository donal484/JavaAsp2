using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideotiendaWFApp.Models;

namespace VideotiendaWFApp.Views
{
    public partial class FrmGestionarDominios : Form
    {

        dominios oDominio = null;
        private string tipoDominio;
        private string idDominio;

        public FrmGestionarDominios(string tipoDominio, string idDominio)
        {
            InitializeComponent(); //Dibuja el formulario
            //Recibir los datos llave primaria, si son nul
            this.tipoDominio = tipoDominio;
            this.idDominio = idDominio;

            if (!string.IsNullOrEmpty(this.idDominio) && !string.IsNullOrEmpty(this.tipoDominio))
            {
                cargarDatos();
                //Si es modo edidicion bloqueo los text box de la PK
                this.txtId.ReadOnly = true;
                this.txtTipo.ReadOnly = true;
            }
            else {
                this.txtId.ReadOnly = false;
                this.txtTipo.ReadOnly = false;
            }
        }

        private void cargarDatos()
        {
            using (videotiendaEntities db = new videotiendaEntities())
            {
                oDominio = db.dominios.Find(tipoDominio, idDominio);
                txtTipo.Text = oDominio.TIPO_DOMINIO;
                txtId.Text = oDominio.ID_DOMINIO;
                txtValor.Text = oDominio.VLR_DOMINIO;
            }
        }

        private void FrmGestionarDominios_Load(object sender, EventArgs e)
        {
            this.txtTipo.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtTipo.Text) || string.IsNullOrEmpty(this.txtId.Text)  || string.IsNullOrEmpty(this.txtValor.Text))
            {
                MessageBox.Show("Los Campos marcados con asterisco (*) son obligatorios");
            }
            else
            {
                //El using permite establecer conexion con la base de datos a tra ves de EF
                using (videotiendaEntities db = new videotiendaEntities())
                {
                    //Si estamos en modo insercion inicializamos el objeto Odominios
                    if (this.tipoDominio == null && this.idDominio==null) {
                        oDominio = new dominios();
                    }
                    
                    oDominio.TIPO_DOMINIO = this.txtTipo.Text;
                    oDominio.ID_DOMINIO = this.txtId.Text;
                    oDominio.VLR_DOMINIO = this.txtValor.Text;
                    //En modo insercion, adicionamos un nuevo registro
                    if (this.tipoDominio == null && this.idDominio == null)
                    {
                        db.dominios.Add(oDominio);
                    }
                    else {
                        //En modo edicion, cambiamos el estado del objeto a modificaci{on
                        db.Entry(oDominio).State = System.Data.Entity.EntityState.Modified;
                       
                    }

                    db.SaveChanges();
                    
                    this.Close();

                }
            }
        }
    }
}
