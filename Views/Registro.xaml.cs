namespace jcaillaguaExamen.Views;
using System.Text.RegularExpressions;
public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    public Registro(String usuarioLogin)
    {
        InitializeComponent();
        string usuario = usuarioLogin;
        lbluser.Text = "Usuario conectado: " + usuarioLogin;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        Double cuota = (300*0.05) + (300-45)/3;
        txtCuota.Text = cuota.ToString("F2");
    }

    private async void btnResumen_Clicked(object sender, EventArgs e)
    {
        if (pCiudad.SelectedIndex == -1 ||
            pVA.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtMonto.Text) ||
                string.IsNullOrWhiteSpace(txtCuota.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
            return;
        }

        if (!Regex.IsMatch(txtNombre.Text, @"^[A-Za-z¡…Õ”⁄·ÈÌÛ˙—Ò\s]+$") ||
               !Regex.IsMatch(txtApellido.Text, @"^[A-Za-z¡…Õ”⁄·ÈÌÛ˙—Ò\s]+$"))
        {
            await DisplayAlert("Error", "Nombres y apellidos solo deben contener letras.", "Aceptar");
            return;
        }

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string fecha = dtpFecha.Date.ToString();
        string ciudad= pCiudad.SelectedItem.ToString();
        string VA =pVA.SelectedItem.ToString();
        string monto = txtMonto.Text;
        string cuota = txtCuota.Text;
        string usarioLogin =lbluser.Text;
        await Navigation.PushAsync(new Resumen(usarioLogin,nombre,apellido,fecha,ciudad,VA,monto,cuota));
    }
}