using System.ComponentModel;
using System.Reflection;
using KlonsLIB.Components;
using DataObjectsP;

namespace KlonsP.Classes
{
    public class CompanyData : DataObjectsP.CompanyData
    {
        private KlonsData MyData => KlonsData.St;

        public void LoadData()
        {
            PropertyInfo[] pri = this.GetType().GetProperties();
            foreach (var pr in pri)
            {
                if (!pr.Name.StartsWith("_")) continue;
                var param_name = pr.Name.Substring(1);
                var param_value = MyData.Params.GetParamStr(param_name);
                pr.SetValue(this, param_value, null);
            }
        }

        public void SaveData()
        {
            PropertyInfo[] pri = this.GetType().GetProperties();
            foreach (var pr in pri)
            {
                if (!pr.Name.StartsWith("_")) continue;
                var param_name = pr.Name.Substring(1);
                var param_value = (string)pr.GetValue(this, null);
                MyData.Params.SetParamStr(param_name, param_value);
            }
        }
    }
}
