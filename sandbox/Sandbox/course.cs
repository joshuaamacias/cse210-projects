
class Course
{
    public string _ClassCode;
    public string _ClassName;
    public int _Credits;
    public string _Color;

    public void Display() {
        Console.WriteLine($"{_ClassCode}{_ClassName}{_Credits}{_Color}");
    }

}