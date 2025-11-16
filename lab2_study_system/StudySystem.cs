using lab2_study_system.models;

namespace lab2_study_system;

public class StudySystem
{   
    private static StudySystem? _instance;
    public static StudySystem Instance => _instance ??= new StudySystem();
    private StudySystem() { }
    
    public static void Reset()
    {
        _instance = null;
    }
    
    private List<Course> _courses = new();
    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();
    
    private List<Teacher> _teachers = new();
    public IReadOnlyList<Teacher> Teachers => _teachers.AsReadOnly();

    private List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students.AsReadOnly();
    
    public void AddOnlineCourse(string courseName, int teacherIsuNumber, string teacherName, string platform)
    {
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course != null)
            throw new InvalidOperationException($"Курс '{courseName}' уже существует.");
        
        var teacher = _teachers.FirstOrDefault(t => t.IsuNumber == teacherIsuNumber);
        if (teacher == null)
        {
            teacher = new Teacher(teacherIsuNumber, teacherName);
            _teachers.Add(teacher);
        }
        
        var newCourse = new OnlineCourse(courseName, teacher, platform);
        _courses.Add(newCourse);
        
        teacher.AddCourse(newCourse);
    }
    
    public void AddOfflineCourse(string courseName, int teacherIsuNumber, string teacherName, string location, string classroom)
    {   
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course != null)
            throw new InvalidOperationException($"Курс '{courseName}' уже существует.");
        
        var teacher = _teachers.FirstOrDefault(t => t.IsuNumber == teacherIsuNumber);
        if (teacher == null)
        {
            teacher = new Teacher(teacherIsuNumber, teacherName);
            _teachers.Add(teacher);
        }
        
        var newCourse = new OfflineCourse(courseName, teacher,  location, classroom);
        _courses.Add(newCourse);
        
        teacher.AddCourse(newCourse);
    }
    
    public void RemoveCourse(string courseName)
    {   
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
            throw new InvalidOperationException("Курс не найден.");
        
        course.Teacher.RemoveCourse(course);
        
        foreach (var student in course.Students.ToList())
            course.RemoveStudent(student);
        
        _courses.Remove(course);
    }

    public void ChangeCourseTeacher(string courseName, int newTeacherIsu, string newTeacherName)
    {
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
            throw new InvalidOperationException("Курс не найден.");
        
        var teacher = _teachers.FirstOrDefault(t => t.IsuNumber == newTeacherIsu);
        if (teacher == null)
        {
            teacher = new Teacher(newTeacherIsu, newTeacherName);
            _teachers.Add(teacher);
        }
        
        course.ChangeTeacher(teacher);
    }
    
    public void AddStudentOnCourse(string courseName, int newStudentIsuNumber, string newStudentName)
    {
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
            throw new InvalidOperationException("Курс не найден.");
        
        var student = _students.FirstOrDefault(s => s.IsuNumber == newStudentIsuNumber);
        if (student == null)
        {
            student = new Student(newStudentIsuNumber, newStudentName);
            _students.Add(student);
        }
        
        if (course.Students.Contains(student))
            throw new InvalidOperationException("Студент уже записан на этот курс.");
        
        course.AddStudent(student);
    }

    public void RemoveStudentFromCourse(string courseName, int newStudentIsuNumber)
    {
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        if (course == null)
            throw new InvalidOperationException("Курс не найден.");

        var student = _students.FirstOrDefault(s => s.IsuNumber == newStudentIsuNumber);
        if (student == null)
            throw new InvalidOperationException("Студент не найден.");
        
        if (!course.Students.Contains(student))
            throw new InvalidOperationException("Студент не записан на этот курс.");

        course.RemoveStudent(student);
    }

    public IReadOnlyList<Course> GetCoursesByTeacher(int teacherIsuNumber)
    {
        var teacher = _teachers.FirstOrDefault(t => t.IsuNumber == teacherIsuNumber);
        if (teacher == null)
            return [];

        return teacher.Courses;
    }

    public IReadOnlyList<Course> GetCoursesByStudent(int studentIsuNumber)
    {
        var student = _students.FirstOrDefault(s => s.IsuNumber == studentIsuNumber);
        if (student == null)
            return [];
        
        return student.Courses;
    }

    public Course? GetCourseByName(string courseName)
    {
        var course = _courses.FirstOrDefault(c => c.Name == courseName);
        return course;
    }
    
    public Teacher? GetTeacherByIsu(int teacherIsuNumber)
    {
        var teacher = _teachers.FirstOrDefault(t => t.IsuNumber == teacherIsuNumber);
        return teacher;
    }
    
    public Student? GetStudentByIsu(int studentIsuNumber)
    {
        var student = _students.FirstOrDefault(s => s.IsuNumber == studentIsuNumber);
        return student;
    }
}

