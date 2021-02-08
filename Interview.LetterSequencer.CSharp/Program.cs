using System;
using System.Collections.Generic;
using System.Linq;

/*
    From : https://danielbmarkham.com/fun-with-an-interview-question/

        Most candidates cannot solve this interview problem:

            Input: "aaaabbbcca"
            Output: [("a", 4), ("b", 3), ("c", 2), ("a", 1)]
        
            Write a function that converts the input to the output I ask it in the screening interview and give it 25 minutes How would you solve it?
        
    I deliberately kept this REALLY simple - the way I'd do it if I was in an interview situation and knew I needed an easy
    to debug program. Nothing fancy, does the job ... but very verbose. I suspect the interviewer would have some additional
    questions and try to nudge me to rework it.
 */

static IEnumerable<(char, int)> ConvertToSequence(string input)
{
    var result = new List<(char, int)>();

    char? currentChar = null;
    int count = -1;

    foreach (var c in input)
    {
        if (!currentChar.HasValue)
        {
            currentChar = c;
            count = 1;
        }
        else if (currentChar == c)
        {
            count++;
        }
        else
        {
            result.Add(
                (currentChar.Value, count)
            );
            currentChar = c;
            count = 1;
        }
    }

    result.Add(
        (currentChar.Value, count)
        );

    return result;
}

static string SerializeSequence(IEnumerable<(char, int)> sequence)
{
    var res = new List<string>();

    foreach (var (c, count) in sequence)
    {
        res.Add($"(\"{c}\", {count})");
    }

    return $"[{string.Join(", ", res)}]";
}

var sequence = ConvertToSequence("aaaabbbcca");
var answer = SerializeSequence(sequence);

Console.WriteLine("[(\"a\", 4), (\"b\", 3), (\"c\", 2), (\"a\", 1)]");
Console.WriteLine(answer);