using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{

    public static float forest_speed = 0f;

    public static bool player_is_hidden = false;
    public static bool player_is_inside_object = false;
    public static bool player_behind_object = false;

    public static bool startup_script_ran = false;

    public static int saved_game_point = 0;
    // 0 - First time running the game
    // 1 - Entered the blank world
    // 2 - Entered the fleshy world
    // 3 - Entered the asylum
    // 4 - Saw the final cutscene

}
