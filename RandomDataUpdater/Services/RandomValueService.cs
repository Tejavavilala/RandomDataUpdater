using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using RandomDataUpdater.Models;
using System;
using System.Linq;

namespace RandomDataUpdater.Services
{
    public static class RandomValueService
    {
        public static object Generate(
            IOrganizationService service,
            AttributeMetadata attr,
            MockType mockType,
            Random rnd)
        {
            // 🚫 NEVER generate DateTime
            if (attr.AttributeType == AttributeTypeCode.DateTime)
                return null;

            switch (mockType)
            {
                case MockType.String:
                    return "TXT_" + Guid.NewGuid().ToString("N").Substring(0, 6);

                case MockType.Number:
                    return rnd.Next(1, 100);

                case MockType.Boolean:
                    return rnd.Next(0, 2) == 1;

                case MockType.Picklist:
                    var pick = attr as EnumAttributeMetadata;
                    if (pick?.OptionSet?.Options == null || !pick.OptionSet.Options.Any())
                        return null;

                    var option = pick.OptionSet.Options[rnd.Next(pick.OptionSet.Options.Count)];
                    return new OptionSetValue(option.Value.Value);

                case MockType.Lookup:
                    var lookup = attr as LookupAttributeMetadata;
                    if (lookup?.Targets == null || lookup.Targets.Length == 0)
                        return null;

                    var target = lookup.Targets[0];
                    var qe = new QueryExpression(target)
                    {
                        ColumnSet = new ColumnSet(false),
                        TopCount = 50
                    };

                    var list = service.RetrieveMultiple(qe).Entities;
                    if (!list.Any()) return null;

                    var chosen = list[rnd.Next(list.Count)];
                    return new EntityReference(target, chosen.Id);

                default:
                    return null;
            }
        }
    }
}
