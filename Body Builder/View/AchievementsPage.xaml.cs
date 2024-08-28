namespace Body_Builder
{
    public partial class AchievementsPage : ContentPage
    {
        public AchievementsPage(AchievementsVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
