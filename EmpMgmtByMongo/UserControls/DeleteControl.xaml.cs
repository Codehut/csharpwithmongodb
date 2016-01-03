using EmpMgmtByMongo.Models;
using EmpMgmtByMongo.MongoHelper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EmpMgmtByMongo.UserControls
{
    /// <summary>
    /// Interaction logic for DeleteControl.xaml
    /// </summary>
    public partial class DeleteControl : UserControl
    {
        public DeleteControl()
        {
            this.InitializeComponent();
            Loaded += DeleteControl_Loaded;
        }

        private void DeleteControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmpDetails();
        }

        private async void GetEmpDetails()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList = await MongoInstance.EmployeeCollection.Find(FilterDefinition<Employee>.Empty).ToListAsync();
            empListView.DataContext = null;
            empListView.DataContext = employeeList;
        }
        private async void empListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(empListView.SelectedItem != null)
            {
                var clickedItem = (Employee)e.AddedItems[0];
                var result = MessageBox.Show("Are you sure you want to delete " + clickedItem.Name + " record?", "Employee Management", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                var filter = Builders<Employee>.Filter.Eq("Name", clickedItem.Name);
                if (result == MessageBoxResult.Yes)
                {
                    var deleteResult = await MongoInstance.EmployeeCollection.DeleteOneAsync(filter);
                    MessageBox.Show(deleteResult.DeletedCount + " record has been deleted.");
                }
                GetEmpDetails();
            }
        }
    }
}
