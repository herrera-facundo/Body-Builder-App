using Microsoft.Extensions.Logging;

namespace Body_Builder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // builder.Services.AddSingleton<WorkoutPage>();
            //builder.Services.AddSingleton<MonkeyService>();
            builder.Services.AddSingleton<AchievementsVM>();
            builder.Services.AddSingleton<AchievementsPage>();

            builder.Services.AddSingleton<HomeVM>();
            builder.Services.AddSingleton<HomePage>();

            builder.Services.AddSingleton<WorkoutVM>();
            builder.Services.AddSingleton<WorkoutPage>();

            // use transient for things like summary page or workingOut page

            builder.Services.AddTransient<WorkingOutVM>();
            builder.Services.AddTransient<WorkingOutPage>();

            builder.Services.AddTransient<SummaryVM>();
            builder.Services.AddTransient<SummaryPage>();

            builder.Services.AddTransient<MakeWorkoutVM>();
            builder.Services.AddTransient<MakeWorkoutPage>();

            return builder.Build();
        }
    }
}
