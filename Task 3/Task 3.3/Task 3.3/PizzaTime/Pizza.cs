namespace Task_3._3
{
    class Pizza
    {
        private string _name;
        private int _cocingTime;
        public string NamePizza { get => _name; }
        public int CocingTime { get => _cocingTime; }
        public string Name { get; internal set; }

        public Pizza(string name, int cocingTime)
        {
            _name = name;
            _cocingTime = cocingTime;
        } 
    }
}
