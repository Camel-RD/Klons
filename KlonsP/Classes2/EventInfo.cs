using System;
using KlonsP.DataSets;

namespace KlonsP.Classes
{
    public class EventInfo0
    {
        protected static KlonsData MyData => KlonsData.St;

        public int Id { get; set; } = 0;
        public int IdIt { get; set; } = 0;

        public int SNR { get; set; } = 0;
        public int Event { get; set; } = 0;

        public DateTime ItemDate1 { get; set; } = DateTime.MinValue;
        public DateTime ItemDate2 { get; set; } = DateTime.MinValue;

        public EEvent XEvent
        {
            get { return (EEvent)Event; }
            set { Event = (int)value; } 
        }

        public DateTime Dt { get; set; } = DateTime.MinValue;
        public DateTime DtReg { get; set; } = DateTime.MinValue;
        public int Year => Dt.Year;
        public int Month => Dt.Month;
        public string Descr { get; set; } = "";
        public string Docnr { get; set; } = "";
        public int Cat1 { get; set; } = 0;
        public int CatD { get; set; } = 0;
        public int CatT { get; set; } = 0;
        public int Place { get; set; } = 0;
        public int Department { get; set; } = 0;

        public decimal Value0 { get; set; } = 0.0M;
        public decimal Deprec0 { get; set; } = 0.0M;
        public decimal ValueC { get; set; } = 0.0M;
        public decimal DeprecC { get; set; } = 0.0M;
        public decimal Value1 { get; set; } = 0.0M;
        public decimal Deprec1 { get; set; } = 0.0M;
        public decimal ValueLeft0 { get; set; } = 0.0M;
        public decimal ValueLeft1 { get; set; } = 0.0M;

        public decimal ValueNew { get; set; } = 0.0M;
        public decimal DeprecNew { get; set; } = 0.0M;

        public decimal ValueAdd { get; set; } = 0.0M;
        public decimal DeprecAdd { get; set; } = 0.0M;

        public decimal ValueRevalue { get; set; } = 0.0M;
        public decimal DeprecRevalue { get; set; } = 0.0M;

        public decimal ValueRecat { get; set; } = 0.0M;
        public decimal DeprecRecat { get; set; } = 0.0M;

        public decimal ValueExclude { get; set; } = 0.0M;
        public decimal DeprecExclude { get; set; } = 0.0M;

        public decimal SellValue { get; set; } = 0.0M;

        public decimal DeprecCalc { get; set; } = 0.0M;
        public decimal DeprecCalcThisMt { get; set; } = 0.0M;

        public float RateD { get; set; } = 0.0f;
        public decimal RateDMt { get; set; } = 0.0M;
        public decimal ChangeRateDMt { get; set; } = 0.0M;

        public int MtTotal { get; set; } = 0;
        public int MtUsed { get; set; } = 0;
        public decimal TaxVal { get; set; } = 0.0M;
        public decimal TaxValLeft0 { get; set; } = 0.0M;
        public decimal TaxValLeft1 { get; set; } = 0.0M;
        public decimal TaxValC { get; set; } = 0.0M;
        public float TaxRate { get; set; } = 0.0f;
        public decimal TaxDeprec { get; set; } = 0.0M;
        public decimal TaxDeprecCalc { get; set; } = 0.0M;

        public decimal TaxValNewCalc { get; set; } = 0.0M;
        public decimal TaxValAddCalc { get; set; } = 0.0M;
        public decimal TaxValRecatCalc { get; set; } = 0.0M;
        public decimal TaxValExcludeCalc { get; set; } = 0.0M;

        public decimal TaxValLeftAtEnd { get; set; } = 0.0M;
        public decimal TaxValLeftAtEndCalc { get; set; } = 0.0M;
        public int TaxEach { get; set; } = 0;
        public DateTime? ZDt { get; set; } = null;
        public string ZU { get; set; } = null;

        public bool LastInDay = false;

        public EState State = EState.OK;


