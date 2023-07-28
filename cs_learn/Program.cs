using System.Collections.ObjectModel;

namespace cs_learn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ObservableCollection<Student> students = new ObservableCollection<Student>();
            // students.Add(new Student() {Name="A", Id=1});
            // students.Add(new Student() { Name="B", Id=2});
            // students.Add(new Student() { Id=3, Name="C"});
            // students.Add(new Student() {Id=4, Name="D"});
            // students.Add(new Student() {Id=5, Name="E"});
            //
            // var stu = students.ToList().Find(t => t.Id == 4);
            // if (stu  != null)
            // {
            //     stu.Name = "A";
            // }
            //
            // foreach (var student in students)
            // {
            //     Console.WriteLine($"No.{student.Id}-{student.Name}");
            // }
            var a = Test.A;
            var b = Test.B;
            Console.WriteLine(a.ToString());
            Console.WriteLine((a | b).ToString());
            Console.WriteLine((b | a).HasFlag(Test.A & Test.B & Test.C));
        }

        class Student
        {
            public string? Name { get; set; }
            public int Id {get; set; }
        }

        [Flags]
        enum Test
        {
            A = 0x01,
            B = 0x02,
            C = 0x04,
            D = 0x08
        }
    }
}