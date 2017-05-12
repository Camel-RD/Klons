using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using KlonsLIB.Forms;

namespace KlonsLIB.Data
{
    public class ExceptionHelper
    {

        private static string GetColumnDescr(DataTable table, string columnname)
        {
            if (table == null ||
                !table.Columns.Contains(columnname)) return columnname;
            return table.Columns[columnname].Caption;
        }

        private static string GetColumnDescr(DataGridView dgv, string sourcecolumnname)
        {
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (c.DataPropertyName == sourcecolumnname)
                    return c.HeaderText;
            }
            return sourcecolumnname;
        }

        private static string GetFieldNameSimple(string s)
        {
            int pos1 = s.IndexOf('\'');
            if (pos1 == -1) return "";
            int pos2 = s.IndexOf('\'', pos1 + 1);
            if (pos2 == -1) return "";
            return s.Substring(pos1 + 1, pos2 - pos1 - 1);
        }

        private static string GetFieldName(ArgumentException e)
        {
            return GetFieldNameSimple(e.Message);
        }
        private static string GetFieldName(NoNullAllowedException e)
        {
            return GetFieldNameSimple(e.Message);
        }
        private static string GetFieldName(ConstraintException e)
        {
            return GetFieldNameSimple(e.Message);
        }

        public static DataTable GetDataTableFromDataGridView(DataGridView dgv)
        {
            if (dgv.DataSource is MyBindingSource2)
            {
                return (dgv.DataSource as MyBindingSource2).GetTable();
            }

            if (dgv.Rows.Count == 0 || dgv.NewRowIndex == 0) return null;
            object o;
            try
            {
                o = dgv.Rows[0].DataBoundItem;
                if(o == null) return null;
            }
            catch (Exception)
            {
                return null;
            }
            if (!(o is DataRowView)) return null;
            return (o as DataRowView).Row.Table;
        }

        private static string GetFieldName(InvalidConstraintException e, DataTable erroredtable)
        {
            if (erroredtable == null || e == null) return "";
            var t01 = "ForeignKeyConstraint ";
            var t02 = " requires the";
            int pos1 = e.Message.IndexOf(t01);
            int pos2 = -1;
            if (pos1 >= 0)
            {
                pos1 += t01.Length;
                pos2 = e.Message.IndexOf(t02);
            }
            string s = "";
            // constraints are enforced on relation FK_OPS_AC11_ACP21_AC, and deleting this row will 
            var t11 = "constraints are enforced on relation ";
            var t12 = ", and deleting this row will";
            if (pos1 >= 0 && pos2 >= 0)
                s = e.Message.Substring(pos1, pos2 - pos1);
            else
            {
                pos1 = e.Message.IndexOf(t11);
                if(pos1 >= 0)
                {
                    pos1 += t11.Length;
                    pos2 = e.Message.IndexOf(t12);
                    s = e.Message.Substring(pos1, pos2 - pos1);
                }
            }
            if (!erroredtable.Constraints.Contains(s)) return "";
            ForeignKeyConstraint fk = erroredtable.Constraints[s] as ForeignKeyConstraint;
            return fk.Columns[0].ColumnName;
        }

        private const string _sqlExceoptionStr1 = "The UPDATE statement conflicted with the REFERENCE constraint";
        private static string GetFieldName(SqlException e, DataTable dt)
        {
            //The UPDATE statement conflicted with the REFERENCE constraint \"fk_OPS_AC11_Acp21_AC\". The conflict occurred in database \"C:\\A1-DOCS\\C_NET\\KLONS1\\DB\\KLONS.MDF\", table \"dbo.OPS\", column 'AC11'.\r\nThe statement has been terminated.                dv.Row.RejectChanges();
            string s = "";
            int k1, k2;
            if (e.Message.IndexOf(_sqlExceoptionStr1) >= 0)
            {
                k1 = _sqlExceoptionStr1.Length + 2;
                k2 = e.Message.IndexOf(". The conflict occurred in database");
                s = e.Message.Substring(k1, k2 - k1 - 1);
            }
            if (!dt.Constraints.Contains(s)) return "";
            ForeignKeyConstraint fk = dt.Constraints[s] as ForeignKeyConstraint;
            return fk.Columns[0].Caption;
        }

