namespace jcaillaguaExamen.Views;

public partial class Resumen : ContentPage
{
	public Resumen()
	{
		InitializeComponent();
	}

    public Resumen(string usaurio)
    {
        InitializeComponent();
    }

    public Resumen(string usaurio, string nombre, string apellido, string fecha, string ciudad, string vA, string monto, string cuota) : this(usaurio)
    {
        nombre = nombre;
        apellido = apellido;
        fecha = fecha;
        ciudad = ciudad;
        vA = vA;
        monto = monto;
        cuota = cuota;

        lbluser.Text = usaurio;
        double cuotacalc = double.Parse(cuota);
        double montocalc = double.Parse(monto);
        double total = (cuotacalc * 3) + montocalc;

        txtNombre.Text = nombre;
        txtApellido.Text = apellido;
        txtVA.Text = vA;
        txtFecha.Text = fecha;
        txtCiudad.Text = ciudad;
        txtMontoInicial.Text = monto;
        txtCuotaMensual.Text = cuota;
        txtPagoTotal.Text = total.ToString("F2");

    }

    private async void btnCerrar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Login());
    }
}