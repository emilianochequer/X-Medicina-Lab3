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
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();

            this.BackColor = Colores.ColorFondoFormulario;
        }

        public FormularioBase(Color colorFondoForm)             
        {
            this.BackColor = colorFondoForm;
        }

        public virtual bool VerificarSiHayDatosCargadosEnControles(FormularioABM form)
        {
            foreach (var ctrol in form.Controls)
            {
                if (VerificarControles(ctrol))
                {
                    return true;
                };
            }

            return false;
        }

        public virtual bool VerificarControles(object ctrol)
        {
            if (ctrol is TextBox)
            {
                return !string.IsNullOrEmpty(((TextBox)ctrol).Text);
            }

            if (ctrol is CheckBox)
            {
                if (((CheckBox)ctrol).Checked)
                {
                    return true;
                }
            }

            if (ctrol is Panel)
            {
                VerificarControles(((Panel)ctrol));
            }

            return false;
        }

        public virtual void LimpiarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Clear();
            }

            if (obj is ComboBox)
            {
                ((ComboBox)obj).SelectedIndex = 0;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Checked = false;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Value = DateTime.Now;
            }
        }

        public virtual void LimpiarControles(object obj, bool valorPorDefectoCheckBox)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Clear();
            }

            if (obj is ComboBox)
            {
                ((ComboBox)obj).SelectedIndex = 0;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Checked = valorPorDefectoCheckBox;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Value = DateTime.Now;
            }

            if (obj is NumericUpDown)
            {
                ((NumericUpDown)obj).Value = ((NumericUpDown)obj).Minimum;
            }
        }

        public virtual bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            if (controlesParaVerificar != null)
            {
                foreach (var ctrol in controlesParaVerificar)
                {
                    if (ctrol is TextBox)
                    {
                        if (VerificarSiTieneDatosCtrol(((TextBox)ctrol)))
                            return false;
                    }

                    if (ctrol is NumericUpDown)
                    {
                        if (VerificarSiTieneDatosCtrol(((NumericUpDown)ctrol)))
                            return false;
                    }

                    if (ctrol is ComboBox)
                    {
                        if (VerificarSiTieneDatosCtrol(((ComboBox)ctrol)))
                            return false;
                    }
                }
            }

            return true;
        }        

        public virtual bool VerificarSiTieneDatosCtrol(TextBox txt)
        {
            return string.IsNullOrEmpty(txt.Text) && string.IsNullOrWhiteSpace(txt.Text);
        }

        public virtual bool VerificarSiTieneDatosCtrol(NumericUpDown nud)
        {
            return string.IsNullOrEmpty(nud.Text) && string.IsNullOrWhiteSpace(nud.Text);
        }

        public virtual bool VerificarSiTieneDatosCtrol(ComboBox cmb)
        {
            return !string.IsNullOrEmpty(cmb.Text) && !string.IsNullOrWhiteSpace(cmb.Text) && cmb.Items.Count > 0;
        }

        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            }
        }

        public virtual void PoblarComboBox(ComboBox cmb, object lista, string PropiedadMostrar, string propiedadDevolver = "Id")
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = PropiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }


        public virtual void DesactivarControles(object obj, bool estado)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    DesactivarControles(ctrol, estado);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    DesactivarControles(ctrol, estado);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Enabled = estado;
            }

            if (obj is ComboBox)
            {
                ((ComboBox)obj).Enabled = estado;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Enabled = estado;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Enabled = estado;
            }

            if (obj is NumericUpDown)
            {
                ((NumericUpDown)obj).Enabled = estado;
            }

            if (obj is RadioButton)
            {
                ((RadioButton)obj).Enabled = estado;
            }
        }

        public virtual void Control_Enter(object sender, EventArgs e)
        {
            CambiarColorControl(sender, Colores.ColorControlConFoco);
        }

        public virtual void Control_Leave(object sender, EventArgs e)
        {
            CambiarColorControl(sender, Colores.ColorControlSinFoco);
        }

        public virtual void CambiarColorControl(object sender, Color colorControl)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = colorControl;
            }

            if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = colorControl;
            }
        }
    }
}
