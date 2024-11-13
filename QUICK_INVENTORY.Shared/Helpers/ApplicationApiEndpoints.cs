namespace QUICK_INVENTORY.Shared.Helpers;

public class ApplicationApiEndpoints
{
    private const string Home = "api";

    public class Productos
    {
        public const string Principal = $"{Home}/productos";

        public class Movimientos
        {
            public const string Principal = $"{Productos.Principal}/movimientos";
        }
    }
}
