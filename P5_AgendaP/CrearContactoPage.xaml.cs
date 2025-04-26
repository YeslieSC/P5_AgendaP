using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace P5_AgendaP;

public partial class CrearContactoPage : ContentPage
{
    public CrearContactoPage()
    {
        InitializeComponent();
    }

    private async void GuardarContacto(object sender, EventArgs e)
    {
        var nuevoContacto = new
        {
            Nombre = nombreEntry.Text,
            Telefono = telefonoEntry.Text,
            Correo = correoEntry.Text,
            Direccion = direccionEntry.Text
        };

        ContactosPage.contactos.Add(nuevoContacto);

        await Navigation.PopAsync();
    }
}