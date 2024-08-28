using System.Collections.ObjectModel;

namespace Body_Builder.Model
{
    public partial class WorkoutManager : ObservableObject
    {

        public WorkoutManager()
        {
            WorkoutList = new ObservableCollection<Workout>();
            workoutList = WorkoutList;
        }


        // changed from List to ObservableCollection so that Workout View can reflect changes to the WorkoutList in real time
        [ObservableProperty]
        public ObservableCollection<Workout> workoutList;
    }
}
