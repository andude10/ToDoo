using ToDoo.Models;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;

namespace ToDoo.Views
{
    public partial class MyTodo : ContentPage
    {
        public MyTodo()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listcases = await App.Database.GetCasesAsync();
            collectionView.ItemsSource = new ObservableCollection<Case>(listcases);
        }
        private async void AddCase(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CaseEntryPage));
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Case _case = (Case)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CaseEntryPage)}?{nameof(CaseEntryPage.ItemId)}={_case.ID.ToString()}");
            }
        }
    }
}