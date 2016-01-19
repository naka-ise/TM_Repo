using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApplication1.Controller;
using WpfApplication1.Model;

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IView
    {
        public MyController controller;
        Lessons lesson_window;
        Assignments assignment_window;
        Teachers teacher_window;
        Students student_window;

        IModel model;

        public MainWindow()
        {
            InitializeComponent();
            controller = new MyController();
            model = new MyModel();
            controller.SetModel(model);
            lesson_window = new Lessons();
            teacher_window = new Teachers();
            student_window = new Students();
            assignment_window = new Assignments();
            SetEvents();
        }
        void SetEvents()
        {
            lesson_window.search_window.SearchWindowChanged += SearchCommand;
            lesson_window.searchRes_window.scheduleWindowChanged += scheduleCommand;
            lesson_window.payment_window.PaymentShowLessonsChanged += paymentShowCommand;
            lesson_window.payment_window.PaymentPayLessonsChanged += paymentPayCommand;
        }

        void SearchCommand()
        {
            string[] param = new string[3];
            param[0] = lesson_window.search_window._Fields;
            param[1] = lesson_window.search_window._City;
            param[2] = lesson_window.search_window._MaxPrice;
            DataTable LessonTable = new DataTable();
            LessonTable = controller.SearchLesson(param);
            lesson_window.searchRes_window.dg_results.ItemsSource = LessonTable.DefaultView;
            lesson_window.searchRes_window.ShowDialog();
        }
        void scheduleCommand()
        {
            string[] param = new string[6];
            param[0] = lesson_window.searchRes_window._StudentId;
            param[1] = lesson_window.searchRes_window._TeacherId;
            param[2] = lesson_window.searchRes_window._Field;
            param[3] = lesson_window.searchRes_window._Date;
            param[4] = lesson_window.searchRes_window._Hour;
            param[5] = lesson_window.searchRes_window._Duration;
            controller.SetNewLesson(param);
            System.Windows.MessageBox.Show("The lesson was scheduled sucessfully!");
        }
        void paymentShowCommand()
        {
            string param;
            DataTable LessonTable = new DataTable();
            param = lesson_window.payment_window._Id;
            LessonTable = controller.ShowUnpayedLesson(param);
            lesson_window.showLessons_window.lessons_table.ItemsSource = LessonTable.DefaultView;
            lesson_window.showLessons_window.ShowDialog();
        }
        void paymentPayCommand()
        {
            string param;
            param = lesson_window.payment_window._LessonNum;
            controller.lessonPayment(param);
            System.Windows.MessageBox.Show("The lesson was payed sucessfully!");
        }
        private void Btn_clk_LessonMng(object sender, RoutedEventArgs e)
        {
            lesson_window.ShowDialog();
        }
        private void Btn_clk_AssignmentMng(object sender, RoutedEventArgs e)
        {
            assignment_window.ShowDialog();
        }
        private void Btn_clk_TeacherMng(object sender, RoutedEventArgs e)
        {
            teacher_window.ShowDialog();
        }
        private void Btn_clk_StudentMng(object sender, RoutedEventArgs e)
        {
            student_window.ShowDialog();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }


        public void Output(string ex)
        {
            MessageBox.Show(ex);
        }
    }
}
