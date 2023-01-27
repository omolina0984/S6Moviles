using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
namespace S6Moviles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtName.Text, Usuario = txtUser.Text, Contrasena = txtPass.Text };
            con.InsertAsync(datos);
            txtName.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            Navigation.PushAsync(new Login());
        }
    }
}