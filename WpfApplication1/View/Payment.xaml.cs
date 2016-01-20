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

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public delegate void PaymentWindowFunc();
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public event PaymentWindowFunc PaymentShowLessonsChanged;
        public event PaymentWindowFunc PaymentPayLessonsChanged;
        public ShowLessons showLessons_window;
        private string m_Id;
        public string _Id
        {
            get { return m_Id; }
            set { m_Id = _Id; }
        }
        private string m_LessonNum;
        public string _LessonNum
        {
            get { return m_LessonNum; }
            set { m_LessonNum = _LessonNum; }
        }
        public Payment()
        {
            InitializeComponent();
            showLessons_window = new ShowLessons();
            webBrowser.Navigate(new Uri("http://paypal.com"));
        }

        private void show_lessons(object sender, RoutedEventArgs e)
        {
            int num = 0;
            bool isNum = Int32.TryParse(s_id.Text, out num);
            if (!isNum || s_id.Text.Length != 9)
            {
                MessageBox.Show("ID couldn't be empty, longer then 9 characters or not a number!");
                return;
            }
            m_Id = s_id.Text;
            PaymentShowLessonsChanged();
        }

        private void pay(object sender, RoutedEventArgs e)
        {
            if (name.Text == null || name.Text.Length < 1)
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }
            string[] cardArr = car_num.Text.Split('-');
            int num = 0;
            bool isNum;
            foreach (string s in cardArr)
            {
                isNum = Int32.TryParse(s, out num);
                if (!isNum)
                {
                    MessageBox.Show("Card number isn't valid");
                    return;
                }

            }
            if (month.Text == null || month.Text.Length < 1)
            {
                MessageBox.Show("Please choose a valid expiration date");
                return;
            }
            isNum = Int32.TryParse(lesson_num.Text, out num);
            if (lesson_num == null || lesson_num.Text.Length < 1)
            {
                MessageBox.Show("Lesson number couldn't be empty or not a number!");
                return;
            }
            isNum = Int32.TryParse(CVV.Text, out num);
            if (CVV.Text == null || !isNum || CVV.Text.Length < 1)
            {
                MessageBox.Show("Please enter a valid CVV number");
                return;
            }
            m_LessonNum = lesson_num.Text;
            PaymentPayLessonsChanged();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        
    }

}
