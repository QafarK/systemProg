using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace systemProg
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskManager>? TaskManager_ { get; set; } = [];
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(textBox.Text);
                TaskManager taskManager = new TaskManager();
                var processes = Process.GetProcessesByName(textBox.Text);

                taskManager.Id = processes[processes.Length - 1].Id;
                taskManager.Name = processes[processes.Length - 1].ProcessName;
                taskManager.MachineName = processes[processes.Length - 1].MachineName;
                taskManager.HandleCount = processes[processes.Length - 1].HandleCount;
                taskManager.ThreadCount = processes[processes.Length - 1].Threads.Count;

                TaskManager_.Add(taskManager);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem is not null)
                {
                      Process.GetProcessById(TaskManager_[listView.SelectedIndex].Id).Kill();
                }
            }
            catch (Exception ex)
            {

          MessageBox.Show("Error: " + ex.Message);

            }

        }
    }
}