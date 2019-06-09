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
            lbx_topics.ItemsSource = topics;
            lbx_topics.SelectedIndex = 0;
        }

        private void Lbx_topics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_OuterGrid.DataContext = topics;
            grid_SubTopicGrid.DataContext = (Topic)lbx_topics.SelectedItem;
            lbx_subTopics.SelectedIndex = 0;
        }

        private void Lbx_subTopics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbx_subTopics.SelectedItem == null)
            {
                return;
            }
            tbx_subTopic.Text = ((SubTopic)lbx_subTopics.SelectedItem).name.ToString();
            //tbx_points.ItemsSource = (List<string>)((SubTopic)lbx_subTopics.SelectedItem).points;
        }
    }
}
