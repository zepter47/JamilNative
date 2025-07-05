using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamilNative.Services.Helpers;
using Refit;

namespace JamilNative.ViewModel
{
    public partial class SettingsViewModel:ObservableValidator
    {
        private readonly IAppNative _native;
        private readonly INavigator _navigation;


        [ObservableProperty]
        [Required(ErrorMessage ="Please Enter Relationship")]
        [NotifyDataErrorInfo]
        [NotifyCanExecuteChangedFor(nameof(PostRshipCommand))]
        private string? _relationship;

        [ObservableProperty]
        [Required(ErrorMessage ="Please enter house Number")]
        [NotifyDataErrorInfo]
        //[NotifyCanExecuteChangedFor(nameof(AddHouseNumberCommand))]
        private string? _house;

        public SettingsViewModel() { }

        public SettingsViewModel(IAppNative native, INavigator navigation)
        {
            _native = native;
            _navigation = navigation;

            // ValidateAllProperties();
        }


        [RelayCommand(CanExecute = nameof(CanAddRelationship))]
        private async Task PostRship(MaritalStatus status)
        {
                try
                {
                    await _native.AddNokRelatioship(new NokRelationship { Status = Relationship });
                    ClearRship();

                    await HelperDialog.ShowOKDialog("Api Success", "Relationship Addition Successful");
                }
                catch (ApiException ex)
                {

                    await HelperDialog.ShowApiErrorMessage("API Error", "Addition of relationship Failed", "OK", ex);
                }
        }

        private void ClearRship()
        {
            Relationship = string.Empty;
        }

        [RelayCommand(CanExecute = nameof(CanAddHouse))]
        private async Task AddHouseNumber()
        {
            ContentDialogResult result = await HelperDialog.ShowYesNoDialog("Inquiry", "Would you like to add house", "OK", "NO");

            if(result == ContentDialogResult.Primary)
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

            if(result == ContentDialogResult.Secondary)
            {
                return;
            }
        }

        private void ClearHouse()
        {
            House = string.Empty;
        }


        private bool CanAddRelationship()
        {
            return !HasErrors;
        }

        private bool CanAddHouse()
        {
            return !HasErrors;
        }

        //navigating to the maritalsettingsPage
        [RelayCommand]
        private async Task GoToMaritalSetting()
        {
            await _navigation.NavigateRouteAsync(this,"MaritalSettings");
        }

    }
}
