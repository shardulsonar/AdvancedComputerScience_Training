using ACS_Training.Classes;
using ACS_Training.Screens;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACS_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Topic> topics;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Quiz_Click(object sender, RoutedEventArgs e)
        {
            var quizWindow = new Quiz();
            quizWindow.Owner = this;
            quizWindow.Show();
            Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            topics = Storage.ReadJson<List<Topic>>("content.json");
            Lbx_topics.ItemsSource = topics;
            Lbx_topics.SelectedIndex = 0;
        }

        private void Lbx_topics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grid_OuterGrid.DataContext = (Topic)Lbx_topics.SelectedItem;
            Lbx_subTopics.SelectedIndex = 0;
        }

        private void Lbx_subTopics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Lbx_subTopics.SelectedItem == null)
            {
                return;
            }
            Tbx_subTopic.Text = ((SubTopic)Lbx_subTopics.SelectedItem).name.ToString();
            Lbx_points.ItemsSource = (List<string>)((SubTopic)Lbx_subTopics.SelectedItem).points;
        }
    }
}
