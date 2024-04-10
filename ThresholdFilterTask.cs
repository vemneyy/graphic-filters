using System;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        // Метод для применения порогового фильтра к изображению в одном шаге
        public static double[,] ThresholdFilter(double[,] input, double whitePixelsFraction)
        {
            var num_rows = input.GetLength(0);
            var num_cols = input.GetLength(1);
            var num_values = num_rows * num_cols;
            var num_whites = (int)Math.Floor(num_values * whitePixelsFraction);

            // Копирование значений пикселей в одномерный массив и сортировка
            var values = new double[num_values];
            for (int i = 0; i < num_values; i++)
            {
                values[i] = input[i / num_cols, i % num_cols];
            }
            Array.Sort(values);
            
            // Определение порогового значения
            var threshold = values[num_values - num_whites];
            
            // Бинаризация изображения по порогу
            var output = new double[num_rows, num_cols];
            for (int row = 0; row < num_rows; ++row)
            {
                for (int col = 0; col < num_cols; ++col)
                {
                    output[row, col] = input[row, col] >= threshold ? 1.0 : 0.0;
                }
            }
            
            return output;
        }
    }
}
