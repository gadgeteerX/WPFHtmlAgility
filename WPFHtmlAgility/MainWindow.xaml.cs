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
using System.IO;
using Microsoft.Win32;

namespace WPFHtmlAgility
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

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultDirectory = "d:\\repos2\\WPFHtmlAgility";
            o.Filter = "Text file | *.txt";
            o.FileName = "aaa.txt";
            if (o.ShowDialog() == true)
            {
                string s = File.ReadAllText(o.FileName);
                txtEditor.Text = s;
            }
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute= true;
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.DefaultDirectory = "d:\\repos2\\WPFHtmlAgility";
            s.Filter = "Text file | *.txt";
            s.FileName = "aaa.txt";
            if (s.ShowDialog() == true)
            {
                File.WriteAllText(s.FileName, txtEditor.Text);
            }
        }
    }
}