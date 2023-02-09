#region variables
int min = -1_000_000_000;
int max = 1_000_000_000;
string output;

const string QUIT = "Quit";
#endregion

#region main code
Console.Clear();
do
{
    output = NumberIntoLongText(AskForUserInput());
    Console.WriteLine(output != QUIT ? $"Your output: {output}" : "Quitting the program...");
} while (output != QUIT);
#endregion

#region methods
string AskForUserInput()
{
    string number;
    do
    {
        Console.Write("Enter a number: ");
        number = Console.ReadLine()!.ToLower();
    } while (number != "q" && (int.Parse(number) < min || int.Parse(number) > max));
    return number;
}

string NumberIntoLongText(string number)
{
    string numberInText = "";
    int originalLength = number.Length;
    if (number == "q") { return QUIT; }
    if (int.Parse(number) < 0)
    {
        numberInText += "minus ";
        number = number.Substring(1);
    }
    do
    {
        if (number.Length is 1 or 3 or 4 or 6 or 7 or 9)
        {
            numberInText += DigitIntoLongText(int.Parse(number[0].ToString()), originalLength);
            number = GetSubstring(1, number);
        }
        else if (int.Parse(number.Substring(0, 2)) < 20)
        {
            numberInText += SmallerTwentyBiggerTen(int.Parse(number.Substring(0, 2)));
            number = GetSubstring(2, number);
        }
        else
        {
            numberInText += BiggerTwentySmallerHundred(int.Parse(number[0].ToString()));
            number = GetSubstring(1, number);
        }
        if (number.Length == 2 || number.Length == 5 || number.Length == 8)
        { numberInText += "hundred"; }
        else if (number.Length == 3)
        { numberInText += "thousand "; }
        else if (number.Length == 6)
        { numberInText += "million "; }
    } while (number.Length >= 1);
    return numberInText;
}

string DigitIntoLongText(int digit, int originalLength)
{
    return digit switch
    {
        0 => originalLength == 1 ? "zero" : "",
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => ""
    };
}

string SmallerTwentyBiggerTen(int number)
{
    return number switch
    {
        0 => "",
        10 => "ten",
        11 => "eleven",
        12 => "twelve",
        13 => "thirteen",
        15 => "fifteen",
        18 => "eighteen",
        _ => $"{DigitIntoLongText(number % 10, 0)}teen"
    };
}

string BiggerTwentySmallerHundred(int digit)
{
    return digit switch
    {
        2 => "twenty",
        3 => "thirty",
        4 => "forty",
        5 => "fifty",
        8 => "eighty",
        _ => $"{DigitIntoLongText(digit, 0)}ty"
    };
}
string GetSubstring(int index, string text) => text.Substring(index);
#endregion