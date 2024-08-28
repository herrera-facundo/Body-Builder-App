
namespace Body_Builder
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
