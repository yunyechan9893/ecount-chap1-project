using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandThird
{
    public enum OrderType
    {
        desc,
        asc
    }
    public class Order<T>
    {
        public T Column {  get; set; }
        public OrderType Type { get; set; }

        public Order( T column, OrderType type)
        {
            Column = column;
            Type = type;
        }
    }
}
