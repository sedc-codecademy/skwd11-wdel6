using Accessing;

internal class PeopleProcessor
{
    private List<Person> persons = new ();

    internal void Process(Person person)
    {
        // person.FirstName = "AAAAAAAAAAAAAAAA";
        persons.Add(person);
    }
}