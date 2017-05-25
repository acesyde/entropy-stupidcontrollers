using Framework.StupidControllers;
using System.Collections.Generic;

namespace Framework.StupidControllers
{
    public class Paginated<T, TIdentifier> where T : IBaseEntity<TIdentifier>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public ICollection<T> Items { get; set; }
    }
}
