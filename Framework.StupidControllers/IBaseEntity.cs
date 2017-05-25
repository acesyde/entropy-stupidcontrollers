namespace Framework.StupidControllers
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
