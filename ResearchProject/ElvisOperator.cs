namespace ResearchProject
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ElvisOperator
    {
        [Theory(DisplayName = "Test Elvis Operator")]
        [MemberData(nameof(RunElvisOperatorTestData))]
        public void RunElvisOperatorTest(BaseClass actual, ResultModel expected)
        {
            // Arrange
            var exceptionThrown = false;
            bool? result1 = null;
            bool? result2 = null;
            bool? result3 = null;

            try
            {
                // Act 
                result1 = actual?.InnerClass?.InnerInnerClass == null;

                result2 = actual?.InnerClass.InnerInnerClass == null;

                result3 = actual.InnerClass.InnerInnerClass == null;
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.Equal(result1, expected.ResultIsNull1);
            Assert.Equal(result2, expected.ResultIsNull2);
            Assert.Equal(result3, expected.ResultIsNull3);
            Assert.Equal(exceptionThrown, expected.MustThrowExcpetion);
        }

        public static IEnumerable<object[]> RunElvisOperatorTestData()
        {
            yield return new object[] {
                null,
                new ResultModel
                {
                    ResultIsNull1 = true,
                    ResultIsNull2 = true,
                    ResultIsNull3 = null,
                    MustThrowExcpetion = true
                }
            };

            yield return new object[] {
                new BaseClass
                {
                    Name = "this is a base only;"
                },
                new ResultModel
                {
                    ResultIsNull1 = true,
                    ResultIsNull2 = null,
                    ResultIsNull3 = null,
                    MustThrowExcpetion = true
                }
            };

            yield return new object[] {
                new BaseClass
                {
                    Name = "this is a base only;",
                    InnerClass = new InnerClass
                    {
                        Name = "This is Inner"
                    }
                },
                new ResultModel
                {
                    ResultIsNull1 = true,
                    ResultIsNull2 = true,
                    ResultIsNull3 = true,
                    MustThrowExcpetion = false
                }
            };

            yield return new object[] {
                new BaseClass
                {
                    Name = "this is a base only;",
                    InnerClass = new InnerClass
                    {
                        Name = "This is Inner",
                        InnerInnerClass = new InnerInnerClass
                        {
                            Name = "this is inner inner"
                        }
                    }
                },
                new ResultModel
                {
                    ResultIsNull1 = false,
                    ResultIsNull2 = false,
                    ResultIsNull3 = false,
                    MustThrowExcpetion = false
                }
            };
        }
    }

    public class ResultModel
    {
        public bool? ResultIsNull1 { get; set; }
        public bool? ResultIsNull2 { get; set; }
        public bool? ResultIsNull3 { get; set; }
        public bool MustThrowExcpetion { get; set; }
    }

    public class BaseClass
    {
        public string Name { get; set; }

        public InnerClass InnerClass { get; set; }
    }

    public class InnerClass
    {
        public string Name { get; set; }

        public InnerInnerClass InnerInnerClass { get; set; }
    }

    public class InnerInnerClass
    {
        public string Name { get; set; }
    }
}
