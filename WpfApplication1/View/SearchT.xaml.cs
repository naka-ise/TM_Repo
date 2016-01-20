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
    /// Interaction logic for SearchT.xaml
    /// </summary>
    public delegate void SearchWindowFunc();
    /// <summary>
    /// Interaction logic for SearchT.xaml
    /// </summary>
    public partial class SearchT : Window
    {
        public event SearchWindowFunc SearchWindowChanged;
        private string m_Fields;
        public string _Fields
        {
            get { return m_Fields; }
            set { m_Fields = _Fields; }
        }
        private string m_City;
        public string _City
        {
            get { return m_City; }
            set { m_City = _City; }
        }
        private string m_MaxPrice;
        public string _MaxPrice
        {
            get { return m_MaxPrice; }
            set { m_MaxPrice = _MaxPrice; }
        }
        public SearchT()
        {
            InitializeComponent();
        }

        private void buttn_search(object sender, RoutedEventArgs e)
        {
            if (fields.Text == null || fields.Text.Length < 1)
            {
                MessageBox.Show("Please choose a field of study");
                return;
            }
            m_Fields = fields.Text;
            if (city.Text == null || city.Text.Length < 1 || city.Text.Length > 50)
            {
                MessageBox.Show("Please enter a valid city");
                return;
            }
            m_City = city.Text;
            int num = 0;
            bool isNum = Int32.TryParse(max_price.Text, out num);
            if (!isNum || max_price.Text == null || max_price.Text.Length < 1)
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }
            m_MaxPrice = max_price.Text;
            SearchWindowChanged();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

       
    }
}
