using System;
using UnityEngine;

namespace RockVoyage
{
    public static class Constants
    {
        // common
        public const string GAME_NAME = "Rock Voyage";
        public const float ENERGY_CONSUMPTION_PER_HOUR = 0.04f;
        public const float ENERGY_MAX = 1f;
        public const float FAME_MAX = 1f;
        public const int MONEY_AT_START = 100;
        public const int NEW_DAY_HOUR = 10;
        public const int TAXI_COST = 25;
        public const int PLAYERS_MAX = 2;
        public static readonly Color NIGHT_MODE_COLOR = new Color(0.3f, 0.47f, 0.95f, 1f);
        public const int NIGHT_MODE_HOURS_OFF = 6;
        public const int NIGHT_MODE_HOURS_ON = 22;

        // endgame conditions
        public const int GAME_OVER_YEAR = 1980;
        public const float GAME_WON_FAME = 1f;
        public const int GAME_WON_MONEY = 10000;

        public static class Scenes
        {
            public const string ABOUT = "About";
            public const string MAIN_MENU = "Main Menu";
            public const string CUT_SCENE_START = "Cut Scene Start";
            public const string START_CITY = "Map";
        }

        public static class PlayerAnimationStates
        {
            public const string IDLE = "Idle";
            public const string SING = "Sing";
            public const string WALK_FRONT = "Walk Front";
            public const string WALK_LEFT = "Walk Left";
            public const string WALK_RIGHT = "Walk Right";
            public const string WALK_UP = "Walk Up";
            public const string BOOL_IDLE = "isIdle";
            public const string BOOL_WALK_FRONT = "isWalkingFront";
            public const string BOOL_WALK_LEFT = "isWalkingLeft";
            public const string BOOL_WALK_RIGHT = "isWalkingRight";
            public const string BOOL_WALK_UP = "isWalkingUp";
            public static readonly string[] MOVING_BOOL_NAMES =
            {
                BOOL_IDLE,
                BOOL_WALK_FRONT,
                BOOL_WALK_LEFT,
                BOOL_WALK_RIGHT,
                BOOL_WALK_UP,
            };
        }

        // to do
        public static readonly TimeSpan GARAGE_STUDIO_TIME = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan SCENE_TIME = new TimeSpan(3, 0, 0);
    }
}