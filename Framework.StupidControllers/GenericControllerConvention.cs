namespace Framework.StupidControllers
{
    using Framework.StupidControllers.Attributes;
    using Framework.StupidControllers.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using System;
    using System.Linq;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() != typeof(GenericController<,>))
            {
                throw new Exception("Not a generic controller!");
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0].GetTypeInfo();
            var entityConventionAttribute = entityType.GetCustomAttribute<EntityConventionAttribute>();

            controller.ControllerName = entityConventionAttribute.ControllerName;

            if(entityConventionAttribute == null)
            {
                throw new Exception($"Entity must have {nameof(EntityConventionAttribute)}");
            }

            var selector = controller.Selectors.FirstOrDefault(m => m.AttributeRouteModel != null);
            if(selector != null)
            {
                selector.AttributeRouteModel.Template = entityConventionAttribute.Template;
            }

            if(!entityConventionAttribute.Verbs.Contains(Verb.GET))
                controller.RemoveActionsFor<HttpGetAttribute>(Verb.GET);

            if (!entityConventionAttribute.Verbs.Contains(Verb.PUT))
                controller.RemoveActionsFor<HttpPutAttribute>(Verb.PUT);

            if (!entityConventionAttribute.Verbs.Contains(Verb.POST))
                controller.RemoveActionsFor<HttpPostAttribute>(Verb.POST);

            if (!entityConventionAttribute.Verbs.Contains(Verb.DELETE))
                controller.RemoveActionsFor<HttpDeleteAttribute>(Verb.DELETE);
        }

        
    }
}
