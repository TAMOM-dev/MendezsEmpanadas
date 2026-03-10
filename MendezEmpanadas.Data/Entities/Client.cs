

namespace MendezEmpanadas.Data.Entities
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string CellNumber { get; private set; } = string.Empty;

        public Client() { }

        public Client(string name, string CellPhone)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CellNumber =  CellNumber ?? string.Empty;
        }

    }
}
