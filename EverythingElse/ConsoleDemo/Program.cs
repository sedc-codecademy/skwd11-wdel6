Console.WriteLine("Hello, SEDC !?");

var x = 3;

if (x is 3)
{
    Console.WriteLine("Trojka");
}
else
{
    Console.WriteLine("Ne e trojka");
}

var client = new HttpClient();
var source = await client.GetStringAsync("https://raw.githubusercontent.com/sedc-codecademy/skwd10-wdel6/class-two/SedcServer10/FirstDemo/Program.cs");

Console.WriteLine(source);
