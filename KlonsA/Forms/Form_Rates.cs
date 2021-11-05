using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KlonsA.Classes;
using DataObjectsA;
using KlonsA.DataSets;
using KlonsLIB.Data;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Forms
{
    public partial class Form_Rates : MyFormBaseA
    {
        public Form_Rates()
        {
            InitializeComponent();
            CheckMyFontAndColors();
            SetupToolStrips();
            MakeGrid();
        }

        private void Form_Rates_Load(object sender, EventArgs e)
        {
            bsLikmes.Position = bsLikmes.Count - 1;
        }

        private void SetupToolStrips()
        {
            var k = bnavLikmes.Items.IndexOf(this.bindingNavigatorMoveNextItem);
            InsertInToolStrip(bnavLikmes, cbDates, k);
        }

        private void MakeGrid()
        {
            myGrid1.MakeGrid();
            myGrid1.LinkGrid();
            myGrid1.ArrangeLinkedControls();
        }

        private void CheckRatesRedRows()
        {
            var dr = bsLikmes.CurrentDataRow as KlonsADataSet.RATESRow;
            if (dr == null) return;
            int k = bsLikmes.Position;
            if (k == -1) return;
            if (k == 0)
            {
                myGrid1.ClearRed();
            }
            else
            {
                var drv_prev = bsLikmes[k - 1] as DataRowView;
                var dr_prev = drv_prev?.Row as KlonsADataSet.RATESRow;
                if (dr_prev == null) return;
                if (dr_prev.ONDATE > dr.ONDATE) return;
                myGrid1.CheckRedRows(new[] { dr_prev }, new[] { dr }, new[] { bsLikmes });
            }
        }

        private void CheckRatesRowRed(KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase row)
        {
            if (row == null) return;
            var dr = bsLikmes.CurrentDataRow as KlonsADataSet.RATESRow;
            if (dr == null) return;
            if (bsLikmes.Position == 0) return;
            var dr_prev = (bsLikmes[bsLikmes.Position - 1] as DataRowView)?.Row as KlonsADataSet.RATESRow;
            if (dr_prev == null) return;
            if (dr_prev.ONDATE > dr.ONDATE) return;
            row.CheckRedRow(new[] { dr_prev }, new[] { dr }, new[] { bsLikmes });
        }

        private void bsLikmes_CurrentChanged(object sender, EventArgs e)
        {
            CheckRatesRedRows();
        }

        private void myGrid1_EditEnded(object sender, EventArgs e)
        {
            var row = sender as KlonsLIB.MySourceGrid.GridRows.MyGridRowPropEditorBase;
            if (row == null) return;
            CheckRatesRowRed(row);
        }

        private void SetSaveButton(bool red)
        {
            bnavLikmes.SetSaveButton(tsbSave, red);
        }

        public override bool SaveData()
        {
            var ret = bsLikmes.SaveTableA();
            return ret != EBsSaveResult.Error;
        }

        private void CheckSave()
        {
            SetSaveButton(bsLikmes.HasChanges());
        }

        public void DeletCurrent()
        {
            if (bsLikmes.Count < 2 || bsLikmes.Current == null) return;
            if (!Validate()) return;
            var dr = (bsLikmes.Current as DataRowView).Row as KlonsADataSet.RATESRow;
            dr.Delete();
            SaveData();
            CheckSave();
        }

        private void bsLikmes_ListChanged(object sender, ListChangedEventArgs e)
        {
            CheckSave();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveData();
            CheckSave();
        }

        private void bnavLikmes_ItemDeleting(object sender, CancelEventArgs e)
        {
            e.Cancel = !AskCanDelete();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRowView prevdrv = null;
            if (bsLikmes.Count > 0)
            {
                prevdrv = bsLikmes[bsLikmes.Count - 1] as DataRowView;
            }

            var prevdr = prevdrv.Row as KlonsADataSet.RATESRow;
            if (prevdr == null) return;
            var newdr = DataSetHelper.CopyRow(prevdr, null, -1) as KlonsADataSet.RATESRow;

            if (newdr == null) return;

            newdr.BeginEdit();
            newdr.ONDATE = DateTime.Today;
            //newdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_RATES_ID();
            newdr.ID = MyData.DataSetKlons.RATES.Max(d => d.ID) + 1;
            newdr.EndEdit();

            prevdr.Table.Rows.Add(newdr);

            bsLikmes.Position = bsLikmes.Count - 1;

            SaveData();
            CheckSave();
        }

        /*
        private void bsLikmes_MyBeforeRowInsert(MyRowUpdateEventArgs e)
        {
            var dr = e.DataRow as KlonsADataSet.RATESRow;
            if (dr == null) return;
            dr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_RATES_ID();
        }
        */

        private void bsLikmes_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            Form_Error.ShowException(e.Exception);
        }

        private void cbDates_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value == null || !(e.Value is DateTime)) return;
            e.Value = Utils.DateToString((DateTime)e.Value);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeletCurrent();
        }

    }
}
