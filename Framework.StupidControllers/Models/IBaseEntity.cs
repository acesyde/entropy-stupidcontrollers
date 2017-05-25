namespace Framework.StupidControllers.Models
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
