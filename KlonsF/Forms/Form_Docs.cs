using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using KlonsF.Classes;
using KlonsF.FormsReportParams;
using KlonsF.UI;
using KlonsF.DataSets;
using KlonsF.DataSets.klonsDataSetTableAdapters;
using KlonsF.DataSets.klonsRepDataSetTableAdapters;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;
using OPSdTableAdapter = KlonsF.DataSets.klonsDataSetTableAdapters.OPSdTableAdapter;
using Timer = System.Timers.Timer;

namespace KlonsF.Forms
{
    public partial class Form_Docs : MyFormBaseF
    {
        public Form_Docs()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            LoadColumnWidthsFromSettings();
            FormInitOnLoad();
        }

        private string warnAfterValidation = null;

        private void LoadColumnWidthsFromSettings()
        {
            int[] cw = MyData.Settings.ColumnWidths_Docs;
            if (cw.Length > 0)
            {
                dgvDocs.SetColumnWidths(cw);
            }
            cw = MyData.Settings.ColumnWidths_Ops;
            if (cw.Length > 0)
            {
                dgvOps.SetColumnWidths(cw);
            }
        }

        private void SaveColumnWidthsToSettings()
        {
            MyData.Settings.ColumnWidths_Docs = dgvDocs.GetColumnWidths(10.0f);
            MyData.Settings.ColumnWidths_Ops = dgvOps.GetColumnWidths(10.0f);
        }

        private static string LastConnectionString = null;

        private klonsDataSet MyDataSet
        {
            get { return MyData.DataSetKlons; }
        }

