using CodeBlogFitness.BL.model;
using Fitness.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBlogFitness.BL.Controller
{
   public class ExerciseController:ControllerBase
    {
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";


        public ExerciseController(User user)
        {
            this.user = user??throw new ArgumentException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activityName,DateTime begin,DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activityName.Name);
            if(act==null)
            {
                Activities.Add(activityName);
                var exercise = new Exercise(begin, finish, activityName, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, finish, activityName, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
