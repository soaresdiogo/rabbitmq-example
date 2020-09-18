using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost"};
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting started with .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent message {0}...", message);
            }

            Console.WriteLine("Press [enter] to exit the Sender App...");
            Console.ReadLine();
        }
    }
}
