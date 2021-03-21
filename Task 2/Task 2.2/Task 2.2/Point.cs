namespace Task_2._2
{
    class Point : Bonus
    {
        readonly int points;
        public Point(int x, int y) : base(x, y,'*')
        {

        }


        public void Collect(Player player)
        {
            if(player.X == X && player.Y== Y)
            player.Points += points;
        }
    }
}
