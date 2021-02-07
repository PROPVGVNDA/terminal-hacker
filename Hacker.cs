using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Answers = {"books", "aiske", "self", "password", "font", "borrow"};
    string[] level2Answers = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Answers = { "austronaut", "meteor", "comet", "starship", "jedi" };
    #region Members

    int level;
    string password;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    #endregion

    // Initialization
    void Start()
    {
        print(level1Answers[0]);
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input.ToLower() == "main" || input.ToLower() == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        } 
        else if (input.ToLower() == "quit" || input.ToLower() == "close" || input.ToLower() == "exit")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            SetLevel(input);
        } 
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        } 
    }

    void SetLevel(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            switch (level)
            {
                case 1:
                    password = level1Answers[Random.Range(0, level1Answers.Length)];
                    break;
                case 2:
                    password = level2Answers[Random.Range(0, level2Answers.Length)];
                    break;
                case 3:
                    password = level3Answers[Random.Range(0, level3Answers.Length)];
                    break;
                default:
                    Terminal.WriteLine("Try Again");
                    break;
            }
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Enter a valid level!");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Please enter password! Hint - {password.Anagram()}");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Password is correct!");
            DisplayWinScreen();
        } else
        {
            Terminal.WriteLine("Wrong Password, Try Again!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Well Done! Have a book...");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\ 
 //________.|.________\\ 
`----------`-'----------'
"
                );
                break;
            case 2:
                Terminal.WriteLine(@"
              _ _          
  _ __   ___ | (_) ___ ___ 
 | '_ \ / _ \| | |/ __/ _ \
 | |_) | (_) | | | (_|  __/
 | .__/ \___/|_|_|\___\___|
 |_|                       ⠀⠀⠀⠀⠀
"
                );
                Terminal.WriteLine("WOW! You can now erase all info on you  a");
                break;
            case 3:
                Terminal.WriteLine(@"
                       .-.
                      |_:_|
                     /(_Y_)\
.                   ( \/M\/ )
 '.               _.'-/'-'\-'._
   ':           _/.--'[[[[]'--.\_
     ':        /_'  : |::' | :  '.\
       ':     //   ./ |oUU| \.'  :\
         ':  _:'..' \_|___|_/ :   :|
"
                );
                Terminal.WriteLine("DARTH VADER? IS THAT YOU?");   
                break;
        }
        Terminal.WriteLine("To start a new game enter menu or main");
        Terminal.WriteLine("To close game type exit or close!");
    }
}
