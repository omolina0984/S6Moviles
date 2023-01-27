using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
namespace S6Moviles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();

            con=DependencyService.Get<DataBase>().GetConnection();

        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string login, string pass)
        {
            return db.Query<Estudiante>("Select * from Estudiante where Usuario=? and Contrasena=?", login,pass);

        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                
                db.CreateTable<Estudiante>();
                var resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);

                db.Close();

                if(resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());


                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o Contrasenia incorrecta", "Cerrar");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message,"Cerrar");
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
          await   Navigation.PushAsync(new Registro());
        }
    }
}