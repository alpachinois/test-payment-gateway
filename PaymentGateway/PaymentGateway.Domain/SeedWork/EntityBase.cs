using System;

namespace PaymentGateway.Domain.SeedWork
{
    public abstract class EntityBase : IEntity, IEquatable<EntityBase>
    {
        private const int HashMultiplier = 31;

        public Guid Id { get; private set; } = Guid.NewGuid();

        public bool Equals(EntityBase other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EntityBase);
        }

        public override int GetHashCode()
        {
            var hashCode = this.GetType().GetHashCode();

            return (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }


        /// <summary>
        /// To be used for test example, must not be in prod
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
