using Accessing;

var weko = new Person("Wekoslav", "Stefanovski");
Console.WriteLine(weko);

var neil = new Person
{
    FirstName = "Neil",
    LastName = "Armstrong"
};

Console.WriteLine(neil);

PeopleProcessor pp = new PeopleProcessor();
pp.Process(weko);

Console.WriteLine(weko);