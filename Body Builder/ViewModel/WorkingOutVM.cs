namespace Body_Builder.ViewModel
{
    [QueryProperty(nameof(CurrentWorkout), "CurrentWorkout")]
    public partial class WorkingOutVM : BaseVM
    {
        [ObservableProperty]
        Workout currentWorkout;
        public WorkingOutVM()
        {

            TimeElapsed = "0:00";
            isStarted = false;
            WorkoutStopWatch = new System.Diagnostics.Stopwatch();
            TimerThread = new Thread(new ThreadStart(UpdateTimer));
            TimerThreadStarted = false;
            CaloriesBurned = "0";

        }

        public System.Diagnostics.Stopwatch WorkoutStopWatch;

        Thread TimerThread;

        bool isStarted;

        bool TimerThreadStarted;

        [ObservableProperty]
        public string caloriesBurned;

        [ObservableProperty]
        public string timeElapsed;

        [RelayCommand]
        public void StartWorkout()
        {
            if (!isStarted)
            {
                isStarted = true; // this needs to be first
                StartTimerThread();
                ToggleTimer();
            }

        }

        [RelayCommand]
        public void EndWorkout()
        {
            if (isStarted)
            {
                ToggleTimer();
                isStarted = false;
            }

            // additional info will go here
        }



        [RelayCommand]
        public void ToggleTimer()
        {
            if (!WorkoutStopWatch.IsRunning && isStarted)
            {
                StartTimer();
            }
            else
            {
                PauseTimer();
            }
        }
        void StartTimer()
        {
            WorkoutStopWatch.Start();
        }
        void PauseTimer()
        {
            WorkoutStopWatch.Stop();
        }
        public void ResetTimer()
        {
            WorkoutStopWatch.Reset();
        }

        public void UpdateTimer()
        {
            while (isStarted)
            {
                // gets correct formatting
                if ((int)WorkoutStopWatch.Elapsed.TotalSeconds / 10 == 0)
                {
                    TimeElapsed = (int)WorkoutStopWatch.Elapsed.TotalMinutes + ":0" + (int)WorkoutStopWatch.Elapsed.TotalSeconds % 60;

                }
                else
                {
                    TimeElapsed = (int)WorkoutStopWatch.Elapsed.TotalMinutes + ":" + (int)WorkoutStopWatch.Elapsed.TotalSeconds % 60;
                }
                Thread.Sleep(100);
            }
        }

        private void StartTimerThread()
        {
            if (!TimerThreadStarted)
            {
                TimerThread.Start();
                TimerThreadStarted = true;
            }
        }

        [RelayCommand]
        async Task GoToSummary()
        {
            CurrentWorkout.CompletedExCount = CurrentWorkout.ExerciseList.Count; // should be based on the amount of checkboxes checked
            var navigationParameter = new ShellNavigationQueryParameters
            {
                    { "SummaryInfo", CurrentWorkout },
            };
            await Shell.Current.GoToAsync(nameof(SummaryPage), true, navigationParameter);
        }

        [RelayCommand]
        void CompletedClicked(Exercise exercise)
        {
            exercise.Completed = true;
            CheckToEndWorkout();
        }

        void CheckToEndWorkout()
        {
            int count = 0;
            foreach (Exercise ex in this.CurrentWorkout.ExerciseList)
            {
                if (ex.Completed) count++;
            }

            if(count == this.CurrentWorkout.ExerciseList.Count)
            {
                // prompt to end the workout
            }
        }


    }
}
