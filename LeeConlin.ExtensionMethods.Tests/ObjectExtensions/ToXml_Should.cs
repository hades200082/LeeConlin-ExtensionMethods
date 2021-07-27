using System.Xml.Serialization;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.ObjectExtensions
{
    public class ToXml_Should
    {
        [Fact]
        public void ProduceXml()
        {
            var obj = new TestClass
            {
                TestBool = true,
                TestDecimal = 0.5m,
                TestDouble = 1.5,
                TestInt = 150,
                TestString = "Lorum ipsum dolor set amet",
                TestChildClass = new TestChildClass
                {
                    TestBool = true,
                    TestDecimal = 0.5m,
                    TestDouble = 1.5,
                    TestInt = 150,
                    TestString = "Lorum ipsum dolor set amet",
                }
            };

            var expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><TestClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><TestString>Lorum ipsum dolor set amet</TestString><TestInt>150</TestInt><TestDouble>1.5</TestDouble><TestDecimal>0.5</TestDecimal><TestBool>true</TestBool><TestChildClass><TestString>Lorum ipsum dolor set amet</TestString><TestInt>150</TestInt><TestDouble>1.5</TestDouble><TestDecimal>0.5</TestDecimal><TestBool>true</TestBool></TestChildClass></TestClass>";
            var actual = obj.ToXml();

            actual.Should().Be(expected);
        }
        
        
        [Fact]
        public void ProduceXmlWithAttributes()
        {
            var obj = new TestClassWithAttributes()
            {
                TestInt = 150,
                TestString = "Lorum ipsum dolor set amet"
            };

            var expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Person xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" age=\"150\"><name>Lorum ipsum dolor set amet</name></Person>";
            var actual = obj.ToXml();

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
        public TestChildClass TestChildClass { get; set; }
    }
    public class TestChildClass
    {
        public string TestString { get; set; }
        public int TestInt { get; set; }
        public double TestDouble { get; set; }
        public decimal TestDecimal { get; set; }
        public bool TestBool { get; set; }
    }

    [XmlRoot("Person")]
    public class TestClassWithAttributes
    {
        [XmlElement("name")]
        public string TestString { get; set; }
        
        [XmlAttribute("age")]
        public int TestInt { get; set; }
    }
}