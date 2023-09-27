using Equality;

var weko1 = new PersonClass("Wekoslav", "Stefanovski");

var weko2 = new PersonClass("Wekoslav", "Stefanovski");

Console.WriteLine(weko1 == weko2); 
Console.WriteLine(weko1.Equals(weko2)); 
Console.WriteLine(weko1.Equals((object)weko2));


Console.WriteLine(weko1.Equals(7));
Console.WriteLine(weko1.Equals(null));

Console.WriteLine("--------------------------");

var weko3 = new PersonStruct("Wekoslav", "Stefanovski");

var weko4 = new PersonStruct("Wekoslav", "Stefanovski");

// Console.WriteLine(weko3 == weko4);
Console.WriteLine(weko3.Equals(weko4));
Console.WriteLine(weko3.Equals((object)weko4));


Console.WriteLine(weko3.Equals(7));
Console.WriteLine(weko3.Equals(null));

Console.WriteLine("--------------------------");

var weko5 = new PersonRecord("Wekoslav", "Stefanovski");

var weko6 = new PersonRecord("Wekoslav", "Stefanovski");

Console.WriteLine(weko5 == weko6);
Console.WriteLine(weko5.Equals(weko6));
Console.WriteLine(weko5.Equals((object)weko6));


Console.WriteLine(weko5.Equals(7));
Console.WriteLine(weko5.Equals(null));

Console.WriteLine("--------------------------");
Console.WriteLine(weko1.Equals(weko3));
