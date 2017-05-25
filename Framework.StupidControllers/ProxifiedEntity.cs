namespace Framework.StupidControllers
{
    using System;
    internal class ProxifiedEntity
    {
        public static T GenerateProxy<T>(Type T) where T : IBaseEntity<TIdentitifier>
        {
            Type[] ctorTypes = Type.EmptyTypes;

            // Create the proxy generation options.
            // This is how we tell Castle.DynamicProxy how to create the attribute.
            var proxyOptions = new Castle.DynamicProxy.ProxyGenerationOptions();

            // Create the proxy generator.
            var proxyGenerator = new Castle.DynamicProxy.ProxyGenerator();

            // Create the class proxy.
            var classArguments = new object[] { };
            return (T)proxyGenerator.CreateClassProxy(typeof(T), proxyOptions, classArguments);
        }
    }
}
