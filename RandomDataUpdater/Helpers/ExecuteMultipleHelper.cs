using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System.Collections.Generic;

namespace RandomDataUpdater.Helpers
{
    public class ExecuteMultipleHelper
    {
        private readonly ExecuteMultipleRequest _request =
            new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                },
                Requests = new OrganizationRequestCollection()
            };

        public void AddUpdate(Entity entity)
        {
            _request.Requests.Add(new UpdateRequest { Target = entity });
        }

        public void Execute(IOrganizationService service)
        {
            if (_request.Requests.Count > 0)
                service.Execute(_request);
        }
    }
}
