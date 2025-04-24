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
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        private List<String> taskStats;
        private HotelTask Ht {  get; set; }
        private List<TaskStats> ts;
        internal Editor(HotelTask ht)
        {
            InitializeComponent();
            taskStats = new List<String> { "New", "In_Progress", "Finished" };
            statusListe.DataContext = taskStats;
            Ht = ht;
            ts = new List<TaskStats> { TaskStats.New, TaskStats.In_Progress, TaskStats.Finished };
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            var s = statusListe.SelectedItem.ToString;
            Ht.description = sDesc.ToString();
            foreach (var t in ts)
            {
                if (t.ToString == s)
                {
                    Ht.status = t;
                }
            }

            this.Close();
        }
    }
}
