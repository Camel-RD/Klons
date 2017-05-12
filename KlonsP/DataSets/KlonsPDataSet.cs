using KlonsP.Classes;
using System.Data;

namespace KlonsP.DataSets
{


    partial class KlonsPDataSet
    {
        partial class EVENTSRow
        {
            public EEvent XEvent
            {
                get { return (EEvent)this.ID; }
                set { this.ID = (int)value; }
            }
        }

        partial class ITEMSRow
        {
            public EState XState
            {
                get { return (EState)this.STATE; }
                set
                {
                    if (this.STATE == (int)value) return;
                    this.STATE = (int)value;
                }
            }

            public EState XTState
            {
                get { return (EState)this.TSTATE; }
                set
                {
                    if (this.TSTATE == (int)value) return;
                    this.TSTATE = (int)value;
                }
            }
        }

        partial class ITEMS_EVENTSRow
        {
            public EEvent XEvent
            {
                get { return (EEvent)this.EVENT; }
                set
                {
                    if (this.EVENT == (int)value) return;
                    this.EVENT = (int)value;
                }
            }

            public EChColInd XChColSet
            {
                get { return (EChColInd)this.CHCOLSET; }
                set
                {
                    if (this.CHCOLSET == (int)value) return;
                    this.CHCOLSET = (int)value;
                }
            }
        }
    }
}
