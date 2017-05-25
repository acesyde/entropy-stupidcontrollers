using System;

namespace Framework.StupidControllers.Attributes
{
    public class EntityConventionAttribute : Attribute
    {
        public string ControllerName { get; private set; }
        public string Template { get; private set; }
        public Verb[] Verbs { get; set; }
        public EntityConventionAttribute(string controllerName, string template, params Verb[] verbs)
        {
            ControllerName = controllerName;
            Template = template;
            Verbs = verbs;
        }
    }
}
