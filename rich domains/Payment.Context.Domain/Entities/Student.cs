using Flunt.Validations;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Domain.Entities
{
    public class Student : Entity

    {
    
        private IList<Subscription> _subscriptions;
        public Student(Name name, Email email, Document documents)
        {
            Name = name;
            Email = email;
            Documents = documents;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, email, documents);

        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Documents { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
        

            foreach (var sub in Subscriptions) 
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                }
            }

           AddNotifications(new Contract<Student>().Requires().
           IsFalse(hasSubscriptionActive, "Student.Subscriptions","Voce ja possui um assinatura ativa").
           AreNotEquals(0,subscription.Payments.Count, "Student.Subscription.Payments","Esta Assinatura nao possui Pagamentos"));

           //AddNotification("Student.Subscriptions", "Voce ja possui um assinatura ativa");

            _subscriptions.Add(subscription);
        }

    }
}
