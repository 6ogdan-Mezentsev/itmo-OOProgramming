using Xunit;
namespace lab2_study_system.Tests;

public class StudySystemTests
{
    public StudySystemTests()
    {
        StudySystem.Reset();
    }
    
    [Fact]
    public void AddOnlineCourse_ShouldAddCourse()
    {
        var system = StudySystem.Instance;

        system.AddOnlineCourse("OOProgramming", 000001, "Ivanov", "Zoom");

        Assert.Single(system.Courses);
        Assert.Equal("OOProgramming", system.Courses[0].Name);
    }
    
    [Fact]
    public void AddOnlineCourse_ShouldThrowException_WhenCourseExists()
    {
        var system = StudySystem.Instance;

        system.AddOnlineCourse("OOProgramming", 000001, "Ivanov", "Zoom");

        Assert.Throws<InvalidOperationException>(() =>
        {
            system.AddOnlineCourse("OOProgramming", 000001, "Petrov", "Teams");
        });
    }
    
    [Fact]
    public void AddStudent_ShouldCreateCourseAndAddStudentOnCourse()
    {
        var system = StudySystem.Instance;

        system.AddOnlineCourse("OOProgramming", 000001, "Ivanov", "Zoom");
        system.AddStudentOnCourse("OOProgramming", 000002, "Petrov");

        var course = system.Courses[0];

        Assert.Single(course.Students);
        Assert.Equal("Petrov", course.Students[0].Name);

        var student = system.Students[0];

        Assert.Single(student.Courses);
        Assert.Equal("OOProgramming", student.Courses[0].Name);
    }
    
    [Fact]
    public void RemoveCourse_ShouldRemoveCourse()
    {
        var system = StudySystem.Instance;

        system.AddOnlineCourse("OOProgramming", 000001, "Ivanov", "Zoom");
        system.RemoveCourse("OOProgramming");

        Assert.Empty(system.Courses);
    }
    
    [Fact]
    public void ChangeTeacher_ShouldChangeTeacherOnCourse()
    {
        var system = StudySystem.Instance;

        system.AddOnlineCourse("OOProgramming", 000001, "Ivanov", "Zoom");

        system.ChangeCourseTeacher("OOProgramming", 000002, "Petrov");

        Assert.Equal(000002, system.Courses[0].Teacher.IsuNumber);
        Assert.Equal("Petrov", system.Courses[0].Teacher.Name);
    }

}