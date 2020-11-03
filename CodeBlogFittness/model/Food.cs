using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlogFitness.BL.model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; }
        public double Proteins { get; }
        public double Fets { get; }
        public double Carbohydrates { get; }
        public double Callories { get; }

        private double CaloriesOneGramm{ get { return Callories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FetsOneGramm { get { return Fets / 100.0; } }

        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        public Food(string name)
        {
            Name = name;
        }
        public Food(string name,double callories,double proteins,double fets,double carbohydrates)
        {
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fets = fets / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
