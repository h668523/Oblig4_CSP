using System.Text;
using System.Threading.Tasks.Sources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Oblig4_CSP.Models;
using Task = Oblig4_CSP.Models.HotelTask;

namespace Oblig4_CSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HotelDbContext dx = new();
        private readonly LocalView<HotelTask> tasks;
        public MainWindow()
        {
            InitializeComponent();

            tasks = dx.HotelTasks.Local;

            dx.HotelTasks.Load();

        }

        private void bCleaning_Click(object sender, RoutedEventArgs e)
        {
            //var t = tasks.Where(x=>x.Type == "Cleaning").ToList();
            CSP csp = new(dx, "Cleaning");
            csp.Show();
            this.Close();
        }

        private void bService_Click(object sender, RoutedEventArgs e)
        {
            //var t = tasks.Where(x => x.Type == "Service").ToList();
            CSP csp = new(dx, "Service");
            csp.Show();
            this.Close();
        }

        private void bPersonell_Click(object sender, RoutedEventArgs e)
        {
            //var t = tasks.Where(x => x.Type == "Personell").ToList();
            CSP csp = new(dx, "Personell");
            csp.Show();
            this.Close();
        }

        private void bAdmin_Click(object sender, RoutedEventArgs e)
        {
            Admin a = new(dx); 
            a.Show();
        }
    }
}