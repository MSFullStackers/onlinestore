using System.Collections.Generic;

namespace online.core
{
    public class Student 
    {
        public string Id {get;set;}
        public string Name {get;set;}
    }

    public interface IStudents
    {
        List<Student> Get();
    }

    [DiComponent(Lifetime = Lifetime.PerScope)]
    public class Students : IStudents
    {
        public List<Student> Get()
        {
            return new List<Student>() { new Student(){ Id ="1", Name="Ram" },
            new Student(){ Id ="2", Name="Mar" } };
        }
    }
}