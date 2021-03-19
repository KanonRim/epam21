using System;

namespace Task_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
   
    enum Layers
    {
        Ground  = 0,
        Character = 1,
        Bonus =2
    }

    class Gameobj
    {
        private int _x;
        private int _y;
        private int _layer;
        private bool _permeable;
        private char _skin;
        private Map _map;
        public Gameobj(Layers layer, int x, int y, bool permeable, char skin)
        {

            Skin = skin;
            this._layer = (int)layer;
            X = x;
            Y = y;
            Permeable = permeable;
        }

        public int X
        {
            get { return _x; }
            set 
            {
                if(value<=0)
                _x = value; 
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                if (value <= 0)
                    _y = value;
            }
        }


        
        public bool Permeable { get; set; }
        public char Skin { get => _skin; set => _skin = value; }
        public Map Map { get => _map;}
        public int Layer { get => _layer;}
    }


    class Wall: Gameobj
    {
        public Wall(int x , int y, char skin ):base(Layers.Ground,x, y, false,skin)
        {

        }
    }
    class floor : Gameobj
    {
        public floor(int x, int y) : base(Layers.Ground, x, y, true, ' ')
        {

        }
    }

    class Character : Gameobj
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


    class Player: Character
    {
        int _points;
        Player(int x, int y ):base(x,y,'Т',100)
        {

        }

        public int Points { get => _points; set => _points = value; }
    }

    abstract class Bonus: Gameobj
    {
        public Bonus(int x,int y,char skin):base(Layers.Bonus,x,y,true,skin)
        {

        }
       public abstract void Collect();
    }
    class Point : Bonus
    {
        int points;
        public Point(int x, int y) : base(x, y,'*')
        {

        }


        public override void Collect(Player player)
        {
            player.Points += points;
        }
    }

    class Map
    {
        Gameobj[,,] _obj;

        Gameobj  GetObj(int x,int y, int layer)
        {
            return _obj[x, y, layer];
        }

        void SetAllPos()
        {
            for (int x = 0; x < _obj.GetLength(0); x++)
            {
                for (int y = 0; y < _obj.GetLength(1); y++)
                {
                    for (int l = 0; l < _obj.GetLength(2); l++)
                    {
                        _obj[x, y, l].X = x;
                        _obj[x, y, l].Y = y;

                    }
                }
            }
        }

        public bool PermeableXY(int x, int y)
        {
            for (int l = 0; l < _obj.GetLength(2); l++)
            {
                if (!_obj[x, y, l].Permeable)
                {
                    return false;
                }
            }
            return true;
        }

        public void  Moving(int x,int y,int layer, int toX, int toY)
        {
            if (_obj[toX, toY, layer] != null)
                throw new  Exception("[x,y] != null");
            _obj[toX, toY, layer] = _obj[x, y, layer];
            _obj[x, y, layer] = null;
        }
    }
}
