using Flunt.Notifications;
using Payment.Context.Domain.Commands;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enuns;
using Payment.Context.Domain.Repositories;
using Payment.Context.Domain.Services;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Commands;
using Payment.Context.Shared.Handlers;


namespace Payment.Context.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePaypalSubscription>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IEmailServices _emailServices;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailServices emailServices)
        {
            _studentRepository = studentRepository;
            _emailServices = emailServices;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validations
            command.Validate();

            if(!command.IsValid) 
            {
                AddNotifications(command);
                return new CommandResult(false, "Assinatura nao realizada");
            }

            // Verificar se Documento já está cadastrado
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "CPF ja existe");
                
            }
            // Verificar se E-mail já está cadastrado
            if(_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Email ja exixte");
               
            }


            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood,
                command.City, command.State, command.ZipCode, command.Country);
           
            
            // Gerar as Entidades
            var student = new Student(name, email, document);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PayedDate,
                command.ExpireDate,
                command.Total,
                command.TotalPayed,
                address,
                document,
                command.Payer,
                email
                );


            // Relacionamentos
            subscription.AddPayment( payment );
            student.AddSubscription( subscription );

            // Agrupar as Validações
            AddNotifications(name,document,email,address, student,subscription,payment);

            // Checar as notificações
            if(!IsValid)
            {
                return new CommandResult(false, "Assinatura nao realizada");
            }

            // Salvar as Informações
            _studentRepository.CreateSubscription(student);

            // Enviar E-mail de boas vindas
            _emailServices.Send(student.Name.ToString(),student.Email.Address,"Seja bem vindo","Obrigado por comprar");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada");
        }

        public ICommandResult Handle(CreatePaypalSubscription command)
        {
            // Fail Fast Validations
            //command.Validate();

            //if (!command.IsValid)
            //{
            //    AddNotifications(command);
            //    return new CommandResult(false, "Assinatura nao realizada");
            //}

            // Verificar se Documento já está cadastrado
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "CPF ja existe");

            }
            // Verificar se E-mail já está cadastrado
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Email ja exixte");

            }


            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood,
                command.City, command.State, command.ZipCode, command.Country);


            // Gerar as Entidades
            var student = new Student(name, email, document);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PayedDate,
                command.ExpireDate,
                command.Total,
                command.TotalPayed,
                address,
                document,
                command.Payer,
                email
                );


            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Checar as notificações
            if (!IsValid)
            {
                return new CommandResult(false, "Assinatura nao realizada");
            }

            // Salvar as Informações
            _studentRepository.CreateSubscription(student);

            // Enviar E-mail de boas vindas
            _emailServices.Send(student.Name.ToString(), student.Email.Address, "Seja bem vindo", "Obrigado por comprar");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada");
        }
    }
}
