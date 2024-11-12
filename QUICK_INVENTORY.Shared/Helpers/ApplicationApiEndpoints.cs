namespace QUICK_INVENTORY.Shared.Helpers;

public class ApplicationApiEndpoints
{
    private const string Home = "api";

    public class Productos
    {
        public const string Principal = $"{Home}/productos";

        public const string Busqueda = $"{Principal}";
        public const string Listado = $"{Principal}/listado";

        public const string Crear = $"{Principal}";

        public class Movimientos
        {
            public const string Principal = $"{Productos.Principal}/movimientos";

            public const string Crear = $"{Principal}";
        }
    }
}
