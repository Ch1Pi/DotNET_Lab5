using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Test
    {
        private string _name;
        private bool _isPassed;

        public Test(string name, bool isPassed)
        {
            Name = name;
            IsPassed = isPassed;
        }

        public Test() : this(name: "C#", isPassed: true) { }

        public string Name
        {

            get
            {

                return _name;
            }

            set
            {
                _name = value;
            }




        }

        public bool IsPassed
        {
            get
            {
                return _isPassed;
            }

            set
            {
                _isPassed = value;
            }
        }


        public override string ToString()
        {
            return $"\nName:{Name}\nIsPassed:{IsPassed}\n";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 17 + IsPassed.GetHashCode() * 19;
        }
    }
}
