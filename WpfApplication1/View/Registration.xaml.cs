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
    public delegate void RegisterWindowFunc();
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    /// 
    public partial class Registration : Window
    {
        public event RegisterWindowFunc RegisterWindowChanged;

        private string m_Fname;
        public string _Fname
        {
            get { return m_Fname; }
            set { m_Fname = _Fname; }
        }
        private string m_Lname;
        public string _Lname
        {
            get { return m_Lname; }
            set { m_Lname = _Lname; }
        }
        private string m_Id;
        public string _Id
        {
            get { return m_Id; }
            set { m_Id = _Id; }
        }
        private string m_City;
        public string _City
        {
            get { return m_City; }
            set { m_City = _City; }
        }
        private string m_Phone;
        public string _Phone
        {
            get { return m_Phone; }
            set { m_Phone = _Phone; }
        }
        private string m_Email;
        public string _Email
        {
            get { return m_Email; }
            set { m_Email = _Email; }
        }
        private string m_AcademicDegree;
        public string _AcademicDegree
        {
            get { return m_AcademicDegree; }
            set { m_AcademicDegree = _AcademicDegree; }
        }
        private string m_UserType;
        public string _UserType
        {
            get { return m_UserType; }
            set { m_UserType = _UserType; }
        }
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            m_Fname = first_name.Text;
            m_Lname = last_name.Text;
            m_Id = id.Text;
            m_City = city.Text;
            m_Phone = phone.Text;
            m_Email = mail.Text;
            m_AcademicDegree = degree.Text;
            m_UserType = user_type.Text;
            RegisterWindowChanged();
            this.Visibility = Visibility.Hidden;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
     
    }
}
