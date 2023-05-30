namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    IMap map;
    public MonkeyDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    public Monkey monkey;
    [RelayCommand]
    async Task OpenMapAsync()
    {
        try
        {
            await map.OpenAsync(Monkey.Longitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            }); ;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to open map: {ex.Message}", "OK");
        }

    }

}