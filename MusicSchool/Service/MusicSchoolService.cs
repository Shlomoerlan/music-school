using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.Configuration.AppConfiguration;

namespace MusicSchool.Service
{
    internal static class MusicSchoolService
    {
        public static void CreateXmlIfNotExist()
        {
            if (!File.Exists(musicSchoolPath))
            {
                // create new document
                XDocument document = new();
                // create an element
                XElement musicSchool = new("music-school");
                // document add element
                document.Add(musicSchool);
                // document save change into the path 
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassroom(string classroomName)
        {
            // load document
            XDocument document = XDocument.Load(musicSchoolPath);
            // find musicscool root
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();
            // if not exist return
            if (musicSchool == null)
            {
                return;
            }
            // create child
            XElement classroom = new(
                "class-room",
                // create attribute into child
                new XAttribute("name", classroomName)
            );
            // insert the child with attribute into the root
            musicSchool.Add(classroom);
            // save it in the path
            document.Save(musicSchoolPath);
        }


        public static void AddTeacher(string classroomName, string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? classroom = document.Descendants("class-room")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classroomName);
            if (classroom == null)
            {
                return;
            }
            XElement teacher = new("techer",
            new XAttribute("name", teacherName));
            classroom.Add(teacher);
            document.Save(musicSchoolPath);
        }

        public static void AddStudent(string classroomName, string studentName, string instrument)
        {

            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? classroom = (from room in document.Descendants("class-room")
                                   where room.Attribute("name")?.Value == classroomName
                                   select room).FirstOrDefault();
            if (classroom == null)
            {
                return;
            }
            XElement student = new("student",
                new XAttribute("name", studentName));

            XElement instrument1 = new("instrument", instrument);
            student.Add(instrument1);
            classroom.Add(student);
            document.Save(musicSchoolPath);
        }

        private static XElement ConvertStudentToElement(Student student) =>
            new ("student",
            new XAttribute("name", student.Name),
            new XElement("instrument", student.Instrument.Name));
            

        public static void AddManyStudents(string classroomName, params Student[] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? classroom = document.Descendants(
                "class-room").FirstOrDefault(room => room.Attribute("name")?.Value == classroomName);
                              
            if (classroom == null)
            {
                return;
            }

            List<XElement> studentList = students.Select(ConvertStudentToElement).ToList();
            classroom.Add(studentList);
            document.Save(musicSchoolPath);
        }

        public static void UpdateInstrument(string studentName, Instrument instrument)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? student = document.Descendants(
                "student").FirstOrDefault(s => s.Attribute("name")?.Value == studentName);
            if (student == null) { return; }
            student.SetElementValue("instument", instrument.Name);
            document.Save(musicSchoolPath);
        }

        public static void ChangeTeacherName(string teacherName, string newTeacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? teacher = document.Descendants(
                "techer").FirstOrDefault(t => t.Attribute("name")?.Value == teacherName);
            if (teacher == null) { return; };
            teacher.SetAttributeValue("name", newTeacherName);
            document.Save(musicSchoolPath);
        }

        public static void ChangeStudent(Student student, string studentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? student1 = document.Descendants(
                "student").FirstOrDefault(s => s.Attribute("name")?.Value==studentName);
            if (student1 == null) { return; };
            student1.ReplaceWith(ConvertStudentToElement(student));
            document.Save(musicSchoolPath);
        }

        public static void RemoveStudent(string studentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? student = document.Descendants(
                "student").FirstOrDefault(s => s.Attribute("name")?.Value == studentName);
            if (student == null) { return; };
            student.Remove();
            document.Save(musicSchoolPath);
        }


    }
}
