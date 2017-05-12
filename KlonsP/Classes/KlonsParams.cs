using System;
using System.Diagnostics;
using KlonsLIB.Misc;
using KlonsLIB.Data;
using KlonsP.DataSets;

namespace KlonsP.Classes
{
    public class KlonsParams
    {
        public static KlonsData MyData => KlonsData.St;

        private KlonsPDataSet.PARAMSDataTable GetTable()
        {
            return KlonsData.St.DataSetKlons.PARAMS;
        }

        public void FillForUser(string username)
        {
            KlonsData.St.KlonsTableAdapterManager.PARAMSTableAdapter.FillByUserName(KlonsData.St.DataSetKlons.PARAMS, username);
        }

        public void Save()
        {
            if (KlonsData.St.KlonsTableAdapterManager.PARAMSTableAdapter == null) return;
            var drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PARAMS);
            foreach (var dr in drs)
            {
                var pdr = dr as KlonsPDataSet.PARAMSRow;
                if (pdr.ID >= 0) continue;
                pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PARAMS_ID();
            }
            KlonsData.St.KlonsTableAdapterManager.PARAMSTableAdapter.Update(KlonsData.St.DataSetKlons.PARAMS);
        }

        public int ValueMaxLength
        {
            get { return KlonsData.St.DataSetKlons.PARAMS.PVALUEColumn.MaxLength; }
        }

