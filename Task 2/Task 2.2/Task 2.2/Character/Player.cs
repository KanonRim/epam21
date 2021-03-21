namespace Task_2._2
{
    class Player : Character
    {
        int _points;
        Player(int x, int y ):base(x,y,'Т',100)
        {
            
        }

        public int Points { get => _points; set => _points = value; }
    }
}
