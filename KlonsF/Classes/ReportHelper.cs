using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KlonsF.Classes;
using KlonsF.DataSets;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Misc;
using KlonsLIB.Forms;
using Microsoft.Reporting.WinForms;

namespace KlonsF.Classes
{

    public class ReportHelperF: KlonsLIB.Forms.ReportHelper
    {
        public klonsRepDataSet MyDataSet { get { return KlonsData.St.DataSetKlonsRep; } }

        public override bool CheckForErrors(Action act)
        {
            var t1 = KlonsData.St.DataSetKlons.OPSd.GetChanges();
            var t2 = KlonsData.St.DataSetKlons.OPS.GetChanges();

            if ((t1 != null && t1.Rows.Count > 0) || (t2 != null && t2.Rows.Count > 0))
            {
                KlonsData.St.MyMainForm.ShowWarning("Iespējams, ka datu tabulās ir nesaglabātas izmaiņas.");
            }
            
            try
            {
                act();
                return true;
            }
            catch (Exception e)
            {
                MyException e1 = new MyException(
                    "Neizdevās sagatavot atskaiti!\n" +
                    "(iespējams, ka kļūda programmā).", e);
                Form_Error.ShowException(e1);
            }
            return false;
        }

        public void PrepareRops1a()
        {
            klonsRepDataSet.ROps1aDataTable dt = MyDataSet.ROps1a;
            foreach (var rv in dt)
            {
                rv.RAC2 = rv.RAC2.Nz();
                rv.RAC3 = rv.RAC3.Nz();
                rv.RAC4 = rv.RAC4.Nz();
                rv.RAC5 = rv.RAC5.Nz();
                rv.SAc1 = string.Format("{0},{1},{2},{3},{4}", rv.RAC, rv.RAC2, rv.RAC3, rv.RAC4, rv.RAC5);
            }
        }
        public void PrepareRops1aForKO()
        {
            klonsRepDataSet.ROps1aDataTable dt = MyDataSet.ROps1a;
            foreach (var rv in dt)
            {
                string doctyp = rv.DocTyp1.Nz();
                string docst = rv.DocSt.Nz();
                string docnr = rv.DocNr.Nz();
                string docstr = doctyp;
                
                if (docstr != "" && docst != "") 
                    docstr += " " + docst;
                else 
                    docstr += docst;
                
                if (docstr != "" && docnr != "") 
                    docstr += " " + docnr;
                else 
                    docstr += docnr;

                string clstr = "";
                if (!string.IsNullOrEmpty(rv.ClId2))
                {
                    clstr = rv.Name.Nz();
                    clstr = rv.Name.Nz();
                    string clregnr = rv.RegNr.Nz();
                    if (clstr != "" && clregnr != "")
                        clstr += " " + clregnr;
                    else
                        clstr += clregnr;
                }
                string descr = rv.Descr.Nz();
                string descr2 = docstr;
                if (descr2 != "" && clstr != "")
                    descr2 += "\n" + clstr;
                else
                    descr2 += clstr;

                if (descr2 != "" && descr != "")
                    descr2 += "\n" + descr;
                else
                    descr2 += descr;
                rv.Descr2 = descr2;

                if (rv.ClId2 == null)
                {
                    rv.ClId2 = rv.ClId;
                    rv.Name2 = rv.Name;
                    rv.RegNr2 = rv.RegNr;
                }
            }
        }

