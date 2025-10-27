using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infraestructure.Helpers
{
    internal static class SqlScripts
    {
        private readonly static string RootPath = Path.Combine(Environment.CurrentDirectory, "SqlScripts");
        public static string GetFileAsString(string filepath)
        {
            if (!File.Exists(filepath))
                throw new FileNotFoundException(filepath);

            return File.ReadAllText(filepath);
        }

        public static string FileConsultaRadicacionesScript => GetFileAsString(Path.Combine(RootPath, "obtieneProductividadPorEjecutivo.sql"));

    }
}
