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
    public interface IController
    {
        void SetModel(IModel model);
        //
        void insertUser(string[] param, string user);
        //void updateUser(string[] param, string user);
        void DeleteUser(string[] param, string user);
        DataTable ShowStudentLessons(string id);
        DataTable SearchLesson(string[] param);
        void SetNewLesson(string[] param);
        void lessonPayment(string param);
        DataTable ShowUnpayedLesson(string id);
       // void Output(string ex);
    }
}
