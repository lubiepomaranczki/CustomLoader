using Xamarin.Forms;

namespace CustomLoader
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            loader.Easing = Easing.CubicIn;
        }
    }
}
