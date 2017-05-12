using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsLIB.MySourceGrid;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsP.Classes
{
    public class MyGridRowList3: CollectionBase
    {

        public MyGridRowBase this[int index]
        {
            get
            {
                return ((MyGridRowBase)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(MyGridRowBase value)
        {
            return (List.Add(value));
        }

        public int IndexOf(MyGridRowBase value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, MyGridRowBase value)
        {
            List.Insert(index, value);
        }

        public void Remove(MyGridRowBase value)
        {
            List.Remove(value);
        }

        public bool Contains(MyGridRowBase value)
        {
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
        }

        protected override void OnRemove(int index, Object value)
        {
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(MyGridRowBase))
                throw new ArgumentException("value must be of type MyGridRowBase.", "value");
        }

    }
}
