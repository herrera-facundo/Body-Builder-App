using System.Text.Json;
using System.IO;
using CommunityToolkit.Mvvm.Messaging;

namespace Body_Builder.ViewModel
{
    [QueryProperty(nameof(Template), "Template")]
    //[QueryProperty(nameof(Title), "title")]
    public partial class MakeWorkoutVM : BaseVM
    {
        /*[ObservableProperty]
        Workout workout;
        [ObservableProperty]
        Workout title;*/

        /*[ObservableProperty]
        Dictionary<string, Object> dict;*/
        [ObservableProperty]
        Workout template;

        // constructor
        public MakeWorkoutVM()
        {
        }

        // maybe change name?
        [RelayCommand]
        async Task GoToWorkout()
        {
            // Reads existing workouts and adds the recently created one, then saves
            string path = FileSystem.AppDataDirectory + "\\workouts";
            var rawData = File.ReadAllText(path);
            List<Workout> workouts = JsonSerializer.Deserialize<List<Workout>>(rawData);
            workouts.Add(Template);
            var serializedData = JsonSerializer.Serialize(workouts);
            File.WriteAllText(path, serializedData);

            // use this to pass info to summary page
            var navigationParameter = new ShellNavigationQueryParameters // single use (gets cleared after
                {
                    { "NewWorkout", Template },
                };

            // pass workout to manager to add it to the list
            await Shell.Current.GoToAsync("..", true, navigationParameter);
        }
    }
}
