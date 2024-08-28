namespace Body_Builder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MakeWorkoutPage), typeof(MakeWorkoutPage));
            Routing.RegisterRoute(nameof(WorkingOutPage), typeof(WorkingOutPage));
            Routing.RegisterRoute(nameof(SummaryPage), typeof(SummaryPage));
        }
    }
}
