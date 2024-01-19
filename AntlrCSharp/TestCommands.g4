grammar TestCommands;

// Define a rule for each command
openApplication : 'OpenApplication';
navigateToPage  : 'NavigateToPage';
clickOnElement : 'ClickOnElement' STRING;

// Define a rule for all commands
command : openApplication | navigateToPage | clickOnElement;

// Define a rule for a series of commands
commands : command+ ;

// Helper rules for basic tokens like strings and whitespace
STRING : '"' [^\\"]* '"';
WS     : [ \t\r\n]+ -> skip ;
