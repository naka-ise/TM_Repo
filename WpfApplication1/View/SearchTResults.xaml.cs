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
            int num = 0;
            bool isNum = Int32.TryParse(t_id.Text, out num);
            if (t_id.Text == null || t_id.Text.Length != 9 || !isNum)
            {
                MessageBox.Show("ID couldn't be empty, longer then 9 characters or not a number!");
                return;
            }
            m_TeacherId = t_id.Text;
            isNum = Int32.TryParse(s_id.Text, out num);
            if (s_id.Text == null || s_id.Text.Length != 9 || !isNum)
            {
                MessageBox.Show("ID couldn't be empty, longer then 9 characters or not a number!");
                return;
            }
            m_StudentId = s_id.Text;
            if (fields.Text == null || fields.Text.Length < 1)
            {
                MessageBox.Show("Please choose a field of study");
                return;
            }
            m_Field = fields.Text;
            m_Date = MonthCalendar.SelectedDate.ToString();
            string[] hArr = hour.Text.Split(':');
            bool is1, is2;
            is1 = Int32.TryParse(hArr[0], out num);
            is2 = Int32.TryParse(hArr[1], out num);
            if (!is1 || !is2 || hour.Text.Length > 10 || hour.Text.Length < 1)
            {
                MessageBox.Show("Please enter a valid time");
                return;
            }
            m_Hour = hour.Text;
            isNum = Int32.TryParse(duration.Text, out num);
            if (!isNum || duration.Text.Length < 1)
            {
                MessageBox.Show("Please enter a valid duration (integer)");
                return;
            }
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
