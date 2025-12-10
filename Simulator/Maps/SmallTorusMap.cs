using System.Drawing;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        /// <summary>
        /// Rozmiar mapy torusowej (5–20).
        /// </summary>


        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar  nie może być większy od 20.");
            if (sizeY > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Rozmiar  nie może być większy od 20.");

        }


        public override Point Next(Point p, Direction d)
        {
            var next = p.Next(d);
            return Wrap(next);
        }

        /// <summary>
        /// Zwraca punkt po skosie z zawijaniem torusowym.
        /// </summary>
        public override Point NextDiagonal(Point p, Direction d)
        {
            var next = p.NextDiagonal(d);
            return Wrap(next);
        }

        /// <summary>
        /// Zawija współrzędne 
        /// </summary>
        private Point Wrap(Point p)
        {

            int x = (p.X % SizeX + SizeX) % SizeX;
            int y = (p.Y % SizeY + SizeY) % SizeY;

            return new Point(x, y);

        }

    }

}