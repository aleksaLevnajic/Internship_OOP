using System;
using System.IO;

//OOP

Genre genre1 = new Genre("Social Novel");
Genre genre2 = new Genre("Romance");
Genre genre3 = new Genre("Drama");
Genre genre4 = new Genre("Pshylogical Thriler");
Genre genre5 = new Genre("Pshylogical Novel");

Book book1 = new Book(1, "War and Peace", 820, "Tolstoj", genre1);
Book book2 = new Book(2, "Crime and Punishment", 620, "Dostojevski", genre5);
Movie movie1 = new Movie(3, "Fight club", 138, "David Fincher", genre4);
Movie movie2 = new Movie(3, "Prisones", 128, "David Fincher", genre3);

book1.Print();
book1.PageNumber = 720;
book1.Print();

Console.WriteLine("\n");
//ACCESS MODIFERS

Cat cat1 = new Cat("Lion", "Wild cat that lives in savanna.", "Wild cat");
cat1.Sound();
Dog dog1 = new Dog("Winston", "Friendly, 35kg, likes to play fetch.", "Labradoodle");
dog1.Sound();

Console.WriteLine("\n");
//INTERFACES

ISender sender1 = new Email();
ISender sender2 = new SMS();
Email email = new Email();
SMS sms = new SMS();

sender1.Send("Using ISender as ref.");
sender2.Send("Using ISender as ref.");

email.Send("Using email class.");
sms.Send("Using sms class.");

Console.WriteLine("\n");
//REF&VAL TYPES

int x = 100;
void ValuePassThrough(int x)
{
    x = x + 1;
    Console.WriteLine(x);
}
ValuePassThrough(x);
Console.WriteLine(x); //method dosen't affect the value of x

void ReferencePassThrough(Student student)
{
    student.StudentName = "John";
}

Student student1 = new Student();
student1.StudentName = "Peter";
ReferencePassThrough(student1);
Console.WriteLine(student1.StudentName); //method affects the change of prop. StudentName
public class Student
{
    public string StudentName { get; set; }
}

public abstract class Entity
{
    public int Id { get; set; }
    public string Title { get; set; }

    protected Entity(int id, string title) 
    {
        Id = id;
        Title = title;
    }

    public abstract void Print();
}
public class Genre
{
    public string Name { get; set; }
    public Genre(string name)
    {
        Name = name;
    }
}

internal class Book : Entity
{
    private int _pageNumber;
    private string _author;
    public Genre Genre { get; set; }

    public Book(int id, string title, int pageNumber, string author, Genre genre)
        :base(id, title)
    {
        PageNumber = pageNumber;
        Author = author;
        Genre = genre;
    }

    public int PageNumber
    {
        get
        { 
            return _pageNumber;
        }
        set 
        { 
            if( value > 0 )
            {
                _pageNumber = value;
            }            
        }
    }
    public string Author
    {
        get { return _author; }
        set 
        {
            if (!string.IsNullOrEmpty(value))
                _author = value;
        }
    }

    public override void Print()
    {
        Console.WriteLine($"{nameof(Book)}: {base.Title}, author:{Author}, page number: {PageNumber}, genre: {Genre.Name} ");
    }
}

internal class Movie : Entity
{
    private int _timeInMinutes;
    private string _director;
    private Genre Genre;

    public Movie(int id, string title, int timeInMinutes, string director, Genre genre)
        :base(id, title)
    {
        _timeInMinutes = timeInMinutes;
        _director = director;
        Genre = genre;
    }

    public int TimeInMinutes
    {
        get { return _timeInMinutes; }
        set
        {
            if(value > 0 )
                _timeInMinutes = value;
        }
    }

    public string Director
    {
        get { return _director; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                _director = value;
        }
    }

    public override void Print()
    {
        Console.WriteLine($"{nameof(Movie)}: {base.Title}, director:{Director}, time in minutes: {TimeInMinutes}, genre: {Genre.Name} ");
    }
}

//ACCESS MODIFERS


public class Animal
{
    private string _name;
    private string _description;

    protected Animal(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if(!string.IsNullOrEmpty(value))
                _name = value;
        }
    }
    public string Description
    {
        get { return _description; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                _description = value;
        }
    }

    protected internal virtual void Sound()
    {
        Console.WriteLine(Name + " can make a sound. " + Description);
    }
}

public class Cat : Animal
{
    private string _breed;
    public Cat(string name, string description, string breed) : base(name, description)
    {
        _breed = breed;
    }

    public string Breed
    {
        get { return _breed; }
        set { _breed = value; }
    }
    protected internal override void Sound()
    {
        Console.WriteLine(Name + " can moew. " + Description);
    }
}

public class Dog : Animal
{
    private string _breed;
    public Dog(string name, string description, string breed) : base(name, description)
    {
        _breed = breed;
    }

    public string Breed
    {
        get { return _breed; }
        set { _breed = value; }
    }
    protected internal override void Sound()
    {
        Console.WriteLine(Name + " can bark. " + Description);
    }
}

//INTERFACES

public interface ISender
{
    void Send(string message);
}

public class Email : ISender
{
    public void Send(string message)
    {
        Console.WriteLine("Sending an email, " + message);
    }
}

public class SMS : ISender
{
    public void Send(string message)
    {
        Console.WriteLine("Sending a SMS, " + message);
    }
}




