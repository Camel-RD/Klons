using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsLIB.Misc;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
    public class MyGridRowList : List<MyGridRowBase>, ICollectionEditorOnNewItem
    {
        public MyGrid Grid { get; private set; }
        public MyGridRowList(MyGrid grid)
        {
            Grid = grid;
        }

        public new void Add(MyGridRowBase row)
        {
            row.Owner = this;
            base.Add(row);
        }

        public void OnNewItem(object o)
        {
            var gr = (o as MyGridRowBase);
            if (o == null) return;
            gr.Owner = this;
        }

        public string[] GetNameList()
        {
            var list = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                list[i] = this[i].Name;
            }
            Array.Sort(list);
            return list;
        }

        public MyGridRowBase FindByName(string rowname)
        {
            return this.Where(p => p.Name == rowname).FirstOrDefault();
        }

        public MyGridRowBase FindRow(int rownr)
        {
            for (int i = 0; i < Count; i++)
            {
                var row = this[i];
                if (row.GridRow.Index < rownr) continue;
                if (row.GridRow.Index == rownr)
                {
                    return row;
                }
                if (i == 0) return null;
                return this[i - 1];
            }
            return null;
        }
    }

}
