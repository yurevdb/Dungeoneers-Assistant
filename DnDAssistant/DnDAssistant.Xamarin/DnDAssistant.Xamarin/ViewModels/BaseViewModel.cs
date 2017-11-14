using DnDAssistant.Xamarin.Helpers;
using DnDAssistant.Xamarin.Models;
using DnDAssistant.Xamarin.Services;

using Xamarin.Forms;

namespace DnDAssistant.Xamarin.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		/// <summary>
		/// Get the azure service instance
		/// </summary>
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

		bool _IsBusy = false;
		public bool IsBusy
		{
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }
		/// <summary>
		/// Private backing field to hold the title
		/// </summary>
		string _Title = string.Empty;
		/// <summary>
		/// Public property to set and get the title of the item
		/// </summary>
		public string Title
		{
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
	}
}

