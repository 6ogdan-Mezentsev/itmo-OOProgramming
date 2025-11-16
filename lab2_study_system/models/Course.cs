namespace lab2_study_system.models;

public abstract class Course(string name, Teacher teacher)
{
    public string Name { get; set; } = name;
    public Teacher Teacher { get; private set; } = teacher;
    
    private List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students.AsReadOnly();
    
    public int CountOfStudents {
        get { return _students.Count; }
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

    public void ChangeTeacher(Teacher newTeacher)
    {
        if (Teacher == newTeacher)
            return;
        
        Teacher.RemoveCourse(this);
        Teacher = newTeacher;
        newTeacher.AddCourse(this);
    }

    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            return;
        
        _students.Add(student);
        student.AddCourse(this);
    }

    public void RemoveStudent(Student student)
    {
        if (!_students.Contains(student))
            return;
        
        _students.Remove(student);
        student.RemoveCourse(this);
    }
}
