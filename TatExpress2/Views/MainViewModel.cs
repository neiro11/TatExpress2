using System.Collections.ObjectModel;

namespace TatExpress2.Views
{
    public class MainViewModel
    {
        public ObservableCollection<string> Images { get; set; }

        public MainViewModel()
        {
            Images = new ObservableCollection<string>
        {
            "slider.png",
            "slider_1.png",
            "slider_2.png"
        };
        }
    }
}