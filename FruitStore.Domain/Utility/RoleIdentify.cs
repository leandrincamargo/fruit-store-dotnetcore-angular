using System;

namespace FruitStore.Domain.Utility
{
    public class RoleIdentify
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private RoleIdentify(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static RoleIdentify Administrator { get; } =
            new RoleIdentify(Guid.Parse("41361f47-53bf-4084-965f-cabc95532565"), "Administrator");

        public static RoleIdentify Common { get; } =
            new RoleIdentify(Guid.Parse("5c646334-7f35-43f5-9a84-17a654fbdb32"), "Common");
    }
}
