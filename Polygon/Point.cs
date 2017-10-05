namespace Polygon {
    class Point {
        public readonly double X, Y;
        public Point(double x, double y) {
            X = x;
            Y = y;
        }
        public override bool Equals(object o) {
            if (o is Point) {
                var p = o as Point;
                return p.X == X && p.Y == Y;
            }
            return false;
        }
        public override int GetHashCode() {
            return 13 * X.GetHashCode() + Y.GetHashCode();
        }
    }
}
