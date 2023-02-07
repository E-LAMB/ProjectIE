using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a static script accessible by all other scripts. It stores these variables across scenes without requiring a declaration before the Start Method
public static class Mind // Sets the type
{

    public static string save_path; // The path in which the save file can be found

    // Booleans that control how the player hides during the Fleshy Level
    public static bool player_is_hidden = false;
    public static bool player_is_inside_object = false;
    public static bool player_behind_object = false;

    public static bool startup_script_ran = false; // Prevents parts of the Menu Manager script running multiple times

    // The point where the player is in the game
    public static int saved_game_point = 0;

    public static bool in_control = false;

}
