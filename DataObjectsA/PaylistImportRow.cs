using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsA
{
    public class PaylistImportRow : INotifyPropertyChanged
    {
        public int SBR { get; set; } = 0;
        public DateTime? Date { get; set; } = null;
        public int? IDP { get; set; } = null;
        public int? IDAM { get; set; } = null;
        public string Name { get; set; } = null;
        public string RegNr { get; set; } = null;
        public decimal Amount { get; set; } = 0M;

        public event PropertyChangedEventHandler PropertyChanged;
    }

}

