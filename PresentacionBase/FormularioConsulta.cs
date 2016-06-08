using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionBase
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected FormularioABM _formularioABM;
        protected object EntidadSeleccionada;

        #region Propiedades de los Botones

        public virtual Image ImagenBotonNuevo
        {
            set { this.btnNuevo.Image = value; }
        }

        public virtual Image ImagenBotonEliminar
        {
            set { this.btnEliminar.Image = value; }
        }

        public virtual Image ImagenBotonModificar
        {
            set { this.btnModificar.Image = value; }
        }

        public virtual Image ImagenBotonActualizar
        {
            set { this.btnActualizar.Image = value; }
        }

        public virtual Image ImagenBotonImprimir
        {
            set { this.btnImprimir.Image = value; }
        }

        public virtual Image ImagenBotonSalir
        {
            set { this.btnSalir.Image = value; }
        }

        public virtual Image ImagenBuscar
        {
            set { this.imgBuscar.Image = value; }
        }

        #endregion
        
        /// <summary>
        /// Constructor de Formulario por defecto
        /// </summary>
        public FormularioConsulta()
        {
            InitializeComponent();

            ImagenBotonNuevo = Imagenes.BotonNuevo;
            ImagenBotonEliminar = Imagenes.BotonBorrar;
            ImagenBotonModificar = Imagenes.BotonModificar;
            ImagenBotonActualizar = Imagenes.BotonActualizar;
            ImagenBotonImprimir = Imagenes.BotonImprimir;
            ImagenBotonSalir = Imagenes.BotonSalir;
            ImagenBuscar = Imagenes.BotonBuscar;

            this.txtBuscar.Enter += new EventHandler(Control_Enter);
            this.txtBuscar.Leave += new EventHandler(Control_Leave);
           
        }
        
        /// <summary>
        /// Constructor de Formulario Base de Consultas
        /// </summary>
        /// <param name="tituloGrilla">Titulo de la Grilla</param>
        public FormularioConsulta(string tituloGrilla)
            : this()
        {
            this.lblTitulo.Text = tituloGrilla;
        }

        /// <summary>
        /// Constructor de Formulario Base de Consultas
        /// </summary>
        /// <param name="tituloFormulario">Titulo del Formulario.  
        /// Nota: El formulario hijo NO debe tener asignado el título en la propiedad Text</param>
        /// <param name="tituloGrilla">Titulo de la Grilla</param>
        public FormularioConsulta(string tituloFormulario, string tituloGrilla)
            : this(tituloGrilla)
        {
            Text = tituloFormulario;
        }

        /// <summary>
        /// Constructor de Formulario Base de Consultas
        /// </summary>
        /// <param name="tituloFormulario">Titulo del Formulario.  
        /// Nota: El formulario hijo NO debe tener asignado el título en la propiedad Text</param>
        /// <param name="tituloGrilla">Titulo de la Grilla</param>
        /// <param name="formularioABM">Formulario para Insertar, Modificar o Eliminar un registro
        /// Nota: Los formularios debe heredar de FormularioABM</param>
        public FormularioConsulta(string tituloFormulario, string tituloGrilla, FormularioABM formularioABM)
            : this(tituloFormulario, tituloGrilla)
        {
            this._formularioABM = formularioABM;
        }

        public virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnNuevo_Click(object sender, EventArgs e)
        {
            this._formularioABM.EntidadId = (long?)null;
            this._formularioABM.TipoOperacion = TipoOperacion.Insertar;
            this._formularioABM.ShowDialog();

            if (this._formularioABM.RealizoAlgunaOperacion)
                Actualizar(string.Empty);
        }

        public virtual void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos(TipoOperacion.Modificar))
            {
                this._formularioABM.TipoOperacion = TipoOperacion.Modificar;
                this._formularioABM.ShowDialog();

                if (this._formularioABM.RealizoAlgunaOperacion)
                    Actualizar(string.Empty);
            }
        }

        public virtual void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos(TipoOperacion.Eliminar))
            {
                this._formularioABM.TipoOperacion = TipoOperacion.Eliminar;
                this._formularioABM.ShowDialog();

                if (this._formularioABM.RealizoAlgunaOperacion)
                    Actualizar(string.Empty);
            }
        }

        public virtual void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar(string.Empty);
        }

        public virtual void btnImprimirSelección_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos(TipoOperacion.Imprimir))
            {
                this._formularioABM.TipoOperacion = TipoOperacion.ImprimirSeleccion;
                this._formularioABM.ShowDialog();
            }
        }

        public virtual void btnImprmirListaCompleta_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos(TipoOperacion.Imprimir))
            {
                this._formularioABM.TipoOperacion = TipoOperacion.ImprimirTodo;
                this._formularioABM.ShowDialog();
            }
        }

        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                this._formularioABM.EntidadId = Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value);
            }
            else
            {
                this._formularioABM.EntidadId = (long?)null;
            }
        }

        public virtual void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                EntidadSeleccionada = this.dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadSeleccionada = null;
            }
        }

        public virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(this.txtBuscar.Text);
        }

        public virtual void FormularioConsulta_Load(object sender, EventArgs e)
        {
            Actualizar(string.Empty);
            FormatearGrilla(this.dgvGrilla);
        }

        /// <summary>
        /// Metodo para actualizar los datos de la Grilla
        /// </summary>
        /// <param name="text"></param>
        public virtual void Actualizar(string text)
        {
            
        }

        // ================================================================================================= //
        // =====================================  Metodos Privados  ======================================== //
        // ================================================================================================= //

        /// <summary>
        /// Metodo para verificar si hay datos en la grilla cargados            
        /// </summary>
        /// <param name="operacion">Tipo de Operacion a realizar</param>
        /// <returns>Retorna verdadero si existen datos, caso contrario falso.</returns>
        private bool VerificarSiExistenDatos(TipoOperacion operacion)
        {
            if (this.dgvGrilla.RowCount <= 0)
            {
                Mensaje.Mostrar(string.Format("No hay datos cargados para {0}", operacion), TipoMensaje.Aviso);
                return false;
            }

            return true;
        }

        public virtual void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            //int indice = -1;
            //if (this.dgvGrilla.RowCount > 0)
            //{
            //    EntidadSeleccionada = this.dgvGrilla.Rows[indice].DataBoundItem;
            //}
            //else
            //{
            //    EntidadSeleccionada = null;
            //}
            //this.Close();
        }
    }
}
