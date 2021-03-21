namespace Task_2._1
{
    public class Figure 
    {
        private Position _pos;
        
        public Position Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }


        public Figure(Position pos,string name)
        {
            _name = name;
            Position = pos;
        }
    }

}
