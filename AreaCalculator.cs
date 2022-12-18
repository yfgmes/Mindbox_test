using System;


/*Напишите на C# библиотеку для поставки внешним клиентам, 
 * которая умеет вычислять площадь круга по радиусу 
 * и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
 * Юнит-тесты
 * Легкость добавления других фигур
 * Вычисление площади фигуры без знания типа фигуры в compile-time
 * Проверку на то, является ли треугольник прямоугольным 
 */
namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс подсчитывания площади фигур
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// Подсчитывание площади круга
        /// </summary>
        /// <param name="radius">Длина радиус круга</param>
        /// <returns>Площадь круга</returns>
        public static double AreaRound(double radius)
        {
            return GetArea(new double[] { radius }, "round");
        }

        /// <summary>
        /// Подсчитывание площади прямоугольника
        /// </summary>
        /// <param name="side1">Длина первой стороны</param>
        /// <param name="side2">Длина второй стороны</param>
        /// <param name="side3">Длина третьей стороны</param>
        /// <returns>Площадь прямоугольника</returns>
        public static double AreaTriangle(double side1, double side2, double side3)
        {
            return GetArea(new double[] { side1, side2, side3 }, "triangle");
        }

        /// <summary>
        /// Подсчитывание площади фигур в compile-time
        /// </summary>
        /// <param name="segments">Параметры фигур</param>
        /// <param name="figureType">Тип фигуры</param>
        /// <returns>Площадь фигуры</returns>
        /// <exception cref="NotImplementedException">Отсутвует такой тип фигуры</exception>
        public static double GetArea(double[] segments, string figureType)
        {
            Figure fig = null;
            switch (figureType.ToLower())
            {
                case "round": fig = new Round(segments); break;
                case "triangle": fig = new Triangle(segments); break;
                default: throw new NotImplementedException();
            }
            return fig.getArea();
        }

        /// <summary>
        /// Проверка треугольника на прямоугольность
        /// </summary>
        /// <param name="side1">Длина первой стороны</param>
        /// <param name="side2">Длина второй стороны</param>
        /// <param name="side3">Длина третьей стороны</param>
        /// <returns>true=прямоугольный</returns>
        public static bool CheckSquareTriangle(double side1, double side2, double side3)
        {
            Triangle tri = new Triangle(side1, side2, side3);
            return tri.CheckSquareTriangle();
        }
    }

    /// <summary>
    /// Класс родитель фигура
    /// </summary>
    class Figure
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        private double area;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected Figure()
        {
            area = 0;
        }

        /// <summary>
        /// Возвращение площади фигуры
        /// </summary>
        /// <returns>Площадь фигруы</returns>
        public double getArea()
        {
            return Area;
        }

        /// <summary>
        /// Возвращение площади фигуры
        /// </summary>
        protected double Area
        {
            get { return area; }
            set { area = value; }
        }
    }

    /// <summary>
    /// Класс фигуры - круг
    /// </summary>
    class Round : Figure
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        private double radius;
        private static double Pi = 3.14;

        /// <summary>
        /// Конструктор круг
        /// </summary>
        /// <param name="segment">Массив с радиусом круга</param>
        /// <exception cref="ArgumentOutOfRangeException">Неверный число параметров фигуры</exception>
        /// <exception cref="ArgumentException">Неверный размер радиуса</exception>
        public Round(double[] segment)
        {
            if (segment.Length != 1)
            {
                throw new ArgumentOutOfRangeException("Неверное число аргументов");
            }
            if (segment[0] < 0)
            {
                throw new ArgumentException("Радиус меньше нуля");
            }
            radius = segment[0];
            CalculateArea();
        }

        /// <summary>
        /// Расчет площади круга
        /// </summary>
        private void CalculateArea()
        {
            Area = radius * Pi;
        }
    }

    /// <summary>
    /// Класс фигуры - треугольник
    /// </summary>
    class Triangle : Figure
    {
        private double a;
        private double b;
        private double c;

        /// <summary>
        /// Конструктор треугольник стандартный
        /// </summary>
        /// <param name="segments">Массив с длинами сторон треугольника</param>
        /// <exception cref="ArgumentOutOfRangeException">Неверный число параметров фигуры</exception>
        /// <exception cref="ArgumentException">Неверные параметры треугольника</exception>
        public Triangle(double[] segments)
        {
            if (segments.Length != 3)
            {
                throw new ArgumentOutOfRangeException("Неверное число аргументов");
            }
            c = segments[0];
            a = segments[1];
            b = segments[2];
            if (a > c && a > b)
            {
                c = segments[1];
                a = segments[0];
            }
            if (b > c && b > a)
            {
                c = segments[2];
                b = segments[0];
            }
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("Ввод отрицательной длины");
            }
            if (CheckTriangle())
            {
                throw new ArgumentException("Невозможный треугольник");
            }
            if (CheckSquareTriangle())
            {
                SimpleCalculateArea();
            }
            else
            {
                CalculateArea();
            }
        }

        /// <summary>
        /// Конструктор треугольника длины
        /// </summary>
        /// <param name="side1">Длина первой стороны</param>
        /// <param name="side2">Длина второй стороны</param>
        /// <param name="side3">Длина третьей стороны</param>
        public Triangle(double side1, double side2, double side3) : this(new double[] { side1, side2, side3 }) { }

        /// <summary>
        /// Проверка треугольника на прямоугольность
        /// </summary>
        /// <returns>true=треугольник прямоугольный</returns>
        public bool CheckSquareTriangle()
        {
            //сравнение велечин типа double
            return Double.Equals(c * c, a * a + b * b);
        }

        /// <summary>
        /// Проверка на возможность треугольника
        /// </summary>
        /// <returns>false=треугольник возможен по длинам</returns>
        private bool CheckTriangle()
        {
            return (c >= b + a);
        }

        /// <summary>
        /// Подсчёт площади треугольника
        /// </summary>
        private void CalculateArea()
        {
            double p = (a + b + c) / 2;
            Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Подсчёт площади прямоугольного треугольника
        /// </summary>
        private void SimpleCalculateArea()
        {
            Area = a * b * 0.5;
        }

    }
}