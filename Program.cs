using System.Linq;


string[] names = { "lenin", "hayase", "sana", "kurumi", "tohka", "kotori", "origami" };
int[] numbers = { 1, 2, 5, 4, 6, 4, 5, 3, 11, 2, 3, 7, 8, 9, 0, 8, 9, 7, 6 };
string sentence = "i love sana";



var output = from number in numbers
             where number < 5
             select number;

List<int> newNumbers = new();
foreach (var item in numbers)
{
    if (item < 5)
    {
        newNumbers.Add(item);
    }
}
Console.WriteLine(string.Join(", ", output));
Console.WriteLine(string.Join(", ", newNumbers));

var namesWith_A = from name in names
                    where name.Contains("a")
                    where name.Length < 10
                    orderby name ascending
                    select name;


Console.WriteLine(string.Join(", ", namesWith_A));

