using Microsoft.AspNetCore.WebUtilities;

namespace UrlShorterExample.Models
{
    public class ShortLink 
    {
        public int Id { get; set; } 

        public string GetUrlChunk()=> WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id));

        public int GetId(string urlChunk)
        {
            if(!string.IsNullOrEmpty(urlChunk))
                return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(urlChunk));
            return 0;
        }

    }
}
