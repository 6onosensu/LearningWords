using LearningWords.Models;

namespace LearningWords.Views;

public class ReviewSection : ContentView
{
    VerticalStackLayout vsl;
    List<Word> wordsOnReview;
    List<int> textSize; //28,22,20
    List<string> wordVar; // WordText, Translation, Explanation
    public int _curWordIndex;
    public ReviewSection()
    {
        var words = wordsOnReview.Select(w => w.Category = "reviewing").ToArray();
        Label label = new Label
        {
            Text = $"Review some words ({words.Count()}):",
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
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal),
            IndicatorView = indicatorView,
        };

        carouselView.ItemTemplate = new DataTemplate(() =>
        {
            var vsl = new VerticalStackLayout();
            for (int i = 0; i <= 0; i++)
            {
                Label lbl = new Label
                {
                    TextColor = Colors.White,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = textSize[i],
                    Padding = 10,
                };
                lbl.SetBinding(Label.TextProperty, $"{wordVar[i]}");
                vsl.Children.Add(lbl);
            };

            Frame frame = new Frame
            {
                WidthRequest = 250,
                HeightRequest = 300,
                Padding = 40,
            };

            frame.Content = vsl;
            return frame;
        });

        Content = new VerticalStackLayout() { label, carouselView, indicatorView };

    }
}