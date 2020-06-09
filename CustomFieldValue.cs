namespace Commerce.Api.Model
{
    public class CustomFieldValue
    {
        public long CustomFieldId { get; set; }
        public string ExtCustomFieldId { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string NativeValue { get; set; }
    }
}