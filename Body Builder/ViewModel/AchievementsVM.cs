//using Body_Builder.Services; for the future


using Body_Builder.ViewModel;

namespace Body_Builder.ViewModel // this makes it so that others can see the section below when using xmlns:Body_Builder.ViewModel
{
    public partial class AchievementsVM : BaseVM
    {
        /*public ObservableCollection<Monkey> Monkeys { get; } = new();
        Body_BuilderService Body_BuilderService;
        IConnectivity connectivity;
        IGeolocation geolocation;*/
        //Body_BuilderService Body_BuilderService, IConnectivity connectivity, IGeolocation geolocation
        public AchievementsVM()
        {
            Title = "Achievements";
            /*this.monkeyService = monkeyService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;*/
        }

        /*[RelayCommand]
        async Task GoToDetails(Monkey monkey)
        {
            if (monkey == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Monkey", monkey }
            });
        }*/
    }
}