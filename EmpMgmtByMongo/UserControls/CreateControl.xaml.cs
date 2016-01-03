using EmpMgmtByMongo.Models;
using EmpMgmtByMongo.MongoHelper;
using System.Windows;
using System.Windows.Controls;

namespace EmpMgmtByMongo.UserControls
{
    /// <summary>
    /// Interaction logic for CreateControl.xaml
    /// </summary>
    public partial class CreateControl : UserControl
    {
        public CreateControl()
        {
            InitializeComponent();
        }

        private async void addNewEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            //I didn't do any validation
            var employee = new Employee() { Name = newEmpName.Text, Employer = newEmpCompany.Text, Position = newEmpPosition.Text, Salary = double.Parse(newEmpSalary.Text) };
            //Getting instance of MongoDB
            await MongoInstance.EmployeeCollection.InsertOneAsync(employee);
        }
    }
}
