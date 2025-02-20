class Program
{
    static void Main()
    {
        var classes = new[]
        {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
        };

        var allStudents = GetAllStudents(classes);

        if (allStudents != null)
        {
            Console.WriteLine(string.Join(" ", allStudents));
        }
    }

    static string[]? GetAllStudents(Classroom[] classes)
    {
        return classes?.SelectMany(c => c.Students).ToArray();

        // Как второй вариант

        //if (classes == null || classes.Length == 0)
        //    return null;
        //List<string> students = new List<string>();

        //foreach (var classroom in classes)
        //{
        //    students.AddRange(classroom.Students);
        //}

        //return students.ToArray();
    }
}
