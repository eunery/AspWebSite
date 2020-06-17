using System;
using System.Drawing;

namespace WebSite.Models
{
    public class Checker
    {
        public static bool CheckStep(string state, string sFrom, string sTo) 
        {
            Point from = new Point(int.Parse(sFrom[1].ToString()), sFrom[0] - 'A');
            Point to = new Point(int.Parse(sTo[1].ToString()), sTo[0] - 'A');
            switch (state)
            {
                case "p": return Pawn(from, to);
                case "b": return Bishop(from, to);
                case "r": return Rook(from, to);
                case "n": return Knight(from, to);
                case "q": return Queen(from, to);
                case "k": return King(from, to);
                default: return false;
            }
        }

        private static bool Pawn(Point from, Point to) =>
            from.Y == to.Y && (to.X - from.X == 2 || to.X - from.X == 1);

        private static bool Bishop(Point from, Point to) =>
            Math.Abs(from.X - to.X) == Math.Abs(from.Y - to.Y) && from.X != to.X;

        private static bool Rook(Point from, Point to) =>
            from.X == to.X ^ from.Y == to.Y;

        private static bool Queen(Point from, Point to) =>
            Rook(from, to) || Bishop(from, to);

        private static bool King(Point from, Point to) =>
            (Math.Abs(from.X - to.X) <= 1 || Math.Abs(from.Y - to.Y) <= 1) && Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y) != 0;

        private static bool Knight(Point from, Point to) =>
            Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y) == 3 && from.X != to.X && from.Y != to.Y;
    }
}