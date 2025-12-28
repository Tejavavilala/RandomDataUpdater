using Microsoft.Xrm.Sdk.Metadata;

namespace RandomDataUpdater.Models
{
    public class FieldConfig
    {
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
        public AttributeTypeCode AttributeType { get; set; }

        public bool Selected { get; set; }

        public UpdateBehavior UpdateBehavior { get; set; }
        public MockType MockType { get; set; }
    }
}
