using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlogFitness.BL.model
{
    [Serializable]
   public class Activity
    {
        public int Id { get; set; }
        public string Name { get;  }
        public double CaloriesPerMinute { get;  }
        public Activity(string name,double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
    }
}
