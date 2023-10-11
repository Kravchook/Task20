using OpenQA.Selenium;

namespace Task20.Controls
{
    public class LoginInput
    {
        public By ByXpath = By.XPath("//input[@name='username']");//works

        public By ByClassName = By.ClassName("form-control"); //does not work (6 matches)

        public By ByCssSelector = By.CssSelector("#inputEmail"); //works

        public By ById = By.Id("inputEmail"); //works

        public By ByName = By.Name("username"); //works

        public By ByTagName = By.TagName("input"); //does not work (11 matches)

        public By ByLinkedText = By.LinkText("LOGIN"); //works

        public By ByPartialLinkText = By.PartialLinkText("LOGIN"); //works
    }
}