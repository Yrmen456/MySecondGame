using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondGame.Data
{
    class Star
    {
        
    }

    public enum StarList
    {
        WorseGarbage = 0,
        Garbage = 1,
        Common = 2,
        Uncommon = 3,
        Rare = 4,
        Exceedingly_Rare = 5,
        Mythical = 6,
        Legendary = 7,
        Ancient = 8,
        Immortal = 9,
        Divine = 10,
    }

    public static class MyColors
    {
        public static readonly Color WorseGarbage = Color.FromArgb(146, 65, 15);
        public static readonly Color Garbage = Color.FromArgb(255, 255, 255);
        public static readonly Color Common = Color.FromArgb(194, 195, 201);
        public static readonly Color Uncommon = Color.FromArgb(103, 149, 227);
        public static readonly Color Rare = Color.FromArgb(80, 104, 205);
        public static readonly Color Exceedingly_Rare = Color.FromArgb(202, 172, 5);
        public static readonly Color Mythical = Color.FromArgb(137, 71, 255);
        public static readonly Color Legendary = Color.FromArgb(211, 44, 230);
        public static readonly Color Ancient = Color.FromArgb(235, 76, 75);
        public static readonly Color Immortal = Color.FromArgb(136, 105, 11);
        public static readonly Color Divine = Color.FromArgb(16, 195, 167);
    }
}
