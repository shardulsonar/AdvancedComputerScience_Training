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
        Topic topic;
        Question question;
        Option selectedOption;

        public Quiz(Topic topic)
        {
            InitializeComponent();
            this.topic = topic;
            stk_title.DataContext = topic;
            question = new Question(topic);
        }

        private void Quiz_Window_Loaded(object sender, RoutedEventArgs e)
        {
            question = new Question(topic).getQuestion();
            stk_question.DataContext = question;
        }

        private void Quiz_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            selectedOption = (Option)lbx_options.SelectedItem;
            if (selectedOption.status)
            {
                txb_optionStatus.Text = "Correct";
                txb_optionStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txb_optionStatus.Text = "Incorrect";
                txb_optionStatus.Foreground = new SolidColorBrush(Colors.Red);
            } 
        }
    }
}
