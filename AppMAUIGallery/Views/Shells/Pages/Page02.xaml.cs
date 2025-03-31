using System.Web;
using Android.App;
using AppMAUIGallery.Models;
using Person = AppMAUIGallery.Models.Person;

namespace AppMAUIGallery.Views.Shells.Pages;

public partial class Page02 : ContentPage
{
	public Page02()
	{
		InitializeComponent();
	}

    private void GoToStep01WithSimpleParameters(object sender, EventArgs e)
    {
        var text = "Este é um parametro passado pela tela anterior!";
        var codifiedText = HttpUtility.UrlEncode(text);
		Shell.Current.GoToAsync($"//Page02/Page02Step01?texto={codifiedText}");
    }

    private void GoToStep01WithComplexParameters(object sender, EventArgs e)
    {
        Person person = new (){ Id = 1, Name = "John Doe", Email = "jhon_d@gmail.com" };
        var parameter = new Dictionary<string, object> {
            { "texto", "Este é um parâmetro passado de forma complexa!" },
            { "person", person}
        };
        //var codifiedPerson = HttpUtility.UrlEncode(JsonConvert.SerializeObject(person));
        Shell.Current.GoToAsync("//Page02/Page02Step01", parameter);
    }
}