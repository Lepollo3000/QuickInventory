namespace QUICK_INVENTORY.Client.Helpers;

internal static class ApplicationPages
{
    public const string Home = "/";

    public static class Productos
    {
        private const string Principal = $"{Home}productos";

        public const string Listado = $"{Principal}";
        public const string Crear = $"{Principal}/crear";

        public static class Movimientos
        {
            private const string Principal = $"{Productos.Principal}/movimientos";

            private const string Listado = $"{Principal}";

            public const string Entradas = $"{Listado}/entradas";
            public const string Salidas = $"{Listado}/salidas";
            public const string Crear = $"{Principal}/crear";
        }
    }

    public static class Inventario
    {
        private const string Principal = $"{Home}inventario";

        public const string Listado = $"{Principal}";

        public static class Corte
        {
            private const string Principal = $"{Inventario.Principal}/cortes";

            public const string Listado = $"{Principal}";

            public const string Actual = $"{Principal}/actual";
            public const string Crear = $"{Principal}/crear";
        }
    }
}
