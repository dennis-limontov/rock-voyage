using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace RockVoyage
{
    public static class AppInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            const string DATE_STRING_FORMAT = "yyyy/MM/dd";
            const string TIME_STRING_FORMAT = "hh:mm tt";
            CultureInfo cultureInfo = new CultureInfo(CultureInfo.InvariantCulture.Name);
            cultureInfo.DateTimeFormat.ShortDatePattern = DATE_STRING_FORMAT;
            cultureInfo.DateTimeFormat.LongTimePattern = TIME_STRING_FORMAT;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
