namespace WebApplication10.Models
{
    using Framework.StupidControllers;
    using Framework.StupidControllers.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [EntityConvention("applications", "api/applications", Verb.GET, Verb.POST, Verb.DELETE, Verb.PUT)]
    public class Application : IBaseEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [EntityConvention("applicationTranslations", "api/applications/{id}/stores", Verb.GET, Verb.POST, Verb.DELETE, Verb.PUT)]
        public ICollection<Translation> Translations { get; set; }
        [EntityConvention("applicationStores", "api/applications/{id}/stores", Verb.GET, Verb.POST, Verb.DELETE, Verb.PUT)]
        public ICollection<Store> Stores { get; set; }
    }
}
