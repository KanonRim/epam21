using System;

namespace Task_2._2
{
    class Map
    {
        Gameobj[,,] _obj;
        Map(int maxX, int maxY, int l)
        {
            _obj = new Gameobj[maxX, maxY, l];
        }
        public Gameobj  GetObj(int x,int y, int layer)
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
                        if (_obj[x, y, l] != null)
                        {
                            _obj[x, y, l].X = x;
                            _obj[x, y, l].Y = y;

                        }
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
