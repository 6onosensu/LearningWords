using LearningWords.Models;
using LearningWords.Pages;
using SQLite;
using System.IO;

namespace LearningWords;
public partial class MainPage : ContentPage
{
    public List<Word> _words;
    public int _curWordIndex;

    VerticalStackLayout _verticalSL;
    ScrollView _scrollView;
    Picker _categoryPicker;
    Label _appLbl;
    Button _addWordBtn, _editWordBtn, _nextWordBtn, _prevWordBtn;
    public MainPage()
	{
        InitializeComponents();
        
        _words = new List<Word>();
        _curWordIndex = 0;
    }
    private void InitializeComponents()
    {
        _verticalSL = new VerticalStackLayout
        {
            Padding = 10,
            Spacing = 40,
        };

        _appLbl = new Label
        {
            Text = "Learning Words",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 33,
        };
        _verticalSL.Children.Add(_appLbl);

        _addWordBtn = new Button
        {
            Text = "Add",
            HorizontalOptions = LayoutOptions.Center
        };
        _addWordBtn.Clicked += OnAddWordClicked;
        _verticalSL.Children.Add(_addWordBtn);

        _prevWordBtn = new Button
        {
            Text = "Previous",
            HorizontalOptions = LayoutOptions.Center
        };
        //_prevWordBtn.Clicked += OnPrevWordClicked;
        _verticalSL.Children.Add(_prevWordBtn);

        _nextWordBtn = new Button
        {
            Text = "Next",
            HorizontalOptions = LayoutOptions.Center
        };
        //_nextWordBtn.Clicked += OnNextWordClicked;
        _verticalSL.Children.Add(_nextWordBtn);

        _scrollView = new ScrollView
        {
            Content = _verticalSL,
            VerticalOptions = LayoutOptions.FillAndExpand,
        };

        Content = _scrollView;
    }
 
/*  private void DisplayCurWord()
    {
        if (_words.Count > 0 && _curWordIndex >= 0 && _curWordIndex < _words.Count)
        {
            var currentWord = _words[_curWordIndex];

            _wordLbl.Text = currentWord.WordText;
            _translationLbl.Text = currentWord.Translation;
            _explanationLbl.Text = currentWord.Explanation;
            _categoryLbl.Text = currentWord.Category;
        }
        else
        {
            _wordLbl.Text = "No word available.";
            _translationLbl.Text = "";
            _explanationLbl.Text = "";
            _categoryLbl.Text = "";
        }
    }
    private void OnPrevWordClicked(object sender, EventArgs e)
    {
        if (_curWordIndex > 0)
        {
            _curWordIndex--;
            DisplayCurWord();
        }
    }
    private void OnNextWordClicked(object sender, EventArgs e)
    {
        if (_curWordIndex < _words.Count - 1)
        {
            _curWordIndex++;
            DisplayCurWord();
        }
    }
*/
    private async void OnAddWordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddNewWordPage());
    }
    private async void OnEditWordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditWordPage());
    }
}