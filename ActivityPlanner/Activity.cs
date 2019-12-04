using System;

namespace ActivityPlanner
{
    public enum TypeOfActivity { Air, Water, Land }
    public class Activity : IComparable<Activity>
    {
        // Properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }

        private decimal cost;
        public decimal Cost 
        {
            get { return cost; }
            set 
            { 
                TotalExpenses += value;
                cost = value;
            } 
        }
        public string Description { get; set; }
        public TypeOfActivity ActivityType { get; set; }

        public static decimal TotalExpenses;

        // Constructors
        public Activity(string name, DateTime activityDate, decimal cost, string description, TypeOfActivity activityType)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            Description = description;
            ActivityType = activityType;
        }

        // Methods
        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

        public int CompareTo(Activity other)
        {
            return this.ActivityDate.CompareTo(other.ActivityDate);
        }
    }
}
