namespace MauiCrudJuht
{
    public partial class FrontPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editCustomerId;
        private bool _isEditing;

        public FrontPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => ListView.ItemsSource = await _dbService.GetCustomers());
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (_editCustomerId == 0)
            {
                // ADD  
                await _dbService.Create(new Customer
                {
                    CustomerName = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    Mobile = mobileEntryField.Text,
                });
            }
            else
            {
                // EDIT

                await _dbService.Update(new Customer
                {
                    Id = _editCustomerId,
                    CustomerName = nameEntryField.Text,
                    Email = emailEntryField.Text,
                    Mobile = mobileEntryField.Text,
                });

                _editCustomerId = 0;
                _isEditing = false;
            }

            nameEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;
            mobileEntryField.Text = string.Empty;

            ListView.ItemsSource = await _dbService.GetCustomers();

        }


        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var customer = (Customer)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", _isEditing ? null : "Delete");

            switch (action)
            {
                case "Edit":

                    _editCustomerId = customer.Id;
                    nameEntryField.Text = customer.CustomerName;
                    emailEntryField.Text = customer.Email;
                    mobileEntryField.Text = customer.Mobile;
                    _isEditing = true;

                    break;
                case "Delete":
                    if (!_isEditing)
                    {
                        await _dbService.Delete(customer);
                        ListView.ItemsSource = await _dbService.GetCustomers();
                    }
                    break;
            }

        }
    }

}
