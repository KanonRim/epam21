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

    class Gameobj
    {
        private int _x;
        private int _y;
        private int _layer;
        private bool _permeable;
        private char _skin;
        private Map _map;
        public Gameobj(int layer, int x, int y, bool permeable, char skin)
        {
            Skin = skin;
            _layer = layer;
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
    }


    class Wall: Gameobj
    {
        public Wall(int x , int y, char skin ):base(x,y,0,false,skin)
        {

        }
    }
    class floor : Gameobj
    {
        public floor(int x, int y) : base(x, y, 0, true, ' ')
        {

        }
    }

    class Character : Gameobj
    {
        int _heal;

        public Character(int x, int y, char skin,int heal) : base(x, y, 1, false, skin)
        {
            Heal = heal;
        }

        public int Heal { get => _heal; set => _heal = value; }

        bool Step(int x,int y)
        {
            if()
        }
    }


    class Player: Character
    {
        int points;
        Player(int x, int y ):base(x,y,'Т',100)
        {

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

        bool PermeableXY(int x, int y)
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
    }
}
