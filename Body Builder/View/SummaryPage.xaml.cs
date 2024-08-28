namespace Body_Builder
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage(SummaryVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
