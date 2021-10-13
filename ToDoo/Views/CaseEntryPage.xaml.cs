using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoo.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CaseEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public CaseEntryPage()
        {
            InitializeComponent();

            BindingContext = new Case();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                Case _case = await App.Database.GetCaseAsync(id);
                BindingContext = _case;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void SaveNote(object sender, EventArgs e)
        {
            var _case = (Case)BindingContext;
            _case.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(_case.Title))
            {
                await App.Database.SaveCaseAsync(_case);
            }
            await Shell.Current.GoToAsync("..");
        }

        async void DeleteNote(object sender, EventArgs e)
        {
            var _case = (Case)BindingContext;
            await App.Database.DeleteCaseAsync(_case);

            await Shell.Current.GoToAsync("..");
        }
    }
}