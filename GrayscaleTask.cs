using System;

namespace Recognizer
{
    // Статический класс GrayscaleTask, который содержит метод для преобразования изображения в оттенки серого
    public static class GrayscaleTask
    {
        // Коэффициенты для вычисления значения оттенка серого из цветовых каналов
        private const double RedCoefficient = 0.299;
        private const double GreenCoefficient = 0.587;
        private const double BlueCoefficient = 0.114;
        private const double NormalizationFactor = 255; // Фактор нормализации для перевода значения в диапазон [0, 1]

        // Метод для преобразования цветного изображения в оттенки серого
        public static double[,] ToGrayscale(Pixel[,] originalPixels)
        {
            // Получаем высоту и ширину исходного изображения
            int height = originalPixels.GetLength(0);
            int width = originalPixels.GetLength(1);

            // Создаем двумерный массив для хранения значений оттенков серого
            double[,] grayscaleImage = new double[height, width];

            // Проходимся по каждому пикселю исходного изображения
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Получаем пиксель из исходного изображения
                    Pixel pixel = originalPixels[i, j];

                    // Вычисляем значение оттенка серого для данного пикселя и сохраняем его в массив оттенков серого
                    grayscaleImage[i, j] = ComputeGrayscaleValue(pixel);
                }
            }

            // Возвращаем массив оттенков серого
            return grayscaleImage;
        }

        // Метод для вычисления оттенка серого для конкретного пикселя
        private static double ComputeGrayscaleValue(Pixel pixel)
        {
            // Вычисляем значение оттенка серого с использованием коэффициентов для каждого цветового канала
            return (pixel.R * RedCoefficient + pixel.G * GreenCoefficient + pixel.B * BlueCoefficient) / NormalizationFactor;
        }
    }
}
