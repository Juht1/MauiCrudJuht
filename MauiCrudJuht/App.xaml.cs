namespace MauiCrudJuht
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set MainPage to your MainPage instance
            MainPage = new NavigationPage(new MainPage(new LocalDbService()));
        }
    }
}
