using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetKafkaConsole.Producer.Repositories
{
    public interface IdotnetKafkaProducer
    {
        void Producer(string message);
    }
}
