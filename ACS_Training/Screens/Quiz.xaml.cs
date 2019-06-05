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
            topics = new List<Topic>();
        }

        private void Quiz_Window_Loaded(object sender, RoutedEventArgs e)
        {
            topics = new List<Topic>();
            topics = Storage.ReadJson<List<Topic>>("content.json");
            Console.WriteLine(topics);
        }

        private void Quiz_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
            //Storage.WriteJson<List<Topic>>(topics, "data.json");
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Topic topic = new Topic();
            topic.name = Tbx_Topic.Text;
            List<SubTopic> subTopics = new List<SubTopic>();
            SubTopic subTopic = new SubTopic();
            subTopic.name = Tbx_SubTopic.Text;
            subTopic.imageLocation = "Image 1_1.jpg";
            subTopic.points = new List<string>(Tbx_Points.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
            subTopics.Add(subTopic);
            topic.subTopics = subTopics;
            topics.Add(topic);

        }
    }
}
