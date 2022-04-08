using CampeonatoBrasileiro.Mensageiro.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Mensageiro
{
    public class Send : ISend
    {
        public void EnviarMensagem(string mensagem)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "partida",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(mensagem);

                channel.BasicPublish(exchange: "",
                                             routingKey: "partida",
                                             basicProperties: null,
                                             body: body);
                Console.WriteLine("Mensagem enviada", mensagem);
            }

        }
    }
}
