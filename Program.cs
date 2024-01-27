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
    new Person("sana", 60, 23, Gender.Female),
    new Person("lenin", 55, 22, Gender.Male),
    new Person("sss", 55, 22, Gender.Male),
    new Person("dd", 55, 22, Gender.Male),
    new Person("aaaaaa", 55, 22, Gender.Male),
    new Person("ggggg", 55, 22, Gender.Male),
    new Person("zxzxzx", 55, 22, Gender.Male),
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

var oddNumbers = from n in numbers 
                where n % 1 == 0
                select n;

Console.WriteLine(string.Join(", ", oddNumbers));

// lambda expressions
oddNumbers = numbers.Where(n => n % 1 == 0);
Console.WriteLine(string.Join(", ", oddNumbers));

var youngestPeople = people.Where(p => p.age < 20);
foreach(var item in youngestPeople){
    Console.WriteLine($"name: {item.name} age: {item.age}");
}

var youngestPeople2 = people.Where(p => p.age < 20).Select(p => p.age);
foreach(var item in youngestPeople2){
    Console.WriteLine($"age: {item}");
}

List<int> youngestPeopleList = people.Where(p => p.age < 20).Select(p => p.age).ToList();
Console.WriteLine(string.Join(", ",youngestPeopleList));
youngestPeopleList.ForEach(p => Console.WriteLine(p));


// group by 
var groupPeople = from p in people
            where p.age > 21
            group p by p.gender;
foreach (var item in groupPeople)
{   
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine($"name: {person.name} age:{person.age}");
    }
}

var alphabetical = from p in people
                    group p by p.name[0];




foreach (var item in alphabetical)
{   
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine($"name: {person.name} age:{person.age}");
    }
}

var byGender = people.GroupBy(p => (
    p.gender
));

foreach (var item in byGender)
{   
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine($"name: {person.name} gender:{person.gender}");
    }
}


Console.WriteLine("order alphabetical, order by letter .....");

var byGender2 = people.OrderBy(p => (
    p.name[0]
)).GroupBy(p => (
    p.name[0]
));
foreach (var item in byGender2)
{   
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine($"name: {person.name} gender:{person.gender}");
    }
}

// mulitkey

var multikey = people.GroupBy(p => new {
    p.gender, p.age
}).OrderBy(p => p.Count());
foreach (var item in multikey)
{   
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine($"name: {person.name} gender:{person.gender}");
    }
}


// join 
List<Cat> cats = new(){
    new Cat("purr", 2, Gender.Female),
    new Cat("lala", 3, Gender.Female),
    new Cat("lalo", 1, Gender.Female),
    new Cat("oto", 2, Gender.Female),
    new Cat("morris", 4, Gender.Female),
    new Cat("bibi", 5, Gender.Female),
    new Cat("snow", 4, Gender.Female),
    new Cat("tripi", 3, Gender.Female),
    new Cat("piti", 2, Gender.Male),
    new Cat("zaco", 4, Gender.Male),
    new Cat("koko", 5, Gender.Male),
    new Cat("guu", 7, Gender.Male),
    new Cat("fyu", 6, Gender.Male),
    new Cat("kal", 4, Gender.Male),
    new Cat("wonk", 5, Gender.Male),
    new Cat("tehte", 5, Gender.Male),
    new Cat("jojo", 7, Gender.Male),
    new Cat("naij", 8, Gender.Male),
};

Console.WriteLine("inner join ...............");

var innerjoin = people.Join(cats, p => p.gender, c => c.gender, (p,c) => new{
    owner = p.name,
    cat = c.name,
    catAge = c.age,
});

foreach (var item in innerjoin)
{   
    
    Console.WriteLine($"name: {item.owner} cat:{item.cat}");
    
}


Console.WriteLine("inner join 2 .........");
var innerjoin2 = from p in people
                join c in cats on p.gender equals c.gender
                select new {
                    owner = p.name,
                    cat = c.name,
                };

foreach (var item in innerjoin2)
{   
    Console.WriteLine($"name: {item.owner} cat:{item.cat}");
}

// filters
Console.WriteLine("filters.......");

object[] objs = {111, 123, new List<Object>{345, 455, 234, "lalala", "dead", new List<int>{888, 999}}, new List<int>{66,55,44,33}, "fff", "sss", "aaa", 123, 123.23};


var filtered = objs.OfType<int>();
Console.WriteLine(string.Join(", ",filtered));


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

public class Cat{
    public string name;
    public int age;
    public Gender gender;

    public Cat(string name, int age, Gender gender){
        this.name = name;
        this.age = age;
        this.gender = gender;
    }
}




