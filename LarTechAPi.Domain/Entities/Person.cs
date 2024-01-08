using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarTechAPi.Domain.Entities
{
    public sealed class Person
    {
        public Person(string name, DateTime birthday, bool isActive)
        {
            Name = name;
            Birthday = birthday;
            IsActive = isActive;
        }

        public Person(int id, string name, DateTime birthday, bool isActive)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            IsActive = isActive;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public bool IsActive { get; private set; }

        public void StatusUpdate(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
