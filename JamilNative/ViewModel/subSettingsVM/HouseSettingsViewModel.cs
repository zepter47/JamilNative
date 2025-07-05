using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamilNative.Services.Helpers;
using Refit;

namespace JamilNative.ViewModel.subSettingsVM;
public partial class HouseSettingsViewModel:ObservableValidator
{
    private readonly IAppNative _native;

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter house Number")]
    [NotifyDataErrorInfo]
    [NotifyCanExecuteChangedFor(nameof(AddHouseNumberCommand))]
    private string? _house;


    public HouseSettingsViewModel() { }

    public HouseSettingsViewModel(IAppNative native)
    {
        _native = native;

        ValidateAllProperties();
    }

    [RelayCommand(CanExecute = nameof(CanAddHouse))]
    private async Task AddHouseNumber()
    {
        ContentDialogResult result = await HelperDialog.ShowYesNoDialog("Inquiry", "Would you like to add house", "YES", "NO");

        if (result == ContentDialogResult.Primary)
        {
            try
            {
                await _native.AddHouseNumber(new House { HouseNumber = House });
                ClearHouse();

                await HelperDialog.ShowOKDialog("Api Success", "House Addition Successful");

            }
            catch (ApiException ex)
            {

                await HelperDialog.ShowApiErrorMessage("API Error", "Addition of House Failed", "OK", ex);
            }
        }

        if (result == ContentDialogResult.Secondary)
        {
            return;
        }
    }

    private bool CanAddHouse()
    {
        return !HasErrors;
    }


    private void ClearHouse()
    {
        House = string.Empty;
    }


}
