using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui;

namespace MauiApp1.Pages.Controls;

public partial class MyPopup : Popup<Result?>
{
	public MyPopup()
	{
		InitializeComponent();
	}

	private void Ok_handler(object sender, EventArgs e)
	{
		dlgClose(true);
	}

	private void Cancel_handler(object sender, EventArgs e)
	{
		dlgClose(false);
	}

	void dlgClose(bool ok)
	{
		var result = ok ? new Result() { Message = $"OK {DateTime.Now.ToShortTimeString()}" } : null;

		CloseAsync(result);
	}
}