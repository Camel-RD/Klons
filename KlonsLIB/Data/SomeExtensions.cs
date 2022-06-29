using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsLIB.Misc;

namespace KlonsLIB.Data
{
    public static class SomeExtensions
    {
        public static EnumerableRowCollection<TRow> WhereX<TRow>(this TypedTableBase<TRow> source, Func<TRow, bool> predicate) where TRow : DataRow
        {
            return TypedTableBaseExtensions.Where(source,
                d => 
                d.RowState != DataRowState.Deleted &&
                d.RowState != DataRowState.Detached &&
                predicate(d));
        }

        public static EnumerableRowCollection<TRow> WhereNotDeleted<TRow>(this TypedTableBase<TRow> source) where TRow : DataRow
        {
            return TypedTableBaseExtensions.Where(source,
                d =>
                d.RowState != DataRowState.Deleted &&
                d.RowState != DataRowState.Detached);
        }

        public static IEnumerable<TSource> WhereX<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) where TSource : DataRow
        {
            return Enumerable.Where(source,
                d =>
                d.RowState != DataRowState.Deleted &&
                d.RowState != DataRowState.Detached &&
                predicate(d));
        }

        public static bool HasChanges(this DataTable table)
        {
            DataSetHelper.GetStats(table, out int added, out int modified, out int deleted);
            return (added + modified + deleted) > 0;
        }

    }

    public class FilterBuilder
    {
        public string FilterString = "";
        public void AddFilterPart(string fpart)
        {
            if (FilterString == null) FilterString = "";
            if (fpart == null) fpart = "";
            if (fpart == "") return;
            if (FilterString == "") FilterString = $"({fpart})";
            else FilterString = $"{FilterString} AND ({fpart})";
        }
    }
}
