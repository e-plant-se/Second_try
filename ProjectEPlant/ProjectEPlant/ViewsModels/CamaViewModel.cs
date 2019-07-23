using ProjectEPlant.Services;
using ProjectEPlant.ViewsModels.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ProjectEPlant.Models.Cama;

namespace ProjectEPlant.ViewsModels
{
    public class CamaViewModel : BaseViewModel
    {

        public Command GetListCamasCommand { get; set; }

        public ObservableCollection<Item> CamaList { get; set; }

        public CamaViewModel(INavigation navigation) : base(navigation)
        {
            WebApi = new FirebaseConnection();
            GetListCamasCommand = new Command(async () => await GetListCamasAsync());
        }

        public async Task PostCamaAsync(string huerto, string idCama, string tipo, string estructura, string planta, string fechaCultivo)
        {
            var model = new Item()
            {
                Huerto = huerto,
                IdCama = idCama,
                Tipo = tipo,
                Estructura = estructura,
                Planta1 = planta,
                FechaCultio = fechaCultivo
            };
            await WebApi.PostRegisterCama(model);
        }

        public async Task GetListCamasAsync()
        {
            var response = await WebApi.GetCamasAsync();
            var camasList = response;
            if (camasList == null)
            {
                return;
            }
            CamaList = new ObservableCollection<Item>(camasList);
            OnPropertyChanged(nameof(CamaList));
        }
    }
}