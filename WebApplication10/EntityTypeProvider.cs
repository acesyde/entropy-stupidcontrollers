namespace WebApplication10
{
    using Framework.StupidControllers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using WebApplication10.Models;

    public class EntityTypeProvider : IEntityTypeProvider
    {
        public IList<TypeInfo> GetEntities()
        {
            return new List<TypeInfo>
            {
                typeof(Application).GetTypeInfo()
            };
        }
    }
}
