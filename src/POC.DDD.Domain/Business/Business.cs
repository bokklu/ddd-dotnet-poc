namespace POC.DDD.Domain.Business
{
    public class Business
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;

        private Business(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Business CreateNew(string name) => new(default, name);

        public static Business LoadExisting(int id, string name) => new(id, name);

        //Can be used if you return Id from repo layer
        //public static Business WithId(int id, Business business) => new(id, business.Name);
    }
}
