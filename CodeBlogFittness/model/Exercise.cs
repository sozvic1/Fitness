using Fitness.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlogFitness.BL.model
{
    [Serializable]
    public  class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity,User user )
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }


    }
}
