using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using TodoapiKontaktyTest.DTO;
using TodoapiKontaktyTest.Pages;

namespace TodoapiKontaktyTest
{
    public class Tests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:7150");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        //[Test]
        //public void TestUsePomAdd()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://localhost:7150");
        //    KontaktyOM pom = new(driver);
        //    pom.AddKontakt2("tom2", "tom2@s.cz");
        //}

        //[Test]
        //public void TestbyPOMbyKnohovna()
        //{
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://localhost:7150");
        //    KontaktyOM pom = new(driver);
        //    pom.AddKontakt2byKnihovna("Add2byPOMbyKnihovna", "tom2@s.cz");
        //}

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(KontaktyJsonDataSource))]
        public void TestbyExtensMetod(KontaktDTO kontakt)
        {
            KontaktyOM pom = new(driver);
            pom.AddKontaktByExtensionMetod(kontakt);
        }

        private static IEnumerable<KontaktDTO> KontaktyJsonDataSource()
        { 
            string fp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "addKontakty1.json");
            string js = File.ReadAllText(fp);
            var os = JsonSerializer.Deserialize<List<KontaktDTO>>(js);
            foreach (var k in os)
                { yield return k; }
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(KontaktySource))]
        public void TestHardCodedData(KontaktDTO kontakt)
        {
            //var driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://localhost:7150");
            KontaktyOM pom = new(driver);
            pom.AddKontaktByExtensionMetod(kontakt);
        }

        private static IEnumerable<KontaktDTO> KontaktySource()
        {
            yield return new KontaktDTO()
            {
                Name = "jmeno",
                Surname = "prijmeni",
                Email = "em@w.a",
                Phone = "123"
            };
            yield return new KontaktDTO()
            {
                Name = "jmeno2ggggggggggggggggggggggggggggggggggg",
                Surname = "prijmeni2uuuuuuuuuuuuuuuuuuuuuuuuuuu",
                Email = "em@w.a",
                Phone = "123"
            };
        }

        [Test]
        public void TestCountOfRows()
        {
            KontaktyOM pom = new(driver);
            int c = pom.GetRowCount();
            Assert.AreEqual(7, c);
        }
    }
}