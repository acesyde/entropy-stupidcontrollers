namespace Framework.StupidControllers
{
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
            // This is designed to run after the default ControllerTypeProvider, so the list of 'real' controllers
            // has already been populated.
            foreach (var entityType in _provider.GetEntities())
            {
                var typeName = entityType.Name + "sController";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    var genericType = entityType.ImplementedInterfaces.First().GenericTypeArguments[0];
                    // There's no 'real' controller for this entity, so add the generic version.
                    var controllerType = typeof(GenericController<,>).MakeGenericType(entityType.AsType(), genericType).GetTypeInfo();
                    ProxifiedEntity.GenerateProxy()
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
}
