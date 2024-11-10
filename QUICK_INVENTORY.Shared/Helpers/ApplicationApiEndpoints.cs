namespace QUICK_INVENTORY.Shared.Helpers;

public class ApplicationApiEndpoints
{
    private const string Principal = "api";

    public class Productos
    {
        public const string Producto = $"{Principal}/productos";

        public const string Busqueda = $"{Producto}";
        public const string Listado = $"{Producto}/listado";

        public const string Crear = $"{Producto}";

        public class Movimientos
        {
            public const string Movimiento = $"{Producto}/movimientos";

            public const string Crear = $"{Movimiento}";
        }
    }
}
