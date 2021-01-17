using Core;

namespace Billing.Company_
{
    public class Company : ICompany
    {
        public Company(string name, IStation station)
        {
            Name = name;
            Station = station;
            ClientHandler = new ClientHandler(this);
        }

        public string Name { get; }
        public IStation Station { get; set; }
        public IClientHandler ClientHandler { get; set; }

    }
}

