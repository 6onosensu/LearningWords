using LearningWords.Models;
using LearningWords.Classes;

namespace LearningWords.Pages;
public partial class AddNewWordPage : ContentPage
{
	public AddNewWordPage()
	{
		InitializeComponent();
	}

	private async void OnButtonClicked(object? sender, EventArgs args)
	{
        string _word = wordEntry.Text;
        string _trans = translationEntry.Text;
        string _explan = explanationEntry.Text;

        if (String.IsNullOrEmpty(_word) || String.IsNullOrEmpty(_trans) || String.IsNullOrEmpty(_explan))
        {
            await DisplayAlert("Error", "All the fields are required!", "OK");
            return;
        }
        var newWord = new Word
        {
            WordText = _word,
            Translation = _trans,
            Explanation = _explan,
            Category = "learning",
            RepetitionCount = 0,
        };

        var dbHelper = new DbHelper();
        await dbHelper.SaveWord(newWord);

        await DisplayAlert("Success", "Word added successfully!", "OK");
        await Navigation.PopAsync();
    }
}