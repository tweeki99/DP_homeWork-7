using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_7.DIP
{
    // Интерфейс отправки сообщения
    public interface IMessage
    {
        void SendMessage();
    }

    // Класс отправки по Email
    public class Email : IMessage
    {
        public string ToAddress { get; set; }
        public string Message { get; set; }
        public void SendMessage()
        {
            Console.WriteLine("Отправлено письмо на адрес {0}, с текстом: {1}", ToAddress, Message);
        }
    }

    // Класс отправки по Sms
    public class SMS : IMessage
    {
        public string ToPhoneNumber { get; set; }
        public string Message { get; set; }
        public void SendMessage()
        {
            Console.WriteLine("Отправлено смс на номер {0}, с текстом: {1}", ToPhoneNumber, Message);
        }
    }

    // Выполняет действия в зависимости от того, какой способ отправки выбран
    public class MessageService
    {
        public IMessage Sender { get; set; }

        public MessageService(IMessage sender)
        {
            this.Sender = sender;
        }
        public void Send()
        {
            Sender.SendMessage();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MessageService notification = new MessageService(new Email { ToAddress = "danil@gmail.com", Message = "Privet" });
            notification.Send();
            notification.Sender = new SMS { ToPhoneNumber = "+77011230322", Message = "Privet" };
            notification.Send();
            Console.ReadLine();
        }
    }
}
