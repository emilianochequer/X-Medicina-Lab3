using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionBase
{
    public static class InicializadorDiccionarioABM
    {
        public static void Cargar(ref Dictionary<TipoOperacion, string> diccionario)
        {
            diccionario.Add(TipoOperacion.CargarDatos, "CargarDatos");
            // Operaciones ABM
            diccionario.Add(TipoOperacion.Insertar, "InsertarRegistro");
            diccionario.Add(TipoOperacion.Eliminar, "ElimnarRegistro");
            diccionario.Add(TipoOperacion.Modificar, "ModificarRegistro");
            diccionario.Add(TipoOperacion.ImprimirTodo, "ImprimirTodo");
            diccionario.Add(TipoOperacion.ImprimirSeleccion, "ImprimirSeleccion");
        }
    }
}
