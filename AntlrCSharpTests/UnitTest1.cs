using Antlr4.Runtime;
using AntlrCSharpTests;
using System.Text;
using static TestCommandsParser;

namespace AntlrCSharp;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        string openAppCommand = "OpenApplication";
        string navigateToPage = "NavigateToPage";
        string clickOnElement = "ClickOnElement \"Element111\"";

        StringBuilder fullCommandSB = new StringBuilder();
        fullCommandSB.AppendLineExt(openAppCommand)
            .AppendLineExt(navigateToPage)
            .AppendLineExt($"{clickOnElement} TheElement111");

        var testStepsCommandsContext = ParseCommands(fullCommandSB.ToString());

        ProcessTestStepCommands(testStepsCommandsContext);

    }

    private void ProcessTestStepCommands(TestCommandsParser.CommandsContext commandsContext)
    {
        foreach (var commandContext in commandsContext.command())
        {
            if (commandContext.openApplication() != null)
            {
                Console.WriteLine("Telling us to open the application...");
                //HandleOpenApplication(commandContext.openApplication());
            }
            else if (commandContext.navigateToPage() != null)
            {
                Console.WriteLine("Telling us to navigateToPage...");
                //HandleNavigateToPage(commandContext.navigateToPage());
            }
            else if (commandContext.clickOnElement() != null)
            {
                // HandleClickOnElement(commandContext.clickOnElement());

                // Retrieve the STRING token from the context
                // TODO: make the casting more efficient! Check and return in 1 call.
                var context = commandContext.clickOnElement();
                var stringToken = context.STRING();

                // Extract the text from the token, and trim the surrounding quotes
                string elementId = stringToken.GetText().Trim('\"');

                //TODO: handle missing STRING

                // Now you can use elementId in your custom logic
            }



        }
    }

public TestCommandsParser.CommandsContext ParseCommands(string input)
{
    AntlrInputStream inputStream = new AntlrInputStream(input);
    // Auto-generated with Antrl4 from our .g4 grammar!
    TestCommandsLexer lexer = new TestCommandsLexer(inputStream);
    CommonTokenStream tokens = new CommonTokenStream(lexer);
    TestCommandsParser parser = new TestCommandsParser(tokens);

    // Add your logic to work with the parser
    // For example, parse a 'commands' rule
    var context = parser.commands();
    // Process the parsed data

    // TODO: add your custom logic to handle the parsed data, like executing the specific actions for OpenApplication, NavigateToPage, and ClickOnElement.
    string investigateCommands = "";
    return context;
}

}