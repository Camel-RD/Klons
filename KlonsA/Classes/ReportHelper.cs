using System;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using KlonsLIB.Forms;

namespace KlonsA.Classes
{

    public class ReportHelperA: KlonsLIB.Forms.ReportHelper
    {
        public void WarnIfHasChanges()
        {
            if (KlonsData.St.KlonsDataHasChangesA())
            {
                KlonsData.St.MyMainForm.ShowWarning("Iespējams, ka datu tabulās ir nesaglabātas izmaiņas.");
            }
        }

        public override bool CheckForErrors(Action act)
        {
            WarnIfHasChanges();
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
