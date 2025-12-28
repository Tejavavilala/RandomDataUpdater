using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace RandomDataUpdater.Services
{
    public static class UndoService
    {
        private static readonly Stack<Entity> _undo = new Stack<Entity>();

        public static void Store(Entity original)
        {
            _undo.Push(original);
        }

        public static void Undo(IOrganizationService service)
        {
            while (_undo.Count > 0)
            {
                service.Update(_undo.Pop());
            }
        }
    }
}
