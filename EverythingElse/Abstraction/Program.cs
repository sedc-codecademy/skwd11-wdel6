// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


abstract class PersonBase
{
    public abstract string FirstName { get; set; }
    public abstract string LastName { get; set; }
    public virtual string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}

class Person1 : PersonBase
{
    public override string FirstName { get; set; }
    public override string LastName { get; set; }

}

interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}

class Person2 : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}