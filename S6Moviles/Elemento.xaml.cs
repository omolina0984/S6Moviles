using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
namespace S6Moviles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;

          
        public Elemento(int id, string Nombre, string Usuario, string Contrasena)
        {
            InitializeComponent();

            txtNombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtPass.Text = Contrasena;
            idSeleccionado= id;

        }
        
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {

            return db.Query<Estudiante>("Delete from Estudiante where Id=?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string user, string pass)
        {

            return db.Query<Estudiante>("Update Estudiante set Nombre=?, Usuario=?, Contrasena=? where Id=?", nombre, user,pass, id);
        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }
        }
    


        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db= new SQLiteConnection(ruta);
                rActualizar = Update(db, idSeleccionado, txtNombre.Text, txtUsuario.Text, txtPass.Text);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");

                
            }
        }
    
}
}