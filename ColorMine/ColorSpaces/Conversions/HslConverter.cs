﻿using System.Drawing;
using ColorMine.Utility;

namespace ColorMine.ColorSpaces.Conversions
{
    internal static class HslConverter
    {
        internal static void ToColorSpace(Color color, IHsl item)
        {
            item.H = color.GetHue();
            item.S = color.GetSaturation();
            item.L = color.GetBrightness();
        }

        internal static Color ToColor(IHsl item)
        {
            var rangedH = item.H/360.0;
            var r = 0.0;
            var g = 0.0;
            var b = 0.0;

            if (!item.L.BasicallyEqualTo(0))
            {
                if (item.S.BasicallyEqualTo(0))
                {
                    r = g = b = item.L;
                }
                else
                {
                    var temp2 = (item.L < 0.5) ? item.L*(1.0 + item.S) : item.L + item.S - (item.L*item.S);
                    var temp1 = 2.0*item.L - temp2;

                    r = GetColorComponent(temp1, temp2, rangedH + 1.0/3.0);
                    g = GetColorComponent(temp1, temp2, rangedH);
                    b = GetColorComponent(temp1, temp2, rangedH - 1.0/3.0);
                }
            }
            return Color.FromArgb((int) (255*r), (int) (255*g), (int) (255*b));
        }

        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            temp3 = MoveIntoRange(temp3);
            if (temp3 < 1.0/6.0)
            {
                return temp1 + (temp2 - temp1)*6.0*temp3;
            }

            if (temp3 < 0.5)
            {
                return temp2;
            }

            if (temp3 < 2.0/3.0)
            {
                return temp1 + ((temp2 - temp1)*((2.0/3.0) - temp3)*6.0);
            }

            return temp1;
        }

        private static double MoveIntoRange(double temp3)
        {
            if (temp3 < 0.0) return temp3 + 1;
            if (temp3 > 1.0) return temp3 - 1;
            return temp3;
        }
    }
}