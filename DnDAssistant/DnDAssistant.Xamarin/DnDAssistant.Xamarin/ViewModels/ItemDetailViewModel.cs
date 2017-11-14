using DnDAssistant.Xamarin.Models;

namespace DnDAssistant.Xamarin.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = item.Text;
			Item = item;
		}

		int _Quantity = 1;
		public int Quantity
		{
            get => _Quantity;
            set => SetProperty(ref _Quantity, value);
        }
	}
}