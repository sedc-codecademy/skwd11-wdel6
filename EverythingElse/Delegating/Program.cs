// See https://aka.ms/new-console-template for more information
using Delegating;

Console.WriteLine("Hello, World!");


int[] numbers = [ 1, 2, 3, 4, 5 ];

var evensArr = numbers.Where(n => n % 2 == 0);

List<int> nlist = [1, 2, 3, 4, 5];

var evensList = nlist.FindAll(n => n % 2 == 0);

IntOperation add = (int first, int second) => first + second;
var subtract = (int first, int second) => first - second;
Func<int, int, int> multiply = (int first, int second) => first * second;

var result = add(2, 3);
Console.WriteLine(result);
