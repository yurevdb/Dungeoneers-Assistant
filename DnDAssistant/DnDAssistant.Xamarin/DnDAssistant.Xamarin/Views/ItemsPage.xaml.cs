using System;

using DnDAssistant.Xamarin.Models;
using DnDAssistant.Xamarin.ViewModels;

using Xamarin.Forms;

namespace DnDAssistant.Xamarin.Views
{
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel _ViewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = _ViewModel = new ItemsViewModel();
		}

		private async void OnItemSelectedAsync(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		private async void AddItem_ClickedAsync(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_ViewModel.Items.Count == 0)
				_ViewModel.LoadItemsCommand.Execute(null);
		}
	}
}
