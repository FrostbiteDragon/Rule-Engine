using System;
using System.Collections.Generic;
using System.Linq;


Func<string, Result> mustBe3Words = (text) =>
{
    if (text.Split(' ').Length == 3)
        return new Pass();
    else
        return new Fail("Must be 3 words");
};

Func<string, Result> MaxLength10 = (text) =>
{
    if (text.Split(' ').Length == 3)
        return new Pass();
    else
        return new Fail("Length cannot excced 10");
};

Func<string, Result> mustHaveNoCaps = (text) =>
{
    if (text.All(x => char.IsLower(x)))
        return new Pass();
    else
        return new Fail("Must have no caps");
};

var rules = new List<Func<string, Result>>()
{ 
    mustBe3Words,
    MaxLength10,
    mustHaveNoCaps
};

Func<string, Result> BuildValidator(IEnumerable<Func<string, Result>> rules)
{
    return rules.Aggregate((previusRules, nextRule) =>
    {
        return (text) =>
        {
            var result = previusRules(text);
            return result switch
            {
                Pass => nextRule(text),
                Fail errorMessage => result
            };
        };
    });
}

var validate = BuildValidator(rules);

Console.WriteLine(validate("aaaaaaaaaa aaa"));