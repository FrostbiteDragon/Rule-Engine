using System;
using Xunit;
using RuleEngine;

namespace ValidatorTests
{
    public class BuildValidatorTests
    {
        Func<string, Result> validate;

        public BuildValidatorTests()
        {
            var rules = new Func<string, Result>[]
            {
                (text) =>
                {
                    if (text.Split(' ').Length == 3)
                        return new Pass();
                    else
                        return new Fail("Must be 3 words");
                },

                (text) =>
                {
                    if (text.Length <= 13)
                        return new Pass();
                    else
                        return new Fail("Length cannot excced 13");
                }
            };
            validate = Validator.BuildValidator(rules);
        }

        [Fact]
        public void BuildValidatorPasses()
        {
            var actual = validate("aaa aaa aaa");

            Assert.IsType<Pass>(actual);
        }

        [Fact]
        public void BuildValidatorFailes()
        {
            var actual = validate("aaa aaaaaa");

            Assert.IsType<Fail>(actual);
        }

        [Fact]
        public void BuildValidatorFailesWithCorrectMessage()
        {
            var actual = validate("aaa aaaaaa");

            Assert.True((actual as Fail).ErrorMessage == "Must be 3 words");
        }
    }
}
