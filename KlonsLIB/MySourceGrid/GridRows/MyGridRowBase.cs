using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceGrid.Cells;

namespace KlonsLIB.MySourceGrid.GridRows
{
    public enum EMyGridRowType
    {
        None, Title, SubTitle, TextBox, ComboBox, Control, CheckBox, Command
    }
    public enum EMyGridRowValueType
    {
        None, String, Integer, IntegerN, ShortInt, Single, Double, Date, DateN,
        Decimal, DecimalN
    }
    public enum EMyGridRowTypeX
    {
        None, Title, TextBox, ComboBox, Control
    }

    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public class MyGridRowBase : IComponent, IDisposable
    {
        private string name = null;

        [Browsable(false)]
        public string Name
        {
            get
            {
                if (this.Site != null && !string.IsNullOrEmpty(this.Site.Name))
                    this.name = this.Site.Name;
                return this.name;
            }
            set
            {
                string b = this.name;
                this.name = !string.IsNullOrEmpty(value) ? value : string.Empty;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MyGridRowList Owner { get; set; } = null;
        public string RowTitle { get; set; } = null;

        [Category("Misc")]
        public string TypeName { get { return this.GetType().Name; } }

        [DefaultValue(EMyGridRowType.None)]
        public virtual EMyGridRowType RowType { get; protected set; } = EMyGridRowType.None;

        [DefaultValue(EMyGridRowValueType.None)]
        public virtual EMyGridRowValueType RowValueType { get; set; } = EMyGridRowValueType.None;

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public SourceGrid.GridRow GridRow = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MyGrid Grid {get; protected set;} = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object Value { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowNr = -1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ColNr = -1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int RowHeaderColumnNr => Grid.RowHeadersUsed ? ColNr : -1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int CaptionColumnNr => Grid.RowHeadersUsed ? ColNr + 1 : ColNr;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int DataColumnNr => Grid.RowHeadersUsed ? ColNr + 2 : ColNr + 1;

        public MyGridRowBase()
        {
            RowType = EMyGridRowType.None;
            RowValueType = EMyGridRowValueType.None;
        }
        public MyGridRowBase(string name, string title)
        {
            Name = name;
            RowTitle = title;
        }

        public Type GetValueType()
        {
            switch (RowValueType)
            {
                case EMyGridRowValueType.String:
                    return typeof(string);
                case EMyGridRowValueType.Integer:
                    return typeof(int);
                case EMyGridRowValueType.IntegerN:
                    return typeof(int?);
                case EMyGridRowValueType.ShortInt:
                    return typeof(Int16);
                case EMyGridRowValueType.Single:
                    return typeof(Single);
                case EMyGridRowValueType.Double:
                    return typeof(double);
                case EMyGridRowValueType.Date:
                    return typeof(DateTime);
                case EMyGridRowValueType.DateN:
                    return typeof(DateTime?);
                case EMyGridRowValueType.Decimal:
                    return typeof(decimal);
                case EMyGridRowValueType.DecimalN:
                    return typeof(decimal?);
            }
            return null;
        }

        public virtual object GetDefaultValue()
        {
            switch (RowValueType)
            {
                case EMyGridRowValueType.String:
                    return (string) null;
                case EMyGridRowValueType.Integer:
                    return (int) 0;
                case EMyGridRowValueType.IntegerN:
                    return (int?)null;
                case EMyGridRowValueType.ShortInt:
                    return (Int16) 0;
                case EMyGridRowValueType.Single:
                    return 0.0f;
                case EMyGridRowValueType.Double:
                    return 0.0d;
                case EMyGridRowValueType.Date:
                    return DateTime.Today;
                case EMyGridRowValueType.DateN:
                    return (DateTime?)null;
                case EMyGridRowValueType.Decimal:
                    return 0.0M;
                case EMyGridRowValueType.DecimalN:
                    return (decimal?)null;
            }
            return null;
        }

        public virtual int GetRowCount()
        {
            return 1;
        }

        public virtual Cell MakeDataCell()
        {
            return null;
        }

        public virtual void MakeRow(SourceGrid.GridRow gridrow, int colnr)
        {
            RowNr = gridrow.Index;
            ColNr = colnr;
            Grid = gridrow.Grid as MyGrid;
        }

        public virtual void MakeTemplateRow(MyGrid grid)
        {
            this.Grid = grid;
        }

        public virtual void LinkRow()
        {
        }
        public virtual void UnLinkRow()
        {
        }
        public virtual void UpdateDataCell()
        {
        }

        public virtual void MakeFirstCell(uint addpos = 0)
        {
            var grid = Grid;
            int i = RowNr + (int)addpos;
            grid[i, RowHeaderColumnNr] = new SourceGrid.Cells.Cell("");
            grid[i, RowHeaderColumnNr].View = grid.gridViewModel.rowHeaderModel;
            grid[i, RowHeaderColumnNr].AddController(RowMarkCellController.Default);
        }

        public virtual SourceGrid.Cells.Cell MakeCaptionCell()
        {
            var grid = Grid;
            int i = RowNr;
            var newcell = new SourceGrid.Cells.Cell(RowTitle);
            grid[i, CaptionColumnNr] = newcell;
            newcell.View = grid.gridViewModel.captionModel;
            return newcell;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool CanBeMarked
        {
            get { return false; }
        }

        private ISite site = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISite Site
        {
            get { return site; }
            set { site = value; }
        }

        public event EventHandler Disposed;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    lock (this)
                    {
                        if (this.site != null && this.site.Container != null)
                        {
                            this.site.Container.Remove(this);
                        }

                        if (this.Disposed != null)
                        {
                            this.Disposed(this, EventArgs.Empty);
                        }
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
