using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Oblig4_CSP.Models;

namespace Oblig4_CSP
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private readonly HotelDbContext dx;
        private readonly LocalView<HotelTask> tasks;
        private readonly LocalView<Room> rooms;
        public Admin(HotelDbContext d)
        {
            InitializeComponent();
            dx = d;
            tasks = dx.HotelTasks.Local;
            rooms = dx.Rooms.Local;

            dx.HotelTasks.Load();
            dx.Rooms.Load();

            List<string> tl = new List<string>() { "Cleaning", "Service", "Personell" };
            List<string> sl = new List<string>() { "New", "In_Progress", "Finished" };

            AdminView.DataContext = rooms.OrderBy(x=>x.Id);
            TaskView.DataContext = tasks.OrderBy(x => x.Id);
            TypeListe.DataContext = tl;
            statusListe.DataContext = sl;
            statusListe.SelectedItem = "New";
        }

        private void bNewTask_Click(object sender, RoutedEventArgs e)
        {
            
            HotelTask h = new HotelTask();
            h.Room = AdminView.SelectedItem as Room;
            if (h.Room != null)
            {
                h.Status = statusListe.SelectedItem.ToString();
                h.Description = DescriptionBox.Text;
                h.Type = TypeListe.SelectedItem.ToString();
                h.Room.IsAvailable = false;
                dx.HotelTasks.Add(h);
                dx.SaveChanges();
            }

            DescriptionBox.Text = "";
            AdminView.DataContext = rooms.OrderBy(x => x.Id);
            TaskView.DataContext = tasks.OrderBy(x => x.Id);

        }
        private void AdminView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room selectedRoom = AdminView.SelectedItem as Room;
            if (selectedRoom != null)
            {
                RoomId.Content = selectedRoom.Id.ToString(); 
            }
        }
        private void TaskView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HotelTask? ht = TaskView.SelectedItem as HotelTask;

            if (ht != null)
            {
                Editor ed = new(tasks, dx);
                ed.roomNr.Content = ht.Room.Id.ToString();
                ed.statusListe.SelectedItem = ht.Status.ToString();
                ed.sDesc.Text = ht.Description.ToString();
                ed.Ht = ht;

                bool? r = ed.ShowDialog();
                if (r == true)
                {
                    TaskView.ItemsSource = dx.HotelTasks.Include(x => x.Room).ToList();
                }
            }
        }
    }
}
