using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using KlonsLIB.MySourceGrid;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
    public class SharedControlDef : IComponent, IDisposable
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

        [DefaultValue(EMyGridRowType.None)]
        public virtual EMyGridRowType EditorType { get; protected set; } = EMyGridRowType.None;

        [DefaultValue(EMyGridRowValueType.None)]
        public virtual EMyGridRowValueType RowValueTeyp { get; set; } = EMyGridRowValueType.None;


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
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

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
