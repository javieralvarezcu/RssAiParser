using System.ComponentModel.DataAnnotations;

namespace RssAiParser.Models
{
    public class OriginalNew
    {
        [Key]
        [MaxLength(500)]
        public string Url { get; set; }
        public string? Titular { get; set; }
        public string? Subtitulo { get; set; }
        public string? Cuerpo { get; set; }
        public DateTime? ProdDate { get; set; }

        public List<ParsedNew>? ParsedNews { get; set; }
    }
}
