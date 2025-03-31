using System.Web;
using AppMAUIGallery.Models;

namespace AppMAUIGallery.Views.Shells.Pages;

[QueryProperty(nameof(receivedText), "texto")]
[QueryProperty(nameof(receivedPerson), "person")]
public partial class Page02Step01WithParameters : ContentPage
{
	private string text;
	public string receivedText { get { return text; } set { text = HttpUtility.UrlDecode(value); lblMsgParameter.Text = text; } }
	
	private Person person;
	public Person receivedPerson { get { return person; } set { person = value; lblMsgParameter.Text = $"A pessoa recebida é: {person.Name} ({person.Email})"; } }
	public Page02Step01WithParameters()
	{
		InitializeComponent();
	}
}