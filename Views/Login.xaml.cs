namespace jcaillaguaExamen.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
    string[] usuario = { "estudiante2025", "uisrael", "sistemas" };
    string[] contrasena = { "moviles", "2025", "2025_1" };

    private async void btnIniciar_Clicked(object sender, EventArgs e)
    {
        if (
        string.IsNullOrWhiteSpace(txtUsuario.Text) ||
        string.IsNullOrWhiteSpace(txtContrasena.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
            return;
        }

        string usuarioIngresado = txtUsuario.Text;
        string contrasenaIngresada = txtContrasena.Text;
        bool ingresoCorrecto = false;


        for (int i = 0; i < usuario.Length; i++)
        {
            if (usuarioIngresado == usuario[i] && contrasenaIngresada == contrasena[i])
            {
                ingresoCorrecto = true;
                await DisplayAlert("Acceso correcto", $"Hola {usuario[i]}", "Acceder");
                await Navigation.PushAsync(new Registro(usuario[i])); 
                break;
            }

        }
        if (!ingresoCorrecto)
        {
            await DisplayAlert("Acceso incorrecto", $"Vuelva a intentarlo", "Salir");
            txtContrasena.Text = string.Empty;
            txtUsuario.Text = string.Empty;
        }
    }

    private async void btnAcerca_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sistema", $"Este sistema fue realizado por: Joel Caillagua" , "Salir");
    }
}