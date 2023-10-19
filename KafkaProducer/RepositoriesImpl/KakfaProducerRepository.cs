using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using KafkaProducer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducer.RepositoriesImpl
{
    public class KakfaProducerRepository : IKakfaProducerRepository
    {
        public void Produce(string message)
        {
            var config = new Dictionary<string, object>
            {
               
                { "bootstrap.servers", "localhost:9092" },
              

            };
            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                producer.ProduceAsync("dotnettopic", null, message);
                producer.Flush(10);
            }
        }
    }
}
