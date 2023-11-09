using System;
using UnityEngine;

namespace RockVoyage
{
    public class Constants
    {
        // scenes
        public const string MAIN_MENU_SCENE_NAME = "Main Menu";
        public const string START_CITY_NAME = "Map";

        // layers
        public static string HOUSE_LAYER = "House";

        public const float ENERGY_CONSUMPTION_PER_HOUR = 4f;
        public const float ENERGY_LIMIT_MIDDLE = 70f;
        public const float ENERGY_LIMIT_LOW = 40f;
        public const float ENERGY_LIMIT_DANGER = 10f;
        public const float ENERGY_MAX = 100f;
        public static Color ENERGY_COLOR_MAX = Color.green;
        public static Color ENERGY_COLOR_MIDDLE = Color.yellow;
        public static Color ENERGY_COLOR_LOW = new Color(1f, 0.5f, 0f, 1f);
        public static Color ENERGY_COLOR_DANGER = Color.red;
        public static float FAME_INCREMENT = 0.01f;
        public static float FAME_MAX = 1f;

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

        public static string DATE_STRING_FORMAT = "yyyy/MM/dd hh:mm tt";
        public const int PLAYERS_MAX = 2;

        public static float STREET_MUSIC_TIME = 30f;
        public static float REMEMBER_CHANCE = 0.5f;
        public static float EARN_MONEY_CHANCE = 0.05f;
    }
}