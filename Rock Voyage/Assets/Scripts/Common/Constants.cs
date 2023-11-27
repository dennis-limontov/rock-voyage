using System;
using UnityEngine;

namespace RockVoyage
{
    public class Constants
    {
        public const string GAME_NAME = "Rock Voyage";

        // scenes
        public const string MAIN_MENU_SCENE_NAME = "Main Menu";
        public const string CUT_SCENE_START = "Cut Scene Start";
        public const string START_CITY_NAME = "Map";

        // layers
        public static string HOUSE_LAYER = "House";

        // sliders
        public const float SLIDER_LIMIT_MIDDLE = 0.7f;
        public const float SLIDER_LIMIT_LOW = 0.4f;
        public const float SLIDER_LIMIT_DANGER = 0.1f;
        public static Color SLIDER_COLOR_MAX = new Color(0.04f, 0.62f, 0.1f, 1f);
        public static Color SLIDER_COLOR_MIDDLE = Color.yellow;
        public static Color SLIDER_COLOR_LOW = new Color(1f, 0.5f, 0f, 1f);
        public static Color SLIDER_COLOR_DANGER = Color.red;

        public const float ENERGY_CONSUMPTION_PER_HOUR = 0.04f;
        public const float ENERGY_MAX = 1f;
        public static float SCENE_PROFIT_PERCENT = 0.1f;
        public static float FAME_INCREMENT = 0.01f;
        public static float FAME_MAX = 1f;

        // states
        public const string PLAYER_STATE_IDLE = "Idle";
        public const string PLAYER_STATE_SING = "Sing";
        public const string PLAYER_STATE_WALK_FRONT = "Walk Front";
        public const string PLAYER_STATE_WALK_LEFT = "Walk Left";
        public const string PLAYER_STATE_WALK_RIGHT = "Walk Right";
        public const string PLAYER_STATE_WALK_UP = "Walk Up";
        public const string PLAYER_STATE_BOOL_IDLE = "isIdle";
        public const string PLAYER_STATE_BOOL_WALK_FRONT = "isWalkingFront";
        public const string PLAYER_STATE_BOOL_WALK_LEFT = "isWalkingLeft";
        public const string PLAYER_STATE_BOOL_WALK_RIGHT = "isWalkingRight";
        public const string PLAYER_STATE_BOOL_WALK_UP = "isWalkingUp";

        // time
        public static TimeSpan GARAGE_STUDIO_TIME = new TimeSpan(2, 0, 0);
        public static TimeSpan PRO_STUDIO_TIME = new TimeSpan(6, 0, 0);
        public static TimeSpan SCENE_TIME = new TimeSpan(3, 0, 0);

        // costs
        public static int MONEY_AT_START = 100;
        public static int MAP_COST = 60;
        public static int NEWSPAPER_COST = 60;
        public const int HOSTEL_NEW_DAY_HOUR = 10;
        public const int PRO_STUDIO_RECORD_COST = 50;
        public const int TAXI_COST = 25;

        public static string DATE_STRING_FORMAT = "yyyy/MM/dd hh:mm tt";
        public const int PLAYERS_MAX = 2;
        public static Color NIGHT_MODE_COLOR = new Color(0.3f, 0.47f, 0.95f, 1f);
        public static int NIGHT_MODE_HOURS_OFF = 6;
        public static int NIGHT_MODE_HOURS_ON = 22;

        public static float STREET_MUSIC_TIME = 30f;
        public static float REMEMBER_CHANCE = 0.5f;
        public static float EARN_MONEY_CHANCE = 0.05f;
    }
}