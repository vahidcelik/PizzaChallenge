using System;

namespace OloPizza
{
    internal class Pizza
    {
        private string[] _toppings;

        public string[] Toppings
        {
            get { return _toppings; }
            set
            {
                Array.Sort(value);
                _toppings = value;
            }
        }
    }
}
