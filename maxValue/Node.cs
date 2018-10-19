using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxValue
{
    public class Node
    {
        public int Value { get; set; }
        public int Sum { get; set; }
        public Node LeftChile { get; set; }
        public Node RightChile { get; set; }
        public Node Parent { get; set; }
        public NumberType Type
        {
            set { }
            get
            {
                return Value % 2 == 0 ? NumberType.Even : NumberType.Odd;
            }
        }
    }
}
