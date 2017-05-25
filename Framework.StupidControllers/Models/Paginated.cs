namespace Framework.StupidControllers.Models
{
    using System.Collections.Generic;

    public class Paginated<T, TIdentifier> where T : IBaseEntity<TIdentifier>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public ICollection<T> Items { get; set; }
    }
}
