using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public interface IModel
    {
        void AddUser(string[] param, string user);
        void DeleteUser(string[] param, string user);
        DataTable SearchLesson(string[] param);
        void SetNewLesson(string[] param);
        DataTable ShowLessonsForStudent(string id);
        DataTable ShowUnpayedLessons(string id);
        void PayForLesson(string lesson);
    }
}
