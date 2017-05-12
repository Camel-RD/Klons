using System;
using KlonsA.Classes;
using System.Linq;
using System.Text;
using System.Data;

namespace KlonsA.DataSets
{
    partial class KlonsARepDataSet
    {
        partial class SP_STATS_02Row
        {
            public string ZName
            {
                get
                {
                    string s = FNAME == null ? "" : FNAME;
                    s = s + " " + (LNAME == null ? "" : LNAME);
                    return s;
                }
            }
        }

        partial class AVPAYCALCRow
        {
            public ESalarySheetRowType XType
            {
                get { return (ESalarySheetRowType)this.TYPE_TAG; }
                set { this.TYPE_TAG = (short)value; }
            }
        }

    }
}

