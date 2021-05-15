using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FruitStore.Domain.Entities
{
    public class Role : IIdentityEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        private ICollection<User> _users { get; set; }
        public virtual IReadOnlyCollection<User> Users { get { return _users as Collection<User>; } }

        public Role()
        {
            _users = new Collection<User>();
        }
    }
}
