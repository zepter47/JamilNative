using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamilNative.Services.Helpers;
using Refit;

namespace JamilNative.ViewModel.subSettingsVM
{
    public partial class MaritalSettingsViewModel: ObservableValidator
    {
        private readonly IAppNative _native;

        public MaritalSettingsViewModel() { }

        public MaritalSettingsViewModel(IAppNative native)
        {
            _native = native;

            ValidateAllProperties();
        }

        [ObservableProperty]
        [Required(ErrorMessage = "Pleaase enter Status")]
        [NotifyDataErrorInfo]
        [NotifyCanExecuteChangedFor(nameof(PostMaritalStatusCommand))]
        private string? _status;



        [RelayCommand(CanExecute = nameof(CanAddMarital))]
        private async Task PostMaritalStatus()
        {
            try
            {
                await _native.AddMaritalStatus(new MaritalStatus { TStatus = Status });
                ClearStatus();

                await HelperDialog.ShowOKDialog("Success", "Marital Status Addition Successful");
            }
            catch (ApiException ex)
            {

                await HelperDialog.ShowApiErrorMessage("API Error", "Addition of Marital Status Failed", "OK", ex);
            }
        }

        private void ClearStatus()
        {
            Status = string.Empty;
        }

        public bool CanAddMarital()
        {
            return !HasErrors;
        }



    }
}
