
namespace Framework.StupidControllers.Attributes
{
    using System;

    public class ControllerNameAttribute : Attribute
    {
        public string Name { get; private set; }
        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
