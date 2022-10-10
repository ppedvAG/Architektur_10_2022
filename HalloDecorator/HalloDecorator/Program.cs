// See https://aka.ms/new-console-template for more information
using HalloDecorator;

Console.WriteLine("Hello, World!");

var pizza = new Pizza();
Console.WriteLine($"{pizza.Beschreibung} {pizza.Preis}");

var brot = new Käse(new Käse(new Käse(new Brot())));
Console.WriteLine($"{brot.Beschreibung} {brot.Preis}");


