using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.WinUI;
using Microsoft.UI.Dispatching;
using Refit;

namespace JamilNative.ViewModel;
public partial class ResidentsListViewModel:ObservableValidator
{
    private readonly IAppNative _native;

    public ObservableCollection<TenantDetails> TenantData { get; } = new();

    public ResidentsListViewModel()
    {
        System.Diagnostics.Debug.WriteLine("ResidentsListViewModel: Parameterless constructor called.");
    }

    public ResidentsListViewModel(IAppNative native)
    {
        _native = native;
        System.Diagnostics.Debug.WriteLine("ResidentsListViewModel: DI constructor called.");
        //RetrieveTenantDetails();
    }

    [RelayCommand]
    public async Task RetrieveTenantDetails()
    {

        System.Diagnostics.Debug.WriteLine("RetrieveTenantDetails: Starting data retrieval. IsLoading = true.");
        System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: TenantData count BEFORE Clear: {TenantData.Count}");

        if(TenantData.Count > 0)
        {
            TenantData.Clear();
        }

        try
        {
            System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: TenantData count AFTER Clear: {TenantData.Count}");

            var response = await _native.GetTenantDetails();
            System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: API call completed. Status: {response.StatusCode}");


            if (response.IsSuccessStatusCode && response.Content != null)
            {
                System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: API response successful. Content items received: {response.Content.Count}");

                //var tena = response.Content.Select(y => new TenantDetails()
                //{
                //    FirstName = y.FirstName,
                //    LastName = y.LastName,
                //    TdHouse = y.TdHouse,
                //}).ToObservableCollection();

                //TenantData.Add(tena);

                var tena = response.Content;

                foreach (var y in tena)
                {
                    TenantData.Add(y);
                }

                System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: TenantData populated. Final count: {TenantData.Count}");

            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: API response not successful or content is null. Status: {response.StatusCode}");

            }
        }
        catch (ApiException ex)
        {
            System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: API Exception: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"API Exception Details: {ex}"); // Log full exception details
        }

        catch(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"RetrieveTenantDetails: General Exception: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"General Exception Details: {ex}");
        }
        finally
        {
            System.Diagnostics.Debug.WriteLine("RetrieveTenantDetails: Data retrieval finished. IsLoading = false.");
        }

    }

    //public async Task InitializeAsync()
    //{
    //    await RetrieveTenantDetails();
    //}

}
