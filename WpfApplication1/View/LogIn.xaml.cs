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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        Registration reg_window;
        MainWindow main_window;

        public LogIn()
        {
            InitializeComponent();
            main_window = new MainWindow();
            reg_window = new Registration();
            SetEvents();
        }

        private void buttn_signIn(object sender, RoutedEventArgs e)
        {
            main_window.ShowDialog();
        }
        private void buttn_register(object sender, RoutedEventArgs e)
        {
            reg_window.ShowDialog();

        }
        void SetEvents()
        {
            reg_window.RegisterWindowChanged += RegisterCommand;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            reg_window.Show();
        }

        void RegisterCommand()
        {
            string[] param = new string[7];
            string user = reg_window._UserType;
            param[0] = reg_window._Id;
            param[1] = reg_window._Fname;
            param[2] = reg_window._Lname;
            param[3] = reg_window._City;
            param[4] = reg_window._Phone;
            param[5] = reg_window._Email;
            param[6] = reg_window._AcademicDegree;
            main_window.controller.insertUser(param, user);
            System.Windows.MessageBox.Show("You are sucessfuly registered!");

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
        


    }
}
