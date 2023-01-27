using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S6Moviles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con=DependencyService.Get<DataBase>().GetConnection();
            Listar();
        }

        public async void Listar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiante.ItemsSource = tEstudiante;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj= (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id= Convert.ToInt32(item);
            var Nombre=obj.Nombre.ToString();
            var Usuario=obj.Usuario.ToString();
            var Contrasena=obj.Contrasena.ToString();
            Navigation.PushAsync(new Elemento(Id, Nombre, Usuario, Contrasena));
        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {


        }
    }
}