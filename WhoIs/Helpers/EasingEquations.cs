using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs
{
    public static class EasingEquations
    {
        // Простая линейная анимация - без замедления, без ускорения
        public static double Linear(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * curentTime / duration + startValue;
        }

        // Квадратичное замедление - ускорение с нулевой скорости
        public static double QuadraticIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 2) + startValue;
        }

        // Квадратичное замедление - ускорение до половины, затем замедление
        public static double QuadraticOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(curentTime, 2) + startValue;
            }
            return -changeVaue / 2 * (curentTime * (curentTime - 2) - 1) + startValue;
        }

        // Кубическое замедление - ускорение с нулевой скорости
        public static double CubicIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 3) + startValue;
        }

        // Кубическое ослабление - замедление до нулевой скорости
        public static double CubicOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * (Math.Pow(curentTime, 3) + 1) + startValue;
        }

        // Кубическое ослабление - ускорение до половины, затем замедление
        public static double CubicInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(curentTime, 3) + startValue;
            }
            curentTime -= 2;
            return changeVaue / 2 * (Math.Pow(curentTime, 3) + 2) + startValue;
        }

        // Квартальное ослабления - ускорение с нулевой скорости
        public static double QuarterIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 4) + startValue;
        }

        // Квартальное ослабление - замедление до нулевой скорости
        public static double QuarterOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return -changeVaue * (Math.Pow(curentTime, 4) - 1) + startValue;
        }

        // Квартальное ослабление - ускорение до половины, затем замедление
        public static double QuarterInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(curentTime, 4) + startValue;
            }
            curentTime -= 2;
            return -changeVaue / 2 * (Math.Pow(curentTime, 4) - 2) + startValue;
        }

        // Пятикратное ослабление с ускорение с нулевой скорости
        public static double QuinticIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 5) + startValue;
        }

        // Пятикратное ослабление - замедление до нулевой скорости
        public static double QuinticOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * (Math.Pow(curentTime, 5) + 1) + startValue;
        }

        // Пятиступенчатое ослабление - ускорение до половины, затем замедление
        public static double QuinticInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(curentTime, 5) + startValue;
            }
            curentTime -= 2;
            return changeVaue / 2 * (Math.Pow(curentTime, 5) + 2) + startValue;
        }

        // Синусоидальное замедление - ускорение от нулевой скорости
        public static double SinIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            return -changeVaue * Math.Cos(curentTime / duration * (Math.PI / 2)) + changeVaue + startValue;
        }

        // Синусоидальное ослабление - замедление до нулевой скорости
        public static double SinOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * Math.Sin(curentTime / duration * (Math.PI / 2)) + changeVaue + startValue;
        }

        // Синусоидальное ослабление - ускорение до половины, затем замедление
        public static double SinInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return -changeVaue / 2 * (Math.Cos(Math.PI * curentTime / duration) - 1) + startValue;
        }

        // Экспоненциальное замедление - ускорение с нулевой скорости
        public static double ExpIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * Math.Pow(2, 10 * (curentTime / duration - 1)) + startValue;
        }

        // Экспоненциальное ослабление - замедление до нулевой скорости
        public static double ExpOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * (-Math.Pow(2, -10 * curentTime / duration) + 1) + startValue;
        }

        // Экспоненциальное замедление - ускорение до половины, затем замедление
        public static double ExpInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(2, 10 * (curentTime - 1)) + startValue;
            }
            curentTime--;
            return changeVaue / 2 * (-Math.Pow(2, -10 * curentTime) + 2) + startValue;
        }

        // Круговое замедление - ускорение с нулевой скорости
        public static double CirculIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return -changeVaue * (Math.Sqrt(1 - Math.Pow(curentTime, 2)) - 1) + startValue;
        }

        // Круговое ослабление - замедление до нулевой скорости
        public static double CirculOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * Math.Sqrt(1 - Math.Pow(curentTime, 2)) + startValue;
        }

        // Круговое замедление - ускорение до половины, затем замедление
        public static double CirculInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return -changeVaue / 2 * (Math.Sqrt(1 - Math.Pow(curentTime, 2)) - 1) + startValue;
            }
            curentTime -= 2;
            return changeVaue / 2 * (Math.Sqrt(1 - Math.Pow(curentTime, 2) + 1) + startValue);
        }
    }
}


