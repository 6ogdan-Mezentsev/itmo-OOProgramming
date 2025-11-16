using lab2_study_system;
using lab2_study_system.models;

class Program
{
    static void Main()
    {
        var system = StudySystem.Instance;

        while (true)
        {
            Console.WriteLine("\n--- Study System ---");
            Console.WriteLine("1. Добавить онлайн-курс");
            Console.WriteLine("2. Добавить оффлайн-курс");
            Console.WriteLine("3. Добавить студента на курс");
            Console.WriteLine("4. Показать курсы преподавателя");
            Console.WriteLine("5. Показать курсы студента");
            Console.WriteLine("6. Показать все курсы");
            Console.WriteLine("7. Сменить преподавателя на курсе");
            Console.WriteLine("8. Удалить курс");
            Console.WriteLine("9. Удалить студента с курса");
            Console.WriteLine("10. Показать информацию о курсе");
            Console.WriteLine("11. Показать преподавателя по ISU");
            Console.WriteLine("12. Показать студента по ISU");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddOnlineCourse(system);
                    break;
                case "2":
                    AddOfflineCourse(system);
                    break;
                case "3":
                    AddStudent(system);
                    break;
                case "4":
                    ShowTeacherCourses(system);
                    break;
                case "5":
                    ShowStudentCourses(system);
                    break;
                case "6":
                    ShowAllCourses(system);
                    break;
                case "7":
                    ChangeTeacher(system);
                    break;
                case "8":
                    RemoveCourse(system);
                    break;
                case "9":
                    RemoveStudent(system);
                    break;
                case "10":
                    ShowCourseInfo(system);
                    break;
                case "11":
                    ShowTeacherInfo(system);
                    break;
                case "12":
                    ShowStudentInfo(system);
                    break;
                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }

    static void AddOnlineCourse(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine()!;

            Console.Write("ISU преподавателя: ");
            int teacherIsu = int.Parse(Console.ReadLine()!);

            Console.Write("Имя преподавателя: ");
            string teacherName = Console.ReadLine()!;

            Console.Write("Платформа: ");
            string platform = Console.ReadLine()!;

            system.AddOnlineCourse(name, teacherIsu, teacherName, platform);
            Console.WriteLine("Онлайн-курс добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void AddOfflineCourse(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine()!;

            Console.Write("ISU преподавателя: ");
            int teacherIsu = int.Parse(Console.ReadLine()!);

            Console.Write("Имя преподавателя: ");
            string teacherName = Console.ReadLine()!;

            Console.Write("Адрес корпуса: ");
            string location = Console.ReadLine()!;

            Console.Write("Аудитория: ");
            string classroom = Console.ReadLine()!;

            system.AddOfflineCourse(name, teacherIsu, teacherName, location, classroom);
            Console.WriteLine("Оффлайн-курс добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void RemoveCourse(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine()!;

            system.RemoveCourse(name);
            Console.WriteLine("Курс удалён.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void AddStudent(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string course = Console.ReadLine()!;

            Console.Write("ISU студента: ");
            int studentIsu = int.Parse(Console.ReadLine()!);

            Console.Write("Имя студента: ");
            string studentName = Console.ReadLine()!;

            system.AddStudentOnCourse(course, studentIsu, studentName);
            Console.WriteLine("Студент добавлен на курс.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void RemoveStudent(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string courseName = Console.ReadLine()!;

            Console.Write("ISU студента: ");
            int studentIsu = int.Parse(Console.ReadLine()!);

            system.RemoveStudentFromCourse(courseName, studentIsu);

            Console.WriteLine("Студент удалён с курса.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void ShowTeacherCourses(StudySystem system)
    {
        Console.Write("ISU преподавателя: ");
        int isu = int.Parse(Console.ReadLine()!);

        var courses = system.GetCoursesByTeacher(isu);

        if (courses.Count == 0)
        {
            Console.WriteLine("У преподавателя нет курсов.");
            return;
        }

        Console.WriteLine("Курсы преподавателя:");
        foreach (var c in courses)
            Console.WriteLine($"- {c.Name}");
    }

    static void ShowStudentCourses(StudySystem system)
    {
        Console.Write("ISU студента: ");
        int isu = int.Parse(Console.ReadLine()!);

        var courses = system.GetCoursesByStudent(isu);

        if (courses.Count == 0)
        {
            Console.WriteLine("Студент ни на что не записан.");
            return;
        }

        Console.WriteLine("Курсы студента:");
        foreach (var c in courses)
            Console.WriteLine($"- {c.Name}");
    }

    static void ShowAllCourses(StudySystem system)
    {
        if (system.Courses.Count == 0)
        {
            Console.WriteLine("Курсов нет.");
            return;
        }

        Console.WriteLine("\nВсе курсы:");
        foreach (var c in system.Courses)
        {
            Console.WriteLine($"- {c.Name} (преподаватель: {c.Teacher.Name}, студентов на курсе: {c.CountOfStudents})");
        }
    }
    
    static void ChangeTeacher(StudySystem system)
    {
        try
        {
            Console.Write("Название курса: ");
            string courseName = Console.ReadLine()!;

            Console.Write("Новый ISU преподавателя: ");
            int newIsu = int.Parse(Console.ReadLine()!);

            Console.Write("Имя нового преподавателя: ");
            string newName = Console.ReadLine()!;

            system.ChangeCourseTeacher(courseName, newIsu, newName);

            Console.WriteLine("Преподаватель успешно сменён.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void ShowCourseInfo(StudySystem system)
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine()!;

        var course = system.GetCourseByName(name);

        if (course == null)
        {
            Console.WriteLine("Курс не найден.");
            return;
        }

        Console.WriteLine($"\nИнформация о курсе \"{course.Name}\":");
        Console.WriteLine($"Преподаватель: {course.Teacher.Name}");
        Console.WriteLine($"Количество студентов: {course.CountOfStudents}");

        if (course is OnlineCourse online)
            Console.WriteLine($"Платформа: {online.Platform}");

        if (course is OfflineCourse offline)
            Console.WriteLine($"Корпус: {offline.Location}, аудитория: {offline.Classroom}");

        if (course.Students.Count > 0)
        {
            Console.WriteLine("\nСписок студентов:");
            foreach (var student in course.Students)
                Console.WriteLine($"- {student.Name} ({student.IsuNumber})");
        }
    }
    
    static void ShowTeacherInfo(StudySystem system)
    {
        Console.Write("ISU преподавателя: ");
        int isu = int.Parse(Console.ReadLine()!);

        var teacher = system.GetTeacherByIsu(isu);

        if (teacher == null)
        {
            Console.WriteLine("Преподаватель не найден.");
            return;
        }

        Console.WriteLine($"\nПреподаватель: {teacher.Name}");
        Console.WriteLine("Курсы:");

        if (teacher.Courses.Count == 0)
        {
            Console.WriteLine("  (нет курсов)");
            return;
        }

        foreach (var c in teacher.Courses)
            Console.WriteLine($"- {c.Name}");
    }
    
    static void ShowStudentInfo(StudySystem system)
    {
        Console.Write("ISU студента: ");
        int isu = int.Parse(Console.ReadLine()!);

        var student = system.GetStudentByIsu(isu);

        if (student == null)
        {
            Console.WriteLine("Студент не найден.");
            return;
        }

        Console.WriteLine($"\nСтудент: {student.Name}");
        Console.WriteLine("Курсы:");

        if (student.Courses.Count == 0)
        {
            Console.WriteLine("  - нет курсов");
            return;
        }

        foreach (var c in student.Courses)
            Console.WriteLine($"- {c.Name}");
    }
}
