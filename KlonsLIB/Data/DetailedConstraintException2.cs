using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KlonsLIB.Data
{

    public class DetailedConstraintException2 : ConstraintException
    {

        private const int InitialCountValue = 1;


        public DetailedConstraintException2(string message, DataSet erroredDataSet)
            : base(message)
        {
            _erroredDataSet = erroredDataSet;
        }


        public DetailedConstraintException2(string message, DataSet erroredDataSet, Exception inner)
            : base(message, inner)
        {
            _erroredDataSet = erroredDataSet;
        }


        private string buildErrorSummaryMessage()
        {
            if (null == _erroredDataSet) { return "No errored DataSet specified"; }
            if (!_erroredDataSet.HasErrors) { return "No Row Errors reported in DataSet"; }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _erroredDataSet.Tables.Count; i++)
            {
                var table = _erroredDataSet.Tables[i];
                if (!table.HasErrors) continue;

                foreach (DataRow row in table.GetErrors())
                {
                    recordColumnsInError(row);
                    recordRowsInError(row);

                    appendSummaryIntro(sb, table);
                    appendErroredColumns(sb);
                    appendRowErrors(sb);

                    _rowErrors.Clear();
                    _erroredColumns.Clear();
                }
            }

            return sb.ToString();
        }


        private void recordColumnsInError(DataRow row)
        {
            foreach (DataColumn column in row.GetColumnsInError())
            {
                if (_erroredColumns.ContainsKey(column.ColumnName))
                {
                    _erroredColumns[column.ColumnName]++;
                    continue;
                }

                _erroredColumns.Add(column.ColumnName, InitialCountValue);
            }
        }


        private void recordRowsInError(DataRow row)
        {
            if (_rowErrors.ContainsKey(row.RowError))
            {
                _rowErrors[row.RowError]++;
                return;
            }

            _rowErrors.Add(row.RowError, InitialCountValue);
        }


        private void appendSummaryIntro(StringBuilder sb, DataTable table)
        {
            sb.AppendFormat("Errors reported for [{1}]{0}", Environment.NewLine, table.TableName);
        }


        private void appendErroredColumns(StringBuilder sb)
        {
            sb.AppendFormat("Columns in error: [{1}]{0}", Environment.NewLine, _erroredColumns.Count);

            foreach (string columnName in _erroredColumns.Keys)
            {
                sb.AppendFormat("\t[{1}] - rows affected: {2}{0}",
                                Environment.NewLine,
                                columnName,
                                _erroredColumns[columnName]);
            }
        }


        private void appendRowErrors(StringBuilder sb)
        {
            sb.AppendFormat("Row errors: [{1}]{0}", Environment.NewLine, _rowErrors.Count);

            foreach (string rowError in _rowErrors.Keys)
            {
                sb.AppendFormat("\t[{1}] - rows affected: {2}{0}",
                                Environment.NewLine,
                                rowError,
                                _rowErrors[rowError]);
            }
        }


        public override string Message
        {
            get { return base.Message + Environment.NewLine + buildErrorSummaryMessage(); }
        }


        private readonly SortedDictionary<string, int> _rowErrors = new SortedDictionary<string, int>();
        private readonly SortedDictionary<string, int> _erroredColumns = new SortedDictionary<string, int>();
        DataSet _erroredDataSet;
    }
}