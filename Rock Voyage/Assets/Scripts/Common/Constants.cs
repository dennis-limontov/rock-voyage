using UnityEngine;

namespace RockVoyage
{
    public class Constants
    {
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
        public const int HOSTEL_NEW_DAY_HOUR = 10;
        public const int PLAYERS_MAX = 2;
    }
}