        public virtual void Reset()
        {
            State = EState.OK;
            Id = 0;
            IdIt = 0;
            SNR = 0;
            Event = 0;
            Dt = DateTime.MinValue;
            DtReg = DateTime.MinValue;
            ItemDate1 = DateTime.MinValue;
            ItemDate2 = DateTime.MinValue;
            Descr = null;
            Docnr = null;
            Cat1 = 0;
            CatD = 0;
            CatT = 0;
            Department = 0;
            Place = 0;
            Value0 = 0.0M;
            Deprec0 = 0.0M;
            ValueLeft0 = 0.0M;
            ValueLeft1 = 0.0M;
            ValueC = 0.0M;
            DeprecC = 0.0M;
            Value1 = 0.0M;
            Deprec1 = 0.0M;
            MtTotal = 0;
            MtUsed = 0;
            SellValue = 0.0M;
            RateD = 0.0f;
            RateDMt = 0.0M;
            DeprecCalc = 0.0M;
            DeprecCalcThisMt = 0.0M;
            ValueNew = 0.0M;
            DeprecNew = 0.0M;
            ValueAdd = 0.0M;
            DeprecAdd = 0.0M;
            ValueRevalue = 0.0M;
            DeprecRevalue = 0.0M;
            ValueRecat = 0.0M;
            DeprecRecat = 0.0M;
            ValueExclude = 0.0M;
            DeprecExclude = 0.0M;
            TaxVal = 0.0M;
            TaxValC = 0.0M;
            TaxValLeft0 = 0.0M;
            TaxValLeft1 = 0.0M;
            TaxDeprec = 0.0M;
            TaxDeprecCalc = 0.0M;
            TaxRate = 0.0f;
            TaxValNewCalc = 0.0M;
            TaxValAddCalc = 0.0M;
            TaxValRecatCalc = 0.0M;
            TaxValExcludeCalc = 0.0M;
            TaxValLeftAtEnd = 0.0M;
            TaxValLeftAtEndCalc = 0.0M;
            TaxEach = 0;
            LastInDay = false;
            ZDt = null;
            ZU = null;
        }

        public virtual void Add(EventInfo0 ev)
        {
            Value0 += ev.Value0;
            Deprec0 += ev.Deprec0;
            ValueLeft0 += ev.ValueLeft0;
            ValueLeft1 += ev.ValueLeft1;
            ValueC += ev.ValueC;
            DeprecC += ev.DeprecC;
            SellValue += ev.SellValue;
            DeprecCalc += ev.DeprecCalc;
            DeprecCalcThisMt += ev.DeprecCalcThisMt;
            Value1 += ev.Value1;
            Deprec1 += ev.Deprec1;

            ValueNew += ev.ValueNew;
            DeprecNew += ev.DeprecNew;
            ValueAdd += ev.ValueAdd;
            DeprecAdd += ev.DeprecAdd;
            ValueRevalue += ev.ValueRevalue;
            DeprecRevalue += ev.DeprecRevalue;
            ValueRecat += ev.ValueRecat;
            DeprecRecat += ev.DeprecRecat;
            ValueExclude += ev.ValueExclude;
            DeprecExclude += ev.DeprecExclude;

            TaxVal += ev.TaxVal;
            TaxValC += ev.TaxValC;
            TaxValLeft0 += ev.TaxValLeft0;
            TaxValLeft1 += ev.TaxValLeft1;
            TaxDeprec += ev.TaxDeprec;
            TaxDeprecCalc += ev.TaxDeprecCalc;
            TaxRate += ev.TaxRate;

            TaxValNewCalc += ev.TaxValNewCalc;
            TaxValAddCalc += ev.TaxValAddCalc;
            TaxValRecatCalc += ev.TaxValRecatCalc;
            TaxValExcludeCalc += ev.TaxValExcludeCalc;
            TaxValLeftAtEnd += ev.TaxValLeftAtEnd;
            TaxValLeftAtEndCalc += TaxValLeftAtEndCalc;
        }

    }


    public class EventInfo : EventInfo0
    {
        public KlonsPDataSet.ITEMS_EVENTSRow DR = null;
        public bool InitFields = false;

        public static EventInfo Zero = new EventInfo();

