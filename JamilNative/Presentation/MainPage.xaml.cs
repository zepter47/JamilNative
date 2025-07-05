using JamilNative.Services.Helpers;

namespace JamilNative.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        this.Loaded += MainPage_Loaded;
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        XamlRootProvider.Initialize(this.XamlRoot);
    }
}
