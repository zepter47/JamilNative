using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace JamilNative.ViewModel;
public partial class AddResidentsViewModel:ObservableValidator
{
    private readonly IAppNative _native;

    [ObservableProperty]
    private ObservableCollection<string> _maritalList = new ObservableCollection<string>();

    [ObservableProperty]
    private ObservableCollection<string> _nokList = new ObservableCollection<string>();

    [ObservableProperty]
    private string _selectedMarital;

    [ObservableProperty]
    private string _selectedNok;

    public AddResidentsViewModel() { }

    public AddResidentsViewModel(IAppNative native)
    {
        //MaritalList = new ObservableCollection<string>();
        //NokList = new ObservableCollection<string>();

        _native = native;

        RetriveMaritalStatus();
        RetrieveNokRelationship();

    }

    private async Task RetriveMaritalStatus()
    {
        //MaritalList = new ObservableCollection<string>();

        //MaritalList.Clear();

        try
        {
            var response = await _native.GetMaritalStatus();

            if(response.IsSuccessStatusCode && response.Content != null)
            {


                //foreach (var item in response.Content)
                //{
                //    MaritalList.Add( new MaritalStatus { TStatus = item.TStatus});
                //}

                MaritalList = response.Content.Select(x=>x.TStatus).ToObservableCollection();

            }
        }
        catch (ApiException)
        {

            throw;
        }
    }

    private async Task RetrieveNokRelationship()
    {
        //NokList = new ObservableCollection<string>();
        //NokList.Clear();

        try
        {
            var response = await _native.GetNokRelationship();

            if(response.IsSuccessStatusCode && response.Content != null)
            {
                NokList = response.Content.Select(x =>  x.Status).ToObservableCollection();
               //foreach(var item in response.Content)
               // {
               //     NokList.Add(new NokRelationship{ Status = item.Status });
               // }
            }
        }
        catch (ApiException)
        {

            throw;
        }
    }

    //public async Task InitializeAsync()
    //{
    //    await RetriveMaritalStatus();
    //    await RetrieveNokRelationship();
    //}


}
