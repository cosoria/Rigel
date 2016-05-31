using System;

namespace Rigel.Core.Data
{
    public abstract class Entity : IEntity, IEquatable<Entity>
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime UpdatedOn { get; set; }

        protected Entity()
        {
            CreatedNow();
        }

        public void CreatedNow()
        {
            this.CreatedOn = SystemTime.UtcNow.DateTime;
            this.UpdatedOn = SystemTime.UtcNow.DateTime;
        }

        public void UpdatedNow()
        {
            this.UpdatedOn = SystemTime.UtcNow.DateTime;
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return Id == other.Id;
        }

        public override string ToString()
        {
            return string.Format("{{\"{0}.Id\"={1}}}", this.GetFriendlyTypeName(), Id);
        }

        public override bool Equals(object obj)
        {

            var other = obj as Entity;

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }
            
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        protected virtual string GetFriendlyTypeName()
        {
            return this.GetType().FullName;
        }
    }

    public abstract class DetachedEntity : Entity, IDetachedEntity
    {
        public EntityState EntityState { get; set; }
    }
}