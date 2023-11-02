using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ConsoleApp4
{


    namespace ConsoleApp4
    {
      
      

        internal class Program
        {

            static void Main(string[] args)
            {

                var rand = new Random();

                // Создаем объект для сериализации
                Person person = new Person("Tom", 25);

                // Создаем поток для записи в файл
                using (FileStream fs = new FileStream("person.dat", FileMode.Create))
                {
                    // Создаем объект для бинарной сериализации
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Сериализуем объект в поток
#pragma warning disable SYSLIB0011 // Тип или член устарел
                    formatter.Serialize(fs, person);
#pragma warning restore SYSLIB0011 // Тип или член устарел
                }

                // Создаем поток для чтения из файла
                using (FileStream fs = new FileStream("person.dat", FileMode.Open))
                {
                    // Создаем объект для бинарной десериализации
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Десериализуем объект из потока
#pragma warning disable SYSLIB0011 // Тип или член устарел
                    Person person2 = (Person)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Тип или член устарел
                    // Выводим свойства объекта
                    Console.WriteLine("BinaryFormatter Person");

                    Console.WriteLine(person2.Name); // Tom
                    Console.WriteLine(person2.Age); // 25
                }

                // Создаем объект для сериализации
                Person persons = new Person("Tom", 25);

                // Создаем поток для записи в файл
                using (FileStream fs = new FileStream("persons.json", FileMode.Create))
                {
                    // Создаем объект для сериализации в JSON
                    DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Person));
                    // Сериализуем объект в поток
                    formatter.WriteObject(fs, persons);
                }


                // Создаем поток для чтения из файла
                using (FileStream fs = new FileStream("persons.json", FileMode.Open))
                {
                    // Создаем объект для десериализации из JSON
                    DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Person));
                    // Десериализуем объект из потока
                    Person person2 = (Person)formatter.ReadObject(fs);

                    Console.WriteLine("DataContractJsonSerializer Person ");
                    // Выводим свойства объекта
                    Console.WriteLine(person2.Name); // Tom
                    Console.WriteLine(person2.Age); // 25
                }

                Book book = new Book("C#", "Максим", 18, 180000000000000);



                string NameFile = Environment.CurrentDirectory + "\\book";
                if (File.Exists(NameFile + ".xml"))
                {
                    NameFile = NameFile + rand.Next(101) as String;
                }

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));

                using (FileStream fs1 = new FileStream(NameFile + ".xml", FileMode.OpenOrCreate))
                {
                    //File.Replace("person.xml", NameFile + ".xml", NameFile + ".xml");
                    xmlSerializer.Serialize(fs1, book);

                    Console.WriteLine();
                    Console.WriteLine("Файл из xml сохраняет ");

                    Console.WriteLine("XmlSerializer Book ");

                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Age: {book.Year}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Price: {book.Price}");

                }

                Book booKS = null;
                XmlSerializer xmlSerializers = new XmlSerializer(typeof(Book));
                using (FileStream fs = new FileStream(NameFile + ".xml", FileMode.Open))
                {
                    booKS = xmlSerializers.Deserialize(fs) as Book;
                    Console.WriteLine();
                    Console.WriteLine("Файл из xml считывает ");



                    Console.WriteLine("Deserialize Book ");


                    Console.WriteLine($"Title: {booKS.Title}");
                    Console.WriteLine($"Age: {booKS.Year}");
                    Console.WriteLine($"Author: {booKS.Author}");
                    Console.WriteLine($"Price: {booKS.Price}");



                }
        

                Console.ReadLine();


            }
        }
    }
}