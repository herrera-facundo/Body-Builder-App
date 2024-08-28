namespace Body_Builder
{
    public partial class WorkingOutPage : ContentPage
    {
        public WorkingOutPage(WorkingOutVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
