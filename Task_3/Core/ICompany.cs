namespace Core
{
    public interface ICompany
    {
        string Name { get; }
        IStation Station { get; set; }
        IClientHandler ClientHandler { get; set; }

    }
}
