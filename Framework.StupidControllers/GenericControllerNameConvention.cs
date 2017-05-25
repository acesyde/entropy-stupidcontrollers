namespace Framework.StupidControllers
{
    using Framework.StupidControllers.Attributes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using System;
    using System.Linq;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() != typeof(GenericController<,>))
            {
                throw new Exception("Not a generic controller!");
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0].GetTypeInfo();

            var attributeController = entityType.GetCustomAttribute<ControllerNameAttribute>();
            var attributeVerb = entityType.GetCustomAttribute<VerbAttribute>();
            var attributeRoute = entityType.GetCustomAttribute<RouteAttribute>();

            controller.ControllerName = attributeController.Name;

            if(!attributeVerb.Verbs.Contains(Verb.GET))
            {
                var action = controller.Actions.FirstOrDefault(m => m.ActionName == "Get");
                controller.Actions.Remove(action);

                action = controller.Actions.FirstOrDefault(m => m.ActionName == "GetById");
                controller.Actions.Remove(action);
            }

            if (!attributeVerb.Verbs.Contains(Verb.PUT))
            {
                var action = controller.Actions.FirstOrDefault(m => m.ActionName == "Put");
                controller.Actions.Remove(action);
            }

            if (!attributeVerb.Verbs.Contains(Verb.POST))
            {
                var action = controller.Actions.FirstOrDefault(m => m.ActionName == "Post");
                controller.Actions.Remove(action);
            }

            if (!attributeVerb.Verbs.Contains(Verb.DELETE))
            {
                var action = controller.Actions.FirstOrDefault(m => m.ActionName == "Delete");
                controller.Actions.Remove(action);
            }

        }
    }
}
