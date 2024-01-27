using Flunt.Notifications;

namespace Payment.Context.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; private set; }
    }
}