        public void SetFromRow(KlonsPDataSet.ITEMS_EVENTSRow dr)
        {
            DR = dr;
            Id = dr.ID;
            IdIt = dr.IDIT;
            SNR = dr.SNR;
            Event = dr.EVENT;
            Dt = dr.DT;
            DtReg = dr.DTREG;
            Descr = dr.DESCR;
            Docnr = dr.DOCNR;
            Cat1 = dr.CAT1;
            CatD = dr.CATD;
            CatT = dr.CATT;
            Place = dr.PLACE;
            Department = dr.DEPARTMENT;

            Value0 = dr.VALUE_0;
            Deprec0 = dr.DEPREC_0;
            ValueC = dr.VALUE_C;
            DeprecC = dr.DEPREC_C;
            SellValue = dr.SELL_VALUE;
            RateD = dr.CATDRow.RATE;
            //RateD = dr.RATE_D;
            RateDMt = dr.RATE_D_MT;
            MtTotal = dr.MT_TOTAL;
            MtUsed = dr.MT_USED;

            TaxVal = dr.TAX_VAL;
            TaxValLeft1 = dr.TAX_VAL_LEFT;
            TaxValC = dr.TAX_VAL_C;
            //TaxRate = dr.TAX_RATE;
            TaxRate = dr.CATTRow.RATE;
            TaxEach = dr.TAX_EACH;

        }
        public override void Reset()
        {
            base.Reset();
            InitFields = false;
        }

        public void UpdateRow()
        {
            if (DR == null)
                throw new Exception("DR is null.");
            DR.BeginEdit();
            DR.VALUE_0 = Value0;
            DR.DEPREC_0 = Deprec0;
            DR.TAX_VAL = TaxVal;
            DR.MT_USED = MtUsed;
            DR.EndEdit();
        }

        public void UpdateRowFull(bool dobeginend = true)
        {
            if (DR == null)
                throw new Exception("DR is null.");
            if(dobeginend) DR.BeginEdit();

            if (SNR != DR.SNR) DR.SNR = SNR;
            if (Event != DR.EVENT) DR.EVENT = Event;
            if (Dt != DR.DT) DR.DT = Dt;
            if (DtReg != DR.DTREG) DR.DTREG = DtReg;
            if (Descr != DR.DESCR) DR.DESCR = Descr;
            if (Docnr != DR.DOCNR) DR.DOCNR = Docnr;
            if (Cat1 != DR.CAT1) DR.CAT1 = Cat1;
            if (CatD != DR.CATD) DR.CATD = CatD;
            if (CatT != DR.CATT) DR.CATT = CatT;
            if (Place != DR.PLACE) DR.PLACE = Place;
            if (Department != DR.DEPARTMENT) DR.DEPARTMENT = Department;

            if (Value0 != DR.VALUE_0) DR.VALUE_0 = Value0;
            if (Deprec0 != DR.DEPREC_0) DR.DEPREC_0 = Deprec0;
            if (ValueC != DR.VALUE_C) DR.VALUE_C = ValueC;
            if (DeprecC != DR.DEPREC_C) DR.DEPREC_C = DeprecC;
            if (SellValue != DR.SELL_VALUE) DR.SELL_VALUE = SellValue;
            if (RateD != DR.RATE_D) DR.RATE_D = RateD;
            if (RateDMt != DR.RATE_D_MT) DR.RATE_D_MT = RateDMt;
            if (MtTotal != DR.MT_TOTAL) DR.MT_TOTAL = MtTotal;
            if (MtUsed != DR.MT_USED) DR.MT_USED = MtUsed;

            if (TaxValLeft1 != DR.TAX_VAL_LEFT) DR.TAX_VAL_LEFT = TaxValLeft1;
            if (TaxVal != DR.TAX_VAL) DR.TAX_VAL = TaxVal;
            if (TaxValC != DR.TAX_VAL) DR.TAX_VAL_C = TaxValC;
            if (TaxRate != DR.TAX_RATE) DR.TAX_RATE = TaxRate;
            if (TaxEach != DR.TAX_EACH) DR.TAX_EACH = TaxEach;

            if (dobeginend) DR.EndEditX();
        }

        public void RecalcA()
        {
            RateD = MyData.DataSetKlons.CATD.FindByID(CatD).RATE / 100.0f;
            TaxRate = MyData.DataSetKlons.CATT.FindByID(CatT).RATE / 100.0f;
            var valuetodeprec = Value0 + ValueC - SellValue;
            var valuetodeprecleft = valuetodeprec - Deprec0 - DeprecC;
            if (valuetodeprec > 0.0M && valuetodeprecleft > 0.0M && RateD > 0)
            {
                RateDMt = Math.Round(valuetodeprec * (decimal)(RateD / 12.0f), 2);
                int mtleft = (int)Math.Ceiling(valuetodeprecleft / RateDMt);
                MtTotal = MtUsed + mtleft;
            }
            else
            {

                RateDMt = 0.0M;
                MtTotal = 0;
            }
        }

    }



}
