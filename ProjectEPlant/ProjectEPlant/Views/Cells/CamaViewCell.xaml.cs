using ProjectEPlant.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CamaViewCell : ViewCell
    {
        public CamaViewCell()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            var item = BindingContext as Item;
            if (item == null)
            {
                return;
            }
            //image.Source = item.imageUrl;

            idCama.Text = item.IdCama.ToString();
            tipo.Text = item.Tipo;
            estructura.Text = item.Estructura;
            planta.Text = item.Planta1;
            fechaCultivo.Text = item.FechaCultio;

            base.OnBindingContextChanged();
        }
    }
}