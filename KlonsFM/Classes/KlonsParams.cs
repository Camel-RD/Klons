using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Serialization;
using KlonsFM.DataSets;
using KlonsFM.DataSets.klonsDataSetTableAdapters;
using KlonsLIB.Misc;

namespace KlonsFM.Classes
{
    public class KlonsParams
    {

        private klonsDataSet.ParamsDataTable GetTable()
        {
            return KlonsData.St.DataSetKlons.Params;
        }

        public void FillForUser(string username)
        {
            KlonsData.St.KlonsTableAdapterManager.ParamsTableAdapter.FillByUserName(KlonsData.St.DataSetKlons.Params, username);
        }

        public void Save()
        {
            if (KlonsData.St.KlonsTableAdapterManager.ParamsTableAdapter == null) return;
            KlonsData.St.KlonsTableAdapterManager.ParamsTableAdapter.Update(KlonsData.St.DataSetKlons.Params);
        }

        public int ValueMaxLength
        {
            get { return KlonsData.St.DataSetKlons.Params.PValueColumn.MaxLength; }
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

        public string CHCOL
        {
            get
            {
                string s = GetParamStr("CHCOL");
                if (string.IsNullOrEmpty(s)) return "1111";
                return s;
            }
            set { SetParamStr("CHCOL", value); }
        }

        public bool CHCOL2 { get { return CHCOL[0] == '1'; } }
        public bool CHCOL3 { get { return CHCOL[1] == '1'; } }
        public bool CHCOL4 { get { return CHCOL[2] == '1'; } }
        public bool CHCOL5 { get { return CHCOL[3] == '1'; } }
        
        public bool CHCOLCURR
        {
            get { return GetParamBool("CHCOLCURR").GetValueOrDefault(); }
            set { SetParamBool("CHCOLCURR", value); }
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

        public string OSD
        {
            get { return GetParamStr("OSD"); }
            set { SetParamStr("OSD", value); }
        }
        public string OCL
        {
            get { return GetParamStr("OCL"); }
            set { SetParamStr("OCL", value); }
        }
        public string OED
        {
            get { return GetParamStr("OED"); }
            set { SetParamStr("OED", value); }
        }
        public string OAC11
        {
            get { return GetParamStr("OAC11"); }
            set { SetParamStr("OAC11", value); }
        }
        public string OAC12
        {
            get { return GetParamStr("OAC12"); }
            set { SetParamStr("OAC12", value); }
        }
        public string OAC13
        {
            get { return GetParamStr("OAC13"); }
            set { SetParamStr("OAC13", value); }
        }
        public string OAC14
        {
            get { return GetParamStr("OAC14"); }
            set { SetParamStr("OAC14", value); }
        }
        public string OAC15
        {
            get { return GetParamStr("OAC15"); }
            set { SetParamStr("OAC15", value); }
        }

        public string OAC21
        {
            get { return GetParamStr("OAC21"); }
            set { SetParamStr("OAC21", value); }
        }
        public string OAC22
        {
            get { return GetParamStr("OAC22"); }
            set { SetParamStr("OAC22", value); }
        }
        public string OAC23
        {
            get { return GetParamStr("OAC23"); }
            set { SetParamStr("OAC23", value); }
        }
        public string OAC24
        {
            get { return GetParamStr("OAC24"); }
            set { SetParamStr("OAC24", value); }
        }
        public string OAC25
        {
            get { return GetParamStr("OAC25"); }
            set { SetParamStr("OAC25", value); }
        }
        public string ODOCGR
        {
            get { return GetParamStr("ODOCGR"); }
            set { SetParamStr("ODOCGR", value); }
        }
        public bool OOR
        {
            get { return GetParamBool("OOR").GetValueOrDefault(true); }
            set { SetParamBool("OOR", value); }
        }


        public bool UPRNP
        {
            get { return GetParamBool("UPRNP").GetValueOrDefault(false); }
            set { SetParamBool("UPRNP", value); }
        }

        public bool UPRIIN
        {
            get { return GetParamBool("UPRIIN").GetValueOrDefault(false); }
            set { SetParamBool("UPRIIN", value); }
        }
        public bool UPRIINIEN
        {
            get { return GetParamBool("UPRIINIEN").GetValueOrDefault(false); }
            set { SetParamBool("UPRIINIEN", value); }
        }
        public bool UPRIINIZD
        {
            get { return GetParamBool("UPRIINIZD").GetValueOrDefault(false); }
            set { SetParamBool("UPRIINIZD", value); }
        }
        public bool UPRPVN
        {
            get { return GetParamBool("UPRPVN").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVN", value); }
        }
        public bool UPRPVNIEN
        {
            get { return GetParamBool("UPRPVNIEN").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNIEN", value); }
        }
        public bool UPRPVNIZD
        {
            get { return GetParamBool("UPRPVNIZD").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNIZD", value); }
        }
        public bool UPRPVNDEB
        {
            get { return GetParamBool("UPRPVNDEB").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNDEB", value); }
        }
        public bool UPRPVNKRED
        {
            get { return GetParamBool("UPRPVNKRED").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNKRED", value); }
        }
        public bool UPRPVN5
        {
            get { return GetParamBool("UPRPVN5").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVN5", value); }
        }
        public bool UPRPVNREQPVN
        {
            get { return GetParamBool("UPRPVNREQPVN").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNREQPVN", value); }
        }
        public bool UPRPVNREQIEN
        {
            get { return GetParamBool("UPRPVNREQIEN").GetValueOrDefault(false); }
            set { SetParamBool("UPRPVNREQIEN", value); }
        }

        public string UPRIINIENV
        {
            get { return GetParamStr("UPRIINIENV"); }
            set { SetParamStr("UPRIINIENV", value); }
        }
        public string UPRIINIZDV
        {
            get { return GetParamStr("UPRIINIZDV"); }
            set { SetParamStr("UPRIINIZDV", value); }
        }
        public string UPRPVNIENV
        {
            get { return GetParamStr("UPRPVNIENV"); }
            set { SetParamStr("UPRPVNIENV", value); }
        }
        public string UPRPVNIZDV
        {
            get { return GetParamStr("UPRPVNIZDV"); }
            set { SetParamStr("UPRPVNIZDV", value); }
        }
        public string UPRPVNDEBV
        {
            get { return GetParamStr("UPRPVNDEBV"); }
            set { SetParamStr("UPRPVNDEBV", value); }
        }
        public string UPRPVNKREDV
        {
            get { return GetParamStr("UPRPVNKREDV"); }
            set { SetParamStr("UPRPVNKREDV", value); }
        }
        public string UPRPVN5V
        {
            get { return GetParamStr("UPRPVN5V"); }
            set { SetParamStr("UPRPVN5V", value); }
        }
        public bool AskBeforeDelete
        {
            get { return GetParamBool("MSGONDEL").GetValueOrDefault(true); }
            set { SetParamBool("MSGONDEL", value); }
        }
        public string RSD
        {
            get { return Utils.ReformatDateString(GetParamStr("RSD")); }
            set { SetParamStr("RSD", value); }
        }
        public string RED
        {
            get { return Utils.ReformatDateString(GetParamStr("RED")); }
            set { SetParamStr("RED", value); }
        }
        public string RAC
        {
            get { return GetParamStr("RAC"); }
            set { SetParamStr("RAC", value); }
        }
        public string RACX
        {
            get { return GetParamStr("RACX"); }
            set { SetParamStr("RACX", value); }
        }
        public string RACNM
        {
            get { return GetParamStr("RACNM"); }
            set { SetParamStr("RACNM", value); }
        }
        public string RPER
        {
            get { return GetParamStr("RPER"); }
            set { SetParamStr("RPER", value); }
        }
        public string AVRAC
        {
            get { return GetParamStr("AVRAC"); }
            set { SetParamStr("AVRAC", value); }
        }
        public string AVNorSD
        {
            get { return GetParamStr("AVNorSD"); }
            set { SetParamStr("AVNorSD", value); }
        }
        public string AVNorED
        {
            get { return GetParamStr("AVNorED"); }
            set { SetParamStr("AVNorED", value); }
        }
        public string NorPers
        {
            get { return GetParamStr("NorPers"); }
            set { SetParamStr("NorPers", value); }
        }
        public string AVNorNR
        {
            get { return GetParamStr("AVNorNR"); }
            set { SetParamStr("AVNorNR", value); }
        }
        public string RAP1
        {
            get { return GetParamStr("RAP1"); }
            set { SetParamStr("RAP1", value); }
        }
        public string RAP2
        {
            get { return GetParamStr("RAP2"); }
            set { SetParamStr("RAP2", value); }
        }
        public string RAP3
        {
            get { return GetParamStr("RAP3"); }
            set { SetParamStr("RAP3", value); }
        }
        public string RAP4
        {
            get { return GetParamStr("RAP4"); }
            set { SetParamStr("RAP4", value); }
        }
        public string RAP5
        {
            get { return GetParamStr("RAP5"); }
            set { SetParamStr("RAP5", value); }
        }
        public string RAP6
        {
            get { return GetParamStr("RAP6"); }
            set { SetParamStr("RAP6", value); }
        }
        public string RCURR
        {
            get { return GetParamStr("RCURR"); }
            set { SetParamStr("RCURR", value); }
        }
        public string RpvAmats
        {
            get { return GetParamStr("RpvAmats"); }
            set { SetParamStr("RpvAmats", value); }
        }
        public string RpvVards
        {
            get { return GetParamStr("RpvVards"); }
            set { SetParamStr("RpvVards", value); }
        }
        public string RpvUzvards
        {
            get { return GetParamStr("RpvUzvards"); }
            set { SetParamStr("RpvUzvards", value); }
        }
        public string RpvnRG1
        {
            get { return GetParamStr("RpvnRG1"); }
            set { SetParamStr("RpvnRG1", value); }
        }
        public string RpvnCHRG1
        {
            get { return GetParamStr("RpvnCHRG1"); }
            set { SetParamStr("RpvnCHRG1", value); }
        }
        public string RpvnCHLik
        {
            get { return GetParamStr("RpvnCHLik"); }
            set { SetParamStr("RpvnCHLik", value); }
        }
        public string LinkDocsYR
        {
            get { return GetParamStr("LinkDocsYR"); }
            set { SetParamStr("LinkDocsYR", value); }
        }
        public string RekinaIzr
        {
            get { return GetParamStr("RekinaIzr"); }
            set { SetParamStr("RekinaIzr", value); }
        }
        public string RSKAIDRA1
        {
            get { return GetParamStr("RSKAIDRA1"); }
            set { SetParamStr("RSKAIDRA1", value); }
        }
        public string RSKAIDRA2
        {
            get { return GetParamStr("RSKAIDRA2"); }
            set { SetParamStr("RSKAIDRA2", value); }
        }
        public string PZPARV
        {
            get { return GetParamStr("PZPARV"); }
            set { SetParamStr("PZPARV", value); }
        }
        public string Version
        {
            get { return GetParamStr("version"); }
            set { SetParamStr("version", value); }
        }
        public DateTime? MFILTERDOCSDT1
        {
            get { return GetParamDate("MFILTERDOCSDT1"); }
            set { SetParamDate("MFILTERDOCSDT1", value); }
        }
        public DateTime? MFILTERDOCSDT2
        {
            get { return GetParamDate("MFILTERDOCSDT2"); }
            set { SetParamDate("MFILTERDOCSDT2", value); }
        }
        public int? MFILTERDOCSTP
        {
            get { return GetParamInt("MFILTERDOCSTP"); }
            set { SetParamInt("MFILTERDOCSTP", value); }
        }
        public int? MFILTERDOCSSTATE
        {
            get { return GetParamInt("MFILTERDOCSSTATE"); }
            set { SetParamInt("MFILTERDOCSSTATE", value); }
        }
        public int? MFILTERDOCSOUT
        {
            get { return GetParamInt("MFILTERDOCSOUT"); }
            set { SetParamInt("MFILTERDOCSOUT", value); }
        }
        public int? MFILTERDOCSIN
        {
            get { return GetParamInt("MFILTERDOCSIN"); }
            set { SetParamInt("MFILTERDOCSIN", value); }
        }
        public int? MFILTERDOCSINOROUT
        {
            get { return GetParamInt("MFILTERDOCSINOROUT"); }
            set { SetParamInt("MFILTERDOCSINOROUT", value); }
        }
        public string MAINSTORE
        {
            get { return GetParamStr("MAINSTORE"); }
            set { SetParamStr("MAINSTORE", value); }
        }


        public string GetParamStr(string paramkey)
        {
            string username = KlonsData.St.CurrentUserName;
            klonsDataSet.ParamsDataTable table = GetTable();
            if (table == null)
            {
                throw new Exception("Params table is null.");
            }
            foreach (klonsDataSet.ParamsRow r in table.Rows)
            {
                if (string.Compare(r.PName, paramkey, true) != 0) continue;
                if (r.IsPValueNull()) return "";
                return r.PValue;
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
            klonsDataSet.ParamsDataTable table = GetTable();
            if (table == null)
            {
                throw new Exception("Params table is null.");
            }
            if (paramvalue == null) paramvalue = "";
            paramvalue = paramvalue.LeftMax(ValueMaxLength);
            foreach (klonsDataSet.ParamsRow r in table.Rows)
            {
                if (string.Compare(r.PName, paramkey, true) != 0) continue;
                if (r.PValue != paramvalue)
                    r.PValue = paramvalue;
                return;
            }
            table.AddParamsRow(paramkey, paramvalue, username);
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

        public int? GetParamInt(string paramkey)
        {
            string val = GetParamStr(paramkey);
            if (string.IsNullOrEmpty(val)) return null;
            if (!int.TryParse(val, out int ret)) return null;
            return ret;
        }

        public void SetParamInt(string paramkey, int? paramvalue)
        {
            string val = paramvalue.HasValue ? paramvalue.Value.ToString() : string.Empty;
            SetParamStr(paramkey, val);
        }

        public DateTime? GetParamDate(string paramkey)
        {
            string val = GetParamStr(paramkey);
            if (string.IsNullOrEmpty(val)) return null;
            var ret = Utils.StringToDate(val);
            return ret;
        }

        public void SetParamDate(string paramkey, DateTime? paramvalue)
        {
            string val = paramvalue.HasValue ? 
                Utils.DateToString(paramvalue.Value) : 
                string.Empty;
            SetParamStr(paramkey, val);
        }
    }
}
