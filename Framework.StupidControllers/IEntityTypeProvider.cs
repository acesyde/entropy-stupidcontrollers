namespace Framework.StupidControllers
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IEntityTypeProvider
    {
        IList<TypeInfo> GetEntities();
    }
}
