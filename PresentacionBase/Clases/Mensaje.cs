using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionBase
{
    public static class Mensaje
    {
        public static DialogResult Mostrar(string mensajeMostrar, TipoMensaje tipoMensaje)
        {
            switch (tipoMensaje)
            {
                case TipoMensaje.Aviso:
                    return MessageBox.Show(mensajeMostrar, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                case TipoMensaje.Error:
                    return MessageBox.Show(mensajeMostrar, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                case TipoMensaje.Pregunta:
                    return MessageBox.Show(mensajeMostrar, "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            return DialogResult.OK;
        }

        public static void Mostrar(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
