using System;
using System.Collections.Generic;

class Brackets
{
    static void Main()
    {
        Console.Write("Enter expression: ");
        string exp = Console.ReadLine();

        List<int> openIndexes = FindBracketIndexes('(', exp);
        List<int> closeIndexes = FindBracketIndexes(')', exp);

        if (openIndexes.Count != closeIndexes.Count)
        {
            Console.WriteLine("The expression is invalid");
            return;
        }

        for (int i = 0; i < openIndexes.Count; i++)
        {
            if (closeIndexes[i] <= openIndexes[i])
            {
                Console.WriteLine("The expression is invalid");
                return;
            }
        }

        Console.WriteLine("Valid expression");
    }

    static List<int> FindBracketIndexes(char bracket, string exp)
    {
        int i = 0;
        List<int> brackets = new List<int>();

        if (exp[0] == bracket)
        {
            brackets.Add(0);
        }

        while ((i = exp.IndexOf(bracket, i + 1)) != -1)
        {
            brackets.Add(i);
        }

        return brackets;
    }
}
