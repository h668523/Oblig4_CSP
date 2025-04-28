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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Oblig4_CSP.Models;

namespace Oblig4_CSP
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private readonly LocalView<HotelTask> hotelTask;
        private readonly HotelDbContext dx;
        public HotelTask Ht {  get; set; }
        private List<String> ts;
        public Editor(LocalView<HotelTask> ht, HotelDbContext d)
        {
            InitializeComponent();
            ts = new List<String> { "New", "In_Progress", "Finished" };
            statusListe.DataContext = ts;
            hotelTask = ht;
            dx = d;
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            var s = statusListe.SelectedItem.ToString();
            Ht.Description = sDesc.Text;
            foreach (var t in ts)
            {
                if (t.ToString() == s)
                {
                    Ht.Status = t;
                    if (t.Equals("Finished")) { Ht.Room.IsAvailable = true; } else { Ht.Room.IsAvailable = false; }
                    dx.SaveChanges();
                }
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
