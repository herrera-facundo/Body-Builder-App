using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Body_Builder.ViewModel
{
    public partial class WorkoutVM : BaseVM, IQueryAttributable
    {
        public WorkoutVM()
        {
            Title = "Workout";
            //exName = "default 1";
            manager = new WorkoutManager();

            // automatic loading of saved workouts
            string path = FileSystem.AppDataDirectory + "\\workouts";
            // add default in case there's no workout list
            if (!File.Exists(path))
            {
                Workout pushWorkout = new Workout("Push");
                pushWorkout.AddExercise("Bench Press", 3, 10, 135);
                pushWorkout.AddExercise("Tricep Pulldown", 3, 8, 315);
                pushWorkout.AddExercise("Shoulder Press", 3, 12, 30);
                Workout pullWorkout = new Workout("Pull");
                pullWorkout.AddExercise("Row", 3, 10, 135);
                pullWorkout.AddExercise("Pull Ups", 3, 8, 315);
                pullWorkout.AddExercise("Bicep Curls", 3, 12, 30);
                Workout legsWorkout = new Workout("Legs");
                legsWorkout.AddExercise("Hip Thrusts", 3, 10, 135);
                legsWorkout.AddExercise("Back Squat", 3, 8, 315);
                legsWorkout.AddExercise("Calf Raises", 3, 12, 30);
                Workout coreWorkout = new Workout("Core");
                coreWorkout.AddExercise("Sit Ups", 3, 10, 135);
                coreWorkout.AddExercise("Russian Twist", 3, 8, 315);
                coreWorkout.AddExercise("Leg Raises", 3, 12, 30);

                Manager.WorkoutList.Add(pushWorkout);
                Manager.WorkoutList.Add(pullWorkout);
                Manager.WorkoutList.Add(legsWorkout);
                Manager.WorkoutList.Add(coreWorkout);

                var serializedData = JsonSerializer.Serialize(Manager.WorkoutList);
                File.WriteAllText(path, serializedData);
            }
            else
            {
                loadWorkouts();
            }
        }




        // HITTING CANCEL CRASHES APP !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        [RelayCommand]
        async Task GoToMakeWorkout()
        {
            string title = await App.Current.MainPage.DisplayPromptAsync("Name Workout", "Enter the name of the workout");
            string result = await App.Current.MainPage.DisplayPromptAsync("Add Exercises", "How many exercises would you like to add?", initialValue: "8", maxLength: 2, keyboard: Keyboard.Numeric);
            numExercises = int.Parse(result);

            if (numExercises == 0)
            {
                return;
            }

            Workout temp = new Workout(title, numExercises);

            await Shell.Current.GoToAsync(nameof(MakeWorkoutPage), true, new Dictionary<string, object>
            {
                {"Template", temp}
            });
        }

        [ObservableProperty]
        public WorkoutManager manager;

        int numExercises;

        public void loadWorkouts()
        {
            var rawData = File.ReadAllText(FileSystem.AppDataDirectory + "\\workouts");
            Manager.WorkoutList = JsonSerializer.Deserialize<ObservableCollection<Workout>>(rawData);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                Workout newW = query["NewWorkout"] as Workout;
                Manager.WorkoutList.Add(newW);
                OnPropertyChanged("Manager.WorkoutList");
            }
        }

        [RelayCommand]
        void DeleteWorkout(Workout del)
        {
            Manager.WorkoutList.Remove(del); // assumes del is in WorkoutList
        }
    }
}
