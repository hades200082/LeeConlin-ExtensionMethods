using System;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class FromXml_Should
    {
        [Fact]
        public void DeserialiseToType()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><TestClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><TestString>Lorum ipsum dolor set amet</TestString><TestInt>150</TestInt><TestDouble>1.5</TestDouble><TestDecimal>0.5</TestDecimal><TestBool>true</TestBool></TestClass>";
            
            var expected = new TestClass
            {
                TestBool = true,
                TestDecimal = 0.5m,
                TestDouble = 1.5,
                TestInt = 150,
                TestString = "Lorum ipsum dolor set amet"
            };
            
            var actual = xml.FromXml<TestClass>();

            actual.Should().BeOfType<TestClass>();
            actual.Should().Be(expected);
        }
    }
    
    public class TestClass
    {
        public string TestString { get; set; }
        public int TestInt { get; set; }
        public double TestDouble { get; set; }
        public decimal TestDecimal { get; set; }
        public bool TestBool { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is TestClass))
                return false;
            
            var other = (TestClass) obj;
            return other.TestBool == TestBool &&
                   other.TestDecimal == TestDecimal &&
                   Math.Abs(other.TestDouble - TestDouble) < 0.0001 &&
                   other.TestString == TestString &&
                   other.TestInt == TestInt;

        }
    }
}