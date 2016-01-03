using EmpMgmtByMongo.UserControls;
using System.Windows;

namespace EmpMgmtByMongo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void deleteRecord_Click(object sender, RoutedEventArgs e)
        {
            DeleteControl deleteControl = new DeleteControl();
            MainContentHolder.Content = deleteControl;
        }

        private void updateRecord_Click(object sender, RoutedEventArgs e)
        {
            UpdateControl updateControl = new UpdateControl();
            MainContentHolder.Content = updateControl;
        }

        private void readRecord_Click(object sender, RoutedEventArgs e)
        {
            ReadControl readControl = new ReadControl();
            MainContentHolder.Content = readControl;
        }

        private void createRecord_Click(object sender, RoutedEventArgs e)
        {
            CreateControl createControl = new CreateControl();
            MainContentHolder.Content = createControl;
        }
    }
}
