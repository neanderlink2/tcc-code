using System;

namespace ProgramAcad.Common.Models
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Status = true;
        }

        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public bool Status { get; protected set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity compareTo))
                return false;

            if (Id.Equals(compareTo.Id))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " {EntityId=" + Id + "}";
        }

        public virtual void Deactivate()
        {
            Status = false;
        }
    }
}
