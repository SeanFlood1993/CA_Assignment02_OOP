using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActivityPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> allActivities = new List<Activity>();
        List<Activity> addedActivities = new List<Activity>();
        List<Activity> filteredActivity = new List<Activity>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create activity objects
            Activity land1 = new Activity("Treking", new DateTime(2019, 06, 01), 20, "Instructor led group trek through local mountains.", TypeOfActivity.Land);
            Activity land2 = new Activity("Mountain Biking", new DateTime(2019, 06, 02), 30, "Instructor led half day mountain biking. All equipment provided.", TypeOfActivity.Land);
            Activity land3 = new Activity("Absailing", new DateTime(2019, 06, 03), 40, "Experience the rush of adrenaline as you descend cliff faces from 10-500m.", TypeOfActivity.Land);

            Activity water1 = new Activity("Kayaking", new DateTime(2019, 06, 01), 40, "Half day lakeland kayak with island picnic.", TypeOfActivity.Water);
            Activity water2 = new Activity("Surfing", new DateTime(2019, 06, 02), 25, "2 hour surf lesson on the wild atlantic way", TypeOfActivity.Water);
            Activity water3 = new Activity("Sailing", new DateTime(2019, 06, 03), 25, "Full day lakeland sailing with island picnic.", TypeOfActivity.Water);

            Activity air1 = new Activity("Parachuting", new DateTime(2019, 06, 01), 100, "Experience the thrill of free fall while you tandem jump from an airplane.", TypeOfActivity.Air);
            Activity air2 = new Activity("Hang Gliding", new DateTime(2019, 06, 02), 80, "Soar on hot air currents and enjoy spectacular views of the coastal region.", TypeOfActivity.Air);
            Activity air3 = new Activity("Helicopter Tour", new DateTime(2019, 06, 03), 200, "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", TypeOfActivity.Air);

            // adding activities to list.
            allActivities.Add(land1);
            allActivities.Add(land2);
            allActivities.Add(land3);
            allActivities.Add(water1);
            allActivities.Add(water2);
            allActivities.Add(water3);
            allActivities.Add(air1);
            allActivities.Add(air2);
            allActivities.Add(air3);

            // Sorting by date
            allActivities.Sort();

            // Display in listbox
            lbxAllActivities.ItemsSource = allActivities;   // sends all activities in list to listbox.
            tblkTotalCost.Text = Activity.TotalExpenses.ToString();
        }

        // Method for button  " >> " 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            decimal totalCost = 0;

            // find what item is selected
            Activity chosenActivity = lbxAllActivities.SelectedItem as Activity;
            
            // null check
            if (chosenActivity != null)
            {
                Boolean conflictedDate = false;

                 foreach (Activity activity in chosenActivity)
                {
                    if (activity.ActivityDate == chosenActivity.ActivityDate)
                    {
                        conflictedDate = true;
                        MessageBox.Show("You already picked this date.");
                    }
                } 

                if (!conflictedDate)
                {
                    // move item from left to right
                    allActivities.Remove(chosenActivity);
                    addedActivities.Add(chosenActivity);

                    totalCost += chosenActivity.Cost;
                    tblkTotalCost.Text = Activity.TotalExpenses.ToString();

                    refreshScreen();
                }
            }
            else
            {
                MessageBox.Show("No activity selected!");
            }
        }

        // Method for button " << "
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // find what item is selected
            Activity chosenActivity = lbxSelectedActivities.SelectedItem as Activity;

            // null check
            if (chosenActivity != null)
            {
                // move item from right to left
                allActivities.Add(chosenActivity);
                addedActivities.Remove(chosenActivity);

                refreshScreen();
            }
            else
            {
                MessageBox.Show("No activity selected!");
            }
        }

        // Method fpr screen refresh 
        private void refreshScreen()
        {
            lbxAllActivities.ItemsSource = null;
            lbxAllActivities.ItemsSource = allActivities;

            lbxSelectedActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = addedActivities;
        }

        // Method deals with all radio buttons
        private void rbtnAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivity.Clear();

            if(rbtnAll.IsChecked == true)
            {
                // show all
                refreshScreen();
            }
            else if(rbtnLand.IsChecked == true)
            {
                // show all land
                foreach (Activity activity in allActivities)
                {
                    if(activity.ActivityType == TypeOfActivity.Land)
                    {
                        filteredActivity.Add(activity);

                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivity;
                    }
                }
            }
            else if(rbtnWater.IsChecked == true)
            {
                // show all water
                foreach (Activity activity in allActivities)
                {
                    if (activity.ActivityType == TypeOfActivity.Water)
                    {
                        filteredActivity.Add(activity);

                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivity;
                    }
                }
            }
            else if(rbtnAir.IsChecked == true)
            {
                // show all air
                foreach (Activity activity in allActivities)
                {
                    if (activity.ActivityType == TypeOfActivity.Air)
                    {
                        filteredActivity.Add(activity);

                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivity;
                    }
                }
            }
        }
    }
}
