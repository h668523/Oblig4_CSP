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
using Oblig4_CSP.Models;
using Task = Oblig4_CSP.Models.HotelTask;

namespace Oblig4_CSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<HotelTask> tasks;
        public MainWindow()
        {
            InitializeComponent();
            Room room1 = new Room(101);
            Room room2 = new Room(102);
            Room room3 = new Room(103);
            Room room4 = new Room(201);
            Room room5 = new Room(202);
            Room room6 = new Room(203);

            List<Room> rooms = new List<Room> { 
                       room1, room2, room3, room4, room5, room6
                       };
            tasks = new List<HotelTask> { 
                        new HotelTask(room1, RoomStatus.Personell, "Room Service, they want eggs"),
                        new HotelTask(room2, RoomStatus.Personell, "Room Service, they want wine"),
                        new HotelTask(room3, RoomStatus.Service, "TV won't work"),
                        new HotelTask(room4, RoomStatus.Cleaning, "Change towels"),
                        new HotelTask(room5, RoomStatus.Personell, "Room Service, they want beer"),
                        new HotelTask(room6, RoomStatus.Cleaning, "Checked out")
                        };

        }

        private void bCleaning_Click(object sender, RoutedEventArgs e)
        {
            var t = tasks.Where(x=>x.type == RoomStatus.Cleaning).ToList();
            CSP csp = new(t);
            csp.Show();
            this.Close();
        }

        private void bService_Click(object sender, RoutedEventArgs e)
        {
            var t = tasks.Where(x => x.type == RoomStatus.Service).ToList();
            CSP csp = new(t);
            csp.Show();
            this.Close();
        }

        private void bPersonell_Click(object sender, RoutedEventArgs e)
        {
            var t = tasks.Where(x => x.type == RoomStatus.Personell).ToList();
            CSP csp = new(t);
            csp.Show();
            this.Close();
        }
    }
}