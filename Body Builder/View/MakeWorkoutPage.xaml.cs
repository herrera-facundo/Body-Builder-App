namespace Body_Builder
{
    public partial class MakeWorkoutPage : ContentPage
    {
        public MakeWorkoutPage(MakeWorkoutVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
