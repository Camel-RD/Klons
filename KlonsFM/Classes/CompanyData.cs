using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KlonsFM.Classes;
using KlonsFM.DataSets;
using KlonsLIB.Components;

namespace KlonsFM.Classes
{
    [TypeConverter(typeof(PropertySorter))]
    public class CompanyData
    {
        private const string catParUzņ = "Par uzņēmumu";
        private const string catAdrese = "Adrese";
        private const string catVaditajs = "Vadītājs";
        private const string catGramatv = "Grāmatvedis";
        private const string catBanka = "Bankas dati";

        [CustomSortedCategory(catParUzņ, 1, 5)]
        [PropertyOrder(101)]
        [DisplayName("Uzņēmuma nosaukums")]
        public string CompName { get; set; }

        [CustomSortedCategory(catParUzņ, 1, 5)]
        [PropertyOrder(102)]
        [DisplayName("Reģ.nr. UR")]
        public string CompRegNr { get; set; }

        [CustomSortedCategory(catParUzņ, 1, 5)]
        [PropertyOrder(103)]
        [DisplayName("PVN Reģ.nr.")]
        public string CompRegNrPVN { get; set; }

        [CustomSortedCategory(catParUzņ, 1, 5)]
        [PropertyOrder(104)]
        [DisplayName("VID nodaļa")]
        public string CompVID { get; set; }

        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(201)]
        [DisplayName("Pilna adrese")]
        public string CompAddr { get; set; }

        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(202)]
        [DisplayName("Pasta indeks")]
        public string CompAddrInd { get; set; }

        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(203)]
        [DisplayName("Adrese: rinda 1")]
        public string CompAddr1 { get; set; }

        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(204)]
        [DisplayName("Adrese: rinda 2")]
        public string CompAddr2 { get; set; }
        
        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(205)]
        [DisplayName("Adrese: rinda 3")]
        public string CompAddr3 { get; set; }
        
        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(206)]
        [DisplayName("Adrese: rinda 4")]
        public string CompAddr4 { get; set; }

        [CustomSortedCategory(catAdrese, 2, 5)]
        [PropertyOrder(207)]
        [DisplayName("Preču izsn. adrese")]
        public string CompAddrG { get; set; }

        [CustomSortedCategory(catVaditajs, 3, 5)]
        [PropertyOrder(301)]
        [DisplayName("Vārds, uzvārds")]
        public string CompMName { get; set; }

        [CustomSortedCategory(catVaditajs, 3, 5)]
        [PropertyOrder(302)]
        [DisplayName("Personas kods")]
        public string CompMpk { get; set; }

        [CustomSortedCategory(catVaditajs, 3, 5)]
        [PropertyOrder(303)]
        [DisplayName("Telefona nr.")]
        public string CompPhone { get; set; }

        [CustomSortedCategory(catGramatv, 4, 5)]
        [PropertyOrder(401)]
        [DisplayName("Vārds, uzvārds")]
        public string CompAccName { get; set; }

        [CustomSortedCategory(catGramatv, 4, 5)]
        [PropertyOrder(402)]
        [DisplayName("Telefona nr.")]
        public string CompAccPh { get; set; }


        [CustomSortedCategory(catBanka, 5, 5)]
        [PropertyOrder(501)]
        [DisplayName("Kods")]
        public string BankId { get; set; }

        [CustomSortedCategory(catBanka, 5, 5)]
        [PropertyOrder(502)]
        [DisplayName("Nosaukums")]
        public string BankName { get; set; }

        [CustomSortedCategory(catBanka, 5, 5)]
        [PropertyOrder(503)]
        [DisplayName("Konts")]
        public string BankAcc { get; set; }

        private KlonsData MyData {get { return KlonsData.St; }}

        public void LoadData()
        {
            PropertyInfo[] pri = this.GetType().GetProperties();
            foreach (var pr in pri)
            {
                pr.SetValue(this, (string)MyData.Params.GetParamStr(pr.Name), null);
            }
        }

        public void SaveData()
        {
            PropertyInfo[] pri = this.GetType().GetProperties();
            foreach (var pr in pri)
            {
                MyData.Params.SetParamStr(pr.Name, (string)pr.GetValue(this, null));
            }
        }
    }
}
