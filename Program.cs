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

List<Person> people = new(){
    new Person("sana", 60, 23, Gender.Male),
    new Person("lenin", 55, 22, Gender.Female),
    new Person("hayase", 55, 21, Gender.Female),
    new Person("tohka", 55, 23, Gender.Female),
    new Person("hiyori", 54, 25, Gender.Female),
    new Person("origami", 56, 18, Gender.Female),
    new Person("aqua", 59, 25, Gender.Female),
    new Person("darkness", 67, 26, Gender.Female),
    new Person("megummin", 49, 16, Gender.Female),
    new Person("pris", 58, 23, Gender.Female),
    new Person("asuna", 55, 20, Gender.Female),
};

var newNames = from person in people
                where person.name.Length < 6
                orderby person.age descending
                select person;

foreach (var item in newNames)
{
    Console.WriteLine($"name: {item.name} - age: {item.age}");
    
}

// objects
public enum Gender{
    Male,
    Female
}
public class Person{
    public string name;
    public int number ;
    public int age;
    public Gender gender;

    public Person(string name, int number, int age, Gender gender){
        this.name = name;
        this.number = number;
        this.age = age;
        this.gender = gender;
    }
}




