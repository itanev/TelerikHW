using System;

class ImportantMethodsOfTheStringClass
{
    static void Main()
    {
        //the string is just array of characters.
        //It's goal is to make our lives easier by giving us convinient methods
        //for processing char arrays.
        string str = "     This is a string.        ";

        //WE CAN'T CHANGE THE ACTUAL VALUE OF A STRING THAT'S WHY ALL THE
        //METHODS IN THE STRING CLASS RETURN STRINGS IF THEAR PURPOSE IS TO CHANGE
        //SOMETHING IN A STRING

        //contains method just tells us if the string contans the passed string
        str.Contains("This");
        //equals is very convinient method for comparing strings
        str.Equals("This is string");
        //compareto does the same as equals
        str.CompareTo("This is a string");
        //trim removes all the intervals at the beggining and at the end
        str.Trim();
        //indexof searches for the first occurrence of a string or a char
        str.IndexOf("is");
        //lastindexof searches for the last occurrence of a string or a char
        str.LastIndexOf("string");
        //split method splits the string into array of strings by using the given char of string
        str.Split(' ');
        //replace method replaces character or a string
        str.Replace('T', 't');
        //remove method removes given length of characters starting from given index
        str.Remove(0, 10);
        //tochararray converts the string exactly to char array
        str.ToCharArray();
        //toupper makes all the letters in a string capital
        str.ToUpper();
        //tolower makes all the letters in a string lower
        str.ToLower();
        //substring gives us substring with given length starting from given index
        str.Substring(0, 10);
    }
}