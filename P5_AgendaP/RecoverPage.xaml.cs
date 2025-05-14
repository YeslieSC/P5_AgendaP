namespace P5_AgendaP;

public partial class RecoverPage : ContentPage
{
	public RecoverPage()
	{
		InitializeComponent();
	}
    private async void OnRecoverClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text.Trim();

        if (!string.IsNullOrEmpty(email) && email.Contains("@"))
        {
            StatusLabel.Text = "Hemos enviado instrucciones a tu correo.";
        }
        else
        {
            await DisplayAlert("Error", "Por favor, ingresa un correo válido.", "OK");
        }
    }
}