        public static MyException TranslateException(Exception e, DataTable table)
        {
            string s,msg = "";
            if (e == null)
            {
                throw new ArgumentException();
            }
            if (table == null)
            {
                return new MyException(e.Message, e);
            }
            if (e is SqlException &&
                e.Message.StartsWith(_sqlExceoptionStr1))
            {
                //The UPDATE statement conflicted with the REFERENCE constraint \"fk_OPS_AC11_Acp21_AC\". The conflict occurred in database \"C:\\A1-DOCS\\C_NET\\KLONS1\\DB\\KLONS.MDF\", table \"dbo.OPS\", column 'AC11'
                SqlException esq = e as SqlException;
                //s = GetFieldName(esq, table);
                //s = table.Columns[s].Caption;
                msg = string.Format("Lauka vērtību nevar mainīt,\n" +
                                    "ja tā ir izmantota sistītā tabulā");
            }
            else if (e is FbException &&
                     e.Message.StartsWith("violation of FOREIGN KEY constraint "))
            {
                //violation of FOREIGN KEY constraint "FK_OPSD_CLID_PERSONS_CLID" on table "OPSD" Foreign key references are present for the record Problematic key value is ("CLID" = 'zapte') 
                msg = string.Format("Darbību ar ierakstu nevar izpildīt,\n" +
                                    "ja tas ir izmantots sistītā tabulā");

            }
            else if (e is DBConcurrencyException)
            {
                msg = "Izmaiņas neizdevās saglabāt,\n" +
                      "jo ierakstu ir labojis cits lietotājs.\n" +
                      "Mēģiniet pārlasīt tabulas datus.";
            }
            else if (e is NoNullAllowedException)
            {
                NoNullAllowedException enn = e as NoNullAllowedException;
                s = GetFieldName(enn);
                s = GetColumnDescr(table, s);
                msg = string.Format("Lauks [{0}] nevar būt tukšs", s);
            }
            else if (e is ConstraintException &&
                     e.Message.StartsWith("Failed to enable constraints. One or more rows contain"))
            {
                //Failed to enable constraints. One or more rows contain
                DetailedConstraintException de = new DetailedConstraintException(e.Message,
                    table, e);
                msg = de.Message;
            }
            else if (e is ConstraintException &&
                     e.Message.StartsWith("Column '") &&
                     e.Message.Contains("is constrained to be unique"))
            {
                //Column 'AC' is constrained to be unique.  Value '1210' is already present.
                ConstraintException ec = e as ConstraintException;
                s = GetFieldName(ec);
                s = GetColumnDescr(table, s);
                msg = string.Format("Nekorekta lauka [{0}] vērtība" +
                                    " (šāda vērtība tabulā jau ir).", s);
            }
            else if (e is InvalidConstraintException &&
                e.Message.IndexOf("deleting") >= 0)
            {
                msg = "Ierakstu nevar dzēst, jo tam ir saistīti ieraksti citā tabulā.";
            }
            else if (e is InvalidConstraintException)
            {
                InvalidConstraintException eic = e as InvalidConstraintException;
                s = GetFieldName(eic, table);
                s = GetColumnDescr(table, s);
                msg = string.Format("Nekorekta lauka [{0}] vērtība", s);
            }
            else if (e is ArgumentException &&
                     e.Message.Contains("The value violates the MaxLength limit"))
            {
                //ArgumentException: Cannot set column 'ClId'. The value violates the MaxLength limit of this column
                s = GetFieldName(e as ArgumentException);
                s = GetColumnDescr(table, s);
                msg = string.Format("Lauka [{0}] teksts ir par garu.", s);
            }
            else if (e is FormatException)
            {
                //Input string was not in a correct format.
                msg = string.Format("Ievadīta nekorekta lauka vērtība\n" +
                                    "(nekorekts ievadītā teksta formāts, ...).");
            }
            if (msg == "") msg = e.Message;
            return new MyException(msg, e);
        }

