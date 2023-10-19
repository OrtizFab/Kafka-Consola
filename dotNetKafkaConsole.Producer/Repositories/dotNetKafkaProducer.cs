using Confluent.Kafka.Serialization;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetKafkaConsole.Producer.Repositories
{
    public class dotNetKafkaProducer : IdotnetKafkaProducer
    {
        public void Producer(string message)
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" },
                { "enable.auto.commit", "false" }

            };
            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                producer.ProduceAsync("dotnettopic", null, message);
                producer.Flush(10);
            }
        }
    }
}
