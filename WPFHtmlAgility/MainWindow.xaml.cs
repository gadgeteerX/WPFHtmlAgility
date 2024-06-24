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
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using System.Media;

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
            HttpClient h = new HttpClient();
            var vhtml = h.GetStringAsync("https://www.hattongardenmetals.com/gold-britannia-coins").Result;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(vhtml);
            var vElement = doc.DocumentNode.SelectSingleNode(
                "//span[@id='ctl00_Content_ProductGridBestSellers_gvGridLayout_ctl00_lblPriceEach']");
            var vGold = vElement.InnerText.Trim();
            txtPrice.Text = vGold.ToString();

            DateTime d = DateTime.Now;
            string strDate = d.ToString();
            txtDate.Text = strDate;

            txtEditor.Text += vGold.ToString() + ", " + strDate +"\n";

            txtStatus.Text = "Sourced at:   " + strDate;
            SoundPlayer sp = new SoundPlayer(Properties.Resources.Alarm10);
            sp.Play();
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