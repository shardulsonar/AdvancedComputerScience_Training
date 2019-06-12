using ACS_Training.Classes;
using ACS_Training.Screens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
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
        string language;
        List<string> cultures = new List<string> { "en english", "de deutsch" , "mr मराठी" };

        public MainWindow()
        {
            language = Properties.Settings.Default.language;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            InitializeComponent();
        }

        private void Button_Quiz_Click(object sender, RoutedEventArgs e)
        {
            var quizWindow = new Quiz((Topic)lbx_topics.SelectedItem);
            quizWindow.Owner = this;
            quizWindow.Show();
            Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbx_language.ItemsSource = cultures;
            string defaultLanguage = Properties.Settings.Default.language;
            string defaultCulture = "";
            foreach (var culture in cultures)
            {
                if (culture.Substring(0, 2).Equals(defaultLanguage))
                {
                    defaultCulture = culture;
                }
                
            }

            cbx_language.SelectedItem = defaultCulture;
            topics = Storage.ReadJson<List<Topic>>(Properties.Resources.fileName);
            lbx_topics.ItemsSource = topics;
            string selectedSubTopic = Properties.Settings.Default.selectedSubTopic;
            int indexOfSubtopic = Convert.ToInt16(selectedSubTopic.Substring(2, 1));
            int indexOfTopic = Convert.ToInt16(selectedSubTopic.Substring(0, 1));
            try
            {
                lbx_topics.SelectedItem = topics[indexOfTopic];
                lbx_subTopics.SelectedItem = topics[indexOfTopic].subTopics[indexOfSubtopic];
            }
            catch (ArgumentOutOfRangeException)
            {
                lbx_topics.SelectedItem = topics.FirstOrDefault<Topic>();
                lbx_subTopics.SelectedItem = ((Topic)(lbx_topics.SelectedItem)).subTopics.FirstOrDefault<SubTopic>();
            }
            

        }

        private void Lbx_topics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Topic selectedTopic = (Topic)lbx_topics.SelectedItem;
            if(selectedTopic.subTopics.Count < 3)
            {
                btn_quiz.IsEnabled = false;
            }
            else
            {
                btn_quiz.IsEnabled = true;
            }
            grid_OuterGrid.DataContext = selectedTopic;
            lbx_subTopics.SelectedItem = selectedTopic.subTopics.FirstOrDefault<SubTopic>();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = (sender as ComboBox).SelectedItem.ToString();
            language = text.Substring(0, 2);
            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int indexOfTopic = lbx_topics.SelectedIndex;
            int indexOfSubtopic = lbx_subTopics.SelectedIndex;

            Properties.Settings.Default.selectedSubTopic = indexOfTopic + "." + indexOfSubtopic;
            Properties.Settings.Default.Save();
        }
    }
}
