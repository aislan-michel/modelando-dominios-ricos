using System.Collections.Generic;
using System;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        //private IList<string> Notifications;
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);

            /*
            if (string.IsNullOrEmpty(name.FirstName))
            {
                //Notifications.Add("Nome inválido");
                AddNotification("Name.FirstName", "Nome inválido.");
            }
            */
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach(var sub in _subscriptions)
            {
                if(sub.Active)
                {
                    hasSubscriptionActive = true;
                }
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
                .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Student.Subscriptions.Payments", "Esta assinatura não possui pagamentos"));

            /*
            // Se já tiver uma assinatura, cancela

            //Cancela todas as outras assinaturas, e coloca esta como principal
            foreach(var sub in Subscriptions)
            {
                sub.Inactivate();
            }

            _subscriptions.Add(subscription);
            */
        }
    }
}
