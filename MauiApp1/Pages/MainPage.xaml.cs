using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui;
using MauiApp1.Models;
using MauiApp1.PageModels;
using MauiApp1.Pages.Controls;

namespace MauiApp1.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }

		bool popupped = false;

		private void ToolbarClicked_Handler(object sender, EventArgs e)
		{
			_ = Popup();
		}
		async Task Popup()
          {
			if (!popupped)
			{
				popupped = true;
				var popup = new MyPopup();

			var resultPop = await Shell.Current.ShowPopupAsync<Result?>(popup, new PopupOptions() { Shape = null, CanBeDismissedByTappingOutsideOfPopup = false }).ConfigureAwait(false);

			// Repeating calls of popup sometimes never completes ShowPopupAsync task

			var result = resultPop.Result;

				if (result is null)
					await MainThread.InvokeOnMainThreadAsync(static () => Shell.Current.DisplayAlert("Canceled", "Popup canceled", "ok")).ConfigureAwait(false);
				else
					await MainThread.InvokeOnMainThreadAsync(() => Shell.Current.DisplayAlert("Result", $"result [{result.Id} {result.Message}] ", "ok")).ConfigureAwait(false);

				popupped = false;
			}
			else
				CommunityToolkit.Maui.Alerts.Toast.Make("Popup is active!");
		}


	}
}