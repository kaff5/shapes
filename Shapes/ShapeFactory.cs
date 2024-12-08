namespace Shapes
{
    public static class ShapeFactory
    {
        public static IShape CreateCircle(double radius) => new Circle(radius);

        public static IShape CreateTriangle(double sideA, double sideB, double sideC) => new Triangle(sideA, sideB, sideC);
    }
}
