using System;

namespace WhoIs
{
    public static class EasingEquations
    {
        /// <summary>
        /// Простая линейная анимация - без замедления, без ускорения
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double Linear(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * curentTime / duration + startValue;
        }

        /// <summary>
        /// Квадратичное замедление - ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuadraticIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 2) + startValue;
        }

        /// <summary>
        /// Квадратичное замедление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuadraticOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration / 2;
            if(curentTime < 1)
            {
                return changeVaue / 2 * Math.Pow(curentTime, 2) + startValue;
            }
            return -changeVaue / 2 * (curentTime * (curentTime - 2) - 1) + startValue;
        }

        /// <summary>
        /// Кубическое замедление - ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double CubicIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 3) + startValue;
        }

        /// <summary>
        /// Кубическое ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double CubicOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * (Math.Pow(curentTime, 3) + 1) + startValue;
        }

        /// <summary>
        /// Кубическое ослабление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Четвертичное ослабление - ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuarterIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 4) + startValue;
        }

        /// <summary>
        /// Четвертичное ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuarterOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return -changeVaue * (Math.Pow(curentTime, 4) - 1) + startValue;
        }

        /// <summary>
        /// Четвертичное ослабление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Пятикратное ослабление с ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuinticIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return changeVaue * Math.Pow(curentTime, 5) + startValue;
        }

        /// <summary>
        /// Пятикратное ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double QuinticOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * (Math.Pow(curentTime, 5) + 1) + startValue;
        }

        /// <summary>
        /// Пятиступенчатое ослабление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Синусоидальное замедление - ускорение от нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double SinIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            return -changeVaue * Math.Cos(curentTime / duration * (Math.PI / 2)) + changeVaue + startValue;
        }

        /// <summary>
        /// Синусоидальное ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double SinOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * Math.Sin(curentTime / duration * (Math.PI / 2)) + changeVaue + startValue;
        }

        /// <summary>
        /// Синусоидальное ослабление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double SinInOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return -changeVaue / 2 * (Math.Cos(Math.PI * curentTime / duration) - 1) + startValue;
        }

        /// <summary>
        /// Экспоненциальное замедление - ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double ExpIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * Math.Pow(2, 10 * (curentTime / duration - 1)) + startValue;
        }

        /// <summary>
        /// Экспоненциальное ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double ExpOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * (-Math.Pow(2, -10 * curentTime / duration) + 1) + startValue;
        }

        /// <summary>
        /// Экспоненциальное замедление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Круговое замедление - ускорение с нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double CirculIn(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            return -changeVaue * (Math.Sqrt(1 - Math.Pow(curentTime, 2)) - 1) + startValue;
        }

        /// <summary>
        /// Круговое ослабление - замедление до нулевой скорости
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static double CirculOut(double curentTime, double startValue, double changeVaue, double duration)
        {
            curentTime /= duration;
            curentTime--;
            return changeVaue * Math.Sqrt(1 - Math.Pow(curentTime, 2)) + startValue;
        }

        /// <summary>
        /// Круговое замедление - ускорение до половины, затем замедление
        /// </summary>
        /// <param name="curentTime"></param>
        /// <param name="startValue"></param>
        /// <param name="changeVaue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
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

/* Пример
        double Linear(double curentTime, double startValue, double changeVaue, double duration)
        {
            return changeVaue * curentTime / duration + startValue;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            double i = 0.01;
            while (panel1.Location.X <= Width - 100)
            {
                double lin = Linear(i, panel1.Location.X, Width, 150);
                panel1.Location = new Point((panel1.Location.X + Convert.ToInt32(lin)) / 2, panel1.Location.Y);
                await Task.Delay(5);
                i += 0.01;
            }
        }
 */

