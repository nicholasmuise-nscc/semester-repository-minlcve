using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp
{
    public class Program
    {
        public static void Main(string[] _)
        {
            // Dictionary: Fitness program title => Description
            Dictionary<string, string> fitnessPrograms = new Dictionary<string, string>()
            {
                { "Lose Weight", "Cardio-focused training and calorie deficit" },
                { "Build Muscle", "Strength training with progressive overload" },
                { "Maintain Weight", "Balanced workouts and steady nutrition" }
            };

            Console.WriteLine("Available Fitness Programs:\n");
            foreach (var program in fitnessPrograms)
            {
                Console.WriteLine($"{program.Key}: {program.Value}");
            }

            Console.WriteLine("\n---\n");

            List<User> users = new List<User>()
            {
                new User("John", "Lose Weight", 3),
                new User("Sarah", "Build Muscle", 5),
                new User("Mike", "Lose Weight", 2),
                new User("Emma", "Maintain Weight", 4),
                new User("Lucas", "Build Muscle", 5),
            };

            var weightLossUsers = users
                .Where(user => user.FitnessGoal == "Lose Weight" && user.MonthsTraining >= 3)
                .ToList();

            Console.WriteLine("Users focused on losing weight with at least 3 months of training:\n");
            foreach (var user in weightLossUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine(); // Space

            var muscleBuildUsers = users
                .Where(user => user.FitnessGoal == "Build Muscle" && user.MonthsTraining >= 5)
                .ToList();

            Console.WriteLine("Users focused on building muscle with at least 5 months of training:\n");
            foreach (var user in muscleBuildUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine(); // Space

            var avgTrainingMonths = users
                .Where(user => user.FitnessGoal == "Build Muscle")
                .Average(user => user.MonthsTraining);

            Console.WriteLine($"Average months of training for muscle-building users: {avgTrainingMonths}");
            Console.WriteLine(); // Space

            foreach (var user in users)
            {
                user.CheckGoalAchieved();
                Console.WriteLine(); // Add spacing between each user's goal message
            }
        }
    }

    public class Person
    {
        private string _name;

        public virtual string Name
        {
            get => $"User: {_name}";
            set => _name = value;
        }

        public Person(string name)
        {
            _name = name;
        }
    }

    public class User : Person
    {
        public string FitnessGoal { get; set; }
        public int MonthsTraining { get; set; }

        public delegate void FitnessGoalDelegate(string fitnessGoal);
        public event FitnessGoalDelegate OnFitnessGoalAchieved;

        public User(string name, string fitnessGoal, int monthsTraining)
            : base(name)
        {
            FitnessGoal = fitnessGoal;
            MonthsTraining = monthsTraining;

            OnFitnessGoalAchieved += (goal) =>
                Console.WriteLine($"{Name} is working hard to achieve their {goal} goal!");

            OnFitnessGoalAchieved += (goal) =>
                Console.WriteLine($"Go {Name}! You're doing great with your {goal} goal!");
        }

        public void CheckGoalAchieved()
        {
            if (MonthsTraining >= 3)
            {
                OnFitnessGoalAchieved?.Invoke(FitnessGoal);
            }
        }
    }
}
