using EmpMgmtByMongo.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EmpMgmtByMongo.UserControls
{
    /// <summary>
    /// Interaction logic for ReadControl.xaml
    /// </summary>
    public partial class ReadControl : UserControl
    {
        public ReadControl()
        {
            this.InitializeComponent();
            this.Loaded += ReadControl_Loaded;
        }

        private void ReadControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmpDetails();
        }

        private async void GetEmpDetails()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList = await MongoHelper.MongoInstance.EmployeeCollection.Find(FilterDefinition<Employee>.Empty).ToListAsync();
            empListView.DataContext = null;
            empListView.DataContext = employeeList;
        }
    }
}
