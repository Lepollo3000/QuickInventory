namespace QUICK_INVENTORY.Client.Helpers;

internal static class ApplicationPages
{
    public const string Home = "/";

    public class Productos
    {
        public const string Principal = "/productos";
        public const string Listado = $"{Principal}/lista";
        public const string Crear = $"{Principal}/crear";
    }
}
