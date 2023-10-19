using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducer.Entities
{
    public class BankOperations
    {
        public int ClientId { get; set; }
        public int Capital { get; set; }
        public double rate { get; set; }         
        public int period { get; set; }
        public int days { get; set; }

        public OperationStatus Operationstatus { get; set; }


        public enum OperationStatus
        {
            IN_PROGRESS,
            COMPLETED,
            REJECTED
        }

        public double ftdRates()
        {
            return Math.Round(Capital * (rate / 100) * days / 365,2);
        }
        public string Totalpayment()
        {
            var total = Math.Round(Capital * Math.Pow((rate/100 + 1), period),2);
            var intereses = total - Capital;
            return "Monthly fee: " + total + " Total rates: " + intereses;
                
        }

        public string mortageMonthlyFee()        {
            
            var quote = Capital *rate/ 1 * (1 + rate / 100) - period;
            return "Monthly Fee: " + quote;

        }

    }
}
