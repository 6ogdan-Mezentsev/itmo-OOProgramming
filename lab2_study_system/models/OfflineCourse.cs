namespace lab2_study_system.models;

public class OfflineCourse(string name, Teacher teacher, string location, string classroom) : Course(name, teacher)
{
    public string Location {get;} = location;
    public string Classroom {get;} =  classroom;
}
