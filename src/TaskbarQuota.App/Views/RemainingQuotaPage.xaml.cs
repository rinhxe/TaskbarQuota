using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TaskbarQuota.ViewModels;

namespace TaskbarQuota.Views
{
    public sealed partial class RemainingQuotaPage : Page
    {
        public DashboardViewModel ViewModel { get; }

        public RemainingQuotaPage()
        {
            ViewModel = DashboardPage.SharedViewModel ?? new DashboardViewModel(DispatcherQueue);
            InitializeComponent();
            Loaded += RemainingQuotaPage_Loaded;
        }

        private void RemainingQuotaPage_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= RemainingQuotaPage_Loaded;
            DispatcherQueue.TryEnqueue(
                Microsoft.UI.Dispatching.DispatcherQueuePriority.Low,
                () => _ = ViewModel.LoadAsync());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
