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
using Oblig4_CSP.Models;

namespace Oblig4_CSP
{
    /// <summary>
    /// Interaction logic for CSP.xaml
    /// </summary>
    public partial class CSP : Window
    {
        internal List<HotelTask> HotelTasks;  
        internal CSP(List<HotelTask> ht)
        {
            InitializeComponent();
            HotelTasks = ht;
            CSPList.ItemsSource = HotelTasks;
        }

        private void CSPList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HotelTask ht = CSPList.SelectedItem as HotelTask;

            if (ht != null)
            {
                Editor ed = new(ht);
                ed.roomNr.Content = ht.room.RoomNr.ToString();
                ed.statusListe.SelectedItem = ht.status.ToString();
                ed.sDesc.Text = ht.description.ToString();
                

                ed.Show();
            }
        }

    }
}
