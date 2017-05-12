using System;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{

    public class ReportHelperA: KlonsLIB.Forms.ReportHelper
    {
        public override bool CheckForErrors(Action act)
        {

            var b1 = DataSetHelper.HasChanges(KlonsData.St.DataSetKlons.SALARY_SHEETS.GetChanges()) ||
                DataSetHelper.HasChanges(KlonsData.St.DataSetKlons.SALARY_SHEETS_R.GetChanges()) ||
                DataSetHelper.HasChanges(KlonsData.St.DataSetKlons.TIMESHEET_LISTS.GetChanges()) ||
                DataSetHelper.HasChanges(KlonsData.St.DataSetKlons.TIMESHEET_LISTS_R.GetChanges());

            if (b1)
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

    }
}
