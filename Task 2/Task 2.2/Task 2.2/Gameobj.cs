namespace Task_2._2
{
    abstract class Gameobj
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
}
