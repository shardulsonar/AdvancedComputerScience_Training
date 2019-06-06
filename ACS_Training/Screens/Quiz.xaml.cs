using ACS_Training.Classes;
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

namespace ACS_Training.Screens
{
    /// <summary>
    /// Interaction logic for Quiz.xaml 
    /// </summary>
    public partial class Quiz : Window
    {
        List<Topic> topics;

        public Quiz()
        {
            InitializeComponent();
        }

        private void Quiz_Window_Loaded(object sender, RoutedEventArgs e)
        {
            topics = new List<Topic>();
            topics = Storage.ReadJson<List<Topic>>("content.json");
        }

        private void Quiz_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

    }
}
