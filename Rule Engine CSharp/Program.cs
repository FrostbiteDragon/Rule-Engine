using System;
using System.Collections.Generic;
using System.Linq;
using RuleEngine;

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
    if (text.Where(x => char.IsLetter(x)).All(x => char.IsLower(x)))
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

var validate = Validator.BuildValidator(rules);

Console.WriteLine(validate("aaaaaa aaa aaa"));