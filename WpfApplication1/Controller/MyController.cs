using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;
using WpfApplication1.View;

namespace WpfApplication1.Controller
{
    public class MyController : IController
    {
        private IModel m_model;
        private IView m_view;

        public MyController()
        {

        }

        public void SetModel(IModel model)
        {
            m_model = model;
        }

        /*
        public void SetView(IView view)
        {
            m_view = view;
        }
        */
        public void insertUser(string[] param, string user)
        {
            m_model.AddUser(param, user);
        }

        /*
        public void updateUser(string[] param, string user)
        {
            m_model.updateUser(param, user);
        }
         */
 
        public void DeleteUser(string[] param, string user)
        {
            m_model.DeleteUser(param, user);
        }

        public DataTable SearchLesson(string[] param)
        {
            return m_model.SearchLesson(param);
        }

        public void SetNewLesson(string[] id)
        {
            m_model.SetNewLesson(id);
        }

        public DataTable ShowStudentLessons(string id)
        {
            return m_model.ShowLessonsForStudent(id);
        }

        public void lessonPayment(string details)
        {
            m_model.PayForLesson(details);
        }

        public DataTable ShowUnpayedLesson(string id)
        {
            return m_model.ShowUnpayedLessons(id);
        }
    }
}
