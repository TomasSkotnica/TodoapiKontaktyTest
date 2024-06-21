using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoapiKontaktyTest.DTO;

namespace TodoapiKontaktyTest.Pages
{
    public class KontaktyOM
    {
        // driver je field
        private readonly IWebDriver driver;

        public KontaktyOM(IWebDriver driver)
        {
            // ctrl . na driver
            this.driver = driver;
        }

        // NameINput je properta
        IWebElement NameInput => driver.FindElement(By.Id("add-name"));
        IWebElement SurnameInput => driver.FindElement(By.Id("add-surname"));
        IWebElement EmailInput => driver.FindElement(By.Id("add-email"));
        IWebElement PhoneInput => driver.FindElement(By.Id("add-phone"));
        IWebElement AddButton => driver.FindElement(By.Id("add-button"));

        public void AddKontakt2(string name, string email)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            AddButton.Click(); // nebo Submit() ?
        }

        public void AddKontakt2byKnihovna(string name, string email)
        {
            Knihovna.EnterText(NameInput, name);
            Knihovna.EnterText(EmailInput, email);
            Knihovna.Click(AddButton); // nebo Submit() ?
        }
        public void AddKontaktByExtensionMetod(KontaktDTO kontakt)
        {
            // extension metody umoynuji pridat metody do existujiciho typu
            // aniz by se musel dedit nebo rekompilovat

            NameInput.EnterTextEM(kontakt.Name);
            SurnameInput.EnterTextEM(kontakt.Surname);
            EmailInput.EnterTextEM(kontakt.Email);
            PhoneInput.EnterTextEM(kontakt.Phone);
            AddButton.ClickElement();
        }

        public void AddKontakt2byExtensionMetod(string name, string email)
        {
            // extension metody umoynuji pridat metody do existujiciho typu
            // aniz by se musel dedit nebo rekompilovat

            NameInput.EnterTextEM(name);
            EmailInput.EnterTextEM(email);
            AddButton.ClickElement();
        }
    }
}
