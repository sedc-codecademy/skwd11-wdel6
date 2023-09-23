// See https://aka.ms/new-console-template for more information
using DisposeMe;

using System.Collections;

//Console.WriteLine("Hello, World!");


//IStructuralComparable x = (1, 2, 3, 4, 5);

//IStructuralComparable y = (1, 2, 3, 4, 5);

//Console.WriteLine(x.Equals(y));

using (var r = new Resource()) { 
    r.Open();
    r.Open();
    r.Open();
};

using var r2 = new Resource();

var r3 = 7;

Console.WriteLine("Finished");