        private string PropName
        {
            get
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(4);
                return stackFrame.GetMethod().Name.Substring(4);
            }
        }

        public string CompNameX
        {
            get { return CompName + " " + CompRegNr; }
        }

        public string CompName
        {
            get { return GetParamStr("CompName"); }
            set { SetParamStr("CompName", value); }
        }
        public string CompRegNr
        {
            get { return GetParamStr("CompRegNr"); }
            set { SetParamStr("CompRegNr", value); }
        }
        public string CompMName
        {
            get { return GetParamStr("CompMName"); }
            set { SetParamStr("CompMName", value); }
        }
        public string CompMpk
        {
            get { return GetParamStr("CompMpk"); }
            set { SetParamStr("CompMpk", value); }
        }
        public string CompPhone
        {
            get { return GetParamStr("CompPhone"); }
            set { SetParamStr("CompPhone", value); }
        }
        public string CompAccName
        {
            get { return GetParamStr("CompAccName"); }
            set { SetParamStr("CompAccName", value); }
        }
        public string CompAccPh
        {
            get { return GetParamStr("CompAccPh"); }
            set { SetParamStr("CompAccPh", value); }
        }
        public string CompVID
        {
            get { return GetParamStr("CompVID"); }
            set { SetParamStr("CompVID", value); }
        }
        public string CompAddr
        {
            get { return GetParamStr("CompAddr"); }
            set { SetParamStr("CompAddr", value); }
        }
        public string CompAddrG
        {
            get { return GetParamStr("CompAddrG"); }
            set { SetParamStr("CompAddrG", value); }
        }
        public string CompAddrInd
        {
            get { return GetParamStr("CompAddrInd"); }
            set { SetParamStr("CompAddrInd", value); }
        }
        public string CompAddr1
        {
            get { return GetParamStr("CompAddr1"); }
            set { SetParamStr("CompAddr1", value); }
        }
        public string CompAddr2
        {
            get { return GetParamStr("CompAddr2"); }
            set { SetParamStr("CompAddr2", value); }
        }
        public string CompAddr3
        {
            get { return GetParamStr("CompAddr3"); }
            set { SetParamStr("CompAddr3", value); }
        }
        public string CompAddr4
        {
            get { return GetParamStr("CompAddr4"); }
            set { SetParamStr("CompAddr4", value); }
        }
        public string CompRegNrPVN
        {
            get { return GetParamStr("CompRegNrPVN"); }
            set { SetParamStr("CompRegNrPVN", value); }
        }
        public string CompRegNrPVNa
        {
            get
            {
                var s = CompRegNrPVN;
                if (s.Length < 11)
                    s += "           ".Substring(s.Length);
                return s;
            }
        }
        public string CompRegNrPVNx
        {
            get
            {
                string rn = CompRegNrPVN;
                if (rn.Length < 3) return "";
                return rn.Substring(2);
            }
        }
        public string BankId
        {
            get { return GetParamStr("BankId"); }
            set { SetParamStr("BankId", value); }
        }
        public string BankName
        {
            get { return GetParamStr("BankName"); }
            set { SetParamStr("BankName", value); }
        }
        public string BankAcc
        {
            get { return GetParamStr("BankAcc"); }
            set { SetParamStr("BankAcc", value); }
        }

        public string Version
        {
            get { return GetParamStr("version"); }
            set { SetParamStr("version", value); }
        }

        public string RSD
        {
            get { return GetParamStr("RSD"); }
            set { SetParamStr("RSD", value); }
        }
        public string RED
        {
            get { return GetParamStr("RED"); }
            set { SetParamStr("RED", value); }
        }
        public string RYR
        {
            get { return GetParamStr("RYR"); }
            set { SetParamStr("RYR", value); }
        }
        public string REPDT
        {
            get { return GetParamStr("REPDT"); }
            set { SetParamStr("REPDT", value); }
        }
        public string RVARDS
        {
            get { return GetParamStr("RVARDS"); }
            set { SetParamStr("RVARDS", value); }
        }
        public string RAMATS
        {
            get { return GetParamStr("RAMATS"); }
            set { SetParamStr("RAMATS", value); }
        }
        public string RTELEFONS
        {
            get { return GetParamStr("RTELEFONS"); }
            set { SetParamStr("RTELEFONS", value); }
        }
        public bool ShowItemDataPanel
        {
            get { return GetParamBool("ShowItemDataPanel").GetValueOrDefault(true); }
            set { SetParamBool("ShowItemDataPanel", value); }
        }
        public bool ShowItemsFilterPanel
        {
            get { return GetParamBool("ShowItemsFilterPanel").GetValueOrDefault(true); }
            set { SetParamBool("ShowItemsFilterPanel", value); }
        }
        public DateTime ActiveDate
        {
            get { return GetParamDate("ActiveDate").GetValueOrDefault(DateTime.Today); }
            set { SetParamDate("ActiveDate", value); }
        }


        public string GetParamStr(string paramkey)
        {
            string username = KlonsData.St.CurrentUserName;
            KlonsPDataSet.PARAMSDataTable table = GetTable();
            if (table == null)
            {
                throw new Exception("Params table is null.");
            }
            foreach (KlonsPDataSet.PARAMSRow r in table.Rows)
            {
                if (string.Compare(r.PNAME, paramkey, true) != 0) continue;
                if (r.IsPVALUENull()) return "";
                return r.PVALUE;
            }
            return "";
        }

        public void SetParamStr(string paramkey, string paramvalue)
        {
            string username = KlonsData.St.CurrentUserName;
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username not set.");
            }
            KlonsPDataSet.PARAMSDataTable table = GetTable();
            if (table == null)
            {
                throw new Exception("Params table is null.");
            }
            if (paramvalue == null) paramvalue = "";
            paramvalue = paramvalue.LeftMax(ValueMaxLength);
            foreach (KlonsPDataSet.PARAMSRow r in table.Rows)
            {
                if (string.Compare(r.PNAME, paramkey, true) != 0) continue;
                if (r.PVALUE!= paramvalue)
                    r.PVALUE = paramvalue;
                return;
            }
            table.AddPARAMSRow(paramkey, paramvalue, username);
        }

        public DateTime? GetParamDate(string paramkey)
        {
            string val = GetParamStr(paramkey);
            if (val == "") return null;
            DateTime dt;
            if (!Utils.StringToDate(val, out dt))
                return null;
            return dt;
        }

        public void SetParamDate(string paramkey, DateTime paramvalue)
        {
            string val = Utils.DateToString(paramvalue);
            SetParamStr(paramkey, val);
        }

        public int? GetParamInt(string paramkey)
        {
            string val = GetParamStr(paramkey);
            if (val == "") return null;
            int m;
            if (!int.TryParse(val, out m))
                return null;
            return m;
        }

        public void SetParamInt(string paramkey, int paramvalue)
        {
            string val = paramvalue.ToString();
            SetParamStr(paramkey, val);
        }

        public bool? GetParamBool(string paramkey)
        {
            string val = GetParamStr(paramkey);
            if (val == "") return null;
            return val == "true";
        }

        public void SetParamBool(string paramkey, bool? paramvalue)
        {
            string val = null;
            if(paramvalue.HasValue)
                val = paramvalue.Value ? "true" : "false";
            SetParamStr(paramkey, val);
        }

    }
}
