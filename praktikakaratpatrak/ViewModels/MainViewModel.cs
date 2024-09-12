using praktikakaratpatrak.Models;
using praktikakaratpatrak.Views;

namespace praktikakaratpatrak.ViewModels;

public class MainViewModel : ViewModelBase
{
    public GamePage gamepage { get; set; }
    public GenrePage genrepage { get; set; }

    public MainViewModel() {
        
        gamepage = new GamePage();
        gamepage.DataContext = new GamePageViewModel();
        genrepage = new GenrePage();
        genrepage.DataContext = new GenrePageViewModel();
    }
}
