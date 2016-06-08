using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionBase
{
    public partial class FormularioABM : FormularioBase
    {
        private Dictionary<TipoOperacion, string> diccionarioEjecucion;

        public bool RealizoAlgunaOperacion;
        
        protected TipoOperacion _operacion;
        public TipoOperacion TipoOperacion { set { this._operacion = value; } }

        protected long? _entidadId;
        public long? EntidadId { set { this._entidadId = value; } }

        public virtual Image ImagenBotonEjecutar
        {
            set { this.btnEjecutar.Image = value; }
        }

        public virtual Image ImagenBotonLimpiar
        {
            set { this.btnLimpiar.Image = value; }
        }

        public virtual Image ImagenBotonSalir
        {
            set { this.btnSalir.Image = value; }
        }

        /// <summary>
        /// Constructor del Formulario por defecto
        /// </summary>
        public FormularioABM()
        {
            InitializeComponent();
            
            diccionarioEjecucion = new Dictionary<TipoOperacion, string>();
            InicializadorDiccionarioABM.Cargar(ref diccionarioEjecucion);

            RealizoAlgunaOperacion = false;

            ImagenBotonEjecutar = Imagenes.BotonEjecutar;
            ImagenBotonSalir = Imagenes.BotonSalir;
            ImagenBotonLimpiar = Imagenes.BotonLimpiar;
        }

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        /// <param name="tituloFormulario">Titulo del Formulario.  
        /// Nota: El formulario hijo NO debe tener asignado el título en la propiedad Text</param>
        public FormularioABM(string tituloFormulario)
            :this()
        {
            this.Text = tituloFormulario;
        }

        protected void AgregarOpcionDiccionario(TipoOperacion operacion, string nombreMetodo)
        {
            this.diccionarioEjecucion.Add(operacion, nombreMetodo);
        }

        private void FormularioABM_Load(object sender, EventArgs e)
        {
            CargarDatos();                       
        }

        private void EjecutarOperacion()
        {
            var nombreMetodo = diccionarioEjecucion.First(x => x.Key == this._operacion).Value;
            MethodInfo metodoEjecutar = this.GetType().GetMethod(nombreMetodo);
            metodoEjecutar.Invoke(this, null);
        }

        public virtual void CargarDatos()
        {
            DesactivarControles(this, true);
            LimpiarControles(this);
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosObligatorios(null))
            {
                if (!VerificarSiExisteRegistro())
                {
                    try
                    {
                        EjecutarOperacion();
                    }
                    catch (Exception ex)
                    {
                        RealizoAlgunaOperacion = false;
                        Mensaje.Mostrar(ex);
                    }
                }
                else
                {
                    Mensaje.Mostrar("Los datos cargados ya existen", TipoMensaje.Aviso);
                    this.Controls[0].Focus();
                }               
            }
            else
            {
                Mensaje.Mostrar("Los datos marcados con [*] son Obligatorios", TipoMensaje.Aviso);
                this.Controls[0].Focus();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (this._operacion != TipoOperacion.Eliminar)
            {
                if (VerificarSiHayDatosCargadosEnControles(this))
                    if (Mensaje.Mostrar(@"Hay datos cargados,  esta seguro que desea limpiar?", TipoMensaje.Pregunta)
                        == DialogResult.OK)
                    {
                        LimpiarControles(this);
                    }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioABM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!RealizoAlgunaOperacion)
            {
                if (this._operacion != TipoOperacion.Eliminar)
                {
                    if (VerificarSiHayDatosCargadosEnControles(this))
                    {
                        var mensaje = string.Empty;

                        if (!string.IsNullOrEmpty(this.Name))
                            mensaje += string.Format("Existen datos sin guardar. Desea salir de {0} ?", this.Text);
                        else
                            mensaje += "Existen datos sin guardar. Desea salir de la Pantalla?";

                        if (Mensaje.Mostrar(mensaje, TipoMensaje.Pregunta) == DialogResult.OK)
                        {
                            e.Cancel = false;
                        }
                    }
                }
            }
        }

        // ================================================================================================ //
        // =============== Metodos publicos para sobre escribribir en cada formulario de abm ============== //
        // ================================================================================================ //

        public virtual void InsertarRegistro()
        {
        }

        public virtual void ElimnarRegistro()
        {            
        }

        public virtual void ModificarRegistro()
        {
        }

        public virtual bool VerificarSiExisteRegistro()
        {
            return false;
        }        
    }
}

