int[] numbers = {5, 5, 5, 1, 9, 2, 2, };
List<Object> obs = new(){
    "sss", 2, 3, 4, 5, 6, 7, 8, "ddd", "fff"
};
string[] cities = {"ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI","PARIS"};



Exercises e = new();
e.evenNumbers(numbers);
e.square(obs);
e.numberFrequency(numbers);
e.numberTimesFrequency(numbers);
e.strinStartEndWith(cities, 'A','M');

Console.WriteLine(e.Greetings("asd")());

