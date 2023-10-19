// See https://aka.ms/new-console-template for more information
using dotNetKakfaConsle.Repositories;
using dotNetKakfaConsole.Consumer.RepositoryImpl;

var dotnetKafka = new dotNetKafkaConsumer();
dotnetKafka.Listen(Console.WriteLine);

//Console.WriteLine("Hello, World!");
