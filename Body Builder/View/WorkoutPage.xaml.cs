namespace Body_Builder
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage(WorkoutVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        /*protected override void OnNavigatedTo(NavigatedToEventArgs e)
        {
            base.OnNavigatedTo(e);
            // code here
        }*/
    }

}
