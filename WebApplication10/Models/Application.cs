using Framework.StupidControllers;
using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public class Application : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public ICollection<Translation> Translations { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