        public void PrepareRops2a()
        {
            klonsRepDataSet.ROps2aDataTable dt = MyDataSet.ROps2a;
            decimal d1;
            foreach (var rv in dt)
            {
                d1 = rv.SDb - rv.SCr;
                rv.ADb = 0.0M;
                rv.ACr = 0.0M;
                rv.BDb = 0.0M;
                rv.BCr = 0.0M;
                rv.B0 = d1;
                if (d1 > 0)
                    rv.ADb = d1;
                else
                    rv.ACr = -d1;
                d1 += rv.TDb - rv.TCr;
                if (d1 > 0)
                    rv.BDb = d1;
                else
                    rv.BCr = -d1;

            }
        }
        public void PrepareRops2aRAC()
        {
            klonsRepDataSet.ROps2aDataTable dt = MyDataSet.ROps2a;
            string s;
            foreach (var rv in dt)
            {
                s = string.Format("Konts: [{0}]", rv.Ac);
                if (!string.IsNullOrEmpty(rv.Name))
                    s = string.Format("{0} {1}", s, rv.Name);
                if (!string.IsNullOrEmpty(rv.ClId))
                    s = string.Format("{0}\nPersona: [{1}]", s, rv.ClId);
                if (!string.IsNullOrEmpty(rv.Name1))
                    s = string.Format("{0} {1}", s, rv.Name1);
                rv.RName = s;
            }
        }
        public void PrepareRops2aRAC(string ac, string acname, string clid, string cname)
        {
            klonsRepDataSet.ROps2aDataTable dt = MyDataSet.ROps2a;
            if (dt.Count == 0)
            {
                var dr = dt.NewRow() as klonsRepDataSet.ROps2aRow;
                dr.Ac = ac;
                dr.Name = acname;
                dr.ClId = clid;
                dr.Name1 = cname;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            string s;
            foreach (var rv in dt)
            {
                s = string.Format("Konts: [{0}]", rv.Ac);
                if (!string.IsNullOrEmpty(rv.Name))
                    s = string.Format("{0} {1}", s, rv.Name);
                if (!string.IsNullOrEmpty(rv.ClId))
                    s = string.Format("{0}\nPersona: [{1}]", s, rv.ClId);
                if (!string.IsNullOrEmpty(rv.Name1))
                    s = string.Format("{0} {1}", s, rv.Name1);
                rv.RName = s;
            }
        }

        public void CheckRops2aHasRow()
        {
            klonsRepDataSet.ROps2aDataTable dt = MyDataSet.ROps2a;
            if (dt.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }
        }

        public void PrepareTRepMT()
        {
            klonsRepDataSet.TRepMTDataTable dt = MyDataSet.TRepMT;
            int i,k1 = dt.Columns.IndexOf("M1");
            foreach (var rv in dt)
            {
                for (i = k1; i < k1 + 26; i++)
                {
                    if (rv[i] == DBNull.Value) rv[i] = 0.00M;
                }
                rv.MT = rv.M1 + rv.M2 + rv.M3 + rv.M4 + rv.M5 + rv.M6 + rv.M7 +
                        rv.M8 + rv.M9 + rv.M10 + rv.M11 + rv.M12;
                rv.NT = rv.N1 + rv.N2 + rv.N3 + rv.N4 + rv.N5 + rv.N6 + rv.N7 +
                        rv.N8 + rv.N9 + rv.N10 + rv.N11 + rv.N12;
                /*
                for (i = k1; i < k1 + 25; i++)
                {
                    rv[i] = (decimal) Math.Round((decimal) rv[i], 2);
                }*/
            }
        }
        public void PrepareTRepMTForNPMT1(int month)
        {
            klonsRepDataSet.TRepMTDataTable dt = MyDataSet.TRepMT;
            int i,k1 = dt.Columns.IndexOf("M1");
            foreach (var rv in dt)
            {
                for (i = k1; i < k1 + 26; i++)
                {
                    if (rv[i] == DBNull.Value) rv[i] = 0.00M;
                }

                if (rv.ad == "B" || rv.ad == "C")
                {
                    rv.MT = rv.M1 + rv.M2 + rv.M3 + rv.M4 + rv.M5 + rv.M6 + rv.M7 +
                            rv.M8 + rv.M9 + rv.M10 + rv.M11 + rv.M12;
                }
                if (rv.ad == "A" || rv.ad == "D")
                {
                    rv.M1 = rv.MT - rv.NT + rv.M1 - rv.N1;
                    rv.M2 = rv.M1 + rv.M2 - rv.N2;
                    rv.M3 = rv.M2 + rv.M3 - rv.N3;
                    rv.M4 = rv.M3 + rv.M4 - rv.N4;
                    rv.M5 = rv.M4 + rv.M5 - rv.N5;
                    rv.M6 = rv.M5 + rv.M6 - rv.N6;
                    rv.M7 = rv.M6 + rv.M7 - rv.N7;
                    rv.M8 = rv.M7 + rv.M8 - rv.N8;
                    rv.M9 = rv.M8 + rv.M9 - rv.N9;
                    rv.M10 = rv.M9 + rv.M10 - rv.N10;
                    rv.M11 = rv.M10 + rv.M11 - rv.N11;
                    rv.M12 = rv.M11 + rv.M12 - rv.N12;
                }
                if (rv.ad == "A")
                {
                    rv.M12 = rv.M11;
                    rv.M11 = rv.M10;
                    rv.M10 = rv.M9;
                    rv.M9 = rv.M8;
                    rv.M8 = rv.M7;
                    rv.M7 = rv.M6;
                    rv.M6 = rv.M5;
                    rv.M5 = rv.M4;
                    rv.M4 = rv.M3;
                    rv.M3 = rv.M2;
                    rv.M4 = rv.M3;
                    rv.M1 = rv.MT - rv.NT;
                }
                if (rv.ad == "A" || rv.ad == "D")
                {
                    rv.MT = 0.00M;
                    rv.NT = 0.00M;
                }
                if (rv.ad == "A")
                {
                    for (i = k1 + month; i < k1 + 12; i++)
                    {
                        rv[i] = 0.00M;
                    }
                }
                if (rv.ad == "D")
                {
                    for (i = k1 + month; i < k1 + 12; i++)
                    {
                        rv[i] = 0.00M;
                    }
                }
            }
        }
        public void PrepareTRepMTForNPMT3()
        {
            klonsRepDataSet.TRepMTDataTable dt = MyDataSet.TRepMT;
            int i, k1 = dt.Columns.IndexOf("M1");
            foreach (var rv in dt)
            {
                for (i = k1; i < k1 + 26; i++)
                {
                    if (rv[i] == DBNull.Value) rv[i] = 0.00M;
                }
                rv.MT = 0.00M;
                for (i = k1; i < k1 + 12; i++)
                {
                    rv[i] = (decimal) rv[i + 12] - (decimal) rv[i];
                    rv.MT += (decimal) rv[i];
                }
            }
        }

        public void PrepareTRepDarz1()
        {
            klonsRepDataSet.TRepDarz1DataTable dt = MyDataSet.TRepDarz1;
            for(int i=0;i<dt.Count;i++)
            {
                var rv = dt[i];
                rv.rid = i;
                rv.DocTyp = rv.DocTyp.Nz();
                rv.DocSt = rv.DocSt.Nz();
                rv.DocNr = rv.DocNr.Nz();
                rv.DocStr = string.Format("{0} {1} {2}", rv.DocTyp, rv.DocSt, rv.DocNr);
            }
        }

        public decimal GetBal0ForDate(string pac, DateTime pdt)
        {
            ROps2aTableAdapter ad2a = KlonsData.St.GetKlonsRepAdapter("ROps2a") as ROps2aTableAdapter;
            ad2a.FillBy_apgr_01(MyDataSet.ROps2a, pdt, pdt, pac);
            PrepareRops2a();
            var rv = MyDataSet.ROps2a[0];
            return rv.SDb - rv.SCr;
        }

        public void FillBalA2FromBalA21(string balid)
        {
            foreach (var dr in KlonsData.St.DataSetKlons.BalA22)
            {
                if (dr.balid != balid) continue;
                var dr2 = KlonsData.St.DataSetKlons.BalA21.FindByid(dr.id);
                if (dr2 == null)
                {
                    dr.S1 = 0.00M;
                    dr.S2 = 0.00M;
                    continue;
                }
                if (dr2.Iss1Null()) 
                    dr.S1 = 0.00M;
                else 
                    dr.S1 = dr2.s1;
                
                if (dr2.Iss2Null()) 
                    dr.S2 = 0.00M;
                else 
                    dr.S2 = dr2.s2;
                /*
                if (dr.dc == "PA")
                {
                    dr.S1 = -dr.S1;
                    dr.S2 = -dr.S2;
                }*/
            }
            KlonsData.St.DataSetKlons.BalA22.AcceptChanges();
        }

    }
}
