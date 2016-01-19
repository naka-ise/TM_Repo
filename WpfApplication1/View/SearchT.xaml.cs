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
            m_Fields = fields.Text;
            m_City = city.Text;
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
