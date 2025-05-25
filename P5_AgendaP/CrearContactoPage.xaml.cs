using Microsoft.Maui.Controls;
using System.Collections.Generic;
using P5_AgendaP.Modelos;
using P5_AgendaP.Datos;

namespace P5_AgendaP;

public partial class CrearContactoPage : ContentPage
{
    private readonly ContactoDatabase _database = new();

    public CrearContactoPage()
    {
        InitializeComponent();
    }

    private async void GuardarContacto(object sender, EventArgs e)
    {
        var nuevoContacto = new Contacto
        {
            Nombre = nombreEntry.Text,
            Telefono = telefonoEntry.Text,
            CorreoElectronico = correoEntry.Text,
            Activo = true
        };

        await _database.GuardarContactoAsync(nuevoContacto);

        await DisplayAlert("Contacto Guardado", $"Se ha guardado: {nuevoContacto.Nombre}", "OK");
        await Navigation.PopAsync();
    }
}
