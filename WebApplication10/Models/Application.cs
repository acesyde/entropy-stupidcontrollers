namespace WebApplication10.Models
{
    using Framework.StupidControllers;
    using Framework.StupidControllers.Attributes;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [ControllerName("applications")]
    [Verb(Verb.GET, Verb.POST, Verb.DELETE)]
    [Route("api/applications")]
    public class Application : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        [ControllerName("applicationTranslations")]
        //[Route("api/applications/{id}/translations")]
        [Verb(Verb.GET, Verb.POST, Verb.DELETE, Verb.PUT)]
        public ICollection<Translation> Translations { get; set; }

        [ControllerName("applicationStores")]
        //[Route("api/applications/{id}/stores")]
        [Verb(Verb.GET, Verb.POST, Verb.DELETE, Verb.PUT)]
        public ICollection<Store> Stores { get; set; }
    }
}
