using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Utils
{
    public static class Base64Converter
    {
        public static string ConvertBase64ToFile(string base64)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"FilmImages\", Guid.NewGuid().ToString()+".png");
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path,bytes);
            return path;
        }

        public static string ConvertFileToBase64(string path)
        {
            if (path == null)
            {
                return null;
            }
            byte[] bytes = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
