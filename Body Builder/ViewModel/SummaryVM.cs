
namespace Body_Builder.ViewModel
{
    public partial class SummaryVM : BaseVM, IQueryAttributable
    {
        public SummaryVM()
        {
            Title = "Summary";
            ThisWorkout = new Workout();
            TotalXP = 0;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ThisWorkout = query["SummaryInfo"] as Workout;
            Calories = ThisWorkout.CaloriesBurned;
            TotalXP = ThisWorkout.CompletedExCount * 15;
        }

        [RelayCommand]
        async Task GoToWorkout()
        {
            await Shell.Current.GoToAsync("../..", true);
        }

        [ObservableProperty]
        Workout thisWorkout;

        [ObservableProperty]
        int totalXP;

        [ObservableProperty]
        double calories;
    }
}
