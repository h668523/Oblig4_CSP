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
    /// Interaction logic for CSP.xaml
    /// </summary>
    public partial class CSP : Window
    {
        private readonly HotelDbContext dx;
        private readonly LocalView<HotelTask> tasks;  
        private List<HotelTask> task2;
        private String T;
        public CSP(HotelDbContext d, String t)
        {
            InitializeComponent();
            dx = d;
            T = t;
            tasks = dx.HotelTasks.Local;

            dx.HotelTasks.Load();

            task2 = dx.HotelTasks.Include(x => x.Room).Where(x=> x.Type ==t).ToList();

            CSPList.ItemsSource = task2;
        }

        private void CSPList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HotelTask? ht = CSPList.SelectedItem as HotelTask;

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
                    CSPList.ItemsSource = dx.HotelTasks.Include(x => x.Room).Where(x => x.Type == T).ToList();
                }
            }
        }

    }
}
