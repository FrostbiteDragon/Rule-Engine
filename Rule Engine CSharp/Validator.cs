using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEngine
{
    public static class Validator
    {
        public static Func<string, Result> BuildValidator(IEnumerable<Func<string, Result>> rules)
        {
            return rules.Aggregate((previusRules, nextRule) =>
            {
                return (text) =>
                {
                    var result = previusRules(text);
                    return result switch
                    {
                        Pass => nextRule(text),
                        Fail errorMessage => result,
                    };
                };
            });
        }
    }
}