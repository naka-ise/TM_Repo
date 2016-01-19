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
    /// Interaction logic for Lessons.xaml
    /// </summary>
    public partial class Lessons : Window
    {
        public SearchT search_window;
        public Payment payment_window;
        public SearchTResults searchRes_window;
        public ShowLessons showLessons_window;

        public Lessons()
        {
            InitializeComponent();
            search_window = new SearchT();
            payment_window = new Payment();
            searchRes_window = new SearchTResults();
            showLessons_window = new ShowLessons();
        }

        private void btn_Clk_search(object sender, RoutedEventArgs e)
        {
            searchRes_window.ShowDialog();
        }

        private void btn_Clk_pay(object sender, RoutedEventArgs e)
        {
            payment_window.ShowDialog();
        }

        private void btn_Clk_sched(object sender, RoutedEventArgs e)
        {
            search_window.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        
    }
}
