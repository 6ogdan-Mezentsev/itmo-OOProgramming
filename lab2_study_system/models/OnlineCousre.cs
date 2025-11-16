namespace lab2_study_system.models;

public class OnlineCourse(string name, Teacher teacher, string platform) : Course(name, teacher)
{
    public string Platform { get; } = platform;
}