        public static MyException TranslateException(Exception e, DataGridView dgv)
        {
            string s, msg = "";
            if (e == null)
            {
                throw new ArgumentException();
            }
            if (dgv == null)
            {
                return new MyException(e.Message, e);
            }

            DataTable dt = GetDataTableFromDataGridView(dgv);

            if (e is SqlException &&
                e.Message.StartsWith(_sqlExceoptionStr1))
            {
                //The UPDATE statement conflicted with the REFERENCE constraint \"fk_OPS_AC11_Acp21_AC\". The conflict occurred in database \"C:\\A1-DOCS\\C_NET\\KLONS1\\DB\\KLONS.MDF\", table \"dbo.OPS\", column 'AC11'
                SqlException esq = e as SqlException;
                //s = GetFieldName(esq, table);
                //s = table.Columns[s].Caption;
                msg = string.Format("Lauka vērtību nevar mainīt, " +
                                    "ja tā ir izmantota sistītā tabulā");
            }
            else if (e is FbException &&
                     e.Message.StartsWith("violation of FOREIGN KEY constraint "))
            {
                //violation of FOREIGN KEY constraint "FK_OPSD_CLID_PERSONS_CLID" on table "OPSD" Foreign key references are present for the record Problematic key value is ("CLID" = 'zapte') 
                msg = string.Format("Darbību ar ierakstu nevar izpildīt, " +
                                    "ja tas ir izmantots sistītā tabulā");

            }
            else if (e is DBConcurrencyException)
            {
                msg = "Izmaiņas neizdevās saglabāt,\n" +
                      "jo ierakstu ir labojis cits lietotājs.\n" +
                      "Mēģiniet pārlasīt tabulas datus.";
            }
            else if (e is NoNullAllowedException)
            {
                NoNullAllowedException enn = e as NoNullAllowedException;
                s = GetFieldName(enn);
                s = GetColumnDescr(dgv, s);
                msg = string.Format("Lauks [{0}] nevar būt tukšs", s);
            }
            else if (e is ConstraintException &&
                     e.Message.StartsWith("Column '") &&
                     e.Message.Contains("is constrained to be unique"))
            {
                //Column 'AC' is constrained to be unique.  Value '1210' is already present.
                ConstraintException ec = e as ConstraintException;
                s = GetFieldName(ec);
                s = GetColumnDescr(dgv, s);
                msg = string.Format("Nekorekta lauka [{0}] vērtība" +
                                    " (šāda vērtība tabulā jau ir).", s);
            }
            else if (e is ConstraintException &&
                     e.Message.StartsWith("Failed to enable constraints. One or more rows contain"))
            {
                //Failed to enable constraints. One or more rows contain
                DetailedConstraintException de = new DetailedConstraintException(e.Message,
                    GetDataTableFromDataGridView(dgv), e);
                msg = de.Message;
            }
            else if (e is InvalidConstraintException &&
                e.Message.IndexOf("deleting") >= 0)
            {
                msg = "Ierakstu nevar dzēst, jo tam ir saistīti ieraksti citā tabulā.";
            }
            else if (e is InvalidConstraintException)
            {
                InvalidConstraintException eic = e as InvalidConstraintException;
                s = GetFieldName(eic, dt);
                s = GetColumnDescr(dgv, s);
                msg = string.Format("Nekorekta lauka [{0}] vērtība", s);
            }
            else if (e is ArgumentException &&
                     e.Message.Contains("The value violates the MaxLength limit"))
            {
                //ArgumentException: Cannot set column 'ClId'. The value violates the MaxLength limit of this column
                s = GetFieldName(e as ArgumentException);
                s = GetColumnDescr(dgv, s);
                msg = string.Format("Lauka [{0}] teksts ir par garu.", s);
            }
            else if (e is FormatException)
            {
                //Input string was not in a correct format.
                msg = string.Format("Ievadīta nekorekta lauka vērtība\n" +
                                    "(nekorekts ievadītā teksta formāts, ...).");
            }
            if (msg == "") msg = e.Message;
            return new MyException(msg, e);
        }

    }
}
