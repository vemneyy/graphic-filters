using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        // Определение метода для вычисления значения фильтра Собеля
        public static double[,] SobelFilter(double[,] input, double[,] sx)
        {
            // Вспомогательная функция для вычисления значения фильтра Собеля
            double SobelValue(double[,] inMatrix, double[,] kernel, int firstRow, int firstCol)
            {
                var kernelSize = kernel.GetLength(0);
                var gx = 0.0;
                var gy = 0.0;
                for (int i = 0; i < kernelSize; ++i)
                {
                    for (int j = 0; j < kernelSize; ++j)
                    {
                        gx += inMatrix[firstRow + i, firstCol + j] * kernel[i, j];
                        gy += inMatrix[firstRow + i, firstCol + j] * kernel[j, i];
                    }
                }
                return Math.Sqrt(gx * gx + gy * gy);
            }

            var numRows = input.GetLength(0);
            var numCols = input.GetLength(1);
            var kernelBorder = sx.GetLength(0) / 2;
            var output = new double[numRows, numCols];
            // Проход по каждому пикселю изображения
            for (var row = kernelBorder; row < numRows - kernelBorder; ++row)
            {
                for (var col = kernelBorder; col < numCols - kernelBorder; ++col)
                {
                    // Вычисление значения фильтра Собеля для текущего пикселя
                    output[row, col] = SobelValue(input, sx, row - kernelBorder, col - kernelBorder);
                }
            }
            return output; // Возвращение результата
        }
    }
}
