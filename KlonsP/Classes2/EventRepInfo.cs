using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KlonsP.DataSets;

namespace KlonsP.Classes
{
    public class EventRepInfo : EventInfo, IComparable<EventRepInfo>, IComparable
    {
        private static int[] defaultFieldSortOrder = new[] { 0, 1, 2, 3, 4 };

        public string RegNr { get; set; } = null;
        public string Name { get; set; } = null;

        public string SCat1 { get; set; } = null;
        public string SCatD { get; set; } = null;
        public string SCatT { get; set; } = null;
        public string SDepartment { get; set; } = null;
        public string SPlace { get; set; } = null;

        public string RCat1 { get; set; } = null;
        public string RCat2 { get; set; } = null;
        public string RCat3 { get; set; } = null;
        public string RCat4 { get; set; } = null;
        public string RCat5 { get; set; } = null;

        public int CountAtEnd = 0;

        public int[] FieldSortOrder = defaultFieldSortOrder;

        public bool IsTotal { get; set; } = false;

        public override void Add(EventInfo0 ev)
        {
            base.Add(ev);
            var evr = ev as EventRepInfo;
            if (evr == null) return;
            CountAtEnd += evr.CountAtEnd;
        }

        public string GetRField(int k)
        {
            switch (k)
            {
                case 0: return RCat1;
                case 1: return RCat2;
                case 2: return RCat3;
                case 3: return RCat4;
                case 4: return RCat5;
            }
            throw new ArgumentOutOfRangeException();
        }

        public string GetSField(int k)
        {
            switch (k)
            {
                case 0: return SCat1;
                case 1: return SCatD;
                case 2: return SCatT;
                case 3: return SDepartment;
                case 4: return SPlace;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void SetFieldId(int k, int val)
        {
            switch (k)
            {
                case 0: Cat1 = val; return;
                case 1: CatD = val; return;
                case 2: CatT = val; return;
                case 3: Department = val; return;
                case 4: Place = val; return;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void SetSField(int k, string val)
        {
            switch (k)
            {
                case 0: SCat1 = val; return;
                case 1: SCatD = val; return;
                case 2: SCatT = val; return;
                case 3: SDepartment = val; return;
                case 4: SPlace = val; return;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void SetRField(int k, string val)
        {
            switch (k)
            {
                case 0: RCat1 = val; return;
                case 1: RCat2 = val; return;
                case 2: RCat3 = val; return;
                case 3: RCat4 = val; return;
                case 4: RCat5 = val; return;
            }
            throw new ArgumentOutOfRangeException();
        }


        public void SetSFields()
        {
            SCat1 = MyData.DataSetKlons.CAT1.FindByID(Cat1).CODE;
            SCatD = MyData.DataSetKlons.CATD.FindByID(CatD).CODE;
            SCatT = MyData.DataSetKlons.CATT.FindByID(CatT).CODE;
            SDepartment = MyData.DataSetKlons.DEPARTMENTS.FindByID(Department).CODE;
            SPlace = MyData.DataSetKlons.PLACES.FindByID(Place).CODE;
        }

        public void SetSFieldsIgnore()
        {
            if (FieldSortOrder[0] == -1) SCat1 = null;
            if (FieldSortOrder[1] == -1) SCatD = null;
            if (FieldSortOrder[2] == -1) SCatT = null;
            if (FieldSortOrder[3] == -1) SDepartment = null;
            if (FieldSortOrder[4] == -1) SPlace = null;
        }

        public void SetRFields()
        {

            for (int i = 0; i < 5; i++)
                SetRField(i, null);

            for (int i = 0; i < 5; i++)
            {
                int k = FieldSortOrder[i];
                if (k < 0) continue;
                var sval = GetSField(i);
                SetRField(k, sval);
            }
        }

        public override void Reset()
        {
            base.Reset();
            RegNr = null;
            Name = null;

            SCat1 = null;
            SCatD = null;
            SCatT = null;
            SDepartment = null;
            SPlace = null;

            RCat1 = null;
            RCat2 = null;
            RCat3 = null;
            RCat4 = null;
            RCat5 = null;
            TaxValLeft0 = 0.0M;
        }

        public string GetDescr(int k)
        {
            switch (k)
            {
                case 0: return MyData.DataSetKlons.CAT1.FindByID(Cat1).DESCR;
                case 1: return MyData.DataSetKlons.CATD.FindByID(CatD).DESCR;
                case 2: return MyData.DataSetKlons.CATT.FindByID(CatT).DESCR;
                case 3: return MyData.DataSetKlons.DEPARTMENTS.FindByID(Department).DESCR;
                case 4: return MyData.DataSetKlons.PLACES.FindByID(Place).DESCR;
            }
            return null;
        }

        public void SetName1(int k)
        {
            Name = GetDescr(k);
        }

        int IComparable<EventRepInfo>.CompareTo(EventRepInfo other)
        {
            if (other == null)
                throw new ArgumentNullException();

            for (int i = 0; i < 5; i++)
            {
                var sval1 = GetRField(i);
                var sval2 = other.GetRField(i);
                var k = string.Compare(sval1, sval2);
                if (k != 0) return k;
            }
            return string.Compare(RegNr, other.RegNr);
        }

        int IComparable.CompareTo(object obj)
        {
            var cp = this as IComparable<EventRepInfo>;
            return cp.CompareTo(obj as EventRepInfo);
        }


    }


}
