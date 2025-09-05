namespace TP03_EDD2.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsEnrrollable(Course course)
    {
        //TODO
        return true;
    }
}