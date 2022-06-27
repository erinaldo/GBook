using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inyecciones de dependencias
            BLL.Usuario usuarioService = new BLL.Usuario();
            BLL.Autor autorService = new BLL.Autor();
            BLL.Editorial editorialService = new BLL.Editorial();
            BLL.Genero generoService = new BLL.Genero();
            BLL.Producto productoService = new BLL.Producto();
            BLL.Libro libroService = new BLL.Libro();
            BLL.Compra compraService = new BLL.Compra();
            BLL.Venta ventaService = new BLL.Venta();
            BLL.Observer.Idioma traductorService = new BLL.Observer.Idioma();
            BLL.Composite.Permiso permisoService = new BLL.Composite.Permiso();

            Application.Run(new Login(usuarioService, autorService, editorialService, generoService, productoService, libroService, compraService, ventaService, traductorService, permisoService));
        }
    }
}
