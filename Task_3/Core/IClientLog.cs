namespace Core
{
    public interface IClientLog
    {
        IClient Client { get; }
        IConnection Connections { get; }
        decimal Cost { get; }
    }
}