        private void FormDocs_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CheckSave();
        }

        private void FormDocs_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyData.DataSetKlons.OPS.ColumnChanged -= OPS_ColumnChenged;
            MyData.DataSetKlons.OPS.OPSRowDeleted -= OPS_RowDeleted;
            MyData.DataSetKlons.OPS.OPSRowChanged -= OPS_RowChanged;
            MyData.DataSetKlons.OPS.OPSRowDeleting -= Ops_RowDeleting;
            MyData.DataSetKlons.OPSd.ColumnChanged -= OPSd_ColumnChenged;
            MyData.DataSetKlons.OPSd.OPSdRowChanged -= OPSd_RowChanged;
        }

        private void FormInitOnLoad()
        {
            try
            {
                if (MyDataSet.OPSd.Count == 0)
                {
                    string cs = MyData.GetDataSetHelper(MyData.DataSetKlons).ConnectionString;
                    if (LastConnectionString == null ||
                        LastConnectionString != cs)
                    {
                        FillDocsByParams();
                        LastConnectionString = cs;

                    }
                }
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(this, ex);
            }

            this.bsOPSd.CurrentChanged += bsOPSd_CurrentChanged;
            CheckOpsGrid();

            CheckColumns();

            MyData.DataSetKlons.OPS.ColumnChanged += OPS_ColumnChenged;
            MyData.DataSetKlons.OPS.OPSRowDeleted += OPS_RowDeleted;
            MyData.DataSetKlons.OPS.OPSRowDeleting += Ops_RowDeleting;
            MyData.DataSetKlons.OPS.OPSRowChanged += OPS_RowChanged;
            MyData.DataSetKlons.OPSd.ColumnChanged += OPSd_ColumnChenged;
            MyData.DataSetKlons.OPSd.OPSdRowChanged += OPSd_RowChanged;
        }

        private string ZN(string value)
        {
            string s = string.IsNullOrEmpty(value) ? null : value;
            if (s != null)
                s = s.Replace('*', '%');
            return s;
        }

        private void FillDocsByParams()
        {
            DateTime? dt1, dt2;
            dt1 = Utils.StringToDate(MyData.Params.OSD);
            dt2 = Utils.StringToDate(MyData.Params.OED);
            string sac11, sac12, sac13, sac14, sac15;
            string sac21, sac22, sac23, sac24, sac25;
            string sdocgr;

            string sclid = ZN(MyData.Params.OCL);
            sac11 = ZN(MyData.Params.OAC11);
            sac12 = ZN(MyData.Params.OAC12);
            sac13 = ZN(MyData.Params.OAC13);
            sac14 = ZN(MyData.Params.OAC14);
            sac15 = ZN(MyData.Params.OAC15);
            sac21 = ZN(MyData.Params.OAC21);
            sac22 = ZN(MyData.Params.OAC22);
            sac23 = ZN(MyData.Params.OAC23);
            sac24 = ZN(MyData.Params.OAC24);
            sac25 = ZN(MyData.Params.OAC25);
            sdocgr = ZN(MyData.Params.ODOCGR);

            bool aand = !MyData.Params.OOR;

            string stext = null;

            OPSdTableAdapter addoc = MyData.GetKlonsAdapter("OPSd") as OPSdTableAdapter;
            OPSTableAdapter adops = MyData.GetKlonsAdapter("OPS") as OPSTableAdapter;


            bool b1 = (sac11 == null && sac12 == null && sac13 == null && sac14 == null && sac15 == null)
                      || (sac21 == null && sac22 == null && sac23 == null && sac24 == null && sac25 == null);

            MyData.DataSetKlons.OPS.Clear();
            MyData.DataSetKlons.OPSd.Clear();

            try
            {
                if (aand || b1)
                {

                    addoc.FillByAndFilter(MyData.DataSetKlons.OPSd,
                        dt1, dt2, stext, sclid,
                        sac11, sac12, sac13, sac14, sac15,
                        sac21, sac22, sac23, sac24, sac25, sdocgr);
                }
                else
                {
                    addoc.FillByOrFilter(MyData.DataSetKlons.OPSd,
                        dt1, dt2, stext, sclid,
                        sac11, sac12, sac13, sac14, sac15,
                        sac21, sac22, sac23, sac24, sac25, sdocgr);
                }
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(MyMainForm, ex, dgvDocs);
            }
            try
            {
                if (aand || b1)
                {
                    adops.FillByAndFilter(MyData.DataSetKlons.OPS,
                        dt1, dt2, stext, sclid,
                        sac11, sac12, sac13, sac14, sac15,
                        sac21, sac22, sac23, sac24, sac25, sdocgr);
                }
                else
                {
                    adops.FillByOrFilter(MyData.DataSetKlons.OPS,
                        dt1, dt2, stext, sclid,
                        sac11, sac12, sac13, sac14, sac15,
                        sac21, sac22, sac23, sac24, sac25, sdocgr);
                }
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(MyMainForm, ex, dgvOps);
            }
        }


        public override bool SaveData()
        {
            if (!dgvDocs.EndEditX()) return false;
            if (!dgvOps.EndEditX()) return false;

            var ret = bsOPSd.SaveTable();
            if (ret == EBsSaveResult.Error) return false;
            CheckSave();

            return true;
        }

        private void CheckColumns()
        {
            string CHCOL = MyData.Params.CHCOL;
            bool b1 = CHCOL[0] == '1';
            bool b2 = CHCOL[1] == '1';
            bool b3 = CHCOL[2] == '1';
            bool b4 = CHCOL[3] == '1';
            dgcOpsAC12.Visible = b1;
            dgcOpsAC22.Visible = b1;
            dgcOpsAC13.Visible = b2;
            dgcOpsAC23.Visible = b2;
            dgcOpsAC14.Visible = b3;
            dgcOpsAC24.Visible = b3;
            dgcOpsAC15.Visible = b4;
            dgcOpsAC25.Visible = b4;
            b1 = MyData.Params.CHCOLCURR;
            dgcOpsCur.Visible = b1;
            dgcOpsSumm.Visible = b1;
        }

        private int Get_OPS_Col_Nr(DataColumn col)
        {
            if (col == MyData.DataSetKlons.OPS.AC11Column) return 11;
            if (col == MyData.DataSetKlons.OPS.AC12Column) return 12;
            if (col == MyData.DataSetKlons.OPS.AC13Column) return 13;
            if (col == MyData.DataSetKlons.OPS.AC14Column) return 14;
            if (col == MyData.DataSetKlons.OPS.AC15Column) return 15;

            if (col == MyData.DataSetKlons.OPS.AC21Column) return 21;
            if (col == MyData.DataSetKlons.OPS.AC22Column) return 22;
            if (col == MyData.DataSetKlons.OPS.AC23Column) return 23;
            if (col == MyData.DataSetKlons.OPS.AC24Column) return 24;
            if (col == MyData.DataSetKlons.OPS.AC25Column) return 25;

            if (col == MyData.DataSetKlons.OPS.QVColumn) return 3;
            if (col == MyData.DataSetKlons.OPS.SummCColumn) return 4;
            if (col == MyData.DataSetKlons.OPS.CurColumn) return 5;
            if (col == MyData.DataSetKlons.OPS.SummColumn) return 6;

            if (col == MyData.DataSetKlons.OPS.ZDtColumn) return 99;
            return -1;
        }


        private void OPS_RowChanged(object sender, klonsDataSet.OPSRowChangeEvent e)
        {
            //Debug.Print("OPS_RowChanged {0} {1}", e.Action, e.Row.RowState);
            
            if (!detail_update_enabled) return;

            if (e.Action == DataRowAction.Add)
            {
                if (e.Row.OPSdRow != null)
                {
                    OPSd_CheckDocSums(e.Row.OPSdRow);
                }
            }
            if (e.Action == DataRowAction.Change)
            {
                OPSd_CheckDocSums(e.Row.OPSdRow);

                if (e.Row.OPSdRow != null && e.Row.RowState != DataRowState.Detached)
                {
                    e.Row.OPSdRow.ZDt = DateTime.Now;
                    e.Row.OPSdRow.ZU = MyData.CurrentUserName;
                }
            }

        }
        private klonsDataSet.OPSdRow last_Ops_RowDeleting_parent = null;
        private void Ops_RowDeleting(object sender, klonsDataSet.OPSRowChangeEvent e)
        {
            last_Ops_RowDeleting_parent = e.Row.OPSdRow;
        }

        private void OPS_RowDeleted(object sender, klonsDataSet.OPSRowChangeEvent e)
        {
            //Debug.Print("OPS_RowDeleted");
            if (!detail_update_enabled) return;
            klonsDataSet.OPSdRow dr = null;

            if (e.Row.HasVersion(DataRowVersion.Original))
            {
                int docid = (int)e.Row["DocId", DataRowVersion.Original];
                dr = MyData.DataSetKlons.OPSd.FindByid(docid);
            }
            else
            {
                dr = last_Ops_RowDeleting_parent;
            }
            if (dr == null) return;
            OPSd_CheckDocSums(dr);

            dr.ZDt = DateTime.Now;
            dr.ZU = MyData.CurrentUserName;
        }
        
        private void OPS_ColumnChenged(object sender, DataColumnChangeEventArgs e)
        {
            if (!detail_update_enabled) return;

            var dr = e.Row as klonsDataSet.OPSRow;
            if (dr == null) return;

            int cnr = Get_OPS_Col_Nr(e.Column);
            
            if (cnr == 99) return;

            dr.ZDt = DateTime.Now;

            if (cnr == 4 || cnr == 5)
            {
                CheckCurrencyA(dr);
                return;
            }

            if (cnr == 14 || cnr == 24 || cnr == 3)
            {
                CheckProduct(dr);
                return;
            }

            if (dr["AC11"] == DBNull.Value || dr["AC21"] == DBNull.Value) return;

            string sdeb = null, skred = null, sdnew, sknew;
            bool bdeb = false, bkred = false;
            char c1, c2;

            if (MyData.Params.UPRNP || MyData.Params.UPRIIN)
            {
                sdeb = AcPlanPz3(dr.AC11);
                skred = AcPlanPz3(dr.AC21);
                bdeb = IsKaBaCn(sdeb);
                bkred = IsKaBaCn(skred);
            }


            if (cnr == 11 || cnr == 21 || cnr == 12 || cnr == 22)
            {
                if (MyData.Params.UPRNP)
                {
                    if (bdeb || bkred)
                    {
                        c1 = dr.AC11[0];
                        c2 = dr.AC21[0];

                        if (dr.AC12 == null ||
                            (dr.AC11 != dr.AC12 &&
                             (
                                 bdeb
                                 || cnr == 11
                                 || c1 != '2' && c1 != '5'
                                 || dr.AC11 == "5731")
                                )
                            )
                        {
                            dr.AC12 = dr.AC11;
                        }

                        if (dr.AC22 == null ||
                            (dr.AC21 != dr.AC22 &&
                             (
                                 bkred
                                 || cnr == 21
                                 || c2 != '2' && c2 != '5'
                                 || dr.AC21 == "5731")
                                )
                            )
                        {
                            dr.AC22 = dr.AC21;
                        }
                    }
                    else
                    {
                        if (!dr.IsAC12Null())
                            dr.AC12 = null;
                        if (!dr.IsAC22Null())
                            dr.AC22 = null;
                    }
                }
            }

            if (cnr == 11 || cnr == 21 || cnr == 12 || cnr == 22  || cnr == 13 || cnr == 23)
            {    
                if (MyData.Params.UPRIIN)
                {
                    if (bdeb || bkred)
                    {
                        bool bien = MyData.Params.UPRIINIEN;
                        string sien = MyData.Params.UPRIINIENV;

                        bool bizd = MyData.Params.UPRIINIZD;
                        string sizd = MyData.Params.UPRIINIZDV;

                        c1 = dr.AC11[0];
                        c2 = dr.AC12 == null ? '!' : dr.AC12[0];

                        if (bdeb)
                        {
                            sdnew = sdeb;
                        }
                        else if (!string.IsNullOrEmpty(sdeb))
                        {
                            sdnew = sdeb;
                        }
                        else if (c1 == '6' || c2 == '6')
                        {
                            if (bien && !string.IsNullOrEmpty(sien))
                            {
                                sdnew = sien;
                            }
                            else
                            {
                                sdnew = "NIE";
                            }
                        }
                        else if (c1 == '7' || c2 == '7' || c2 == '8')
                        {
                            if (bizd && !string.IsNullOrEmpty(sizd))
                            {
                                sdnew = sizd;
                            }
                            else
                            {
                                sdnew = "NIZ";
                            }
                        }
                        else
                        {
                            sdnew = "CIZ";
                        }


                        c1 = dr.AC21[0];
                        c2 = dr.AC22 == null ? '!' : dr.AC22[0];

                        if (bkred)
                        {
                            sknew = skred;
                        }
                        else if (!string.IsNullOrEmpty(skred))
                        {
                            sknew = skred;
                        }
                        else if (c1 == '6' || c2 == '6' || c2 == '8')
                        {
                            if (bien && !string.IsNullOrEmpty(sien))
                            {
                                sknew = sien;
                            }
                            else
                            {
                                sknew = "NIE";
                            }
                        }
                        else if (c1 == '7' || c2 == '7')
                        {
                            if (bizd && !string.IsNullOrEmpty(sizd))
                            {
                                sknew = sizd;
                            }
                            else
                            {
                                sknew = "NIZ";
                            }
                        }
                        else
                        {
                            sknew = "CIE";
                        }


                        if (sdnew != dr.AC13)
                        {
                            if (bdeb || dr.AC13 == null ||
                                (cnr != 13 && cnr != 23))

                                dr.AC13 = sdnew;
                        }
                        if (sknew != dr.AC23)
                        {
                            if (bkred || dr.AC23 == null ||
                                (cnr != 13 && cnr != 23))

                                dr.AC23 = sknew;
                        }
                    }
                    else
                    {
                        if (!dr.IsAC13Null())
                            dr.AC13 = null;

                        if (!dr.IsAC23Null())
                            dr.AC23 = null;
                    }

                }
            }

            if (cnr == 11 || cnr == 21 || cnr == 12 || cnr == 22)
            {
                if (MyData.Params.UPRPVN)
                {
                    bool bpvnien = MyData.Params.UPRPVNIEN;
                    string spvnien = MyData.Params.UPRPVNIENV;

                    bool bpvnizd = MyData.Params.UPRPVNIZD;
                    string spvnizd = MyData.Params.UPRPVNIZDV;

                    bool bpvndeb = MyData.Params.UPRPVNDEB;
                    string spvndeb = MyData.Params.UPRPVNDEBV;

                    bool bpvnkred = MyData.Params.UPRPVNKRED;
                    string spvnkred = MyData.Params.UPRPVNKREDV;

                    bool bpvn5 = MyData.Params.UPRPVN5;
                    string spvn5 = MyData.Params.UPRPVN5V;

                    c1 = dr.AC11[0];
                    c2 = dr.AC21[0];

                    sdnew = null;
                    sknew = null;

                    if (bpvnien && !string.IsNullOrEmpty(spvnien))
                    {
                        if (c1 == '6') sdnew = spvnien;
                        if (c2 == '6') sknew = spvnien;
                    }

                    if (bpvnizd && !string.IsNullOrEmpty(spvnizd))
                    {
                        if (c1 == '7') sdnew = spvnizd;
                        if (c2 == '7') sknew = spvnizd;
                    }

                    if (bpvndeb && !string.IsNullOrEmpty(spvndeb))
                    {
                        if (dr.AC11 == "5731") sdnew = spvndeb;
                    }

                    if (bpvnkred && !string.IsNullOrEmpty(spvnkred))
                    {
                        if (dr.AC21 == "5731") sknew = spvnkred;
                    }

                    if (bpvn5 && !string.IsNullOrEmpty(spvn5))
                    {
                        if (dr.AC11 != "5731" && dr.AC12 == "5731") sdnew = spvn5;
                        if (dr.AC21 != "5731" && dr.AC22 == "5731") sknew = spvn5;
                    }

                    if (sdnew != dr.AC15)
                    {
                        if (dr.AC15 == null || (cnr != 15 && cnr != 25))
                            dr.AC15 = sdnew;
                    }

                    if (sknew != dr.AC25)
                    {
                        if (dr.AC25 == null || (cnr != 15 && cnr != 25))
                            dr.AC25 = sknew;
                    }
                }
            }
        }

        private bool CheckProduct(klonsDataSet.OPSRow dr)
        {
            if (dr == null) return false;
            string descr, ac14, ac24;
            decimal summ;
            decimal qv;
            bool ret = false;
            try
            {
                ac14 = dr.AC14;
                ac24 = dr.AC24;
                descr = dr.Descr;
                qv = (decimal)dr.QV;
                summ = dr.SummC;
            }
            catch (Exception)
            {
                MyMainForm.ShowWarning("Ievadīta nekorekta vērtība");
                return false;
            }

            if (string.IsNullOrEmpty(ac14)) ac14 = ac24;
            if (string.IsNullOrEmpty(ac14)) return false;
            if (qv == 0.00M) return false;

            var dr4 = MyData.GetAcP24Row(ac14);
            if (dr4 == null) return false;

            if (!dr4.IsPRICENull() && dr4.PRICE != 0.00M)
            {
                summ = Math.Round(qv * dr4.PRICE, 2);
                if (dr.SummC != summ)
                {
                    dr.SummC = summ;
                    ret = true;
                }
            }

            if (descr == null)
            {
                descr = dr4.Name;
            }

            descr = MyData.SetUnitInDescr(descr, dr4.UNIT);
            descr = descr.LeftMax(50);
            if (dr.Descr != descr)
            {
                dr.Descr = descr;
                ret = true;
            }

            return ret;
        }


        private bool OPSd_Enable_SetDocSums = true;
        private void OPSd_ColumnChenged(object sender, DataColumnChangeEventArgs e)
        {
            if (!detail_update_enabled) return;

            decimal sum, pvn;
            var dr = e.Row as klonsDataSet.OPSdRow;
            
            if (e.Column == MyData.DataSetKlons.OPSd.ZUColumn ||
                e.Column == MyData.DataSetKlons.OPSd.ZDtColumn)
            {
                return;
            }

            dr.ZDt = DateTime.Now;
            dr.ZU = MyData.CurrentUserName;

            if (e.Column == MyData.DataSetKlons.OPSd.idColumn)
            {
                var drv = bsOPSd.Current as DataRowView;
                if (drv == null) return;
                if(drv.Row == dr)
                    CheckOpsGrid();
                return;
            }

            if (e.Column != MyData.DataSetKlons.OPSd.DeteColumn)
            {
                OPSd_CheckDate(dr);
            }

            if (e.Column == MyData.DataSetKlons.OPSd.DeteColumn)
            {
                bool b11 = OPSd_Enable_SetDocSums;
                OPSd_Enable_SetDocSums = false;
                CheckCurrencyB(dr);
                OPSd_CheckDocSums(dr);
                OPSd_Enable_SetDocSums = b11;
            }

            if (e.Column == MyData.DataSetKlons.OPSd.SummColumn)
            {
                try { var sm = dr.Summ; }
                catch (Exception) { return; }
                if (OPSd_Enable_SetDocSums)
                {
                    OPSd_Enable_SetDocSums = false;
                    SetDocSums1(dr, dr.Summ, dr.Dete);
                    SetDocSums3(dr, dr.Summ, dr.Dete);
                    SetDocSums4(dr, dr.Summ, dr.Dete);
                    GetDocSums2(dr, out sum, out pvn);
                    if (dr.Summ != sum) dr.Summ = sum;
                    if (dr.PVN != pvn) dr.PVN = pvn;
                    OPSd_Enable_SetDocSums = true;
                }
            }
            else if (e.Column == MyData.DataSetKlons.OPSd.PVNColumn)
            {
                try { var sm = dr.PVN; }
                catch (Exception) { return; }
                if (OPSd_Enable_SetDocSums)
                {
                    OPSd_Enable_SetDocSums = false;
                    SetDocSums2(dr, dr.Summ, dr.PVN);
                    GetDocSums2(dr, out sum, out pvn);
                    if (dr.Summ != sum) dr.Summ = sum;
                    if (dr.PVN != pvn) dr.PVN = pvn;
                    OPSd_Enable_SetDocSums = true;
                }
            }
        }

        private void OPSd_RowChanged(object sender, klonsDataSet.OPSdRowChangeEvent e)
        {
            //Debug.Print("OPSd_RowChanged {0}", e.Action);
            
            if (!detail_update_enabled) return;

            if (e.Action == DataRowAction.Change)
            {
                OPSd_CheckDocSums(e.Row);
            }
        }

        private void OPSd_CheckDocSums(klonsDataSet.OPSdRow docrow)
        {
            if (docrow == null) return;
            decimal sum, pvn;
            GetDocSums2(docrow, out sum, out pvn);
            bool b = OPSd_Enable_SetDocSums;
            OPSd_Enable_SetDocSums = false;
            if (docrow.Summ != sum) docrow.Summ = sum;
            if (docrow.PVN != pvn) docrow.PVN = pvn;
            OPSd_Enable_SetDocSums = b;
        }

        private void OPSd_CheckDate(klonsDataSet.OPSdRow docrow)
        {
            object o = docrow["Dete"];
            if (o == null || o == DBNull.Value)
            {
                if (lastDate == DateTime.MinValue)
                    lastDate = DateTime.Today;
                docrow.Dete = lastDate;
            }
        }

        private void CheckCurrencyB(klonsDataSet.OPSdRow dr)
        {
            if (dr == null) return;
            var drs = dr.GetOPSRows();
            if (drs == null || drs.Length == 0) return;
            foreach (var dr1 in drs)
            {
                CheckCurrencyA(dr1);
            }
        }

        private bool CheckCurrencyA(klonsDataSet.OPSRow dr)
        {
            if (dr == null) return false;

            decimal rate;

            if (string.IsNullOrEmpty(dr["Cur"].AsString()))
            {
                dr.Cur = "EUR";
                dr.Summ = dr.SummC;
                dr.ZDt = DateTime.Now;
                return true;
            }

            if (dr.OPSdRow == null || dr.OPSdRow["Dete"] == DBNull.Value)
            {
                rate = -1.0M;
            }
            else
            {
                rate = GetCurrencyRate(dr.Cur, dr.OPSdRow.Dete);
            }

            if (rate == -1.0M)
            {
                dr.Cur = "EUR";
                dr.Summ = dr.SummC;
                dr.ZDt = DateTime.Now;
                return true;
            }

            dr.Summ = Math.Round(dr.SummC * rate, 2);
            dr.ZDt = DateTime.Now;
            return true;
        }


        private void SetDocSums1(klonsDataSet.OPSdRow docrow
            , decimal sum, DateTime date)
        {
            if (docrow == null) return;
            klonsDataSet.OPSRow dr;

            var opsrows = docrow.GetOPSRows();
            if (opsrows == null || opsrows.Length == 0 || opsrows.Length > 2) return;

            if (opsrows.Length == 1)
            {
                dr = opsrows[0];
                dr.SummC = sum;
                return;
            }

            int k1 = -1;
            int k2 = -1;

            for (int i = 0; i < 2; i++)
            {
                dr = opsrows[i];

                if (IsPVNx(dr.AC15, dr.AC25))
                {
                    if (k1 > -1) return;
                    k1 = i;
                }
            }
            if (k1 == -1) return;

            k2 = k1 == 0 ? 1 : 0;

            decimal dpvn = 0.0M;
            decimal dsum = 0.0M;

            dr = opsrows[k1];

            decimal t = GetPVNRateAX(dr.AC15, dr.AC25, date);
            if (t == 0) return;

            if (IsGoodPVNx(dr.AC15, dr.AC25))
            {
                dsum = Math.Round(sum / (1.0M + t / 100.0M), 2);
                dpvn = sum - dsum;
            }
            else
            {
                dpvn = Math.Round(sum * (t / 100.0M), 2);
                dsum = sum;
            }

            dr.SummC = dpvn;

            dr = opsrows[k2];

            dr.SummC = dsum;
        }

        private void SetDocSums2(klonsDataSet.OPSdRow docrow
            , decimal sum, decimal pvn)
        {
            if (docrow == null) return;

            klonsDataSet.OPSRow dr;

            DateTime date = docrow.Dete;
            var opsrows = docrow.GetOPSRows();
            if (opsrows.Length == 0 || opsrows.Length > 2) return;

            if (opsrows.Length == 1)
            {
                dr = opsrows[0];
                dr.SummC = sum;
                return;
            }

            int k1 = -1;
            int k2 = -1;

            for (int i = 0; i < 2; i++)
            {
                dr = opsrows[i];

                if (IsPVNx(dr.AC15, dr.AC25))
                {
                    if (k1 > -1) return;
                    k1 = i;
                }
            }
            if (k1 == -1) return;

            k2 = k1 == 0 ? 1 : 0;

            dr = opsrows[k1];

            dr.SummC = pvn;

            if (IsGoodPVNx(dr.AC15, dr.AC25))
                sum -= pvn;

            dr = opsrows[k2];

            dr.SummC = sum;
        }

        private void SetDocSums3(klonsDataSet.OPSdRow docrow
            , decimal sum, DateTime date)
        {
            if (docrow == null) return;
            klonsDataSet.OPSRow dr;

            var opsrows = docrow.GetOPSRows();
            if (opsrows == null || opsrows.Length != 3) return;

            int kpvn = -1;
            int ksum = -1;
            int ksum0 = -1;

            for (int i = 0; i < 3; i++)
            {
                dr = opsrows[i];

                if (IsPVNx(dr.AC15, dr.AC25))
                {
                    if (kpvn > -1) return;
                    kpvn = i;
                }
            }
            if (kpvn == -1) return;

            for (int i = 0; i < 3; i++)
            {
                dr = opsrows[i];

                if (dr.AC15 == "0" && dr.AC25.IsNOE() ||
                    dr.AC15.IsNOE() && dr.AC25 == "0")
                {
                    if (ksum0 > -1) return;
                    ksum0 = i;
                }
            }
            if (ksum0 == -1) return;

            for(int i = 0; i < 3; i++)
            {
                if (i != kpvn && i != ksum0)
                {
                    ksum = i;
                    break;
                }
            }

            decimal dpvn = 0.0M;
            decimal dsum = 0.0M;
            decimal dsum0 = 0.0M;

            dr = opsrows[kpvn];

            decimal t = GetPVNRateAX(dr.AC15, dr.AC25, date);
            if (t == 0) return;

            if (IsGoodPVNx(dr.AC15, dr.AC25))
            {
                dsum0 = Math.Round(sum * 0.5M, 2);
                dsum = sum - dsum0;
                dsum = Math.Round(dsum / (1.0M + t / 100.0M), 2);
                dpvn = sum - dsum0 - dsum;
            }
            else
            {
                return;
            }

            dr.SummC = dpvn;

            dr = opsrows[ksum];
            dr.SummC = dsum;

            dr = opsrows[ksum0];
            dr.SummC = dsum0;
        }

        private void SetDocSums4(klonsDataSet.OPSdRow docrow
            , decimal sum, DateTime date)
        {
            if (docrow == null) return;
            klonsDataSet.OPSRow dr;

            var opsrows = docrow.GetOPSRows();
            if (opsrows == null || opsrows.Length != 2) return;

            var dr1 = opsrows[0];
            var dr2 = opsrows[1];

            if (dr1.AC11 != dr2.AC11) return;
            if (!dr1.AC11.StartsWith("7")) return;
            if (dr1.AC13.IsNOE() || dr2.AC13.IsNOE()) return;
            if (!dr1.AC15.IsNOE() != !dr1.AC25.IsNOE()) return;
            if (!dr2.AC15.IsNOE() != !dr2.AC25.IsNOE()) return;

            decimal dsum1 = Math.Round(sum * 0.5M, 2);
            decimal dsum2 = sum - dsum1;
            dr1.SummC = dsum1;
            dr2.SummC = dsum2;
        }


        private void dgvDocs_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsFormClosing && warnAfterValidation != null)
            {
                MyMainForm.ShowWarning(warnAfterValidation);
                warnAfterValidation = null;
            }
        }

        private void dgvOps_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsFormClosing && warnAfterValidation != null)
            {
                MyMainForm.ShowWarning(warnAfterValidation);
                warnAfterValidation = null;
            }
        }

        private void dgvDocs_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (lastDate == DateTime.MinValue)
                lastDate = DateTime.Today;

            e.Row.Cells[dgcDocsDate.Index].Value = lastDate;
            e.Row.Cells[dgcDocsZU.Index].Value = MyData.CurrentUserName;
            e.Row.Cells[dgcDocsZDt.Index].Value = DateTime.Now;
        }

        private void dgvDocsGetCellValue(object sender, int colind)
        {
            Action<string> act =
                value =>
                {
                    try
                    {
                        if (value != null && dgvDocs.CurrentCell != null)
                        {
                            /*
                            dgvDocs.EndEdit();
                            var dr = dgvDocs.GetCurrentDataRow() as klonsDataSet.OPSdRow;
                            if (dr != null)
                            {
                                if (dgvDocs.CurrentCell.ColumnIndex == dgcDocsClid.Index)
                                {
                                    dr.ClId = value;
                                }
                                else if (dgvDocs.CurrentCell.ColumnIndex == dgcDocsClid2.Index)
                                {
                                    dr.ClId2 = value;
                                }
                                else if (dgvDocs.CurrentCell.ColumnIndex == dgcDocsDocTyp.Index)
                                {
                                    dr.DocTyp = value;
                                }
                            }
                            dgvDocs.RefreshCurrent();
                             */
                            
                            dgvDocs.BeginEdit(false);
                            dgvDocs.EditingControl.Text = value;
                            dgvDocs.EndEdit();
                            
                        }
                        dgvDocs.Select();
                        if (dgvDocs.EditingControl != null)
                            ActiveControl = dgvDocs.EditingControl;
                    }
                    finally
                    {
                        dgvDocs.GoingToDialog = false;
                    }
                };
            if (colind == dgcDocsClid.Index
                || colind == dgcDocsClid2.Index)
            {
                dgvDocs.GoingToDialog = true;
                MyMainForm.ShowFormPersonsDialog(act);
                return;
            }

            if (colind == dgcDocsDocTyp.Index)
            {
                dgvDocs.GoingToDialog = true;
                MyMainForm.ShowFormDocTypDialog(act);
            }
        }

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDocsGetCellValue(sender, e.ColumnIndex);
        }

        private void dgvOpsGetCellValue(object sender, int colind)
        {
            Action<string> act =
                value =>
                {
                    try
                    {
                        if (value != null && dgvOps.CurrentCell != null)
                        {
                            dgvOps.BeginEdit(false);
                            dgvOps.EditingControl.Text = value;
                            dgvOps.EndEdit();
                        }

                        dgvOps.Select();
                        if (dgvOps.EditingControl != null)
                            ActiveControl = dgvOps.EditingControl;
                    }
                    finally
                    {
                        dgvOps.GoingToDialog = false;
                        //this.AutoValidate = AutoValidate.EnablePreventFocusChange;
                    }
                };
            if (colind == dgcOpsAC11.Index
                || colind == dgcOpsAC12.Index
                || colind == dgcOpsAC21.Index
                || colind == dgcOpsAC22.Index)
            {
                dgvOps.GoingToDialog = true;
                //this.AutoValidate = AutoValidate.Disable;
                MyMainForm.ShowFormAcplanDialog(act);
                return;
            }

            if (colind == dgcOpsAC13.Index
                || colind == dgcOpsAC23.Index)
            {
                dgvOps.GoingToDialog = true;
                MyMainForm.ShowFormAcp3Dialog(act);
                return;
            }

            if (colind == dgcOpsAC14.Index
                || colind == dgcOpsAC24.Index)
            {
                dgvOps.GoingToDialog = true;
                MyMainForm.ShowFormAcp4Dialog(act);
                return;
            }

            if (colind == dgcOpsAC15.Index
                || colind == dgcOpsAC25.Index)
            {
                dgvOps.GoingToDialog = true;
                MyMainForm.ShowFormAcp5Dialog(act);
                return;
            }
        }

        private void dgvOps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvOpsGetCellValue(sender, e.ColumnIndex);
        }

        private string AcPlanPz3(string ac)
        {
            klonsDataSet.AcP21Row dr = MyData.DataSetKlons.AcP21.FindByAC(ac);
            if (dr == null) return null;
            return dr.id1;
        }

        private int AcPVNPz3(string id)
        {
            klonsDataSet.AcPVNRow dr = MyData.DataSetKlons.AcPVN.FindByid(id);
            if (dr == null) return -1;
            return dr.pz3;
        }

        private bool IsKaBaCn(string acp3)
        {
            if (string.IsNullOrEmpty(acp3)) return false;
            return acp3 == "KA" || acp3 == "BA" || acp3 == "CN";
        }

        private decimal GetCurrencyRate(string curr, DateTime date)
        {
            if (string.Compare(curr, "EUR", true) == 0)
            {
                return 1.0M;
            }
            
            var dr = MyData.DataSetKlons.Currency.FindByidDete(curr, date);
            if (dr != null)
            {
                return dr.rate;
            }
            decimal rate = 1.0M;
            string s = string.Format(
                "Jāievada valūtas [{0}] kurs datumam [{1}]",
                curr, Utils.DateToString(date));
            Form_InputBox f = new Form_InputBox("", s, "1.0000");
            if (f.ShowDialog(MyMainForm) == DialogResult.OK)
            {
                if (decimal.TryParse(f.SelectedValue, out rate))
                {
                    MyData.DataSetKlons.Currency.AddCurrencyRow(curr, date, rate);
                    var ad = MyData.GetSqlDataAdapter(MyData.DataSetKlons.Currency);
                    try
                    {
                        ad.Update(MyData.DataSetKlons.Currency);
                        return rate;
                    }
                    catch (Exception e)
                    {
                        MyException e1 = new MyException("Neizdevās saglabāt valūtas kursu", e);
                        Form_Error.ShowException(MyMainForm, e1);
                    }
                }
            }
            return -1.0M;
        }

        private DateTime GetOpsGridRowDate(DataGridViewRow dgvr)
        {
            var dr = GetDataGridRowObject(dgvr) as klonsDataSet.OPSRow;
            if (dr == null) throw new Exception("Bad DataGridViewRow");
            return dr.OPSdRow.Dete;
        }

        private void dgvOps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOps_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int ci = e.ColumnIndex;
            int ri = e.RowIndex;
            if (ri == -1 || ci == -1) return;

            dgvOps.InvalidateRow(ri);

            //Debug.Print("dgvOps_CellEndEdit: {1}-{0}", dgvOps.Columns[ci].Name, ri);
        }

        private void dgvOps_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            warnAfterValidation = null;

            int ri = e.RowIndex;
            if (ri < 0 || ri == dgvOps.NewRowIndex) return;
            if (ri != dgvOps.CurrentRow.Index || !dgvOps.IsCurrentRowDirty) return;

            var dr = dgvOps.GetDataRow(ri) as klonsDataSet.OPSRow;
            if (dr == null) return;

            //Debug.Print("dgvOps_RowValidating");

            if (dr["AC11"] == DBNull.Value || dr["AC21"] == DBNull.Value)
            {
                MyMainForm.ShowError("Jānorāda Kontējuma debets un kredīts.");
                e.Cancel = true;
                return;
            }

            string sdeb = null, skred = null;
            bool bdeb = false, bkred = false;
            char c1, c2;

            StringBuilder sb = new StringBuilder();

            if (MyData.Params.UPRNP || MyData.Params.UPRIIN)
            {
                sdeb = AcPlanPz3(dr.AC11);
                skred = AcPlanPz3(dr.AC21);
                bdeb = IsKaBaCn(sdeb);
                bkred = IsKaBaCn(skred);
            }

            if (MyData.Params.UPRNP)
            {
                if (bdeb || bkred)
                {
                    if (dr.AC12 == null || dr.AC22 == null)
                    {
                        MyMainForm.ShowError("Kontējuma 2. pazīmei jābūt aizpildītai.");
                        e.Cancel = true;
                        return;
                    }
                }
            }


            if (MyData.Params.UPRIIN)
            {
                if (bdeb || bkred)
                {

                    c1 = dr.AC11[0];
                    c2 = dr.AC12 == null ? '!' : dr.AC12[0];

                    if (dr.AC13 == null || dr.AC23 == null)
                    {
                        MyMainForm.ShowError("Kontējuma 3. pazīmei jābūt aizpildītai.");
                        e.Cancel = true;
                        return;
                    }

                    if ((!bdeb && IsKaBaCn(dr.AC13))
                        || (!bkred && IsKaBaCn(dr.AC23)))
                    {
                        MyMainForm.ShowError("Kontējuma 3. pazīme nevar būt KA,BA,CA.");
                        e.Cancel = true;
                        return;
                    }

                    if (!string.IsNullOrEmpty(sdeb) && sdeb != dr.AC13)
                    {
                        sb.AppendLine("Vai debete 3. pazīmei nevajadzētu būt [" + sdeb + "]");
                        sb.AppendLine();
                    }

                    if (c1 == '6' || c2 == '6')
                    {
                        if ("LIENIESUB".IndexOf(dr.AC13) == -1)
                        {
                            sb.AppendLine("Vai debete 3. pazīmei nevajadzētu būt LIE, NIE");
                            sb.AppendLine();
                        }
                    }
                    else if (c1 == '7' || c2 == '7' || c1 == '8' || c2 == '8')
                    {
                        if ("LIZ1NIZ1PIZDIZMIZ".IndexOf(dr.AC13) == -1)
                        {
                            sb.AppendLine("Vai debete 3. pazīmei nevajadzētu būt LIZ, LIZ1, NIZ, NIZ1, PIZ");
                            sb.AppendLine();
                        }
                    }


                    c1 = dr.AC21[0];
                    c2 = dr.AC22 == null ? '!' : dr.AC22[0];

                    if (!string.IsNullOrEmpty(skred) && skred != dr.AC23)
                    {
                        sb.AppendLine("Vai kredīta 3. pazīmei nevajadzētu būt [" + skred + "]");
                        sb.AppendLine();
                    }

                    if (c1 == '6' || c1 == '8' || c2 == '6' || c2 == '8')
                    {
                        if ("LIENIESUB".IndexOf(dr.AC23) == -1)
                        {
                            sb.AppendLine("Vai kredīta 3. pazīmei nevajadzētu būt LIE, NIE");
                            sb.AppendLine();
                        }
                    }
                    else if (c1 == '7' || c2 == '7')
                    {
                        if ("LIZ1NIZ1PIZDIZMIZ".IndexOf(dr.AC23) == -1)
                        {
                            sb.AppendLine("Vai kredīta 3. pazīmei nevajadzētu būt LIZ, LIZ1, NIZ, NIZ1, PIZ");
                            sb.AppendLine();
                        }

                    }

                }

            }


            if (MyData.Params.UPRPVN)
            {
                bool bpvnreqpvn = MyData.Params.UPRPVNREQPVN;
                bool bpvnreqien = MyData.Params.UPRPVNREQIEN;

                bool bpvn5 = MyData.Params.UPRPVN5;
                string spvn5 = MyData.Params.UPRPVN5V;

                int dp3 = dr.AC15 != null ? AcPVNPz3(dr.AC15) : -1;
                int kp3 = dr.AC25 != null ? AcPVNPz3(dr.AC25) : -1;

                c1 = dr.AC11[0];
                c2 = dr.AC21[0];

                if (bpvnreqpvn && dr.AC11 == "5731" && dr.AC15 != "0"
                    && (dp3 == -1 || MyData.IsIenemumiA(dp3)))
                {
                    MyMainForm.ShowError("Debeta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvnreqpvn && dr.AC21 == "5731" && dr.AC25 != "0"
                    && (kp3 == -1 || MyData.IsIenemumiA(kp3)))
                {
                    MyMainForm.ShowError("Kredīta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvnreqien && c1 == '6' && dr.AC15 != "0"
                    && !MyData.IsIenemumiA(dp3))
                {
                    MyMainForm.ShowError("Debeta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvnreqpvn && c2 == '6' && dr.AC25 != "0"
                    && !MyData.IsIenemumiA(kp3))
                {
                    MyMainForm.ShowError("Kredīta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvn5 && dr.AC12 == "5731" && dr.AC15 != "0"
                    && (dp3 == -1 || MyData.IsIenemumiA(dp3)))
                {
                    MyMainForm.ShowError("Debeta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvn5 && dr.AC22 == "5731" && dr.AC25 != "0"
                    && (kp3 == -1 || MyData.IsIenemumiA(kp3)))
                {
                    MyMainForm.ShowError("Kredīta PVN pazīme nepareiza.");
                    e.Cancel = true;
                    return;
                }

                if (bpvn5 && dr.AC11 != "5731" && dr.AC12 == "5731" &&
                    dr.AC15 != "0" && !(dp3 == 9 || dp3 == 10))
                {
                    sb.AppendLine("Vai debeta PVN pazīmei nevajadzētu būt 5xx, Axx");
                    sb.AppendLine();
                }

                if (bpvn5 && dr.AC21 != "5731" && dr.AC22 == "5731" &&
                    dr.AC25 != "0" && !(kp3 == 9 || kp3 == 10))
                {
                    sb.AppendLine("Vai kredīta PVN pazīmei nevajadzētu būt 5xx, Axx");
                    sb.AppendLine();
                }
            }

            if (sb.Length != 0)
            {
                warnAfterValidation = sb.ToString();
                //MyMainForm.ShowWarning(sb.ToString());
            }

        }

        private void toolStripButtonInfo_Click(object sender, EventArgs e)
        {
            if (!dgvDocs.EndEdit()) return;
            if (!dgvOps.EndEdit()) return;
            string s1 = bsOPSd.GetStats();
            string s2 = bsOPS.GetStats();
            if (s1 == null || s2 == null) return;
            MyMainForm.ShowWarning("Nesaglabātie ieraksti\n  dokumenti: "
                + s1 + "\n  kontējumi: " + s2);
        }

        private bool AskCanDeleteDoc()
        {
            if (!MyData.Params.AskBeforeDelete) return true;
            DialogResult response = MyMessageBox.Show("Vai dzēst dokumentu?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MyMainForm);

            return response == DialogResult.Yes;
        }

        private bool AskCanDeleteOp()
        {
            if (!MyData.Params.AskBeforeDelete) return true;
            DialogResult response = MyMessageBox.Show("Vai dzēst ierakstu?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2,
                MyMainForm);

            return response == DialogResult.Yes;
        }

        private void dgvDocs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if (!AskCanDeleteDoc()) e.Cancel = true;
            }
        }

        private void dgvOps_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                if (!AskCanDeleteOp()) e.Cancel = true;
            }
        }

        private void bnavNav_ItemDeleting(object sender, CancelEventArgs e)
        {
            if (bnavNav.BindingSource == bsOPSd)
            {
                if (!AskCanDeleteDoc()) e.Cancel = true;
                return;
            }
            if (bnavNav.BindingSource == bsOPS)
            {
                if (!AskCanDeleteOp()) e.Cancel = true;
                return;
            }
        }

        private void dgvDocs_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsOPSd;
            bnavNav.DataGrid = dgvDocs;
            toolStripLabel1.Text = "Dokumenti:";
        }

        private void dgvOps_Enter(object sender, EventArgs e)
        {
            bnavNav.BindingSource = bsOPS;
            bnavNav.DataGrid = dgvOps;
            toolStripLabel1.Text = "Ieraksti:";
        }

        private void CopyOpsRow()
        {
            if (dgvOps.CurrentCell == null || dgvOps.CurrentRow == null) return;
            if (dgvOps.CurrentRow.IsNewRow || dgvOps.IsCurrentCellDirty) return;
            if (!dgvOps.EndEditX()) return;

            if (dgvOps.CurrentRow == null || dgvOps.CurrentRow.IsNewRow) return;

            bsOPS.CopyCurrent();

        }

        private void CopyDocsRow()
        {
            if (dgvDocs.CurrentCell == null) return;
            if (dgvDocs.CurrentRow == null) return;
            if (dgvDocs.CurrentRow.IsNewRow) return;
            if (dgvDocs.IsCurrentCellDirty) return;
            if (!dgvDocs.EndEdit()) return;
            if (!dgvDocs.EndEditX()) return;

            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;

            var dr = bsOPSd.CopyCurrent(0) as klonsDataSet.OPSdRow;
            if (dr == null) return;

            dgvDocs.CurrentCell = dgvDocs.CurrentRow.Cells[dgcDocsDate.Index];
            if (lastDate != DateTime.MinValue)
            {
                //dgvDocs.BeginEdit(false);
                //dgvDocs.CurrentRow.Cells[dgcDocsDate.Index].Value = lastDate;
                //dgvDocs.EndEdit();
                dr.Dete = lastDate;
                dgvDocs.InvalidateCell(dgcDocsDate.Index, dgvDocs.CurrentRow.Index);
                //dgvDocs.RefreshCurrent();
            }
            //dgvDocs.InvalidateCell(dgcDocsNrx.Index, dgvDocs.CurrentRow.Index);
            CheckOpsGrid();
        }

        private void ToolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (bnavNav.BindingSource == bsOPSd)
                CopyDocsRow();
            if (bnavNav.BindingSource == bsOPS)
                CopyOpsRow();
        }

        private void dgvOps_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvOps.CurrentCell == null) return;
            if (e.KeyCode == Keys.F5)
            {
                dgvOpsGetCellValue(sender, dgvOps.CurrentCell.ColumnIndex);
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                if(!dgvOps.EndEdit()) return;
                if (dgvOps.CurrentRow != null && !dgvOps.CurrentRow.IsNewRow)
                {
                    bnavNav.DeleteCurrent();
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvOps.EndEdit()) return;
                dgvOps.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Control)
            {
                CopyOpsRow();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                dgvDocs.Select();
                e.Handled = true;
                return;
            }

        }

        private void dgvDocs_MyKeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDocs.CurrentCell == null) return;
            if (e.KeyCode == Keys.F3)
            {
                if (tsbSearch.Text == "")
                {
                    tsbSearch.Focus();
                    e.Handled = true;
                    return;
                }
                if (e.Shift)
                {
                    SearchText(false, false);
                }
                else
                {
                    SearchText(false, true);
                }
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.F5)
            {
                dgvDocsGetCellValue(sender, dgvDocs.CurrentCell.ColumnIndex);
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Delete && e.Control)
            {
                if (!dgvDocs.EndEdit()) return;
                if (dgvDocs.CurrentRow != null && !dgvDocs.CurrentRow.IsNewRow)
                {
                    bnavNav.DeleteCurrent();
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Shift)
            {
                if (!dgvDocs.EndEdit()) return;
                dgvDocs.MoveToNewRow();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Insert && e.Control)
            {
                CopyDocsRow();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                dgvOps.Select();
                e.Handled = true;
                return;
            }

        }

        private bool IsPVNx(string dac5, string kac5)
        {
            return MyData.IsPVN(dac5) || MyData.IsPVN(kac5);
        }

        private bool IsGoodPVNx(string dac5, string kac5)
        {
            return MyData.IsGoodPVN(dac5) || MyData.IsGoodPVN(kac5);
        }

        private int GetPVNRateAX(string dac5, string kac5, DateTime date)
        {
            int k = MyData.GetPVNRateA(dac5, date);
            if (k > 0) return k;
            return MyData.GetPVNRateA(kac5, date);
        }

        private bool GetDocSums2(klonsDataSet.OPSdRow docrow
            , out decimal sum, out decimal pvn)
        {
            sum = 0.0M;
            pvn = 0.0M;
            
            if (docrow == null) return false;
            var opsrows = docrow.GetOPSRows();
            if (opsrows == null || opsrows.Length == 0) return false;
            
            klonsDataSet.OPSRow dr;

            for (int i = 0; i < opsrows.Length; i++)
            {
                dr = opsrows[i];
                if (IsPVNx(dr.AC15, dr.AC25))
                {
                    pvn += dr.Summ;
                    if (IsGoodPVNx(dr.AC15, dr.AC25))
                    {
                        sum += dr.Summ;
                    }
                }
                else
                {
                    sum += dr.Summ;
                }
            }
            return true;
        }

        public DataRow GetDataGridRowObject(DataGridViewRow dgr)
        {
            if (dgr == null || dgr.IsNewRow) return null;
            try
            {
                object o = dgr.DataBoundItem;
                if (o == null) return null;
                var drv = o as DataRowView;
                if (drv == null) return null;
                return drv.Row;
            }
            catch (Exception)
            {
                
            }
            return null;
        }

        private void dgvDocs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDocs_CellEndEdit_A(e);
            }
            catch (Exception) { }
        }

        private void dgvDocs_CellEndEdit_A(DataGridViewCellEventArgs e)
        {
            string collname = e.ColumnIndex == -1 ? "" : dgvDocs.Columns[e.ColumnIndex].Name;
            //Debug.Print("dgvDocs_CellEndEdit {0} {1}", e.RowIndex, collname);
            //bsOPSd.ResetBindings(false);
            if (e.ColumnIndex == dgcDocsSumm.Index ||
                e.ColumnIndex == dgcDocsPVN.Index)
            {
                dgvDocs.EndEditX();
            }
        }

        private DateTime lastDate = DateTime.MinValue;


        private void dgvDocs_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

            if (e.ColumnIndex == dgcDocsDate.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                if (!(e.Value is string)) return;
                string s = (string) e.Value;
                if (string.IsNullOrEmpty(s)) return;
                DateTime dt;
                if (Utils.StringToDate(s, out dt))
                {
                    e.Value = dt;
                    lastDate = dt;
                    e.ParsingApplied = true;
                    return;
                }

                if (lastDate == DateTime.MinValue) return;

                string[] ss = s.Split('.');
                if (ss.Length > 2) return;

                int dd, mm = -1;

                if (!int.TryParse(ss[0], out dd)) return;
                if (ss.Length == 1)
                {
                    try
                    {
                        dt = new DateTime(lastDate.Year, lastDate.Month, dd);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    e.Value = dt;
                    lastDate = dt;
                    e.ParsingApplied = true;
                    return;
                }

                if (!int.TryParse(ss[1], out mm)) return;
                try
                {
                    dt = new DateTime(lastDate.Year, mm, dd);
                }
                catch (Exception)
                {
                    return;
                }
                e.Value = dt;
                lastDate = dt;
                e.ParsingApplied = true;
                return;
            }
            if (e.ColumnIndex == dgcDocsDT2.Index)
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                if (!(e.Value is string)) return;
                string s = (string) e.Value;
                if (string.IsNullOrEmpty(s)) return;
                DateTime dt;
                if (Utils.StringToDate(s, out dt))
                {
                    e.Value = dt;
                    e.ParsingApplied = true;
                    return;
                }

            }
        }

        private void tsbIeraksti_Click(object sender, EventArgs e)
        {
            if (!dgvDocs.EndEditX() || !dgvOps.EndEditX()) return;
            if (!SaveData()) return;
            MyMainForm.ShowFormOPSFilter();
        }

        private void tbsRefresh_Click(object sender, EventArgs e)
        {
            if (!dgvDocs.EndEditX() || !dgvOps.EndEditX()) return;
            if (!SaveData()) return;
            try
            {
                EnableDetailUpdate(false);
                FillDocsByParams();
            }
            finally
            {
                EnableDetailUpdate(true);
            }
        }

        private void dgvOps_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == dgvOps.NewRowIndex || e.ColumnIndex == -1) return;
            var o = dgvOps[e.ColumnIndex, e.RowIndex].Value;
            if (o == null || o == DBNull.Value) return;
            string s = o.ToString();
            if (string.IsNullOrEmpty(s)) return;
            if (e.ColumnIndex == dgcOpsAC11.Index ||
                e.ColumnIndex == dgcOpsAC12.Index ||
                e.ColumnIndex == dgcOpsAC21.Index ||
                e.ColumnIndex == dgcOpsAC22.Index)
            {
                e.ToolTipText = MyData.GetAcName(s);
                return;
            }
            if (e.ColumnIndex == dgcOpsAC13.Index ||
                e.ColumnIndex == dgcOpsAC23.Index)
            {
                e.ToolTipText = MyData.GetAc3Name(s);
                return;
            }
            if (e.ColumnIndex == dgcOpsAC14.Index ||
                e.ColumnIndex == dgcOpsAC24.Index)
            {
                e.ToolTipText = MyData.GetAc4Name(s);
                return;
            }
            if (e.ColumnIndex == dgcOpsAC15.Index ||
                e.ColumnIndex == dgcOpsAC25.Index)
            {
                e.ToolTipText = MyData.GetAc5Name(s);
                return;
            }

        }

        private void FormDocs_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveColumnWidthsToSettings();
            if (!SaveData())
            {
                MyMainForm.ShowWarning("Logs tiks aizvērt, bet\ndatos bija kļūda.");
                //e.Cancel = true;
                return;
            }
        }

        private void dgvDocs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            warnAfterValidation = null;
        }

        private void dgvOps_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            warnAfterValidation = null;
        }

        private void DoKasesOrderis(int reportid)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;
            if (bsOPSd.SaveCurrentItem() == EBsSaveResult.Error) return;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            
            int did = (int)dgvDocs.CurrentRow.Cells[dgcDocsId.Index].Value;
            ROps1aTableAdapter ad1 = MyData.GetKlonsRepAdapter("ROps1a") as ROps1aTableAdapter;
            ReportViewerData rd = new ReportViewerData();

            if (!MyData.ReportHelper.CheckForErrors(() =>
            {
                ad1.FillBy_kieo_1(MyData.DataSetKlonsRep.ROps1a, did);
            })) return;
            
            MyData.ReportHelper.PrepareRops1aForKO();

            switch (reportid)
            {
                case 0:
                    rd.FileName = "Report_KIEO_1";
                    break;
                case 1:
                    rd.FileName = "Report_KIZO_1";
                    break;
                case 2:
                    rd.FileName = "Report_KIEOkv_1";
                    break;
                case 3:
                    rd.FileName = "Report_KIZOkv_1";
                    break;
            }
            rd.Sources["DataSet1"] = MyData.DataSetKlonsRep.ROps1a;
            rd.AddReportParameters(
                new string[]
                {
                    "RCOMPNAME", MyData.Params.CompName,
                    "RREGNR", MyData.Params.CompRegNr,
                    "RPVNREGNR", MyData.Params.CompPhone
                });

            MyMainForm.ShowReport(rd);
        }

        private void kasesIeņēmumuOrderisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoKasesOrderis(0);
        }

        private void kasesIzdevumuOrderisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoKasesOrderis(1);
        }

        private void kasesIeņēmumuOrderaKvītsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoKasesOrderis(2);
        }

        private void kasesIzdevumuOrderaKvītsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoKasesOrderis(3);
        }

        private void DoLinkedDocs()
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (dgvDocs.IsCurrentCellDirty)
            {
                if(!dgvDocs.EndEdit()) return;
            }
            if (dgvDocs.CurrentRow == null) return;
            if (bsOPS.Count == 0)
            {
                MyMainForm.ShowInfo("Dokumentam nav kontējumu.");
                return;
            }
            string clid = dgvDocs.CurrentRow.Cells[dgcDocsClid.Index].Value.AsString();
            string docsr = dgvDocs.CurrentRow.Cells[dgcDocsDocSt.Index].Value.AsString().Zn();
            string docnr = dgvDocs.CurrentRow.Cells[dgcDocsDocNr.Index].Value.AsString().Zn();
            if (clid == null)
            {
                MyMainForm.ShowInfo("Jāievada dokumenta numurs un persona.");
                return;
            }
            
            Form_LinkedDocs f = new Form_LinkedDocs(clid, docnr);
            if (f.ShowDialog(MyMainForm) != DialogResult.OK) return;

            decimal summ = f.Summ;
            decimal pvn = f.PVN;
            string descr = f.descr;
            string ac1 = f.ac1;
            string docnr2 = f.docnr_out;
            string docsr2 = f.docsr_out;

            var dr = dgvDocs.GetCurrentDataRow() as klonsDataSet.OPSdRow;
            if (dr == null) return;

            if (!string.IsNullOrEmpty(descr) && dr.Descr != descr)
            {
                dr.Descr = descr;
            }
            if (string.IsNullOrEmpty(docsr) && !string.IsNullOrEmpty(docsr2) && dr.DocSt != docsr2)
            {
                dr.DocSt = docsr2;
            }
            if (string.IsNullOrEmpty(docnr) && !string.IsNullOrEmpty(docnr2) && dr.DocNr != docnr2)
            {
                dr.DocNr = docnr2;
            }

            dr.Summ = summ;
            dr.PVN = pvn;

            if (ac1 != null)
            {
                var ops = dr.GetOPSRows();
                if (ac1 != null && ops != null && ops.Length > 0)
                {
                    if (ops[0].AC11.LeftMax(3) == "531" &&
                        ops[0].AC12.LeftMax(1) == "7" &&
                        ops[0].AC12 != ac1)
                    {
                        ops[0].AC12 = ac1;
                    }
                    else if (ops[0].AC21.LeftMax(3) == "231" &&
                             ops[0].AC22.LeftMax(1) == "6" &&
                             ops[0].AC22 != ac1)
                    {
                        ops[0].AC22 = ac1;
                    }
                }
            }

            dgvDocs.RefreshCurrent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DoLinkedDocs();
        }

        private void vienkārssRēķinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;
            if (bsOPSd.SaveCurrentItem() == EBsSaveResult.Error) return;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            int id = (int)(dgvDocs.CurrentRow.Cells[dgcDocsId.Index].Value);
            if (id < 0) return;
            MyMainForm.ShowFormDialog(typeof(FormRep_Rekins1), id);
        }
        private void rēkins2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;
            if (bsOPSd.SaveCurrentItem() == EBsSaveResult.Error) return;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            int id = (int)(dgvDocs.CurrentRow.Cells[dgcDocsId.Index].Value);
            if (id < 0) return;
            MyMainForm.ShowFormDialog(typeof(FormRep_Rekins2), id, 2);
        }
        private void rēķinsArDaudzumiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;
            if (bsOPSd.SaveCurrentItem() == EBsSaveResult.Error) return;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            int id = (int)(dgvDocs.CurrentRow.Cells[dgcDocsId.Index].Value);
            if (id < 0) return;
            MyMainForm.ShowFormDialog(typeof(FormRep_Rekins2), id, 1);
        }
        private void pavadzīmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;
            if (bsOPSd.SaveCurrentItem() == EBsSaveResult.Error) return;
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            int id = (int)(dgvDocs.CurrentRow.Cells[dgcDocsId.Index].Value);
            if (id < 0) return;
            MyMainForm.ShowFormDialog(typeof (FormRep_RekinsPZ1), id, 1);
        }

        private void dgvDocs_Leave(object sender, EventArgs e)
        {
        }

        private void bsOPSd_AddingNew(object sender, AddingNewEventArgs e)
        {
            var rv = e.NewObject as DataRowView;
            if (rv == null) return;
            var dr = rv.Row as klonsDataSet.OPSdRow;

            //Debug.Print("bsOPSd_AddingNew ");

            if (lastDate == DateTime.MinValue)
                lastDate = DateTime.Today;

            dr.Dete = lastDate;
            dr.ZU = KlonsData.St.CurrentUserName;
            dr.ZDt = DateTime.Now;
        }

        private void dgvDocs_CurrentCellChanged(object sender, EventArgs e)
        {
            dgvOps.Enabled = !(dgvDocs.CurrentRow == null || dgvDocs.RowCount == 1 ||
                               dgvDocs.CurrentRow.IsNewRow);
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedCells.Count == 0) return;
            if (IsLoading || IsFormClosing || dgvDocs.RowCount == 1 || dgvDocs.SelectedCells.Count == 1)
            {
                tsbSum.Visible = false;
                return;
            }
            var rowids = new List<int>();
            for (int i = 0; i < dgvDocs.SelectedCells.Count; i++)
            {
                var datacell = dgvDocs.SelectedCells[i];
                if (datacell.RowIndex == dgvDocs.NewRowIndex) continue;
                if (!rowids.Contains(datacell.RowIndex))
                    rowids.Add(datacell.RowIndex);
            }
            if (rowids.Count < 2)
            {
                tsbSum.Visible = false;
                return;
            }
            var sum = rowids
                .Select(x => (decimal)(dgvDocs.Rows[x].Cells[dgcDocsSumm.Index].Value))
                .Sum();
            tsbSum.Text = sum.ToString("N2");
            tsbSum.Visible = true;
        }

        public void SearchId(int id)
        {
            if (bsOPSd.Count == 0) return;
            if (!dgvDocs.EndEditX()) return;

            for (int i = 0; i < bsOPSd.Count; i ++)
            {
                var rv1 = bsOPSd[i] as DataRowView;
                var dr = rv1.Row as klonsDataSet.OPSdRow;
                if (dr.id == id)
                {
                    bsOPSd.Position = i;
                }
            }
        }

        private int SearchText(string text, int colindex,
            int startindex = 0, bool forward = true)
        {
            string propname = dgvDocs.Columns[colindex].DataPropertyName;
            if (bsOPSd.Count == 0) return -1;
            if (startindex < 0 || startindex >= bsOPSd.Count) return -1;
            if (string.IsNullOrEmpty(text)) return -1;
            if (startindex == 0 && !forward) return -1;
            if (startindex == bsOPSd.Count - 1 && forward) return -1;
            var rv = bsOPSd[startindex] as DataRowView;
            if (rv == null) return -1;
            int colnr = rv.Row.Table.Columns.IndexOf(propname);
            if (colnr == -1) return -1;
            int di = forward ? 1 : -1;
            object o;
            string val;
            text = text.ToLower();
            for (int i = startindex; i >= 0 && i < bsOPSd.Count; i += di)
            {
                var rv1 = bsOPSd[i] as DataRowView;
                o = rv1.Row[colnr];
                if (o == null || o == DBNull.Value) continue;
                val = o.ToString();
                if (val.ToLower().Contains(text))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SearchText(bool fromfirst = true, bool forward = true)
        {
            if (dgvDocs.CurrentRow == null || dgvDocs.CurrentRow.IsNewRow) return;
            if (!dgvDocs.EndEditX()) return;

            int startindex = dgvDocs.CurrentRow.Index;
            startindex = fromfirst ? 0 : (forward ? startindex + 1 : startindex - 1);
            string text = tsbSearch.Text;
            if (text == "") return;
            int newindex = SearchText(text, dgvDocs.CurrentCell.ColumnIndex, startindex, forward);
            if (newindex == -1)
            {
                MyMainForm.ShowInfo("Tekts [" + text + "] netika atrasts.");
                return;
            }
            dgvDocs.CurrentCell = dgvDocs[dgvDocs.CurrentCell.ColumnIndex, newindex];
        }

        private void tsbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                SearchText();
                dgvDocs.Focus();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvDocs.Focus();
                e.Handled = true;
                return;
            }
        }

        private void tsbSearchPrev_Click(object sender, EventArgs e)
        {
            SearchText(false, false);
            dgvDocs.Focus();
        }

        private void tsbSearchNext_Click(object sender, EventArgs e)
        {
            SearchText(false, true);
            dgvDocs.Focus();
        }

        private void dgvDocs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.F | Keys.Control))
            {
                tsbSearch.Focus();
            }
        }

        private void tsbSearch_Enter(object sender, EventArgs e)
        {
            tsbSearch.Text = "";
        }

        private void bsOPS_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.OPSRow;
            if (dr != null)
            {
                dr.id = (int) MyData.KlonsQueriesTableAdapter.SP_OPS_ID();
            }
        }

        private void bsOPSd_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.OPSdRow;
            if (dr != null)
            {
                dr.id = (int) MyData.KlonsQueriesTableAdapter.SP_OPSD_ID();
                dr.ZNR = (int) MyData.KlonsQueriesTableAdapter.SP_OPSD_GETNEXTNRFORYEARA(dr.Dete.Year);
            }
            bsOPS_MyBeforeRowInsert(e);
        }
        private void bsOPSd_MyBeforeRowUpdate(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as klonsDataSet.OPSdRow;
            if (dr != null)
            {
                if (dr.HasVersion(DataRowVersion.Original))
                {
                    var dt_current = dr.Dete;
                    var dt_original = (DateTime)dr["Dete", DataRowVersion.Original];
                    if (dt_current.Year != dt_original.Year)
                    {
                        dr.ZNR = (int)MyData.KlonsQueriesTableAdapter.SP_OPSD_GETNEXTNRFORYEARA(dt_current.Year);
                    }
                }
            }
        }

        private void oPSdBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bsOPS_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (!detail_update_enabled) return;
            if (e.ListChangedType == ListChangedType.ItemDeleted ||
                //e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded)
            {
                dgvDocs.RefreshCurrent();
            }
            SetSaveButton(HasChanges());
        }

        private void bsOPSd_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (IsLoading) return;
            if (!detail_update_enabled) return;
            SetSaveButton(HasChanges());
        }

        private void SetSaveButton(bool red)
        {
            bnavNav.SetSaveButton(oPSdBindingNavigatorSaveItem, red);
        }
        private bool HasChanges()
        {
            return bsOPS.HasChanges() || bsOPSd.HasChanges();
        }

        private void CheckSave()
        {
            SetSaveButton(HasChanges());
        }

        // you get CellEndEdit after Binding source PositionChanged
        // when you end cell edit with move to next datagrid row

        private void dgvDocs_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private void dgvOps_MyCheckForChanges(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CheckSave();
        }

        private bool detail_update_enabled = true;
        public void CheckOpsGrid(bool setnull = false)
        {
            DataRowView dv = bsOPSd.Current as DataRowView;
            if (dv == null
                || setnull
                || dv.Row.RowState == DataRowState.Deleted
                //|| dv.Row.RowState == DataRowState.Detached
                )
            {
                bsOPS.DataSource = null;
                dgvOps.Enabled = false;
            }
            else
            {
                if (!detail_update_enabled) return;

                DataView dv1 = dv.CreateChildView(dv.Row.Table.ChildRelations[0]);
                dgvOps.Enabled = true;
                bsOPS.DataSource = dv1;
            }
        }

        private void bsOPSd_CurrentChanged(object sender, EventArgs e)
        {
            CheckOpsGrid();
        }

        public void EnableDetailUpdate(bool b)
        {
            detail_update_enabled = b;
            CheckOpsGrid(!b);
        }

    }

}
