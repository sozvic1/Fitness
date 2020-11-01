﻿using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.model;
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
            var eatingController = new EatingController(userController.CurrentUser);
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
            Console.WriteLine("Что ві хотите сделать? ");
            Console.WriteLine("Е -ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if(key.Key ==ConsoleKey.E)
            {
              var foods =  EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key}-{item.Value}");
                }
            }
            Console.ReadLine();
           
        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var callories = ParseDouble("каллорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, callories, prots, fats, carbs);
            return (Food:product, Weight:weight);
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
