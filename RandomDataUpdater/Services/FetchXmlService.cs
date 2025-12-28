using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

namespace RandomDataUpdater.Services
{
    public static class FetchXmlService
    {
        public static List<Entity> GetRecords(
            IOrganizationService service,
            string fetchXml)
        {
            var result = service.RetrieveMultiple(new FetchExpression(fetchXml));
            return result.Entities.ToList();
        }
    }
}
