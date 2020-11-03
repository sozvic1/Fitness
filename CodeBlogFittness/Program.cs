using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.model;
using Fitness.model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceMeneger = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceMeneger.GetString("Hello", culture));


            Console.WriteLine(resourceMeneger.GetString("EnterName", culture));

            var name = Console.ReadLine();


            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения");

                double weight = ParseDouble("вес");
                var height = ParseDouble("рост");


                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            while (true)
            {
                Console.WriteLine(userController.CurrentUser);
                Console.WriteLine("Что ві хотите сделать? ");
                Console.WriteLine("Е -ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - віход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t {item.Key}-{item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                       
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortDateString()} c {item.Finish.ToShortDateString()} ");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }


                Console.ReadLine();
            }
        }

        private static (DateTime Begin,DateTime End,Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнение");
            var name = Console.ReadLine();
            var energy = ParseDouble("Расход энергии в минуту");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var activity = new Activity(name,energy);
            return (begin, end, activity);

        }

        private static (Food Food, double Weight) EnterEating()
    {
        Console.Write("Введите имя продукта: ");
        var food = Console.ReadLine();

        var callories = ParseDouble("каллорийность");
        var prots = ParseDouble("белки");
        var fats = ParseDouble("жиры");
        var carbs = ParseDouble("углеводы");

        var weight = ParseDouble("вес порции");
        var product = new Food(food, callories, prots, fats, carbs);
        return (Food: product, Weight: weight);
    }

    private static DateTime ParseDateTime(string value)
    {
        DateTime birthDate;
        while (true)
        {
            Console.WriteLine($"Введите {value} пользователя");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Неверній формат {value}");
            }
        }

        return birthDate;
    }

    private static double ParseDouble(string name)
    {
        while (true)
        {
            Console.WriteLine($"Введите {name}: ");
            if (double.TryParse(Console.ReadLine(), out double value))
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
