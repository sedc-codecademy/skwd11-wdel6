// See https://aka.ms/new-console-template for more information
using Bogus;

using System.Diagnostics;
using System.Text;

Console.WriteLine("Hello, World!");
Stopwatch sw = new Stopwatch();

var faker = new Faker<BuilderDemo.Person>()
    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
    .RuleFor(p => p.LastName, f => f.Name.LastName())
    .RuleFor(p => p.Title, f => f.Name.JobTitle())
    .RuleFor(p => p.Email, f => f.Internet.Email());

sw.Start();
var data = faker.Generate(1_000_000).ToList();
sw.Stop();
Console.WriteLine($"{data.Count} items generated");
Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");

//sw.Restart();
//string allInfo = string.Empty;
//foreach (var p in data)
//{
//    allInfo += p.Info() + Environment.NewLine;
//}
//sw.Stop();

//Console.WriteLine($"We have a total of {allInfo.Length} characters");

//Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");


sw.Restart();
StringBuilder allInfoSb = new StringBuilder();
foreach (var p in data)
{
    allInfoSb.Append(p.Info() + Environment.NewLine);
}
string allInfoBuilt = allInfoSb.ToString();
sw.Stop();

Console.WriteLine($"We have a total of {allInfoBuilt.Length} characters");

Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");

// Console.WriteLine(allInfo);