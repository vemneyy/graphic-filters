using System;

namespace Recognizer
{
    public static class GrayscaleTask
    {
        // Метод для преобразования цветного изображения в оттенки серого, объединенный в одну функцию
        public static double[,] ToGrayscale(Pixel[,] originalPixels)
        {
            // Коэффициенты для вычисления значения оттенка серого из цветовых каналов
            const double RedCoefficient = 0.299;
            const double GreenCoefficient = 0.587;
            const double BlueCoefficient = 0.114;
            const double NormalizationFactor = 255; // Фактор нормализации для перевода значения в диапазон [0, 1]

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

                    // Вычисляем значение оттенка серого для данного пикселя прямо здесь, используя коэффициенты
                    double grayscaleValue = (pixel.R * RedCoefficient + pixel.G * GreenCoefficient + pixel.B * BlueCoefficient) / NormalizationFactor;

                    // Сохраняем вычисленное значение оттенка серого в массив
                    grayscaleImage[i, j] = grayscaleValue;
                }
            }

            // Возвращаем массив оттенков серого
            return grayscaleImage;
        }
    }
}
