using System.Text;

namespace XGame.Domain.Extensions
{
   public static class StringExtension
    {
        public static string ConverterMd5(this string Senha)
        {
            if (string.IsNullOrEmpty(Senha)) return "";
            var senha = (Senha += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(senha));
            var substring = new StringBuilder();
            foreach (var t in data)
                substring.Append(t.ToString("x2"));
            return substring.ToString();

                    }
    }
}
