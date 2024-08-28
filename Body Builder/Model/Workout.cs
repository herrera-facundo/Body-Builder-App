using System.ComponentModel;

namespace Body_Builder.Model
{
    public partial class Workout : ObservableObject
    {
        public Workout()
        {
            this.title = "Default";
            this.ExerciseList = new List<Exercise>();
            this.Date = DateTime.Now.ToString();
            this.TimeElapsed = "";
            this.WeightLifted = 0;
            this.CaloriesBurned = 0;
            this.completedExCount = 0;
        }

        public Workout(string title)
        {
            this.title = title;
            this.ExerciseList = new List<Exercise>();
            this.Date = DateTime.Now.ToString();
            this.TimeElapsed = "";
            this.WeightLifted = 0;
            this.CaloriesBurned = 0;
            this.completedExCount = 0;
        }

        public Workout(string title, int num)
        {
            this.title = title;
            this.ExerciseList = new List<Exercise>(num);
            for (int i = 0; i < num; i++)
            {
                ExerciseList.Add(new Exercise());
            }
            this.Date = DateTime.Now.ToString();
            this.TimeElapsed = "";
            this.WeightLifted = 0;
            this.CaloriesBurned = 0;
            this.completedExCount = 0;
        }

        public Workout(Workout copy)
        {
            this.title = copy.title;
            this.ExerciseList = copy.ExerciseList.ConvertAll(x => new Exercise(x)); // creates a deep copy
            this.Date = copy.Date;
            this.TimeElapsed = copy.TimeElapsed;
            this.WeightLifted = copy.WeightLifted;
            this.CaloriesBurned = copy.CaloriesBurned;
            this.completedExCount = copy.CompletedExCount;
        }
        private string title;
        public string Title { get => title; set { this.title = value; } }

        [RelayCommand]
        async Task GoToWorkingOut()
        {
            Workout workoutCopy = new Workout(this);
            if (workoutCopy == null)
            {
                return;
            }
            await Shell.Current.GoToAsync(nameof(WorkingOutPage), true, new Dictionary<string, object>
            {
                {"CurrentWorkout", workoutCopy }
            });
        }


        public List<Exercise> ExerciseList { get; set; }


        public string TimeElapsed;

        public int WeightLifted;

        public double CaloriesBurned;

        private int completedExCount;
        public int CompletedExCount { get => completedExCount; set { if (value >= 0) { this.completedExCount = value; } } }
        public string Date { get; set; }


        public void AddExercise(string name, int sets, int reps, int weight)
        {
            ExerciseList.Add(new Exercise(name, sets, reps, weight));
        }

        public void AddExercise(Exercise newExercise)
        {
            ExerciseList.Add(newExercise);
        }
        public void RemoveExercise(Exercise toDelete)
        {
            ExerciseList.Remove(toDelete);
        }
        //void SetReps(int reps) { }
        //void SetSets(int sets) { }
        void ScheduleWorkout() { }
        private void CalculateCalories(Exercise[] exercises)
        {
            foreach (Exercise ex in ExerciseList)
            {
                if (ex.Completed)
                {
                    CaloriesBurned += ex.getCalories();
                }
            }

        }

        public bool isWorkoutComplete()
        {
            foreach (Exercise ex in ExerciseList)
            {
                if (!ex.Completed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
