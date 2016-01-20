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
            if (first_name.Text == null || first_name.Text.Length > 50 || first_name.Text.Length < 1)
            {
                MessageBox.Show("First name couldn't be empty or longer then 50 characters!");
                return;
            }
            m_Fname = first_name.Text;
            if (last_name.Text == null || last_name.Text.Length > 50 || last_name.Text.Length < 1)
            {
                MessageBox.Show("Last name couldn't be empty or longer then 50 characters!");
                return;
            }
            m_Lname = last_name.Text;
            int num = 0;
            bool isNum = Int32.TryParse(id.Text, out num);
            if (!isNum || id.Text.Length != 9)
            {
                MessageBox.Show("ID couldn't be empty, longer then 9 characters or not a number!");
                return;
            }
            m_Id = id.Text;
            if (city.Text == null || city.Text.Length > 50 || city.Text.Length < 1)
            {
                MessageBox.Show("City couldn't be empty or longer then 50 characters!");
                return;
            }
            m_City = city.Text;
            isNum = Int32.TryParse(phone.Text, out num);
            if (!isNum || phone.Text == null || phone.Text.Length > 50 || phone.Text.Length < 1)
            {
                MessageBox.Show("Phone couldn't be empty, longer then 50 characters or not a number!");
                return;
            }
            m_Phone = phone.Text;
            if (!mail.Text.Contains('@') || !mail.Text.Contains('.') || mail.Text == null || mail.Text.Length > 50 || mail.Text.Length < 10)
            {
                MessageBox.Show("Email couldn't be empty, longer then 50 characters and has to be from the form: 'a@b.com' !");
                return;
            }
            m_Email = mail.Text;
            if (degree.Text.Length > 50)
            {
                MessageBox.Show("Academic Degree couldn't be longer then 50 characters!");
                return;
            }
            m_AcademicDegree = degree.Text;
            if (user_type.Text == null || user_type.Text.Length < 1)
            {
                MessageBox.Show("You must choose user type - student or teacher!");
                return;
            }
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
