using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlonsF.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsF.Classes
{
    public class RepRowDocOps
    {
        public int IdDoc { get; set; }
        public int IdOps { get; set; }
        public DateTime Dt { get; set; }
        public string DtText { get; set; }
        public string NrX { get; set; }
        public string DocTyp { get; set; }
        public string DocSt { get; set; }
        public string DocNr { get; set; }
        public string Name { get; set; }
        public string RegNr { get; set; }
        public string Name2 { get; set; }
        public string RegNr2 { get; set; }
        public string Descr { get; set; }
        public string Descr2 { get; set; }
        public string Ac1 { get; set; }
        public string Ac2 { get; set; }
        public string SAc1 { get; set; }
        public string SAc2 { get; set; }
        public decimal SummC { get; set; }
        public string Cur { get; set; }
        public decimal Summ { get; set; }
        public float QV { get; set; }
        public string SummText { get; set; }
        public decimal PVN { get; set; }
        public string RAC { get; set; }
        public decimal SDb { get; set; }
        public decimal SCr { get; set; }

        public void SetFrom(klonsRepDataSet.ROps1aRow dr)
        {
            IdDoc = dr.did;
            IdOps = dr.id;
            Dt = dr.Dete;
            DtText = LatText.FullDateStr(Dt);
            NrX = dr.NrX;
            DocTyp = dr.DocTyp;
            DocSt = dr.DocSt;
            DocNr = dr.DocNr;
            Name = dr.Name;
            RegNr = dr.RegNr;
            Name2 = dr.Name2;
            RegNr2 = dr.RegNr2;
            Descr = dr.Descr;
            Descr2 = dr.Descr2;
            Ac1 = dr.Ac1;
            Ac2 = dr.Ac2;
            SAc1 = dr.SAc1;
            SAc2 = dr.SAc2;
            SummC = dr.SummC;
            Cur = dr.Cur;
            Summ = dr.Summ;
            PVN = dr.PVN;
            RAC = dr.RAC;
            SDb = dr.SDb;
            SCr = dr.SCr;
            QV = dr.QV;
        }

        public static RepRowDocOps GetFrom(klonsRepDataSet.ROps1aRow dr)
        {
            var ret = new RepRowDocOps();
            ret.SetFrom(dr);
            return ret;
        }

        public static List<RepRowDocOps> GetFrom(klonsRepDataSet.ROps1aDataTable table_rops1a)
        {
            var ret = table_rops1a.Select(x => GetFrom(x)).ToList();
            var totals = ret
                .GroupBy(x => x.IdDoc)
                .ToDictionary(x => x.Key, x => LatText.CikEiro(x.Sum(y => y.Summ)));
            foreach(var row in ret)
            {
                row.SummText = totals[row.IdDoc];
            }
            return ret;
        }

    }
}
