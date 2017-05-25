namespace Framework.StupidControllers
{
    using Framework.StupidControllers.Attributes;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        readonly IEntityTypeProvider _provider;
        public GenericControllerFeatureProvider(IEntityTypeProvider provider)
        {
            _provider = provider;
        }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var entityType in _provider.GetEntities())
            {
                var entityConventionAttribute = entityType.GetCustomAttribute<EntityConventionAttribute>();

                if (entityConventionAttribute == null)
                    continue;

                var typeName = entityConventionAttribute.ControllerName + "Controller";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    var genericType = entityType.ImplementedInterfaces.First().GenericTypeArguments[0];
                    var controllerType = typeof(GenericController<,>).MakeGenericType(entityType.AsType(), genericType).GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }

                var properties = entityType.GetProperties();
                foreach (var property in properties)
                {
                    var propertyEntityAttribute = property.GetCustomAttribute<EntityConventionAttribute>();
                    if(propertyEntityAttribute != null)
                    {

                    }
                }
            }
        }
    }
}
