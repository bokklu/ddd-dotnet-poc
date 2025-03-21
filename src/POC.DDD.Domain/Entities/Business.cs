﻿namespace POC.DDD.Domain.Entities
{
    public class Business
    {
        public int Id { get; }
        public string Name { get; private set; } = string.Empty;

        private Business(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public static Business CreateNew(string name) => new(default, name);

        public static Business LoadExisting(int id, string name) => new(id, name);

        //Can be used if you return Id from repo layer
        //public static Business WithId(int id, Business business) => new(id, business.Name);
    }
}
