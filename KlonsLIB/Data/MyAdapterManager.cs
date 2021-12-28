using System;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using KlonsLIB.Components;
using KlonsLIB.Misc;
using KlonsLIB.Forms;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace KlonsLIB.Data
{
    [TypeConverter(typeof (MyAdapterManagerTypeConverter))]
    public class MyAdapterManager : Component, IMyPropertyValueListProvider, ISupportInitialize
    {
        private string myDataSource = null;
        private object tableAdapterManager = null;

        private const string adapterClassSuffix = "TableAdapter";
        private const string adapterManagerClassSuffix = "TableAdapterManager";

        private MyAdapterManagerItemPropertyDescriptor[] props = null;

        public MyAdapterManager()
        {
            props = new MyAdapterManagerItemPropertyDescriptor[20];
            for (int i = 0; i < props.Length; i++)
            {
                props[i] = new MyAdapterManagerItemPropertyDescriptor("Table_" + i, i, this);
                props[i]._ComponentType = typeof (MyAdapterManager);
            }
        }

        public event EventHandler MyUpdateAll;

        private string[] tableNames = new string[1] {null};
        private object[] adapters = new object[1] {null};

        [Browsable(false)]
        public string[] TableNames
        {
            get
            {
                return tableNames;
            }
            set
            {
                CheckAdapter(value);
            }
        }

        public MyAdapterManagerItemPropertyDescriptor[] GetProps()
        {
            if (tableNames == null) return null;
            var pr = new MyAdapterManagerItemPropertyDescriptor[tableNames.Length];
            for (int i = 0; i < tableNames.Length; i++)
            {
                pr[i] = props[i];
            }
            return pr;
        }


        [DefaultValue("")]
        [Category("Data")]
        [Editor(typeof (MyDropDownPropertyEditor), typeof (UITypeEditor))]
        public string MyDataSource
        {
            get { return myDataSource; }
            set
            {
                if (value == myDataSource) return;
                tableAdapterManager = null;
                if (string.IsNullOrEmpty(value))
                {
                    CheckAdapter(null);
                }
                DataSet ds = KlonsDataModule.St.GetDataSet(value);
                if (ds == null) return;
                DataSetHelper dh = KlonsDataModule.St.GetDataSetHelper(ds);
                if (dh == null) return;
                tableAdapterManager = dh.GetNewTableAdapterManager();
                myDataSource = value;

                CheckAdapter(tableNames);
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet MyDataSet
        {
            get { return KlonsDataModule.St.GetDataSet(myDataSource); }
        }

        private void ClearAdapterManager()
        {
            if (tableAdapterManager == null) return;
            var pr = TypeDescriptor.GetProperties(tableAdapterManager)
                .Cast<PropertyDescriptor>()
                .Where(p => p.Name.EndsWith(adapterClassSuffix));
            foreach (var p in pr)
            {
                p.SetValue(tableAdapterManager, null);
            }
            for (int i = 0; i < adapters.Length; i++)
            {
                adapters[i] = null;
            }
        }

        private void SetAdapterInManager(string classname, object value)
        {
            if (tableAdapterManager == null) return;
            Utils.SetProperty(tableAdapterManager, classname, value);
        }

        public object GetAdapterManager()
        {
            return tableAdapterManager;
        }

        private object GetAdapterInManager(string classname)
        {
            if (tableAdapterManager == null) return null;
            return Utils.GetProperty(tableAdapterManager, classname);
        }

        private bool HasAdapterInManager(string classname)
        {
            if (tableAdapterManager == null) return false;
            return Utils.HasProperty(tableAdapterManager, classname);
        }

        public void OnChanged()
        {
            if (!DesignMode) return;
            if (this.Site == null) return;
            var ss = this.Site.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (ss == null) return;
            ss.OnComponentChanged(this, null, null, null);
            
        }

        public void CheckAdapter(string[] newtablenames)
        {
            CheckAdapterA(newtablenames);
        }

        public void CheckAdapterA(string[] newtablenames)
        {
            ClearAdapterManager();
            if (newtablenames == null || newtablenames.Length == 0)
            {
                tableNames = new string[1] { null };
                adapters = new object[1] { null };
                return;
            }

            List<string> newnames = new List<string>();
            int i, k = newtablenames.Length;
            if (k > 20) k = 20;
            for (i = 0; i < newtablenames.Length; i++)
            {
                var s = newtablenames[i];
                if (string.IsNullOrEmpty(s)) continue;
                if (newnames.Contains(s)) continue;
                newnames.Add(s);
            }
            newnames.Add(null);

            tableNames = newnames.ToArray();
            adapters = new object[newnames.Count];

            if (tableAdapterManager == null)
            {
                return;
            }

            DataSetHelper dh = KlonsDataModule.St.GetDataSetHelper(MyDataSet);
            if (dh == null)
            {
                return;
            }

            for (i = 0; i < tableNames.Length; i++)
            {
                var s = tableNames[i];
                if (s == null) continue;
                if (!this.DesignMode)
                {
                    var ad = dh.GetDataAdapter(s);
                    adapters[i] = ad;
                    SetAdapterInManager(GetAdapterClassName(s), ad);
                    if (ad == null)
                    {
                        MessageBox.Show("Table adapter not found for: " + s,"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetAdapterClassName(string tablename)
        {
            if (tableAdapterManager == null) return null;
            return tablename + adapterClassSuffix;
        }

        public bool UpdateAll(bool bthrow = false)
        {
            if (tableAdapterManager == null) return false;
            DataSet ds = MyDataSet;
            if (ds == null) return false;
            try
            {
                if (MyUpdateAll != null)
                    MyUpdateAll(this, new EventArgs());
                else
                    Utils.CallMethod(tableAdapterManager, "UpdateAll", ds);
                return true;
            }
            catch (TargetInvocationException e)
            {
                Exception e1 = null;
                e1 = e.InnerException == null ? e : e.InnerException;
                var e2 = new MyException("Neizdevās saglabāt izmaiņas.", e1);
                if (bthrow)
                {
                    throw e1;
                }
                else
                {
                    Form_Error.ShowException(e1);
                }
            }
            return false;
        }

        public bool HasChanges()
        {
            int k1, k2, k3;
            GetStats(out k1, out k2, out k3);
            return (k1 + k2 + k3) > 0;
        }

        public string GetStats()
        {
            int kmod, kadd, kdel;
            GetStats(out kadd, out kmod, out kdel);

            return string.Format(
                "mainīti - {0},  jauni - {1},  dzēsti - {2}"
                , kmod, kadd, kdel);
        }

        public void GetStats(out int added, out int modified, out int deleted)
        {
            added = 0;
            modified = 0;
            deleted = 0;
            int kadd, kmod, kdel;
            var ds = MyDataSet;
            if (ds == null) return;
            foreach(var tablename in TableNames)
            {
                var table = ds.Tables[tablename];
                DataSetHelper.GetStats(table, out kadd, out kmod, out kdel);
                added += kadd;
                modified += kmod;
                deleted += kdel;
            }
        }

        string[] IMyPropertyValueListProvider.GetPropertyValueList(string propname)
        {
            if (propname == "MyDataSource")
            {
                return KlonsDataModule.GetAllDataSetNames();
            }
            if (propname.StartsWith("Table") || !string.IsNullOrEmpty(MyDataSource))
            {
                return KlonsDataModule.St.GetTableNames(MyDataSource);
            }
            return null;
        }

        private bool initialized = false;
        void ISupportInitialize.BeginInit()
        {
            initialized = false;
        }

        void ISupportInitialize.EndInit()
        {
            initialized = true;
        }

        #region -------- IComponent
        /*
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

        private ISite site = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ISite Site
        {
            get { return site; }
            set { site = value; }
        }
        */
        #endregion -------- IComponent

    }

    public class MyAdapterManagerItemPropertyDescriptor : PropertyDescriptor
    {
        public int Index { get; set; } = -1;
        public Type _ComponentType { get; set; } = null;

        public MyAdapterManager MyAdapterManager = null;

        private static DesignerSerializationVisibilityAttribute atr1 =
            new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden);

        private static EditorAttribute attr2 = new EditorAttribute(typeof (MyDropDownPropertyEditor),typeof (UITypeEditor));
        private static DefaultValueAttribute attr3 = new DefaultValueAttribute("");
        private static CategoryAttribute attr4 = new CategoryAttribute("Tables");
        private static RefreshPropertiesAttribute attr5 = RefreshPropertiesAttribute.All;
        public MyAdapterManagerItemPropertyDescriptor(string name,
            int index, MyAdapterManager am)
            : base(name, new Attribute[] { atr1, attr2, attr3, attr4, attr5 })
        {
            Index = index;
            MyAdapterManager = am;
        }

        public override Type ComponentType
        {
            get { return _ComponentType; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return typeof (string); }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            if (MyAdapterManager == null || Index < 0 ||
                MyAdapterManager.TableNames == null ||
                MyAdapterManager.TableNames.Length <= Index) return null;
            return MyAdapterManager.TableNames[Index];
        }

        public override void ResetValue(object component)
        {
            SetValue(component, null);
        }

        public override void SetValue(object component, object value)
        {
            if (MyAdapterManager == null || Index < 0 ||
                MyAdapterManager.TableNames == null ||
                MyAdapterManager.TableNames.Length <= Index)
                return;
            MyAdapterManager.TableNames[Index] = value as string;
            MyAdapterManager.CheckAdapter(MyAdapterManager.TableNames);
            MyAdapterManager.OnChanged();
            TypeDescriptor.Refresh(MyAdapterManager);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }

    public class MyAdapterManagerTypeConverter : TypeConverter
    {
        public MyAdapterManagerTypeConverter()
        {
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
            Attribute[] attributes)
        {
            var pr1 = TypeDescriptor.GetProperties(value as MyAdapterManager, attributes)
                .Cast<PropertyDescriptor>();
            var m = context.Instance as MyAdapterManager;
            if (m != null)
            {
                var pr2 = m.GetProps();
                if (pr2 != null)
                {
                    pr1 = pr1.Concat(pr2);
                }
            }

            return new PropertyDescriptorCollection(pr1.ToArray());

        }

    }
}