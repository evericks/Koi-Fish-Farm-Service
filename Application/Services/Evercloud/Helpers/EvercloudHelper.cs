using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Evercloud.Helpers
{
    public static class EvercloudHelper
    {
        public static string BuildUrl(string enpoint, string bucket, string path)
        {
            return enpoint + "/" + bucket + "/" + path;
        }

        public static string GetBoundaryFromContentType(string contentType)
        {
            var index = contentType.IndexOf("boundary=", StringComparison.Ordinal);
            if (index == -1) return null!;
            var boundaryValue = contentType[(index + "boundary=".Length)..];
            return boundaryValue;
        }

        public static string CreateSignature(string signature, string boundary)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(signature));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(boundary));
            var base64 = Convert.ToBase64String(hash);
            return base64.Replace('+', '-').Replace('/', '_').Replace("=", "");
        }
    }
}
