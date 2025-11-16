namespace lab2_study_system.models;

public class Teacher(int isuNumber, string name)
{
    public int IsuNumber { get; } = isuNumber;
    public string Name { get; } = name;
    
    private List<Course> _courses = new();
    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();
    
    public void AddCourse(Course course)
    {
        if (!_courses.Contains(course))
            _courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        if (_courses.Contains(course))
            _courses.Remove(course);
    }
}
