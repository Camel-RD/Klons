using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    [ToolboxItem(true)]
    public class DLJoinView : JoinView
    {
        public KlonsData MyData { get { return KlonsData.St; } }

        public DLJoinView()
        {
            this.Table = KlonsData.St.DataSetKlons.TIMESHEET;
            this.AddedObjectType = typeof(AddToDLJoinViewRow);
        }

        public DLJoinView(System.ComponentModel.IContainer container) : this() {
            if (container == null)
                throw new ArgumentNullException("container");
            container.Add(this);
        }


        public void MakeList(KlonsADataSet.TIMESHEET_LISTSRow dr_sar)
        {
            ClearList();

            if (dr_sar == null) return;

            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;

            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;

            var dv_darba_laiks = table_darba_laiks.AsDataView();
            dv_darba_laiks.Sort = "ID";

            var drs_sar_r = dr_sar.GetTIMESHEET_LISTS_RRows();

            var jr_list = new List<TimeSheetJoinViewRow>();

            foreach (var dr_sar_r in drs_sar_r)
            {
                var drs_darba_laiks = dr_sar_r.GetTIMESHEETRows();

                var dr_pers = table_persons.FindByID(dr_sar_r.IDP);
                var dr_amats = table_amati.FindByID(dr_sar_r.IDAM);
                var s_name = string.Format("{0} {1}", dr_pers.FNAME, dr_pers.LNAME);
                var s_position = dr_amats.TITLE;
                var s_title = string.Format("{0} {1}, {2}", dr_pers.FNAME, dr_pers.LNAME, s_position);

                var jadd = new AddToDLJoinViewRow()
                {
                    DRV = dr_sar_r,
                    Name = s_name,
                    Position = s_position,
                    Title = s_title
                };

                var jrset = new TimeSheetJoinViewRowSet();

                var act_add_row = new Action<KlonsADataSet.TIMESHEETRow>(dr => {
                    var drv_darba_laiks = dv_darba_laiks.FindRows(dr.ID)[0];
                    var jr_darba_laiks = new TimeSheetJoinViewRow(this, drv_darba_laiks, jadd);
                    jr_darba_laiks.RowSet = jrset;
                    jrset.SetRow(jr_darba_laiks);
                    jr_list.Add(jr_darba_laiks);
                });


                foreach (var dr_darba_laiks in drs_darba_laiks)
                {
                    act_add_row(dr_darba_laiks);
                }

                if (dr_sar_r.XPlanType == EPlanType.Fixed)
                {
                    var drs_darba_laiks_plans = table_darba_laiks.WhereX(dr =>
                        !dr.IsIDPNull() &&
                        dr.IsIDLNull() &&
                        dr.IDP == dr_sar_r.IDPL &&
                        dr.YR == dr_sar.YR &&
                        dr.MT == dr_sar.MT).ToArray();

                    foreach (var dr_darba_laiks in drs_darba_laiks_plans)
                    {
                        act_add_row(dr_darba_laiks);
                    }
                }
            }

            AddFrom(jr_list);
        }

        public string AddNew(KlonsADataSet.TIMESHEET_LISTSRow dr_sar, out int id,
            int snr, int idp, int idam, int idpl, bool plind, bool night, bool overtime)
        {
            string er = "OK";
            id = int.MinValue;

            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;

            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;

            var dv_darba_laiks = table_darba_laiks.AsDataView();
            dv_darba_laiks.Sort = "ID";

            int yr = dr_sar.YR;
            int mt = dr_sar.MT;


            var has_it = table_sar_r.WhereX(d =>
                d.TIMESHEET_LISTSRow.YR == yr &&
                d.TIMESHEET_LISTSRow.MT == mt &&
                d.IDP == idp &&
                d.IDAM == idam
            ).Count() > 0;
            if (has_it)
            {
                er =
                    "Nevar izveidot ierakstu darbiniekam un amatam,\n" +
                    "jo tâds ieraksts ðajâ mçnesî jau ir izveidots.";
                return er;
            }

            var dr_pers = table_persons.FindByID(idp);
            var dr_amats = table_amati.FindByID(idam);
            var s_name = string.Format("{0} {1}", dr_pers.FNAME, dr_pers.LNAME);
            var s_position = dr_amats.TITLE;
            var s_title = string.Format("{0} {1}, {2}", dr_pers.FNAME, dr_pers.LNAME, s_position);

            var new_dr_sar_r = table_sar_r.NewTIMESHEET_LISTS_RRow();
            var dr_pl = table_plans.FindByID(idpl);

            new_dr_sar_r.TIMESHEET_LISTSRow = dr_sar;
            new_dr_sar_r.IDP = idp;
            new_dr_sar_r.IDAM = idam;
            new_dr_sar_r.IDPL = idpl;
            new_dr_sar_r.SNR = (short)snr;
            new_dr_sar_r.XPlanType = plind ? EPlanType.Individual : EPlanType.Fixed;
            new_dr_sar_r.NIGHT = dr_pl.NIGHT;
            new_dr_sar_r.OVERTIME = (short)(overtime ? 1 : 0);

            table_sar_r.Rows.Add(new_dr_sar_r);

            var jadd = new AddToDLJoinViewRow()
            {
                DRV = new_dr_sar_r,
                Name = s_name,
                Position = s_position,
                Title = s_title
            };

            var jrset = new TimeSheetJoinViewRowSet();

            var jr_add_list = new List<JoinViewRow>();

            var act_add_row = new Action<KlonsADataSet.TIMESHEETRow>(dr => {
                var drv_darba_laiks = dv_darba_laiks.FindRows(dr.ID)[0];
                var jr_darba_laiks = new TimeSheetJoinViewRow(this, drv_darba_laiks, jadd);
                jrset.SetRow(jr_darba_laiks);
                jr_darba_laiks.RowSet = jrset;
                jr_add_list.Add(jr_darba_laiks);
            });

            int colnr_v1 = table_darba_laiks.Columns["V1"].Ordinal;
            int colnr_d1 = table_darba_laiks.Columns["D1"].Ordinal;
            var act_copy_darba_laiks_row_data = new Action<KlonsADataSet.TIMESHEETRow,
                KlonsADataSet.TIMESHEETRow>((dfrom, dto) =>
                {
                    for (int i = 0; i < 31; i++)
                    {
                        dto[colnr_v1 + i] = dfrom[colnr_v1 + i];
                        dto[colnr_d1 + i] = dfrom[colnr_d1 + i];
                    }
                });


            var drs_darba_laiks_plans = table_darba_laiks.WhereX(dr =>
                !dr.IsIDPNull() &&
                dr.IsIDLNull() &&
                dr.IDP == idpl &&
                dr.YR == yr &&
                dr.MT == mt).ToArray();

            //add plan
            if (plind)
            {
                foreach (var dr_darba_laiks in drs_darba_laiks_plans)
                {
                    var new_dr_dl_pl = table_darba_laiks.NewTIMESHEETRow();

                    new_dr_dl_pl.TIMESHEET_LISTS_RRow = new_dr_sar_r;
                    new_dr_dl_pl.IDL = new_dr_sar_r.ID;
                    new_dr_dl_pl.YR = yr;
                    new_dr_dl_pl.MT = mt;
                    new_dr_dl_pl.SNR = (short)snr;

                    table_darba_laiks.Rows.Add(new_dr_dl_pl);

                    switch (dr_darba_laiks.XKind1)
                    {
                        case EKind1.PlanGroupDay:
                            new_dr_dl_pl.XKind1 = EKind1.PlanIndividualDay;
                            break;
                        case EKind1.PlanGroupaNight:
                            new_dr_dl_pl.XKind1 = EKind1.PlanIndividualNight;
                            break;
                    }

                    act_copy_darba_laiks_row_data(dr_darba_laiks, new_dr_dl_pl);
                    act_add_row(dr_darba_laiks);
                }
            }
            else
            {
                foreach (var dr_darba_laiks in drs_darba_laiks_plans)
                {
                    act_add_row(dr_darba_laiks);
                }
            }

            //add day
            var new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
            new_dr_darba_laiks.IDL = new_dr_sar_r.ID;
            new_dr_darba_laiks.SNR = (short)snr;
            new_dr_darba_laiks.XKind1 = EKind1.Fact;
            new_dr_darba_laiks.YR = yr;
            new_dr_darba_laiks.MT = mt;
            new_dr_darba_laiks.PERID = idp;
            new_dr_darba_laiks.AMID = idam;

            table_darba_laiks.Rows.Add(new_dr_darba_laiks);

            act_add_row(new_dr_darba_laiks);

            //add night
            if (night)
            {
                new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
                new_dr_darba_laiks.SNR = (short)snr;
                new_dr_darba_laiks.IDL = new_dr_sar_r.ID;
                new_dr_darba_laiks.XKind1 = EKind1.FactNight;
                new_dr_darba_laiks.YR = yr;
                new_dr_darba_laiks.MT = mt;
                new_dr_darba_laiks.PERID = idp;
                new_dr_darba_laiks.AMID = idam;

                table_darba_laiks.Rows.Add(new_dr_darba_laiks);

                act_add_row(new_dr_darba_laiks);
            }

            //add overtime
            if (overtime)
            {
                new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
                new_dr_darba_laiks.SNR = (short)snr;
                new_dr_darba_laiks.IDL = new_dr_sar_r.ID;
                new_dr_darba_laiks.XKind1 = EKind1.FactOvertime;
                new_dr_darba_laiks.YR = yr;
                new_dr_darba_laiks.MT = mt;
                new_dr_darba_laiks.PERID = idp;
                new_dr_darba_laiks.AMID = idam;

                table_darba_laiks.Rows.Add(new_dr_darba_laiks);

                act_add_row(new_dr_darba_laiks);
            }

            AddFrom(jr_add_list);
            DoSort();
            id = new_dr_sar_r.ID;
            return er;
        }

    }

    public class AddToDLJoinViewRow
    {
        public KlonsADataSet.TIMESHEET_LISTS_RRow DRV = null;

        public object this[string propName]
        {
            get
            {
                if (DRV == null)
                    throw new Exception("DataRowView not set");
                if (DRV.RowState == DataRowState.Detached ||
                    DRV.RowState == DataRowState.Deleted)
                    return null;
                return DRV[propName];
            }
            set
            {
                if (DRV == null)
                    throw new Exception("DataRowView not set");
                if (DRV.RowState == DataRowState.Detached ||
                    DRV.RowState == DataRowState.Deleted)
                    return;
                DRV[propName] = value;
            }
        }

        public int IDX => (int)this["ID"];
        public short SNRX => (short)this["SNR"];
        public string Name { get; set; } = null;
        public string Position { get; set; } = null;
        public string Title { get; set; } = null;

    }

    public class TimeSheetJoinViewRowSet
    {
        public TimeSheetJoinViewRow Plan = null;
        public TimeSheetJoinViewRow PlanNight = null;
        public TimeSheetJoinViewRow Fact = null;
        public TimeSheetJoinViewRow FactNight = null;
        public TimeSheetJoinViewRow FactOvertime = null;

        public void Clear()
        {
            Plan = null;
            PlanNight = null;
            Fact = null;
            FactNight = null;
            FactOvertime = null;
        }

        public void SetRow(TimeSheetJoinViewRow row)
        {
            switch (row.XRow.XKind1)
            {
                case EKind1.PlanGroupDay:
                case EKind1.PlanIndividualDay:
                    Plan = row;
                    break;
                case EKind1.PlanGroupaNight:
                case EKind1.PlanIndividualNight:
                    PlanNight = row;
                    break;
                case EKind1.Fact:
                    Fact = row;
                    break;
                case EKind1.FactNight:
                    FactNight = row;
                    break;
                case EKind1.FactOvertime:
                    FactOvertime = row;
                    break;
            }
        }
    }

    public class TimeSheetJoinViewRow : JoinViewRow
    {
        public KlonsData MyData { get { return KlonsData.St; } }

        public TimeSheetJoinViewRowSet RowSet = null;

        public KlonsADataSet.TIMESHEETRow XRow { get { return BaseRow?.Row as KlonsADataSet.TIMESHEETRow; } }
        public AddToDLJoinViewRow XObj { get { return AddedObject as AddToDLJoinViewRow; } }

        public TimeSheetJoinViewRow(JoinView JoinView, DataRowView Record, object AddedObject = null)
            : base(JoinView, Record, AddedObject)
        {

        }

        public string EditCurrent(int snr, int idp, int idam, int idpl, bool plind, bool night, bool overtime)
        {
            string er = "OK";
            var prs = TypeDescriptor.GetProperties(this);
            var id = (int)get_Item("IDX");

            var _view = this.View;

            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;
            var dr_sar_r = table_sar_r.FindByID(id);

            bool cur_plind = dr_sar_r.XPlanType == EPlanType.Individual;

            if (idp == dr_sar_r.IDP &&
                snr == dr_sar_r.SNR &&
                idam == dr_sar_r.IDAM &&
                idpl == dr_sar_r.IDPL &&
                plind == cur_plind &&
                night == (dr_sar_r.NIGHT == 1) &&
                overtime == (dr_sar_r.OVERTIME == 1))
                return er;


            var table_sar = MyData.DataSetKlons.TIMESHEET_LISTS;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;

            var table_plans = MyData.DataSetKlons.TIMEPLAN_LIST;

            var table_persons = MyData.DataSetKlons.PERSONS;
            var table_amati = MyData.DataSetKlons.POSITIONS;

            var dr_sar = dr_sar_r.TIMESHEET_LISTSRow;

            var dv_darba_laiks = table_darba_laiks.AsDataView();
            dv_darba_laiks.Sort = "ID";

            int yr = dr_sar_r.TIMESHEET_LISTSRow.YR;
            int mt = dr_sar_r.TIMESHEET_LISTSRow.MT;


            if (idp != dr_sar_r.IDP ||
                idam != dr_sar_r.IDAM)
            {
                var has_it = table_sar_r.WhereX(d =>
                    d.TIMESHEET_LISTSRow.YR == yr &&
                    d.TIMESHEET_LISTSRow.MT == mt &&
                    d.IDP == idp &&
                    d.IDAM == idam
                ).Count() > 0;
                if (has_it)
                {
                    er ="Nevar mainît ierakstam darbinieku un amatu,\n" +
                        "jo tâds ieraksts ðajâ mçnesî jau ir izveidots.";
                    return er;
                }
            }

            dr_sar_r.IDP = idp;
            dr_sar_r.IDAM = idam;

            if (snr != dr_sar_r.SNR)
                dr_sar_r.SNR = (short)snr;


            var dr_pers = table_persons.FindByID(idp);
            var dr_amats = table_amati.FindByID(idam);
            var s_name = string.Format("{0} {1}", dr_pers.FNAME, dr_pers.LNAME);
            var s_position = dr_amats.TITLE;
            var s_title = string.Format("{0} {1}, {2}", dr_pers.FNAME, dr_pers.LNAME, s_position);

            var jadd = new AddToDLJoinViewRow()
            {
                DRV = dr_sar_r,
                Name = s_name,
                Position = s_position,
                Title = s_title
            };

            var jr_add_list = new List<JoinViewRow>();

            var act_add_row = new Action<KlonsADataSet.TIMESHEETRow>(dr => {
                var drv_darba_laiks = dv_darba_laiks.FindRows(dr.ID)[0];
                var jr_darba_laiks = new TimeSheetJoinViewRow(_view, drv_darba_laiks, jadd);
                jr_darba_laiks.RowSet = RowSet;
                RowSet.SetRow(jr_darba_laiks);
                jr_add_list.Add(jr_darba_laiks);
            });

            int colnr_v1 = table_darba_laiks.Columns["V1"].Ordinal;
            int colnr_d1 = table_darba_laiks.Columns["D1"].Ordinal;
            var act_copy_darba_laiks_row_data = new Action<KlonsADataSet.TIMESHEETRow,
                KlonsADataSet.TIMESHEETRow>((dfrom, dto) =>
                {
                    for (int i = 0; i < 31; i++)
                    {
                        dto[colnr_v1 + i] = dfrom[colnr_v1 + i];
                        dto[colnr_d1 + i] = dfrom[colnr_d1 + i];
                    }
                });

            // remove rows for night
            if (!night && dr_sar_r.NIGHT == 1)
            {
                if(RowSet.PlanNight != null && 
                    RowSet.PlanNight.XRow.XKind1 == EKind1.PlanIndividualNight)
                {
                    RowSet.PlanNight.XRow.Delete();
                    RowSet.PlanNight = null;
                }
                if (RowSet.FactNight != null)
                {
                    RowSet.FactNight.XRow.Delete();
                    RowSet.FactNight = null;
                }
            }

            // remove overtime
            if (!overtime && dr_sar_r.OVERTIME == 1)
            {
                if (RowSet.FactOvertime != null)
                {
                    RowSet.FactOvertime.XRow.Delete();
                    RowSet.FactOvertime = null;
                }
            }


            //remove individual plan
            if (cur_plind && !plind)
            {
                if (RowSet.Plan != null &&
                    RowSet.Plan.XRow.XKind1 == EKind1.PlanIndividualDay)
                {
                    RowSet.Plan.XRow.Delete();
                    RowSet.Plan = null;
                }
                if (RowSet.PlanNight != null &&
                    RowSet.PlanNight.XRow.XKind1 == EKind1.PlanIndividualNight)
                {
                    RowSet.PlanNight.XRow.Delete();
                    RowSet.PlanNight = null;
                }
            }

            //remove group plan
            if (!cur_plind && (plind || idpl != dr_sar_r.IDPL))
            {
                if (RowSet.Plan != null &&
                    RowSet.Plan.XRow.XKind1 == EKind1.PlanGroupDay)
                {
                    RowSet.Plan.RemoveFromView();
                    RowSet.Plan = null;
                }
                if (RowSet.PlanNight != null &&
                    RowSet.PlanNight.XRow.XKind1 == EKind1.PlanGroupaNight)
                {
                    RowSet.PlanNight.RemoveFromView();
                    RowSet.PlanNight = null;
                }
            }

            //add group plan
            if (!plind && (cur_plind || idpl != dr_sar_r.IDPL))
            {
                var drs_darba_laiks_plans = table_darba_laiks.WhereX(dr =>
                    !dr.IsIDPNull() &&
                    dr.IsIDLNull() &&
                    dr.IDP == idpl &&
                    dr.YR == yr &&
                    dr.MT == mt
                    ).ToArray();

                foreach (var dr_darba_laiks in drs_darba_laiks_plans)
                {
                    act_add_row(dr_darba_laiks);
                }
            }

            //add night
            if (night && dr_sar_r.NIGHT == 0)
            {
                var new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
                new_dr_darba_laiks.IDL = dr_sar_r.ID;
                new_dr_darba_laiks.SNR = (short)snr;
                new_dr_darba_laiks.XKind1 = EKind1.FactNight;
                new_dr_darba_laiks.YR = yr;
                new_dr_darba_laiks.MT = mt;
                new_dr_darba_laiks.PERID = idp;
                new_dr_darba_laiks.AMID = idam;

                table_darba_laiks.Rows.Add(new_dr_darba_laiks);

                if (plind)
                {
                    bool have_it = table_darba_laiks.WhereX(d =>
                        !d.IsIDLNull() &&
                        d.IDL == id &&
                        d.XKind1 == EKind1.PlanIndividualNight
                    ).Count() > 0;

                    if (!have_it)
                    {
                        new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
                        new_dr_darba_laiks.IDL = dr_sar_r.ID;
                        new_dr_darba_laiks.SNR = (short)snr;
                        new_dr_darba_laiks.IDP = idpl;
                        new_dr_darba_laiks.XKind1 = EKind1.PlanIndividualNight;
                        new_dr_darba_laiks.YR = yr;
                        new_dr_darba_laiks.MT = mt;
                        new_dr_darba_laiks.PERID = idp;
                        new_dr_darba_laiks.AMID = idam;

                        table_darba_laiks.Rows.Add(new_dr_darba_laiks);
                    }
                }

                act_add_row(new_dr_darba_laiks);
            }

            // add overtime
            if (overtime && dr_sar_r.OVERTIME == 0)
            {
                var new_dr_darba_laiks = table_darba_laiks.NewTIMESHEETRow();
                new_dr_darba_laiks.IDL = dr_sar_r.ID;
                new_dr_darba_laiks.SNR = (short)snr;
                new_dr_darba_laiks.XKind1 = EKind1.FactOvertime;
                new_dr_darba_laiks.YR = yr;
                new_dr_darba_laiks.MT = mt;
                new_dr_darba_laiks.PERID = idp;
                new_dr_darba_laiks.AMID = idam;

                table_darba_laiks.Rows.Add(new_dr_darba_laiks);

                act_add_row(new_dr_darba_laiks);
            }

            //add individual plan
            if (plind && !cur_plind)
            {
                var drs_p = table_darba_laiks.WhereX(d =>
                    d.IsIDLNull() &&
                    !d.IsIDPNull() &&
                    d.IDP == idpl &&
                    d.YR == yr &&
                    d.MT == mt
                ).ToArray();

                foreach (var dr_p in drs_p)
                {
                    var new_dr_darba_laiks_plans_r = table_darba_laiks.NewTIMESHEETRow();
                    new_dr_darba_laiks_plans_r.IDL = dr_sar_r.ID;
                    new_dr_darba_laiks_plans_r.YR = yr;
                    new_dr_darba_laiks_plans_r.MT = mt;
                    new_dr_darba_laiks_plans_r.IDP = dr_sar_r.IDPL;
                    new_dr_darba_laiks_plans_r.SNR = (short)snr;

                    act_copy_darba_laiks_row_data(dr_p, new_dr_darba_laiks_plans_r);

                    table_darba_laiks.Rows.Add(new_dr_darba_laiks_plans_r);

                    switch (dr_p.XKind1)
                    {
                        case EKind1.PlanGroupDay:
                            new_dr_darba_laiks_plans_r.XKind1 = EKind1.PlanIndividualDay;
                            break;
                        case EKind1.PlanGroupaNight:
                            new_dr_darba_laiks_plans_r.XKind1 = EKind1.PlanIndividualNight;
                            break;
                    }

                    act_add_row(new_dr_darba_laiks_plans_r);
                }
            }

            _view.AddFrom(jr_add_list);

            //update ind plan
            if (idpl != dr_sar_r.IDPL && plind)
            {
                var drs_pl_cur = table_darba_laiks.WhereX(d =>
                    !d.IsIDPNull() &&
                    !d.IsIDLNull() &&
                    d.IDL == id
                ).ToArray();

                var drs_pl_new = table_darba_laiks.WhereX(d =>
                    !d.IsIDPNull() &&
                    d.IsIDLNull() &&
                    d.IDP == idpl &&
                    d.YR == yr &&
                    d.MT == mt
                ).ToArray();

                foreach (var dr_pl_cur in drs_pl_cur)
                {
                    var dr_pl_new = drs_pl_new.Where(d =>
                        d.RowState != DataRowState.Deleted &&
                        d.KIND1 == dr_pl_cur.KIND1
                    ).FirstOrDefault();

                    if (dr_pl_new == null) continue;
                    act_copy_darba_laiks_row_data(dr_pl_cur, dr_pl_new);
                }
            }

            if (night != (dr_sar_r.NIGHT == 1))
                dr_sar_r.NIGHT = (short)(night ? 1 : 0);
            if (overtime != (dr_sar_r.OVERTIME == 1))
                dr_sar_r.OVERTIME = (short)(overtime ? 1 : 0);

            if (plind != cur_plind)
                if (plind)
                    dr_sar_r.XPlanType = EPlanType.Individual;
                else
                    dr_sar_r.XPlanType = EPlanType.Fixed;

            dr_sar_r.IDPL = idpl;

            _view.DoSort();
            return er;
        }

        public void DeleteRowSet()
        {
            var dr_sar_r = XObj.DRV;
            var table_darba_laiks = MyData.DataSetKlons.TIMESHEET;
            var table_sar_r = MyData.DataSetKlons.TIMESHEET_LISTS_R;

            // remove rows for fact, night, overtime, individual plan
            var drs_n = dr_sar_r.GetTIMESHEETRows();
            foreach (var dr_n in drs_n)
                dr_n.Delete();

            //remove group plan
            var jrs_remove = View.List.Where(d =>
            {
                int idl = (int)d.get_Item("IDX");
                return idl == dr_sar_r.ID;
            }).ToArray();
            View.RemoveJoinRows(jrs_remove);

            // remove sheet row
            if (dr_sar_r != null)
                dr_sar_r.Delete();

            RowSet.Clear();
        }
    }

}
