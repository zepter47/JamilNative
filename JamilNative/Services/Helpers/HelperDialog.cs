using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace JamilNative.Services.Helpers
{
    public class HelperDialog
    {
        public HelperDialog() { }

        public static async Task<ContentDialogResult> ShowYesNoDialog(string title, string content, string PrimaryButton, string SecondaryButton)
        {
            ContentDialog YesNo = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = PrimaryButton,
                SecondaryButtonText = SecondaryButton
            };
            YesNo.XamlRoot = XamlRootProvider.GetXamlRoot();
            return await YesNo.ShowAsync();

        }

        public static async Task ShowErrorMessage(string Title, string CustomMessage, string PrimaryButtonText, Exception ex)
        {
            string FullCommunication = $"{CustomMessage}:\n {ex.Message}";

            ContentDialog ShowError = new ContentDialog
            {
                Title = Title,
                Content = FullCommunication,
                PrimaryButtonText = PrimaryButtonText,
                XamlRoot = XamlRootProvider.GetXamlRoot()
            };

            await ShowError.ShowAsync();

        }

        public static async Task ShowApiErrorMessage(string Title, string CustomMessage, string PrimaryButtonText, ApiException ex)
        {
            string FullCommunication = $"{CustomMessage}:\n {ex.Message}";

            ContentDialog ShowError = new ContentDialog
            {
                Title = Title,
                Content = FullCommunication,
                PrimaryButtonText = PrimaryButtonText,
                XamlRoot = XamlRootProvider.GetXamlRoot()
            };

            await ShowError.ShowAsync();

        }

        public static async Task<ContentDialogResult> ShowOKDialog(string title, string content)
        {
            ContentDialog OK = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = "OK",
            };
            OK.XamlRoot = XamlRootProvider.GetXamlRoot();
            return await OK.ShowAsync();

        }




    }
}
