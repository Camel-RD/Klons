using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KlonsLIB.Data
{

    /// <summary>
    /// Subclass of ConstraintException that explains row and column errors in the Message property
    /// </summary>
    public class DetailedConstraintException : ConstraintException
    {

        private const int InitialCountValue = 1;


        /// <summary>
        /// Initialises a new instance of DetailedConstraintException with the specified string and DataTable
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="ErroredTable">DataTable in error</param>
        public DetailedConstraintException(string message, DataTable erroredTable)
            : base(message)
        {
            ErroredTable = erroredTable;
        }


        /// <summary>
        /// Initialises a new instance of DetailedConstraintException with the specified string, DataTable and inner Exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="ErroredTable">DataTable in error</param>
        /// <param name="inner">the original exception</param>
        public DetailedConstraintException(string message, DataTable erroredTable, Exception inner)
            : base(message, inner)
        {
            ErroredTable = erroredTable;
        }


        private string buildErrorSummaryMessage()
        {
            if (null == ErroredTable) { return "No errored DataTable specified"; }
            if (!ErroredTable.HasErrors) { return "No Row Errors reported in DataTable=[" + ErroredTable.TableName + "]"; }

            foreach (DataRow row in ErroredTable.GetErrors())
            {
                recordColumnsInError(row);
                recordRowsInError(row);
            }

            StringBuilder sb = new StringBuilder();

            appendSummaryIntro(sb);
            appendErroredColumns(sb);
            appendRowErrors(sb);

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


        private void appendSummaryIntro(StringBuilder sb)
        {
            sb.AppendFormat("Errors reported for {1} [{2}]{0}", Environment.NewLine, ErroredTable.GetType().FullName, ErroredTable.TableName);
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


        /// <summary>
        /// Get the DataTable in error
        /// </summary>
        public DataTable ErroredTable
        {
            get { return _erroredTable; }
            private set { _erroredTable = value; }
        }


        /// <summary>
        /// Get the original ConstraintException message with extra error information
        /// </summary>
        public override string Message
        {
            get { return base.Message + Environment.NewLine + buildErrorSummaryMessage(); }
        }


        private readonly SortedDictionary<string, int> _rowErrors = new SortedDictionary<string, int>();
        private readonly SortedDictionary<string, int> _erroredColumns = new SortedDictionary<string, int>();
        private DataTable _erroredTable;
    }
}