// See https://aka.ms/new-console-template for more information
using KafkaProducer.Entities;
using KafkaProducer.RepositoriesImpl;


//variables
BankOperations objLoan = new BankOperations();
bool exit = false;
int opc = 0;
string message;
string operationCode = string.Empty;
while (!exit)
{
    Menu();
    Console.SetCursorPosition(52, 6);
    //Console.BackgroundColor = ConsoleColor.Green;
    opc = Convert.ToInt32(Console.ReadLine());
    switch (opc)
    {
        case 1:
            operationCode = "0001";
            Console.SetCursorPosition(32, 8);
            Console.Write("Digite customer Id: ");
            objLoan.ClientId = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 9);
            Console.Write("Digite capital: ");
            objLoan.Capital = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 10);
            Console.Write("Digite Monthly rates: ");
            objLoan.rate = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(32, 11);
            Console.Write("Digite number of  days: ");
            objLoan.days = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 12);

            var res0 = (objLoan.ftdRates());
            if (res0 != 0)
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)1;
            }
            else
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)2;

            }
            Console.WriteLine(res0);
            message = "Operation successfully " + res0 + " " + DateTime.Now.ToString() + " status: " + objLoan.Operationstatus;
            var producer = new KakfaProducerRepository();
            producer.Produce(message);
            Console.ReadLine();
            Console.Clear();
            break;
        case 2:
            operationCode = "0002";
            Console.SetCursorPosition(32, 8);
            Console.Write("Digite customer Id: ");
                objLoan.ClientId = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 9);
            Console.Write("Digite capital: ");
                objLoan.Capital = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 10);
            Console.Write("Digite Monthly rates: ");
                objLoan.rate = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(32, 11);
            Console.Write("Digite number of  periods: ");
                objLoan.period = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(32, 12);
            var res =(objLoan.Totalpayment());
            if (res != null)
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)1;
            }
            else
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)2;

            }
            message = "Operation successfully " + res + " " + DateTime.Now.ToString() + " status: " + objLoan.Operationstatus;
                var producer0 = new KakfaProducerRepository();
                producer0.Produce(message);
                Console.ReadLine();
            Console.Clear();
            break;
        case 3:
            operationCode = "0003";
            Console.SetCursorPosition(35, 8);
            Console.Write("Digite Customer ID: ");
            objLoan.ClientId = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(35, 9);
            Console.Write("Digite capital: ");
            objLoan.Capital = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(35, 10);
            Console.Write("Digite Monthly Rates: ");
            objLoan.rate = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(35, 11);
            Console.Write("Digite Term: ");
            objLoan.period = Convert.ToInt32(Console.ReadLine());
            string mstring = String.Format("{0:C}", objLoan.mortageMonthlyFee());
            if (mstring != null)
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)1;
                Console.SetCursorPosition(35, 13);
                Console.WriteLine(mstring);
            }
            else
            {
                objLoan.Operationstatus = (BankOperations.OperationStatus)2;

            }
            message = "Operation successfully " + operationCode + " " +mstring + " " + DateTime.Now.ToString() + " staus: " + objLoan.Operationstatus;
            var producer2 = new KakfaProducerRepository();
            producer2.Produce(message);
            Console.ReadKey();
            Console.Clear();
            break;
      
        case 4:
            exit = true;
            break;
            default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option");
            Console.Clear();
            break; 
}
    
}

static void Menu()
{
    string title = "Dotnet Console with Kafka -  producer and Consumer\n";
    string one = "1. Apply for a fixed Term Deposit";
    string two = "2. Apply for a loan";
    string three = "3. Apply for a Mortage";
    string four = "4. Exit";
    string five = "Choose option: ";

    Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
    Console.WriteLine(title.ToUpper());
    Console.SetCursorPosition((Console.WindowWidth - one.Length) / 2, Console.CursorTop);
    Console.WriteLine(one.ToUpper());
    Console.SetCursorPosition((Console.WindowWidth - two.Length) / 2, Console.CursorTop);
    Console.WriteLine(two.ToUpper());
    Console.SetCursorPosition((Console.WindowWidth - three.Length) / 2, Console.CursorTop);
    Console.WriteLine(three.ToUpper());
    Console.SetCursorPosition((Console.WindowWidth - four.Length) / 2, Console.CursorTop);
    Console.WriteLine(four.ToUpper());
    Console.SetCursorPosition((Console.WindowWidth - five.Length) / 2, Console.CursorTop);
    Console.WriteLine(five.ToUpper());
}

       