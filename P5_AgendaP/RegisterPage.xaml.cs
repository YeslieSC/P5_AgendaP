namespace P5_AgendaP;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text.Trim();
        string email = EmailEntry.Text.Trim();
        string password = PasswordEntry.Text.Trim();

        if (!string.IsNullOrEmpty(name) && email.Contains("@") && password.Length > 5)
        {
            StatusLabel.Text = "Registro exitoso. Ahora puedes iniciar sesión.";
        }
        else
        {
            await DisplayAlert("Error", "Por favor, ingresa datos válidos.", "OK");
        }
    }
}