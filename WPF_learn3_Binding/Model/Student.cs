using System.ComponentModel;

namespace WPF6_Binding.Model;

internal class Student : INotifyPropertyChanged
{
    private string _name;

    public Student(string name)
    {
        _name = name;
    }

    public Student(string name, int id, int age)
    {
        _name = name;
        Id = id;
        Age = age;
    }

    public Student()
    {
        
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
        }
    }

    public int Id { get; set; }
    public int Age { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
}