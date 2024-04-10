using System;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        // Метод для применения медианного фильтра к изображению в одной функции
        public static double[,] MedianFilter(double[,] input)
        {
            var numRows = input.GetLength(0); // Определение количества строк во входном изображении
            var numCols = input.GetLength(1); // Определение количества столбцов во входном изображении
            var output = new double[numRows, numCols]; // Создание массива для хранения результата фильтрации

            // Проход по каждому пикселю изображения
            for (var row = 0; row < numRows; ++row)
            {
                for (var col = 0; col < numCols; ++col)
                {
                    // Создание массива для хранения значений пикселей в окне фильтра
                    var values = new double[(Math.Min(numRows, row + 2) - Math.Max(0, row - 1)) * (Math.Min(numCols, col + 2) - Math.Max(0, col - 1))];
                    var index = 0;

                    // Заполнение массива значениями из окна фильтра
                    for (var filterRow = Math.Max(0, row - 1); filterRow < Math.Min(numRows, row + 2); ++filterRow)
                        for (var filterCol = Math.Max(0, col - 1); filterCol < Math.Min(numCols, col + 2); ++filterCol)
                            values[index++] = input[filterRow, filterCol];

                    // Сортировка значений пикселей
                    Array.Sort(values);
                    var middleIndex = values.Length / 2;

                    // Определение медианы и запись её в выходной массив
                    output[row, col] = values.Length % 2 != 0 ? values[middleIndex] : (values[middleIndex - 1] + values[middleIndex]) / 2.0;
                }
            }

            return output; // Возврат результирующего изображения после применения медианного фильтра
        }
    }
}
