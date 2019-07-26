using ProjectEPlant.Models;
using ProjectEPlant.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetail : MasterDetailPage
    {

        public MainMasterDetail()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs item)
        {
            var myItem = item.SelectedItem as MasterItems;
            if(myItem != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(myItem.tipeClass));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}