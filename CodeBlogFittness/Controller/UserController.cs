using Fitness.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CodeBlogFitness.BL.Controller
{/// <summary>
/// контролер пользователя
/// </summary>
    public class UserController
    {/// <summary>
     /// пользователь приложение
     /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {//ToDO: Проверка
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("имя пользователя не может біть пустім",nameof(userName));
            }
            
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser ==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
           
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
        public void SetNewUserData(string genderName,DateTime birthDate,double weight=1,double height=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }
        /// <summary>
        /// Получить сохраненій список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User>GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }

        }
    }
}
