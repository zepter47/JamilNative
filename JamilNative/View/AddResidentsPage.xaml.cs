using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using JamilNative.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JamilNative.View;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AddResidentsPage : Page
{
    //public AddResidentsViewModel? ViewModel { get; set; }

    public AddResidentsPage()
    {
        this.InitializeComponent();

        var vm = ((App)Application.Current).Host.Services.GetRequiredService<AddResidentsViewModel>();

        DataContext = vm;

        //this.Loaded += AddResidentsPage_Loaded;
    }

    //private async void AddResidentsPage_Loaded(object sender, RoutedEventArgs e)
    //{
    //    var vm = ((App)Application.Current).Host.Services.GetRequiredService<AddResidentsViewModel>();

    //    DataContext = vm;

    //    await vm.InitializeAsync();
    //}


}
