using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using dotNetKakfaConsle.Repositories;
using System.Text;

namespace dotNetKakfaConsole.Consumer.RepositoryImpl
{
    public class dotNetKafkaConsumer : IdotnetKafkaConsumer //Inherit
    {
        //delegate Action
        public void Listen(Action<string> message)
        {
            //dictionary stote data in key-value way
            var config = new Dictionary<string, object>
            {
                { "group.id","kafka"},
                { "bootstrap.servers", "localhost:9092" },
                { "enable.auto.commit", "false" } //not send authomatc updating 

            };
            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe("dotnettopic");
                consumer.OnMessage += (_, msg) =>
                {
                    message(msg.Value);
                };

                while (true)
                {
                    consumer.Poll(100);
                }
            }
        }
    }
}
