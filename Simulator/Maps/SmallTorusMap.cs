namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        /// <summary>
        /// Rozmiar mapy torusowej (5–20).
        /// </summary>
        public int Size { get; }

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size),
                    "Rozmiar musi być w przedziale 5-20.");

            Size = size;
        }

        
        public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
                    
     
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

            int x = (p.X % Size + Size) % Size;
            int y = (p.Y % Size + Size) % Size;

            return new Point(x, y);

        }

    }

}