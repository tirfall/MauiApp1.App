using System.ComponentModel;
using Xamarin.KotlinX.Coroutines.Channels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		CarouselView carouselView = new CarouselView()
		{
			VerticalOptions = LayoutOptions.Center
		};
		carouselView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal);
		carouselView.ItemsSource = new List<Product>()
		{
			new Product {Name="Name1", Description="Disc1", Image="dotnet_bot.svg"},
            new Product {Name="Name2", Description="Disc2", Image="dotnet_bot.svg"},
            new Product {Name="Name3", Description="Disc3", Image="dotnet_bot.svg"},
        };
		carouselView.ItemTemplate = new DataTemplate(() =>
		{
			Label header = new Label
			{
				FontAttributes= FontAttributes.Bold,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = 18
			};
			header.SetBinding(Label.TextProperty, "Name");

			Image image = new Image { WidthRequest = 150, HeightRequest = 150 };
			image.SetBinding(Image.SourceProperty, "Image");

			Label description = new Label { HorizontalTextAlignment = TextAlignment.Center, };
			description.SetBinding(Label.TextProperty, "Description");

			StackLayout stacklayout = new StackLayout() { header, image, description };
			Frame frame = new Frame();
			frame.Content = stacklayout;
			return frame;
		});
		Content = carouselView;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

