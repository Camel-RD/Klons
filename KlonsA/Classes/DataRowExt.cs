using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsA.Classes
{
    public static class DataRowExt
    {
        public static bool HasChanges(this DataRow dr, IDataAdapter ad = null)
        {
            if (!dr.HasVersion(DataRowVersion.Original) ||
                !dr.HasVersion(DataRowVersion.Current)) return false;
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                var col = dr.Table.Columns[i];
                if (col.Caption.StartsWith("!")) continue;
                var vor = dr[i, DataRowVersion.Original];
                var vcur = dr[i, DataRowVersion.Current];
                if (!object.Equals(vor, vcur)) return true;
            }
            return false;
        }

        public static bool HasChanges2(this DataRow dr)
        {
            if (!dr.HasVersion(DataRowVersion.Proposed) ||
                !dr.HasVersion(DataRowVersion.Current)) return false;
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                var vor = dr[i, DataRowVersion.Proposed];
                var vcur = dr[i, DataRowVersion.Current];
                if (!object.Equals(vor, vcur)) return true;
            }
            return false;
        }

        public static void EndEditX(this DataRow dr, IDataAdapter ad = null)
        {
            if (dr.RowState == DataRowState.Added)
            {
                dr.EndEdit();
                return;
            }
            if (dr.HasVersion(DataRowVersion.Current) &&
                dr.HasVersion(DataRowVersion.Proposed))
            {
                if (!HasChanges2(dr))
                {
                    dr.CancelEdit();
                }
                else
                {
                    dr.EndEdit();
                }
            }
            if (dr.HasVersion(DataRowVersion.Current) &&
                dr.HasVersion(DataRowVersion.Original))
            {
                if (!HasChanges(dr, ad))
                {
                    dr.AcceptChanges();
                    return;
                }
            }
        }

        public static string GetChangesAsString(this DataRow dr)
        {
            if (!dr.HasVersion(DataRowVersion.Original) ||
                !dr.HasVersion(DataRowVersion.Current)) return null;
            var sb = new StringBuilder();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                var vor = dr[i, DataRowVersion.Original];
                var vcur = dr[i, DataRowVersion.Current];
                if (object.Equals(vor, vcur)) continue;
                string sor = vor == null || vor == DBNull.Value ? "null" : vor.ToString();
                string scur = vcur == null || vcur == DBNull.Value ? "null" : vcur.ToString();
                var s = string.Format(
                    "{0}: [{1}] - [{2}]",
                    dr.Table.Columns[i].ColumnName,
                    sor,
                    scur);
                sb.AppendLine(s);
            }
            if (sb.Length == 0) return null;
            return sb.ToString();
        }

        public static string GetChangesAsString(this DataTable table, int idcolnr = 0)
        {
            var tch = table.GetChanges();
            var sb = new StringBuilder();
            for (int i = 0; i < tch.Rows.Count; i++)
            {
                var dr = tch.Rows[i];
                sb.AppendFormat(">> {0}: {1}\n", i, dr[idcolnr]);
                sb.AppendLine(dr.GetChangesAsString());
            }
            return sb.ToString();
        }

    }
}
