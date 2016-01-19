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
            m_Id = s_id.Text;
            PaymentShowLessonsChanged();
        }

        private void pay(object sender, RoutedEventArgs e)
        {
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
