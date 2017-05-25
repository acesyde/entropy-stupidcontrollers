namespace Framework.StupidControllers.Extensions
{
    using Attributes;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System.Linq;

    internal static class ControllerModelExtensions
    {
        public static void RemoveActionsFor<T>(this ControllerModel controller, Verb verb) where T : HttpMethodAttribute
        {
            var actions = controller.Actions.Where(m => m.Attributes.Any(a => a.GetType() == typeof(T))).ToList();
            foreach (var action in actions)
            {
                controller.Actions.Remove(action);
            }
        }
    }
}
