namespace Body_Builder.Model
{
    public partial class Exercise : ObservableObject
    {
        public Exercise() { this.name = ""; this.sets = 0; reps = 0; this.weight = 0; this.Completed = false; }

        // may want to change reps and weight to an array/list
        public Exercise(string name, int sets, int reps, int weight) { this.name = name; this.Completed = false; this.sets = sets; this.reps = reps; this.weight = weight; }

        public Exercise(Exercise copy)
        {
            this.name = copy.name;
            this.sets = copy.sets;  
            this.reps = copy.reps;      
            this.weight = copy.weight; 
            this.completed = copy.Completed;
            
        }

        
        private string name;
        public string Name
        { get { return this.name; } set { this.name = value; } }

        public int exerciseId; //This is how we will identify a exercise. Each exercise will have a unique Id that is assigned when the list becomes updated

        [ObservableProperty]
        public bool completed;

        //private bool completed;

       // public bool Completed { get; set; }

        private int sets;
        public int Sets
        { get { return this.sets; } set { if (value >= 0) this.sets = value; else this.sets = 0; } }


        private int reps;
        public int Reps
        { get { return this.reps; } set { if (value >= 0) this.reps = value; else this.reps = 0 ; } }

        private double weight;
        public double Weight
        {  get { return this.weight; } set { if (value >= 0) this.weight = value; else this.weight = 0; } }


        public double getCalories() 
        {
            if (Completed)
            {
                return Reps * Sets;
            }
            else return 0;
        }

        public double getXP() 
        {
            return Sets * Reps * Weight;
        }

        [RelayCommand]
        void CompletedExercise()
        {
            if (Completed == true)
            {
                Completed = false;
            }
            else Completed = true;
        }
    }
}
