using System;
using System.Collections.Generic;

namespace Polygon {
    class Polygon {
        readonly List<Point> pointList;
        int? duplicateVertices = null;
        public int DuplicateVerticesCount {
            get {
                if (!duplicateVertices.HasValue) {
                    duplicateVertices = pointList.Count - new HashSet<Point>(pointList).Count;
                }
                return duplicateVertices.Value;
            }
        }
        
        public Polygon(List<Point> points) {
            pointList = points;
        }
        
        public bool HasCrossings() {
            if (DuplicateVerticesCount != 0) {
                // crossing on vertex
                return true;
            }
            if (pointList.Count <= 3) {
                // no crossing at low vertices count
                return false;
            }
            // edge crossing. naive algorithm for small vertices count from manual input
            
            // starting from 3 points
            int processedIndex = 2;
            for (int i = 3; i < pointList.Count; ++i) {
                for (int j = 0; j < processedIndex - 1; ++j) {
                    if (linesCrossing(pointList[j], pointList[j + 1], pointList[processedIndex], pointList[i])) {
                        return true;
                    }
                }
                processedIndex = i;
            }
            // check last edge
            for (int j = 1; j < processedIndex - 1; ++j) {
                if (linesCrossing(pointList[j], pointList[j + 1], pointList[processedIndex], pointList[0])) {
                    return true;
                }
            }
            return false;
        }
        
        bool linesCrossing(Point a1, Point b1, Point a2, Point b2) {
            // no point duplicates are supposed
            double v1 = vectorMultiply(b2.X - a2.X, b2.Y - a2.Y, a1.X - a2.X, a1.Y - a2.Y);
            double v2 = vectorMultiply(b2.X - a2.X, b2.Y - a2.Y, b1.X - a2.X, b1.Y - a2.Y);
            // v1 * v2 < 0 - different sides
            double v3 = vectorMultiply(b1.X - a1.X, b1.Y - a1.Y, a2.X - a1.X, a2.Y - a1.Y);
            double v4 = vectorMultiply(b1.X - a1.X, b1.Y - a1.Y, b2.X - a1.X, b2.Y - a1.Y);
            // v3 * v4 < 0 - different sides
            double V = v1 * v2;
            double U = v3 * v4;
            if (U < 0 && V < 0) {
                // edge crossing
                return true;
            }
            if (U * V == 0) {
                if ((U + V) < 0) {
                    // vertex on edge
                    return true;
                } else if ((U + V) > 0) {
                    // vertex on edge continuation
                    return false;
                }
                // collinear lines
                if (a1.X == a2.X) {
                    // vertical lines
                    double min1 = Math.Min(a1.Y, b1.Y);
                    double max1 = Math.Max(a1.Y, b1.Y);
                    double min2 = Math.Min(a2.Y, b2.Y);
                    double max2 = Math.Max(a2.Y, b2.Y);
                    if (max1 < min2 || max2 < min1) {
                        return false;
                    }
                    return true;
                } else {
                    // non-vertical lines
                    double min1 = Math.Min(a1.X, b1.X);
                    double max1 = Math.Max(a1.X, b1.X);
                    double min2 = Math.Min(a2.X, b2.X);
                    double max2 = Math.Max(a2.X, b2.X);
                    if (max1 < min2 || max2 < min1) {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        
        double vectorMultiply(double x1, double y1, double x2, double y2) {
            return x1 * y2 - x2 * y1;
        }
        
        public double CalculateArea() {
            // Gauss area formula
            int count = pointList.Count;
            if (count < 3)
                return 0;

            double result = 0;
            for (int i = 0; i < count; ++i) {
                var current = pointList[i];
                var next = pointList[(i + 1) % count];
                result += current.X * next.Y - current.Y * next.X;
            }
            return result / 2;
        }
    }
}
