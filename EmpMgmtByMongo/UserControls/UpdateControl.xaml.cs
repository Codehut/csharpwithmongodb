using EmpMgmtByMongo.Models;
using EmpMgmtByMongo.MongoHelper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EmpMgmtByMongo.UserControls
{
    /// <summary>
    /// Interaction logic for UpdateControl.xaml
    /// </summary>
    public partial class UpdateControl : UserControl
    {
        public UpdateControl()
        {
            this.InitializeComponent();
            this.Loaded += UpdateControl_Loaded;
        }

        private void UpdateControl_Loaded(object sender, RoutedEventArgs e)
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

        private void empListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(empListView.SelectedItem != null)
            {
                var clickedItem = (Employee)e.AddedItems[0];
                updateEmpName.Text = clickedItem.Name;
                updateEmpCompany.Text = clickedItem.Employer;
                updateEmpPosition.Text = clickedItem.Position;
                updateEmpSalary.Text = clickedItem.Salary.ToString();
            }
        }

        private async void updateEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            var filter = Builders<Employee>.Filter.Eq("Name", updateEmpName.Text);
            var update = Builders<Employee>.Update.Set("Salary", double.Parse(updateEmpSalary.Text));

            var result = await MongoInstance.EmployeeCollection.UpdateOneAsync(filter, update);

            if (result.IsModifiedCountAvailable)
            {
                MessageBox.Show(result.ModifiedCount + " Data modified");
            }
            GetEmpDetails();
        }
    }
}
