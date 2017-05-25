using System;

namespace Framework.StupidControllers.Attributes
{
    public class VerbAttribute : Attribute
    {
        public Verb[] Verbs { get; private set; }
        public VerbAttribute(params Verb[] verbs)
        {
            Verbs = verbs;
        }
    }

    public enum Verb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
