using System;
using KlonsA.Classes;
using System.Linq;
using System.Text;
using System.Data;

namespace KlonsA.DataSets
{
    public partial class KlonsADataSet
    {
        public partial class SALARY_SHEETSRow
        {
            public ESalarySheetKind XKind
            {
                get { return (ESalarySheetKind)this.KIND; }
                set { this.KIND = (short)value; }
            }
        }

        public partial class SALARY_SHEETS_RRow
        {
            public ESalarySheetRowType XType
            {
                get { return (ESalarySheetRowType)this.TYPE_TAG; }
                set { this.TYPE_TAG = (short)value; }
            }
        }

        public partial class SALARY_PLUSMINUSRow
        {
            public EBonusRateType XRateType
            {
                get
                {
                    return (EBonusRateType)this.RATE_TYPE;
                }
                set
                {
                    if (value == EBonusRateType.Money)
                        this.RATE_TYPE = 0;
                    else
                        this.RATE_TYPE = 1;
                }
            }

            public EBonusFrom XBonusFrom
            {
                get
                {
                    if (this.IsIDNONull()) return EBonusFrom.None;
                    return (EBonusFrom)this.IDNO;
                }
                set
                {
                    if (value == EBonusFrom.None)
                        this["IDNO"] = DBNull.Value;
                    else
                        this.IDNO = (int)value;
                }
            }

            public EBonusType XBonusType
            {
                get
                {
                    return (EBonusType)this.IDSV;
                }
                set
                {
                    if (value == EBonusType.None)
                        this["IDSV"] = DBNull.Value;
                    else
                        this.IDSV = (int)value;
                }
            }
        }

        public partial class POSITIONS_RRow
        {
            public ESalaryType XRateType
            {
                get { return (ESalaryType)this.SALARY_TYPE; }
                set { this.SALARY_TYPE = (short)value; }
            }
        }

        public partial class POSITIONS_PLUSMINUSRow
        {
            public EBonusFrom XBonusFrom
            {
                get
                {
                    if (this.IsIDNONull()) return EBonusFrom.None;
                    return (EBonusFrom)this.IDNO;
                }
                set
                {
                    if (value == EBonusFrom.None)
                        this["IDNO"] = DBNull.Value;
                    else
                        this.IDNO = (int)value;
                }
            }

            public EBonusType XBonusType
            {
                get
                {
                    if (this.IsIDSVNull()) return EBonusType.None;
                    return (EBonusType)this.IDSV;
                }
                set
                {
                    if (value == EBonusType.None)
                        this["IDSV"] = DBNull.Value;
                    else
                        this.IDSV = (int)value;
                }
            }
        }

        public partial class TIMESHEET_LISTS_RRow
        {
            public EPlanType XPlanType
            {
                get { return (EPlanType)this.PLAN_TYPE; }
                set { this.PLAN_TYPE = (short)value; }
            }

        }

        public interface IDLRowVXIndexer
        {
            float this[int k] { get; set; }
        }

        public interface IDLRowDXPlanIndexer
        {
            EDayPlanId this[int k] { get; set; }
        }

        public interface IDLRowDXFactIndexer
        {
            EDayFactId this[int k] { get; set; }
        }

        public partial class TIMESHEETRow : IDLRowVXIndexer, IDLRowDXPlanIndexer, IDLRowDXFactIndexer
        {
            public int DL_V1_ColNr => this.tableTIMESHEET.V1Column.Ordinal;
            public int DL_D1_ColNr => this.tableTIMESHEET.D1Column.Ordinal;

            public EKind1 XKind1
            {
                get { return (EKind1)KIND1; }
                set { KIND1 = (short)value; }
            }

            public IDLRowVXIndexer Vx => this as IDLRowVXIndexer;
            public IDLRowDXPlanIndexer DxPlan => this as IDLRowDXPlanIndexer;
            public IDLRowDXFactIndexer DxFact => this as IDLRowDXFactIndexer;

            EDayFactId IDLRowDXFactIndexer.this[int k]
            {
                get { return (EDayFactId)this[DL_D1_ColNr + k]; }
                set
                {
                    if ((short)this[DL_D1_ColNr + k] == (short)value) return;
                    this[DL_D1_ColNr + k] = (short)value;
                }
            }

            EDayPlanId IDLRowDXPlanIndexer.this[int k]
            {
                get { return (EDayPlanId)this[DL_D1_ColNr + k]; }
                set
                {
                    if ((short)this[DL_D1_ColNr + k] == (short)value) return;
                    this[DL_D1_ColNr + k] = (short)value;
                }
            }

            float IDLRowVXIndexer.this[int k]
            {
                get { return (float)this[DL_V1_ColNr + k]; }
                set
                {
                    if ((float)this[DL_V1_ColNr + k] == value) return;
                    this[DL_V1_ColNr + k] = value;
                }
            }

            public void SetAllVx(float[] vx)
            {
                int v1_colnr = this.tableTIMESHEET.V1Column.Ordinal;
                for (int i = 0; i < 31; i++)
                    this[i + v1_colnr] = vx[i];
            }

            public float SumV()
            {
                float f = 0.0f;
                int v1_colnr = this.tableTIMESHEET.V1Column.Ordinal;
                for (int i = 0; i < 31; i++)
                    f += (float)this[i + v1_colnr];
                return f;
            }
        }

        public partial class EVENTSRow
        {
            public EEventId EventCode
            {
                get { return (EEventId)this.IDN; }
                set { this.IDN = (int)value; }
            }
        }

        public partial class UNTAXED_MINRow
        {


        }
    }
}

