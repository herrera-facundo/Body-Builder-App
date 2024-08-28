namespace Body_Builder.Model
{
    /// <summary>
    /// In .Net Maui, I've learned that the vast majority of the time,
    /// wether you are using a database, file, or any other type of data
    /// source, you will always abstract that into a data repository of
    /// that class, and then affect the data from there. IMPORTANT: This
    /// is a static class, so to call the functions, you will need to call
    /// ExerciseRepository.<method>();
    public static class ExerciseRepository
    {
        public static List<Exercise> _exercises = new List<Exercise>()
        {
            new Exercise { exerciseId = 1, Name = "Bench Press", Sets = 3, Reps = 12, Weight = 100 },
            new Exercise { exerciseId = 2, Name = "Leg Press", Sets = 3, Reps = 12, Weight = 100 },
            new Exercise { exerciseId = 3, Name = "Arm Curl Machine", Sets = 3, Reps = 12, Weight = 100 }
        };


        public static List<Exercise> GetExercises() => _exercises;


        /// <summary>
        /// This Method will open ExerciseData.txt, read each line, process that line as an Exercise, and add it to _exercises list
        /// </summary>
        public static void getExercisesFromAppData()
        {
            var path = FileSystem.AppDataDirectory;
            var fullPath = System.IO.Path.Combine(path, "ExerciseData.txt");

            StreamReader instream = new StreamReader(fullPath);
            string line;
            string[] data;

            while ((line = instream.ReadLine()) != null)
            {
                data = line.Split(',');
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write(data[i]);
                    if (data[i] == string.Empty)
                    {
                        Console.Write("null");
                    }
                }
                Console.Write("\n");
            }
        }

        /// <summary>
        /// This method will wipe the contents of ExerciseData.txt in the local App Data
        /// and then write the contents of each element in _exercises on their own line.
        /// 
        /// Each Line of an exercise will be formated as:
        /// Name,Sets,Reps,Weight
        /// </summary>
        public static void storeExercisesInAppData()
        {
            var path = FileSystem.AppDataDirectory;
            var fullPath = System.IO.Path.Combine(path, "ExerciseData.txt");

            File.WriteAllText(fullPath, string.Empty); //Clears the current content in ExerciseData.txt

            foreach (var exercise in _exercises)
            {
                File.AppendAllText(fullPath, $"{exercise.Name},{exercise.Sets},{exercise.Reps},{exercise.Weight}");
            }
        }

        public static Exercise GetExerciseById(int exerciseId)
        {
            var exercise = _exercises.FirstOrDefault(x => x.exerciseId == exerciseId); //Find the exercise in the list

            if (exercise != null)
            {
                return new Exercise
                {
                    exerciseId = exerciseId,
                    Name = exercise.Name,
                    Sets = exercise.Sets,
                    Reps = exercise.Reps,
                    Weight = exercise.Weight
                };
            }

            return null; //Exercise with given arguement exerciseId does not exist
        }

        /// <summary>
        /// This method will search _exercise list to find the exercise with the cooresponding exerciseId. If it exists, it will change the Exercise attributes to match the second arguement
        /// </summary>
        /// <param name="exerciseId"></param>
        /// <param name="exercise"></param>
        public static void editExercise(int exerciseId, Exercise exercise)
        {
            var excerciseToUpDate = _exercises.FirstOrDefault(x => x.exerciseId == exerciseId);

            if (excerciseToUpDate != null)
            {
                excerciseToUpDate.Name = exercise.Name;
                excerciseToUpDate.Sets = exercise.Sets;
                excerciseToUpDate.Reps = exercise.Reps;
                excerciseToUpDate.Weight = exercise.Weight;
            }
        }

        /// <summary>
        /// This method will accept an Exercise parameter and append it to the list. It's contact Id
        /// </summary>
        /// <param name="exercise"></param>
        public static void AddExercise(Exercise exercise)
        {
            int maxId;
            if (_exercises.Count == 0)
            {
                maxId = 1;
            }
            else
            {
                maxId = _exercises.Max(x => x.exerciseId);
            }

            exercise.exerciseId = maxId + 1;
            _exercises.Add(exercise);
        }
    }
}

