namespace QUICK_INVENTORY.Shared.Helpers;

public class ApplicationApiEndpoints
{
    private const string Home = "api";

    public class Productos
    {
        public const string Principal = $"{Home}/productos";

        public const string Warnings = $"{Principal}/warnings";

        public class Movimientos
        {
            public const string Principal = $"{Productos.Principal}/movimientos";
        }
    }

    public class Inventario
    {
        public const string Principal = $"{Home}/inventario";

        public class Cortes
        {
            public const string Principal = $"{Inventario.Principal}/cortes";

            public const string Actual = $"{Principal}/actual";
        }
    }
}
