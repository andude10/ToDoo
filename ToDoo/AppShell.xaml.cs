using ToDoo.Views;
using Xamarin.Forms;

namespace ToDoo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CaseEntryPage), typeof(CaseEntryPage));
        }
    }
}
