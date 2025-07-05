using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using JamilNative.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Dispatching;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CommunityToolkit.WinUI;
//using AndroidX.Lifecycle;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JamilNative.View;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ResidentsListPage : Page
{
    //private ResidentsListViewModel vm;
    public ResidentsListPage()
    {
        this.InitializeComponent();

        var vm = ((App)Application.Current).Host.Services.GetRequiredService<ResidentsListViewModel>();

        DataContext = vm;

        //refreshContainer.RefreshRequested += RefreshContainer_RefreshRequested;


        //vm.RetrieveTenantDetails();

        //this.Loaded += ResidentsListPage_Loaded;
        //System.Diagnostics.Debug.WriteLine("ResidentsListPage: Subscribed to Loaded event.");



        //_ = _viewModel.InitializeAsync();
    }

    //private async void RefreshContainer_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
    //{
    //    var UiDispatcher = DispatcherQueue.GetForCurrentThread();

    //    if(UiDispatcher != null)
    //    {
    //        await UiDispatcher.EnqueueAsync(async () =>
    //        {
    //            var deferral = args.GetDeferral();
    //            await vm.RetrieveTenantDetails();
    //            deferral.Complete();

    //        });
    //    }
    //    else { return; }
    //}

    //protected override async void OnNavigatedTo(NavigationEventArgs e)
    //{
    //    base.OnNavigatedTo(e); // IMPORTANT: Always call the base implementation
    //    // Your custom logic here, like loading data
    //    await _viewModel.RetrieveTenantDetails();
    //}

    //private async void ResidentsListPage_Loaded(object sender, RoutedEventArgs e)
    //{
    //    //var vm = ((App)Application.Current).Host.Services.GetRequiredService<ResidentsListViewModel>();

    //    //DataContext = vm;

    //    this.Loaded -= ResidentsListPage_Loaded;
    //    System.Diagnostics.Debug.WriteLine("ResidentsListPage_Loaded: Event fired. Starting data retrieval.");


    //    if (vm != null)
    //    {
    //        await vm.RetrieveTenantDetails();
    //        System.Diagnostics.Debug.WriteLine($"ResidentsListPage_Loaded: Data retrieval completed. TenantData count: {vm.TenantData.Count}");
    //    }
    //    else
    //    {
    //        System.Diagnostics.Debug.WriteLine("Error: ResidentsListViewModel is null in Loaded event. This should not happen.");
    //    }
    //}


}
