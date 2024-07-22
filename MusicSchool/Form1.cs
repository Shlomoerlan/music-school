using MusicSchool.Service;
using static MusicSchool.Service.MusicSchoolService;
using static MusicSchool.Model.Student;
using static MusicSchool.Model.Instrument;
using MusicSchool.Model;

namespace MusicSchool
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExist();
            Instrument instrument = new("pipe");
            Student student = new("yaakov", instrument);
            // ChangeStudent(student, "Moshe");
            // ChangeTeacherName("enosh", "Enosh");
            // RemoveStudent("yaakov");
        }
    }
}
