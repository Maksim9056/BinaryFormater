using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace ConsoleApp4
{


 

    internal class Program
    {

        [Serializable] // Атрибут, указывающий, что класс может быть сериализован
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {   
            // Создаем объект для сериализации
            Person person = new Person { Name = "Tom", Age = 25 };

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
                Console.WriteLine(person2.Name); // Tom
                Console.WriteLine(person2.Age); // 25
            }


           Console.ReadLine();


        }
    }
}