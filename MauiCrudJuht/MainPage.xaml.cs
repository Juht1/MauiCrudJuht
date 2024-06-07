namespace MauiCrudJuht
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;

        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
        }

        async void NavigateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FrontPage(_dbService));
        }
    }
}
