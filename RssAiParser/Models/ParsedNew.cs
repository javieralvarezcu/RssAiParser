using System.ComponentModel.DataAnnotations;

namespace RssAiParser.Models
{
    public class ParsedNew
    {
        [Key]
        public Guid Id { get; set; }
        public string? Titular { get; set; }
        public string? Subtitulo { get; set; }
        public string? Cuerpo { get; set; }
        public DateTime? ParsingDate { get; set; }

        public string OriginalId { get; set; }
        public OriginalNew Original { get; set; }
    }
}
