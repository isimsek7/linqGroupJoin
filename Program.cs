using linqGroupJoin;

List<Sinif> classes = new List<Sinif>
        {
            new Sinif { ClassId = 1, ClassName = "Matematik" },
            new Sinif { ClassId = 2, ClassName = "Türkçe" },
            new Sinif { ClassId = 3, ClassName = "Kimya" }
        };

List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

var classGroups = from c in classes
                  join s in students on c.ClassId equals s.ClassId into studentGroup
                  select new
                  {
                      ClassName = c.ClassName,
                      Students = studentGroup
                  };
foreach (var classGroup in classGroups)
{
    Console.WriteLine($"{classGroup.ClassName} sinifi;");
    foreach (var student in classGroup.Students)
    {
        Console.WriteLine($" - {student.StudentName}");
    }
}