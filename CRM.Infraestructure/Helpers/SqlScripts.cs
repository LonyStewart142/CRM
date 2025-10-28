

using System.Reflection;

namespace CRM.Infraestructure.Helpers
{
    internal static class SqlScripts
    {
        private static readonly string RootPath = Path.Combine(
     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
     "SqlScripts"
 );
        public static string GetFileAsString(string filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException(filepath);

            return File.ReadAllText(filepath);
        }

        public static string FileConsultaRadicacionesScript => GetFileAsString(Path.Combine(RootPath, "obtieneProductividadPorEjecutivo.sql"));

    }
}
