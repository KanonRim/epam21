namespace Task_2._2
{
    abstract class Character : Gameobj
    {
        int _heal;

        public Character(int x, int y, char skin,int heal) : base(Layers.Character, x, y, false, skin)
        {
            Heal = heal;
        }

        public int Heal { get => _heal; set => _heal = value; }

        public bool Move(int x,int y)
        {
            if (Map.PermeableXY(x, y))
            {
                Map.Moving(X, Y, Layer, x, y);
                return true;
            }
            else
                return false;
        }
    }
}
