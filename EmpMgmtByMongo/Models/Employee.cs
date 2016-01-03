namespace EmpMgmtByMongo.Models
{
    public class Employee
    {
        //_id field is mandatory
        public object _id { get; set; }
        public string Name { get; set; }
        public string Employer { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
    }
}
