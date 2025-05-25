using P5_AgendaP.Modelos;
using P5_AgendaP.Datos;

namespace P5_AgendaP;

public partial class RegisterPage : ContentPage
{
    private readonly UsuarioDatabase _database = new();

    public RegisterPage()
    {
        InitializeComponent();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text.Trim();
        string email = EmailEntry.Text.Trim();
        string password = PasswordEntry.Text.Trim();

        if (!string.IsNullOrEmpty(name) && email.Contains("@") && password.Length > 5)
        {
            // Verifica si el usuario ya existe
            var usuarioExistente = await _database.GetUsuarioPorEmailAsync(email);
            if (usuarioExistente != null)
            {
                await DisplayAlert("Error", "El correo ya está registrado.", "OK");
                return;
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = name,
                Email = email,
                Password = password
            };

            await _database.GuardarUsuarioAsync(nuevoUsuario);

            StatusLabel.Text = "Registro exitoso. Ahora puedes iniciar sesión.";
        }
        else
        {
            await DisplayAlert("Error", "Por favor, ingresa datos válidos.", "OK");
        }

    }
}
