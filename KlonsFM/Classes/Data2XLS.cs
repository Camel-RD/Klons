using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KlonsFM.DataSets;
using KlonsFM.Classes;
using KlonsFM.UI;
using KlonsLIB.Forms;
using KlonsLIB.Data;
using KlonsLIB.Misc;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace KlonsFM.Classes
{
    public class RowsData
    {
        private KlonsData MyData => KlonsData.St;

        public List<klonsDataSet.OPSdRow> OPSdRows = null;
        public List<klonsDataSet.OPSRow> OPSRows = null;
        public List<klonsDataSet.AcP21Row> AcP1Rows = null;
        public List<klonsDataSet.Acp23Row> AcP3Rows = null;
        public List<klonsDataSet.AcP24Row> AcP4Rows = null;
        public List<klonsDataSet.Acp25Row> AcP5Rows = null;
        public List<klonsDataSet.PersonsRow> PersonsRows = null;
        public List<klonsDataSet.DocTypRow> DocTypRows = null;
        public List<klonsDataSet.CurrencyRow> CurrencyRows = null;

        public int TotalRowCount { get; private set; } = 0;

        public RowsData()
        {
        }

        public void GetRows()
        {
            var ds = MyData.DataSetKlons;
            OPSdRows = ds.OPSd.WhereNotDeleted()
                .OrderBy(d => d.Dete)
                .ThenBy(d => d.id)
                .ToList();

            OPSRows = ds.OPS.WhereNotDeleted()
                .OrderBy(d => d.OPSdRow.Dete)
                .ThenBy(d => d.OPSdRow.id)
                .ThenBy(d => d.id)
                .ToList();

            var e11 = OPSRows.Select(d => d.AcP21RowByFK_OPS_AC11_ACP21_AC1).Distinct();
            var e21 = OPSRows.Select(d => d.AcP21RowByFK_OPS_AC21_ACP21_AC1).Distinct();
            var e12 = OPSRows.Where(d => d.AC12 != null).Select(d => d.AcP21RowByFK_OPS_AC12_ACP21_AC1).Distinct();
            var e22 = OPSRows.Where(d => d.AC22 != null).Select(d => d.AcP21RowByFK_OPS_AC22_ACP21_AC1).Distinct();
            var e13 = OPSRows.Where(d => d.AC13 != null).Select(d => d.Acp23RowByFK_OPS_AC13_ACP23_IDX1).Distinct();
            var e23 = OPSRows.Where(d => d.AC23 != null).Select(d => d.Acp23RowByFK_OPS_AC23_ACP23_IDX1).Distinct();
            var e14 = OPSRows.Where(d => d.AC14 != null).Select(d => d.AcP24RowByFK_OPS_AC14_ACP24_IDX1).Distinct();
            var e24 = OPSRows.Where(d => d.AC24 != null).Select(d => d.AcP24RowByFK_OPS_AC24_ACP24_IDX1).Distinct();
            var e15 = OPSRows.Where(d => d.AC15 != null).Select(d => d.Acp25RowByFK_OPS_AC15_ACP25_IDX1).Distinct();
            var e25 = OPSRows.Where(d => d.AC25 != null).Select(d => d.Acp25RowByFK_OPS_AC25_ACP25_IDX1).Distinct();
            var epers1 = OPSdRows.Where(d => d.ClId != null).Select(d => ds.Persons.FindByClId(d.ClId)).Distinct();
            var epers2 = OPSdRows.Where(d => d.ClId2 != null).Select(d => ds.Persons.FindByClId(d.ClId2)).Distinct();
            var edoctyp = OPSdRows.Where(d => d.DocTyp != null).Select(d => ds.DocTyp.FindByid(d.DocTyp)).Distinct();
            var ecurr = OPSRows.Where(d => d.Cur != "EUR").Select(d => ds.Currency.FindByidDete(d.Cur, d.OPSdRow.Dete)).Where(d => d != null).Distinct();


            AcP1Rows = e11
                .Union(e21)
                .Union(e12)
                .Union(e22)
                .OrderBy(d => d.AC)
                .ToList();

            AcP3Rows = e13
                .Union(e23)
                .OrderBy(d => d.idx)
                .ToList();

            AcP4Rows = e14
                .Union(e24)
                .OrderBy(d => d.idx)
                .ToList();

            AcP5Rows = e15
                .Union(e25)
                .OrderBy(d => d.idx)
                .ToList();

            PersonsRows = epers1
                .Union(epers1)
                .OrderBy(d => d.ClId)
                .ToList();

            DocTypRows = edoctyp
                .OrderBy(d => d.id)
                .ToList();

            CurrencyRows = ecurr
                .OrderBy(d => d.Dete)
                .ThenBy(d => d.id)
                .ToList();
        }

        public void GetRowsFull()
        {
            var ds = MyData.DataSetKlons;
            OPSdRows = ds.OPSd.WhereNotDeleted()
                .OrderBy(d => d.Dete)
                .ThenBy(d => d.id)
                .ToList();

            OPSRows = ds.OPS.WhereNotDeleted()
                .OrderBy(d => d.OPSdRow.Dete)
                .ThenBy(d => d.OPSdRow.id)
                .ThenBy(d => d.id)
                .ToList();

            AcP1Rows = ds.AcP21
                .WhereNotDeleted()
                .OrderBy(d => d.AC)
                .ToList();

            AcP3Rows = ds.Acp23
                .WhereNotDeleted()
                .OrderBy(d => d.idx)
                .ToList();

            AcP4Rows = ds.AcP24
                .WhereNotDeleted()
                .OrderBy(d => d.idx)
                .ToList();

            AcP5Rows = ds.Acp25
                .WhereNotDeleted()
                .OrderBy(d => d.idx)
                .ToList();

            PersonsRows = ds.Persons
                .WhereNotDeleted()
                .OrderBy(d => d.ClId)
                .ToList();

            DocTypRows = ds.DocTyp
                .WhereNotDeleted()
                .OrderBy(d => d.id)
                .ToList();

            var ecurr = OPSRows.Where(d => d.Cur != "EUR").Select(d => ds.Currency.FindByidDete(d.Cur, d.OPSdRow.Dete)).Where(d => d != null).Distinct();
            CurrencyRows = ecurr
                .OrderBy(d => d.Dete)
                .ThenBy(d => d.id)
                .ToList();
        }

        public void GetTotalRowCount()
        {
            TotalRowCount = OPSRows.Count + AcP1Rows.Count + AcP3Rows.Count +
                AcP4Rows.Count + AcP5Rows.Count + PersonsRows.Count +
                DocTypRows.Count + CurrencyRows.Count;
        }

        public List<InfoRow> GetCounts()
        {
            var ret = new List<InfoRow>();
            ret.Add(new InfoRow("Dokumenti", OPSdRows.Count));
            ret.Add(new InfoRow("Ieraksti", OPSRows.Count));
            ret.Add(new InfoRow("Kontu plāns", AcP1Rows.Count));
            ret.Add(new InfoRow("Darijumu žurnāla pazīmes", AcP3Rows.Count));
            ret.Add(new InfoRow("Papildpazīmes", AcP4Rows.Count));
            ret.Add(new InfoRow("PVN pazīmes", AcP5Rows.Count));
            ret.Add(new InfoRow("Personas", PersonsRows.Count));
            ret.Add(new InfoRow("Dokumentu veidi", DocTypRows.Count));
            ret.Add(new InfoRow("Valūtas kursi", CurrencyRows.Count));
            return ret;
        }

        public List<InfoRow> GetCountsNone()
        {
            var ret = new List<InfoRow>();
            string[] titles = { "Ieraksti", "Kontu plāns", "Darijumu žurnāla pazīmes"
                    ,"Papildpazīmes", "PVN pazīmes", "Personas","Dokumentu veidi","Valūtas kursi"};
            for (int i = 0; i < titles.Length; i++)
            {
                var ir = new InfoRow(titles[i], 0);
                ret.Add(ir);
            }
            return ret;
        }

        public void ExportToXLS(WorkBookConfig wbc)
        {
            IEnumerable<DataRow>[] rowsets = { OPSRows, AcP1Rows, AcP3Rows
                    ,AcP4Rows, AcP5Rows, PersonsRows, DocTypRows, CurrencyRows};

            wbc.RowsDone = 0;
            for (int i = 0; i <= 7; i++)
            {
                wbc.SheetsConfig[i].MakeSheet(rowsets[i]);
                if (wbc.Cancel) return;
            }

        }

    }

    public enum ESheetTask
    {
        Ignore, AddNew, DoAll
    }

    public class InfoRow
    {
        public InfoRow(string caption, int count)
        {
            Caption = caption;
            Count = count;
        }

        public string Caption { get; set; } = null;
        public int Count { get; set; } = 0;
        public int CountNew { get; set; } = 0;
        public int CountExisting { get; set; } = 0;
        public int CountChanging { get; set; } = 0;
        public int CountBad { get; set; } = 0;
        public int Task { get; set; } = 2;

    }

    public enum EFieldType
    {
        Int, Int16, Single, Double, Decimal, String, Date, DateTime, Bool
    }

    public enum ERowKind
    {
        Ignore, New, Existing, Changing
    }

    public interface IFieldHelper
    {
        DataColumn GetDataColumn(string fieldname);
        object GetFieldValue(string fieldname, DataRow dr);
        void SetFieldValue(string fieldname, DataRow dr, object value);
    }

    public class FieldConfig
    {
        public int Index = 0;
        public string Caption = "";
        public string FieldName = "";
        public EFieldType FieldType = EFieldType.String;
        public int MaxLength = 0;
        public int WidthInChars = 10;
        public ICellStyle CellStyle = null;
        public bool AllowNull = false;

        public FieldConfig()
        {

        }

        public FieldConfig(string caption, string fieldname)
        {
            Caption = caption;
            FieldName = fieldname;
        }

        public IFieldHelper FieldHelper = null;

        public void ApplyFrom(DataTable table)
        {
            DataColumn cm = FieldHelper == null ? table.Columns[FieldName] : FieldHelper.GetDataColumn(FieldName);
            if (cm.DataType == typeof(int))
            {
                FieldType = EFieldType.Int;
            }
            else if (cm.DataType == typeof(Int16))
            {
                FieldType = EFieldType.Int16;
            }
            else if (cm.DataType == typeof(Single))
            {
                FieldType = EFieldType.Single;
            }
            else if (cm.DataType == typeof(double))
            {
                FieldType = EFieldType.Double;
            }
            else if (cm.DataType == typeof(decimal))
            {
                FieldType = EFieldType.Decimal;
            }
            else if (cm.DataType == typeof(string))
            {
                FieldType = EFieldType.String;
            }
            else if (cm.DataType == typeof(DateTime))
            {
                FieldType = EFieldType.Date;
            }
            else if (cm.DataType == typeof(bool))
            {
                FieldType = EFieldType.Bool;
            }
            else
            {
                throw new Exception("Bad field type.");
            }

            if (cm.DataType == typeof(string))
            {
                MaxLength = cm.MaxLength;
            }
            else
            {
                MaxLength = 0;
            }

            AllowNull = cm.AllowDBNull;
        }

        public void SetCellStyle(WorkBookConfig wbc)
        {
            switch (FieldType)
            {
                case EFieldType.Date:
                    CellStyle = wbc.CellStyleDate;
                    break;
                case EFieldType.DateTime:
                    CellStyle = wbc.CellStyleDateTime;
                    break;
                case EFieldType.Decimal:
                    CellStyle = wbc.CellStyleMoney;
                    break;
            }
        }

    }


    public class SheetConfig
    {
        public WorkBookConfig WBC { get; protected set; } = null;

        public List<FieldConfig> FieldsConfig = new List<FieldConfig>();

        public string SheetName { get; set; } = "";
        public int RowCount { get; set; } = 0;
        public int RowCountNew { get; set; } = 0;
        public int RowCountExisting { get; set; } = 0;
        public int RowCountChanging { get; set; } = 0;
        public int RowCountBad { get; set; } = 0;
        public ESheetTask Task { get; set; } = ESheetTask.AddNew;

        public SheetConfig(WorkBookConfig wbc)
        {
            WBC = wbc;
            Init();
        }

        public virtual FieldConfig AddSheetField(string caption, string fieldname,
            int width = 10,
            IFieldHelper fieldhelper = null)
        {
            var ret = new FieldConfig(caption, fieldname);
            ret.Index = FieldsConfig.Count;
            ret.WidthInChars = width;
            ret.FieldHelper = fieldhelper;
            FieldsConfig.Add(ret);
            return ret;
        }

        public void ApplyFrom(DataTable table)
        {
            foreach (var fc in FieldsConfig)
            {
                fc.ApplyFrom(table);
            }
        }

        public virtual void Init()
        {
        }

        public void SetCellValue(ICell cell, FieldConfig fc, object value)
        {
            if (value == DBNull.Value)
                cell.SetCellType(CellType.Blank);
            else
            {
                switch (fc.FieldType)
                {
                    case EFieldType.Int:
                        cell.SetCellValue((double)(int)value);
                        break;
                    case EFieldType.Int16:
                        cell.SetCellValue((double)(Int16)value);
                        break;
                    case EFieldType.Single:
                        cell.SetCellValue((double)(Single)value);
                        break;
                    case EFieldType.Double:
                        cell.SetCellValue((double)value);
                        break;
                    case EFieldType.Decimal:
                        cell.SetCellValue((double)(decimal)value);
                        break;
                    case EFieldType.String:
                        string s = (value == DBNull.Value) ? null : (string)value;
                        cell.SetCellValue(s);
                        break;
                    case EFieldType.DateTime:
                    case EFieldType.Date:
                        cell.SetCellValue((DateTime)value);
                        break;
                    case EFieldType.Bool:
                        cell.SetCellValue((bool)value);
                        break;
                }
            }
        }

        public string GetCellValue(ICell cell, FieldConfig fc, out object value)
        {
            value = null;
            if (cell.CellType == CellType.Error || cell.CellType == CellType.Unknown)
                return "Kļūdaina vērtība.";

            if (cell.CellType == CellType.Blank)
            {
                if (!fc.AllowNull) return "Nav norādīta vērtība.";
                if (fc.FieldType == EFieldType.String) value = null;
                else value = DBNull.Value;
                return "OK";
            }

            switch (fc.FieldType)
            {
                case EFieldType.Int:
                case EFieldType.Int16:
                case EFieldType.Single:
                case EFieldType.Double:
                case EFieldType.Decimal:
                    if (cell.CellType != CellType.Numeric)
                        return "Kļudains vērtības tips.";
                    break;
                case EFieldType.String:
                    if (cell.CellType != CellType.String)
                        return "Kļudains vērtības tips.";
                    break;
                case EFieldType.DateTime:
                case EFieldType.Date:
                    if (cell.CellType != CellType.Numeric)
                        return "Kļudains vērtības tips.";
                    break;
                case EFieldType.Bool:
                    if (cell.CellType != CellType.Boolean)
                        return "Kļudains vērtības tips.";
                    break;
            }
            try
            {

                switch (fc.FieldType)
                {
                    case EFieldType.Int:
                        value = (int)cell.NumericCellValue;
                        break;
                    case EFieldType.Int16:
                        value = (Int16)cell.NumericCellValue;
                        break;
                    case EFieldType.Single:
                        value = (Single)cell.NumericCellValue;
                        break;
                    case EFieldType.Double:
                        value = (double)cell.NumericCellValue;
                        break;
                    case EFieldType.Decimal:
                        value = (decimal)cell.NumericCellValue;
                        break;
                    case EFieldType.String:
                        string s = cell.StringCellValue.Zn();
                        value = s;
                        if (s != null && fc.MaxLength > 0 && s.Length > fc.MaxLength)
                            return "Teksta garums pārsniedz atļauto.";
                        break;
                    case EFieldType.DateTime:
                    case EFieldType.Date:
                        value = cell.DateCellValue;
                        break;
                    case EFieldType.Bool:
                        value = cell.BooleanCellValue;
                        break;
                }
            }
            catch (Exception)
            {
                return "Kļūdaina vērtība.";
            }
            return "OK";
        }

        public string GetBlancCellValue(FieldConfig fc, ref object value)
        {
            if (!fc.AllowNull) return "Nav norādīta vērtība.";
            if (fc.FieldType == EFieldType.String) value = null;
            else value = DBNull.Value;
            return "OK";
        }

        public virtual void SetCellStyle()
        {
            foreach (var fc in FieldsConfig)
            {
                fc.SetCellStyle(WBC);
            }
        }

        public void MakeSheet(IEnumerable<DataRow> rows)
        {
            ISheet sh1 = WBC.WB.CreateSheet(SheetName);
            var row0 = sh1.CreateRow(0);

            for (int i = 0; i < FieldsConfig.Count; i++)
            {
                var fc = FieldsConfig[i];
                var cell = row0.CreateCell(i);
                cell.CellStyle = WBC.CellStyleCations;
                cell.SetCellValue(FieldsConfig[i].Caption);
                sh1.SetColumnWidth(i, fc.WidthInChars * 256);

                if (fc.CellStyle != null)
                    sh1.SetDefaultColumnStyle(i, fc.CellStyle);
            }


            int ct = 1;
            foreach (var dr in rows)
            {
                var row = sh1.CreateRow(ct);
                ct++;
                for (int i = 0; i < FieldsConfig.Count; i++)
                {
                    var fc = FieldsConfig[i];
                    object value = null;
                    if (fc.FieldHelper == null)
                        value = dr[fc.FieldName];
                    else
                        value = fc.FieldHelper.GetFieldValue(fc.FieldName, dr);

                    var cell = row.CreateCell(i);

                    SetCellValue(cell, fc, value);
                }
                WBC.RowsDone++;
                WBC.OnProgress();
                if (WBC.Cancel) return;
            }

            sh1.CreateFreezePane(0, 1);
        }

        public int GetFieldIndex(string fieldname, int startindex = 0)
        {
            for (int i = startindex; i < FieldsConfig.Count; i++)
                if (FieldsConfig[i].FieldName == fieldname) return i;
            return -1;
        }

        public bool GetFieldIndex(string field1, string field2, out int ind1, out int ind2)
        {
            ind1 = 0;
            ind2 = FieldsConfig.Count - 1;
            if (field1 != null) ind1 = GetFieldIndex(field1);
            if (ind1 == -1) return false;
            if (field2 != null) ind2 = GetFieldIndex(field2, ind1 + 1);
            if (ind2 == -1) return false;
            return true;
        }

        public virtual bool EqualsDataRowFields(DataRow dr, object[] vr, int ind1 = 0, int ind2 = -1)
        {
            if (ind2 == -1) ind2 = FieldsConfig.Count - 1;
            if (ind1 < 0 || ind1 >= FieldsConfig.Count || ind2 < 0 || ind2 >= FieldsConfig.Count || ind2 < ind1)
                throw new ArgumentException("Bad index.");
            for (int i = ind1; i <= ind2; i++)
            {
                var fc = FieldsConfig[i];
                object drval = dr[fc.FieldName];
                object vval = vr[i];
                if (drval == DBNull.Value) drval = null;
                if (vval == DBNull.Value) vval = null;
                if (!object.Equals(drval, vval)) return false;
            }
            return true;
        }

        public virtual bool EqualsDataRowFieldsA(DataRow dr, object[] vr, string field1 = null, string field2 = null)
        {
            if(!GetFieldIndex(field1, field2, out int ind1, out int ind2))
                throw new ArgumentException("Bad field.");
            return EqualsDataRowFields(dr, vr, ind1, ind2);
        }

        public virtual void SetDataRowFields(DataRow dr, object[] vr, int ind1 = 0, int ind2 = -1)
        {
            if (ind2 == -1) ind2 = FieldsConfig.Count - 1;
            if (ind1 < 0 || ind1 >= FieldsConfig.Count || ind2 < 0 || ind2 >= FieldsConfig.Count || ind2 < ind1)
                throw new ArgumentException("Bad index.");

            if (EqualsDataRowFields(dr, vr, ind1, ind2)) return;

            dr.BeginEdit();
            for (int i = ind1; i <= ind2; i++)
            {
                var fc = FieldsConfig[i];
                dr[fc.FieldName] = vr[i];
            }
            dr.EndEdit();
        }

        public virtual void SetDataRowFieldsA(DataRow dr, object[] vr, string field1 = null, string field2 = null)
        {
            if (!GetFieldIndex(field1, field2, out int ind1, out int ind2))
                throw new ArgumentException("Bad field.");

            SetDataRowFields(dr, vr, ind1, ind2);
        }

        public virtual ERowKind GetRowKind(object[] valuerow)
        {
            return ERowKind.Ignore;
        }

        public virtual void Prepare()
        {

        }

        public virtual void UseRow(object[] valuerow)
        {

        }

        public int GetFirstCount()
        {
            ISheet sh1 = WBC.WB.GetSheet(SheetName);
            if (sh1 == null) return 0;
            return sh1.PhysicalNumberOfRows - 1;
        }

        public List<CellError> TestSheet()
        {
            RowCount = 0;
            RowCountNew = 0;
            RowCountExisting = 0;
            RowCountChanging = 0;
            RowCountBad = 0;

            var ret = new List<CellError>();
            ISheet sh1 = WBC.WB.GetSheet(SheetName);
            if (sh1 == null)
            {
                ret.Add(new CellError(SheetName, 0, 0, "Nav tādas lapas."));
                return ret;
            }
            if (sh1.PhysicalNumberOfRows == 0)
            {
                ret.Add(new CellError(SheetName, 0, 0, "Nav datu."));
                return ret;
            }

            RowCount = sh1.PhysicalNumberOfRows - 1;

            var row0 = sh1.GetRow(0);
            if (row0.Cells.Count != FieldsConfig.Count)
            {
                ret.Add(new CellError(SheetName, 0, 0, "Nekorekts kolonu skaits."));
                return ret;
            }

            for (int i = 0; i < FieldsConfig.Count; i++)
            {
                var fc = FieldsConfig[i];
                var cell = row0.Cells[i];
                if (cell.CellType != CellType.String || cell.StringCellValue != fc.Caption)
                    ret.Add(new CellError(SheetName, 0, i, "Nekorekts kolonnas nosaukums."));
            }

            if (ret.Count > 0) return ret;

            var valuerow = new object[FieldsConfig.Count];

            for (int i = 1; i < sh1.PhysicalNumberOfRows; i++)
            {
                var row = sh1.GetRow(i);
                if (row == null)
                {
                    ret.Add(new CellError(SheetName, i, 0, "Tukša rinda."));
                    return ret;
                }

                bool badrow = false;
                for (int j = 0; j < FieldsConfig.Count; j++)
                {
                    object value = null;
                    var fc = FieldsConfig[j];
                    var cell = row.GetCell(j);
                    string er = null;
                    if (cell == null)
                        er = GetBlancCellValue(fc, ref value);
                    else
                        er = GetCellValue(cell, fc, out value);
                    valuerow[j] = value;
                    if (er != "OK")
                    {
                        badrow = true;
                        ret.Add(new CellError(SheetName, i, j, er));
                    }
                }

                if (badrow)
                {
                    RowCountBad++;
                }
                else
                {
                    var rowkind = GetRowKind(valuerow);
                    switch (rowkind)
                    {
                        case ERowKind.New:
                            RowCountNew++;
                            break;
                        case ERowKind.Existing:
                            RowCountExisting++;
                            break;
                        case ERowKind.Changing:
                            RowCountChanging++;
                            break;
                    }
                }

                WBC.RowsDone++;
                WBC.OnProgress();
                if (WBC.Cancel) return ret;
            }

            return ret;
        }

        public string ReadSheet()
        {
            ISheet sh1 = WBC.WB.GetSheet(SheetName);
            var row0 = sh1.GetRow(0);
            var valuerow = new object[FieldsConfig.Count];

            Prepare();

            for (int i = 1; i < sh1.PhysicalNumberOfRows; i++)
            {
                var row = sh1.GetRow(i);
                for (int j = 0; j < FieldsConfig.Count; j++)
                {
                    object value = null;
                    var fc = FieldsConfig[j];
                    var cell = row.GetCell(j);
                    string er = null;
                    if (cell == null)
                        er = GetBlancCellValue(fc, ref value);
                    else
                        er = GetCellValue(cell, fc, out value);
                    valuerow[j] = value;
                    if (er != "OK")
                        return $"Sheet:{SheetName}, Row:{i}, col:{j}, {er}";
                }

                try
                {
                    UseRow(valuerow);
                }
                catch (Exception ex)
                {
                    return $"Sheet:{SheetName}, Row:{i}, {ex.Message}";
                }

                WBC.RowsDone++;
                WBC.OnProgress();
                if (WBC.Cancel) return "OK";
            }

            return "OK";
        }
    }

    public class CellError
    {
        public string SheetName { get; set; } = null;
        public int RowNr { get; set; } = -1;
        public int ColNr { get; set; } = -1;
        public string Error { get; set; } = null;

        public CellError(string sheetname, int rownr, int colnr, string error)
        {
            SheetName = sheetname;
            RowNr = rownr;
            ColNr = colnr;
            Error = error;
        }
    }

    public class OPSSheetConfig : SheetConfig, IFieldHelper
    {
        public OPSSheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public DataColumn GetDataColumn(string name)
        {
            return KlonsData.St.DataSetKlons.OPSd.Columns[name];
        }

        public object GetFieldValue(string fieldname, DataRow dr)
        {
            var dr_ops = dr as klonsDataSet.OPSRow;
            return dr_ops.OPSdRow[fieldname];
        }

        public void SetFieldValue(string fieldname, DataRow dr, object value)
        {
            var dr_ops = dr as klonsDataSet.OPSRow;
            dr_ops.OPSdRow[fieldname] = value;
        }

        public override void Init()
        {
            SheetName = "Ieraksti";
            AddSheetField("Dok.Id.", "DOCID", 6);
            AddSheetField("Ier.Id.", "ID", 6);
            AddSheetField("Nr.", "ZNR", 6, this);
            AddSheetField("Datums", "DETE", 11, this);
            AddSheetField("Dok.veids", "DOCTYP", 8, this);
            AddSheetField("Sērija", "DOCST", 6, this);
            AddSheetField("Dok.numurs", "DOCNR", 12, this);
            AddSheetField("Persona", "CLID", 15, this);
            AddSheetField("Apraksts", "DESCR", 50, this);
            AddSheetField("Summa", "SUMM", 11, this);
            AddSheetField("PVN", "PVN", 11, this);
            AddSheetField("Nor.persona", "CLID2", 15, this);
            AddSheetField("Nr.2", "NRX", 5, this);
            AddSheetField("Datums2", "DT2", 11, this);
            AddSheetField("Lietotājs", "ZU", 12, this);
            var fzdt = AddSheetField("Labojuma laiks", "ZDT", 18, this);

            AddSheetField("Debets", "AC11", 10);
            AddSheetField("D.n.p.", "AC12", 10);
            AddSheetField("D.iin", "AC13", 5);
            AddSheetField("D.kat.", "AC14", 10);
            AddSheetField("D.pvn", "AC15", 6);
            AddSheetField("Kredits", "AC21", 10);
            AddSheetField("K.n.p.", "AC22", 10);
            AddSheetField("K.iin", "AC23", 5);
            AddSheetField("K.kat.", "AC24", 10);
            AddSheetField("K.pvn", "AC25", 6);
            AddSheetField("Summa", "SUMMC", 11);
            AddSheetField("Valūta", "CUR", 5);
            AddSheetField("EUR", "SUMM", 11);
            AddSheetField("Daudzums", "QV", 8);
            AddSheetField("Apraksts", "DESCR", 20);

            ApplyFrom(KlonsData.St.DataSetKlons.OPS);
            fzdt.FieldType = EFieldType.DateTime;
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            return ERowKind.New;
        }

        private int lastXLSDocId = 0;
        private int lastOPSdId = 0;
        private bool haveLastDocId = false;

        public override void Prepare()
        {
            haveLastDocId = false;
        }

        public override void UseRow(object[] valuerow)
        {
            int docid = (int)valuerow[0];
            if (!haveLastDocId || docid != lastXLSDocId)
            {
                var dr_opsd = KlonsData.St.DataSetKlons.OPSd.NewOPSdRow();
                SetDataRowFieldsA(dr_opsd, valuerow, "ZNR", "DT2");
                dr_opsd.ZU = KlonsData.St.CurrentUserName;
                dr_opsd.ZDt = DateTime.Now;
                KlonsData.St.DataSetKlons.OPSd.Rows.Add(dr_opsd);

                lastXLSDocId = docid;
                lastOPSdId = dr_opsd.id;
                haveLastDocId = true;
            }

            var dr_ops = KlonsData.St.DataSetKlons.OPS.NewOPSRow();
            SetDataRowFieldsA(dr_ops, valuerow, "AC11", "DESCR");
            dr_ops.DocId = lastOPSdId;
            dr_ops.ZDt = DateTime.Now;
            KlonsData.St.DataSetKlons.OPS.Rows.Add(dr_ops);

        }


    }

    public class AC1SheetConfig : SheetConfig
    {
        public AC1SheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Kontu plāns";

            AddSheetField("Konts", "AC", 10);
            AddSheetField("Nosaukums", "NAME", 50);
            AddSheetField("Paz.np.", "ID1", 8);
            AddSheetField("Paz.2", "ID2", 8);

            ApplyFrom(KlonsData.St.DataSetKlons.AcP21);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.AcP21;
            string ac = (string)valuerow[0];
            var dr = table.FindByAC(ac);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.AcP21;
            string ac = (string)valuerow[0];
            var dr = table.FindByAC(ac);
            if(dr == null)
            {
                dr = table.NewAcP21Row();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }

    }

    public class AC3SheetConfig : SheetConfig
    {
        public AC3SheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Darijumu pazīmes";
            AddSheetField("Kods", "IDX", 5);
            AddSheetField("Nosaukums", "NAME", 50);

            ApplyFrom(KlonsData.St.DataSetKlons.Acp23);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            return ERowKind.Ignore;
        }

    }

    public class AC4SheetConfig : SheetConfig
    {
        public AC4SheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Papildpazīmes";
            AddSheetField("Kods", "IDX", 10);
            AddSheetField("Nosaukums", "NAME", 50);
            AddSheetField("Mērv.", "UNIT", 8);
            AddSheetField("Cena", "PRICE", 8);

            ApplyFrom(KlonsData.St.DataSetKlons.AcP24);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.AcP24;
            string idx = (string)valuerow[0];
            var dr = table.FindByidx(idx);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.AcP24;
            string idx = (string)valuerow[0];
            var dr = table.FindByidx(idx);
            if (dr == null)
            {
                dr = table.NewAcP24Row();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }

    }

    public class AC5SheetConfig : SheetConfig
    {
        public AC5SheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "PVN pazīmes";
            AddSheetField("Kods", "IDX", 8);
            AddSheetField("Nosaukums", "NAME", 50);

            ApplyFrom(KlonsData.St.DataSetKlons.Acp25);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Acp25;
            string idx = (string)valuerow[0];
            var dr = table.FindByidx(idx);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Acp25;
            string idx = (string)valuerow[0];
            var dr = table.FindByidx(idx);
            if (dr == null)
            {
                dr = table.NewAcp25Row();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }

    }

    public class PersonsSheetConfig : SheetConfig
    {
        public PersonsSheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Personas";
            AddSheetField("Kods", "CLID", 15);
            AddSheetField("Nosaukums", "NAME", 50);
            AddSheetField("Reģ.nr.", "REGNR", 13);
            AddSheetField("PVN reģ.nr.", "PVNREGNR", 16);
            AddSheetField("Veids", "TP", 5);
            AddSheetField("Fp/Jp", "TP2", 6);
            AddSheetField("PVN", "TP3", 5);
            AddSheetField("Jur.adrese", "ADDR", 30);
            AddSheetField("Fiz.adrese", "ADDR2", 30);
            AddSheetField("ATK", "ATK", 10);
            AddSheetField("Bankas kods", "BANKID", 10);
            AddSheetField("Bankas nosaukums", "BANK", 20);
            AddSheetField("Bankas konts", "BANKACC", 20);
            AddSheetField("Telefons", "PHONE", 10);

            ApplyFrom(KlonsData.St.DataSetKlons.Persons);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Persons;
            string clid = (string)valuerow[0];
            var dr = table.FindByClId(clid);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Persons;
            string clid = (string)valuerow[0];
            var dr = table.FindByClId(clid);
            if (dr == null)
            {
                dr = table.NewPersonsRow();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }

    }


    public class DocTypSheetConfig : SheetConfig
    {
        public DocTypSheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Dokumentu veidi";
            AddSheetField("Kods", "ID", 8);
            AddSheetField("Nosaukums", "NAME", 50);
            AddSheetField("Kods2", "ID1", 8);
            AddSheetField("PVN paz", "PVNPAZ", 8);

            ApplyFrom(KlonsData.St.DataSetKlons.DocTyp);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.DocTyp;
            string id = (string)valuerow[0];
            var dr = table.FindByid(id);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.DocTyp;
            string id = (string)valuerow[0];
            var dr = table.FindByid(id);
            if (dr == null)
            {
                dr = table.NewDocTypRow();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }
    }

    public class CurrencySheetConfig : SheetConfig
    {
        public CurrencySheetConfig(WorkBookConfig wbc) : base(wbc)
        {
        }

        public override void Init()
        {
            SheetName = "Valūtas kursi";
            AddSheetField("Kods", "ID", 6);
            AddSheetField("Datums", "DETE", 11);
            AddSheetField("Kurs", "RATE", 10);

            ApplyFrom(KlonsData.St.DataSetKlons.Currency);
        }

        public override ERowKind GetRowKind(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Currency;
            string id = (string)valuerow[0];
            DateTime dt = (DateTime)valuerow[1];
            var dr = table.FindByidDete(id, dt);
            if (dr == null) return ERowKind.New;
            if (EqualsDataRowFields(dr, valuerow)) return ERowKind.Existing;
            return ERowKind.Changing;
        }

        public override void UseRow(object[] valuerow)
        {
            var table = KlonsData.St.DataSetKlons.Currency;
            string id = (string)valuerow[0];
            DateTime dt = (DateTime)valuerow[1];
            var dr = table.FindByidDete(id, dt);
            if (dr == null)
            {
                dr = table.NewCurrencyRow();
                SetDataRowFields(dr, valuerow);
                table.Rows.Add(dr);
            }
            else
            {
                if (Task != ESheetTask.DoAll) return;
                SetDataRowFields(dr, valuerow);
            }
        }

    }

    public class WorkBookConfig
    {
        public IWorkbook WB { get; protected set; }
        public Stream Stream = null;

        public List<SheetConfig> SheetsConfig = null;

        public ICellStyle CellStyleCations = null;
        public ICellStyle CellStyleMoney = null;
        public ICellStyle CellStyleDate = null;
        public ICellStyle CellStyleDateTime = null;

        public bool Cancel = false;
        public int RowsDone = 0;

        public int RowCount = 0;
        public int RowCountNew = 0;
        public int RowCountExisting = 0;
        public int RowCountChanging = 0;
        public int RowCountBad = 0;

        public bool ImportDone = false;

        public event EventHandler ProgressChanged;

        public WorkBookConfig()
        {
            WB = new HSSFWorkbook();
            InitSheetsConfig();
        }

        public WorkBookConfig(Stream sr)
        {
            WB = new HSSFWorkbook(sr);
            Stream = sr;
            InitSheetsConfig();
        }

        public void InitSheetsConfig()
        {
            SheetsConfig = new List<SheetConfig>();
            SheetsConfig.Add(new OPSSheetConfig(this));
            SheetsConfig.Add(new AC1SheetConfig(this));
            SheetsConfig.Add(new AC3SheetConfig(this));
            SheetsConfig.Add(new AC4SheetConfig(this));
            SheetsConfig.Add(new AC5SheetConfig(this));
            SheetsConfig.Add(new PersonsSheetConfig(this));
            SheetsConfig.Add(new DocTypSheetConfig(this));
            SheetsConfig.Add(new CurrencySheetConfig(this));
        }

        public void InitCellStyles()
        {
            if (WB == null) throw new Exception("No workbook.");
            var dataformat = WB.CreateDataFormat();
            var boldfont = WB.CreateFont();
            boldfont.IsBold = true;

            CellStyleCations = WB.CreateCellStyle();
            CellStyleMoney = WB.CreateCellStyle();
            CellStyleDate = WB.CreateCellStyle();
            CellStyleDateTime = WB.CreateCellStyle();

            CellStyleCations.SetFont(boldfont);
            CellStyleMoney.DataFormat = dataformat.GetFormat("# ##0.00;-# ##0.00");
            CellStyleDate.DataFormat = dataformat.GetFormat("yyyy.MM.dd");
            CellStyleDateTime.DataFormat = dataformat.GetFormat("yyyy.MM.dd hh:mm");

            foreach (var shc in SheetsConfig)
            {
                shc.SetCellStyle();
            }
        }

        public void OnProgress()
        {
            if (ProgressChanged != null)
                ProgressChanged(this, new EventArgs());
        }

        public int GetFirstCount()
        {
            int ret = 0;
            foreach (var shc in SheetsConfig)
            {
                ret += shc.GetFirstCount();
            }
            return ret;
        }

        public void GetCount()
        {
            RowCount = 0;
            RowCountNew = 0;
            RowCountExisting = 0;
            RowCountChanging = 0;
            RowCountBad = 0;
            foreach (var sh in SheetsConfig)
            {
                if (sh.Task == ESheetTask.Ignore) continue;
                RowCount += sh.RowCount;
                RowCountNew += sh.RowCountNew;
                RowCountExisting += sh.RowCountExisting;
                RowCountChanging += sh.RowCountChanging;
                RowCountBad += sh.RowCountBad;
            }
        }

        public int GetUpdateCount()
        {
            int ct = 0;
            foreach (var sh in SheetsConfig)
            {
                if (sh.Task == ESheetTask.Ignore) continue;
                ct += sh.RowCountNew;
                if (sh.Task == ESheetTask.DoAll) ct += sh.RowCountChanging;
            }
            return ct;
        }

        public List<InfoRow> GetCountA()
        {
            var ret = new List<InfoRow>();
            string[] titles = { "Ieraksti", "Kontu plāns", "Darijumu žurnāla pazīmes"
                    ,"Papildpazīmes", "PVN pazīmes", "Personas","Dokumentu veidi","Valūtas kursi"};
            for (int i = 0; i < titles.Length; i++)
            {
                var shc = SheetsConfig[i];
                var ir = new InfoRow(titles[i], shc.RowCount)
                {
                    CountNew = shc.RowCountNew,
                    CountExisting = shc.RowCountExisting,
                    CountChanging = shc.RowCountChanging,
                    CountBad = shc.RowCountBad
                };
                ret.Add(ir);
            }
            return ret;
        }

        public List<CellError> TestXLS()
        {
            var ret = new List<CellError>();
            RowsDone = 0;
            for (int i = 0; i <= 7; i++)
            {
                var shc = SheetsConfig[i];
                var er = shc.TestSheet();
                ret.AddRange(er);
                if (Cancel) return ret;
            }
            return ret;
        }

        public string ImportXLS()
        {
            RowsDone = 0;
            int[] ord = { 1, 2, 3, 4, 5, 6, 7, 0 };
            for (int i = 0; i <= 7; i++)
            {
                int j = ord[i];
                var shc = SheetsConfig[j];
                if (shc.Task == ESheetTask.Ignore) continue;
                string er = null;
                try
                {
                    er = shc.ReadSheet();
                }
                catch (Exception ex)
                {
                    return $"Sheet:{shc.SheetName}, {ex.ToString()}";
                }
                if (er != "OK") return er;
                if (Cancel) return "OK";
            }
            return "OK";
        }

    }

}
