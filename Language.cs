namespace Commerce.Api.Model
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string NativeName { get; set; }
        public string ExtLanguageId { get; set; }
        public string Iso639AlphaCode3 { get; set; }
        public string Iso639AlphaCode2 { get; set; }
        public int UiSortOrder { get; set; }
    }
}