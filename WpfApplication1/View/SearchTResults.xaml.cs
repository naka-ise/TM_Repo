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
    /// Interaction logic for SearchTResults.xaml
    /// </summary>
    public delegate void scheduleWindowFunc();
    /// <summary>
    /// Interaction logic for SearchTResults.xaml
    /// </summary>
    public partial class SearchTResults : Window
    {
        public event scheduleWindowFunc scheduleWindowChanged;
        private string m_TeacherId;
        public string _TeacherId
        {
            get { return m_TeacherId; }
            set { m_TeacherId = _TeacherId; }
        }
        private string m_StudentId;
        public string _StudentId
        {
            get { return m_StudentId; }
            set { m_StudentId = _StudentId; }
        }
        private string m_Hour;
        public string _Hour
        {
            get { return m_Hour; }
            set { m_Hour = _Hour; }
        }
        private string m_Duration;
        public string _Duration
        {
            get { return m_Duration; }
            set { m_Duration = _Duration; }
        }
        private string m_Date;
        public string _Date
        {
            get { return m_Date; }
            set { m_Date = _Date; }
        }
        private string m_Field;
        public string _Field
        {
            get { return m_Field; }
            set { m_Field = _Field; }
        }
        public SearchTResults()
        {
            InitializeComponent();
        }

        private void check_date(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Google Calender:\n Schedule is approve!");
        }

        private void schedule(object sender, RoutedEventArgs e)
        {
            m_TeacherId = t_id.Text;
            m_StudentId = s_id.Text;
            m_Field = fields.Text;
            m_Date = MonthCalendar.SelectedDate.ToString();
            m_Hour = hour.Text;
            m_Duration = duration.Text;
            scheduleWindowChanged();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
       
       
    }
}
