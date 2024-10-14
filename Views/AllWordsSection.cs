using LearningWords.Models;

namespace LearningWords.Views;
public class AllWordsSection : ContentView
{
    VerticalStackLayout vsl;
	List<Word> words;
    Label _wordLbl;
    public AllWordsSection()
	{
        Label label = new Label
        {
            Text = $"All Words ({words.Count()}):",
            FontSize = 25,
            FontAttributes = FontAttributes.Bold,
        };

        IndicatorView indicatorView = new IndicatorView
        {
            SelectedIndicatorColor = Color.FromRgba(20, 150, 250, 100),
            HorizontalOptions = LayoutOptions.Center,
            IndicatorColor = Colors.Transparent,
            Margin = new Thickness(10),
            IndicatorTemplate = new DataTemplate(() =>
            {
                Label label = new Label
                {
                    Text = "\uf30c",
                    FontSize = 30,
                    TextColor = Colors.Blue,
                };
                return label;
            })
        };

        CarouselView carouselView = new CarouselView
        {
            VerticalOptions = LayoutOptions.Center,
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical),
            IndicatorView = indicatorView,
        };

        carouselView.ItemTemplate = new DataTemplate(() =>
        { 
            for (int i = 0; i < words.Count; i++)
            {
                _wordLbl = new Label
                {
                    Text = words[i].ToString(),
                    FontSize = 16,
                    Margin = 10,
                }; 
                HorizontalStackLayout hsl = new HorizontalStackLayout
                {
                    Children = {
                        _wordLbl,
                    }
                };
            };
        });

        Content = new VerticalStackLayout() { label, carouselView, indicatorView };
    }
}