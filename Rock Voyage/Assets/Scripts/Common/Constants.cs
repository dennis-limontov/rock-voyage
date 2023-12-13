using System;
using UnityEngine;

namespace RockVoyage
{
    public static class Constants
    {
        public const string GAME_NAME = "Rock Voyage";

        // scenes
        public const string MAIN_MENU_SCENE_NAME = "Main Menu";
        public const string CUT_SCENE_START = "Cut Scene Start";
        public const string START_CITY_NAME = "Map";

        // sliders
        public const float SLIDER_LIMIT_MIDDLE = 0.7f;
        public const float SLIDER_LIMIT_LOW = 0.4f;
        public const float SLIDER_LIMIT_DANGER = 0.1f;
        public static readonly Color SLIDER_COLOR_MAX = new Color(0.04f, 0.62f, 0.1f, 1f);
        public static readonly Color SLIDER_COLOR_MIDDLE = Color.yellow;
        public static readonly Color SLIDER_COLOR_LOW = new Color(1f, 0.5f, 0f, 1f);
        public static readonly Color SLIDER_COLOR_DANGER = Color.red;

        public const float ENERGY_CONSUMPTION_PER_HOUR = 0.04f;
        public const float ENERGY_DRINK_EFFECT = 0.5f;
        public const float ENERGY_MAX = 1f;
        public const float SCENE_PROFIT_PERCENT = 0.1f;
        public const float FAME_INCREMENT = 0.01f;
        public const float FAME_MAX = 1f;

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
        public static readonly string[] PLAYER_STATE_MOVING_BOOL_NAMES =
        {
            PLAYER_STATE_BOOL_IDLE,
            PLAYER_STATE_BOOL_WALK_FRONT,
            PLAYER_STATE_BOOL_WALK_LEFT,
            PLAYER_STATE_BOOL_WALK_RIGHT,
            PLAYER_STATE_BOOL_WALK_UP,
        };

        // time
        public static readonly TimeSpan GARAGE_STUDIO_TIME = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan PRO_STUDIO_TIME = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan SCENE_TIME = new TimeSpan(3, 0, 0);
        public static readonly TimeSpan BAR_QUEST_TIME = new TimeSpan(3, 0, 0);

        // costs
        public const int MONEY_AT_START = 100;
        public const int MAP_COST = 60;
        public const int NEWSPAPER_COST = 60;
        public const int HOSTEL_NEW_DAY_HOUR = 10;
        public const int PRO_STUDIO_RECORD_COST = 50;
        public const int TAXI_COST = 25;

        public const string DATE_STRING_FORMAT = "yyyy/MM/dd hh:mm tt";
        public const int PLAYERS_MAX = 2;
        public static readonly Color NIGHT_MODE_COLOR = new Color(0.3f, 0.47f, 0.95f, 1f);
        public const int NIGHT_MODE_HOURS_OFF = 6;
        public const int NIGHT_MODE_HOURS_ON = 22;

        // street music
        public const float STREET_MUSIC_TIME = 30f;
        public const float REMEMBER_CHANCE = 0.5f;
        public const float EARN_MONEY_CHANCE = 0.05f;

        // cut scenes
        public const int GAME_OVER_YEAR = 1980;
        public const float GAME_WON_FAME = 1f;
        public const int GAME_WON_MONEY = 10000;
    }
}