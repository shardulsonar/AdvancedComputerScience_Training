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
            if ((Option)lbx_options.SelectedItem == null)
            {
                MessageBox.Show(Application.Current.MainWindow, "Please select an option", "Option not found", MessageBoxButton.OK,  MessageBoxImage.Error);
            }
            else
            {
                selectedOption = (Option)lbx_options.SelectedItem;
                if (selectedOption.status)
                {
                    tbx_optionStatus.Text = "Correct";
                    tbx_optionStatus.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    tbx_optionStatus.Text = "Incorrect";
                    tbx_optionStatus.Foreground = new SolidColorBrush(Colors.Red);
                    tbx_correctAnswer.Text = "Correct answer is : " + question.correctAnswer;
                }
            }
            btn_check.IsEnabled = false;

        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            tbx_optionStatus.Text = "";
            tbx_correctAnswer.Text = "";
            btn_check.IsEnabled = true;
            this.Quiz_Window_Loaded(sender, e);
        }
    }
}
