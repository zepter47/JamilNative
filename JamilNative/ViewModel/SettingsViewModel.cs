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



        private bool CanAddRelationship()
        {
            return !HasErrors;
        }


        //navigating to the maritalsettingsPage
        [RelayCommand]
        private async Task GoToMaritalSetting()
        {
            await _navigation.NavigateRouteAsync(this,"MaritalSettings");
        }

        [RelayCommand]
        private async Task GoToHouseSetting()
        {
            await _navigation.NavigateRouteAsync(this, "HouseSettings");
        }

    }
}
