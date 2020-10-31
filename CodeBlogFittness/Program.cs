using CodeBlogFitness.BL.Controller;
using Fitness.model;
using System;

namespace CodeBlogFittness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует Code Blog");
            
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
               
         
            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();

                double weight = ParseDouble("вес");
                var height = ParseDouble("рост");


                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
           
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождение пользователя");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверній формат даті рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while(true)
            {
                Console.WriteLine($"Введите {name}: ");
                if(double.TryParse(Console.ReadLine(),out double value))
                {
                    return value;

                }
                else
                {
                    Console.WriteLine($"Неверній формат {name}");
                }
            }
        }
    }
}
