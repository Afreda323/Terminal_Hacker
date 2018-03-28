using UnityEngine;

public class Hacker : MonoBehaviour {
    // user selected level
    int level;
    // randomly selected password
    string password;
    // Possible level 1 and 2 passwords
    string[] level1Passwords = { "book", "books", "harrypotter", "password" };
    string[] level2Passwords = { "Dolan", "trump", "maga", "thewall" };

    // Game screens
    enum Screen {
        MainMenu,
        Password,
        Victory
    }
    // Currently active screen
    Screen currentScreen;

    // Clear screen
    //Display main menu
    void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for US Government");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Called when user hits enter
    // Handle various inputs 
    void OnUserInput (string input) {
        if (input == "menu") {
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            ValidatePassword(input);
        }
    }

    // Handle user selecting level
    void RunMainMenu (string input) {
        bool isLevel = input == "1" || input == "2";

        if (isLevel) {
            level = int.Parse(input);
            AskForPassword();
        } else {
            Terminal.WriteLine("Enter a valid number");
        }
    }

    // Assign a random password
    // Give hint
    // Ask user for it
    void AskForPassword () {
        currentScreen = Screen.Password;
        switch(level) {
            case 1:
                int random1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[random1];
                break;
            case 2:
                int random2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[random2];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password: hint: " + password.Anagram());

    }

    void ValidatePassword (string input) {
        if (input == password) {
            ShowWinScreen();
        } else {
            Terminal.WriteLine("Incorrect! hint: " + password.Anagram());
        }
    }

    // If user wins
    // Update state
    // display graphic
    void ShowWinScreen () {
        currentScreen = Screen.Victory;
        Terminal.ClearScreen();
        ShowReward();
    }

    // Reward graphics
    void ShowReward () {
        switch (level) {
            case 1:
                Terminal.WriteLine(@"
   /-/|
  /_/ |
  | |/|
  |^| |
  |_|/
You made it
");
                break;
            case 2:
                Terminal.WriteLine(@"

=====;===========;()
            # # # #::::::
            # # # #::::::
            # # # #::::::
            # # # #::::::
            # # # # # # #
            # # # # # # #
            # # # # # # #
            # # # # # # #
            # # # # # # #  
             You Made it              
");
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

	// Use this for initialization
    void Start () {
        ShowMainMenu();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
