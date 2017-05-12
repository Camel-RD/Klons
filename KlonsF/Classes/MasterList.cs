using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;
using KlonsLIB.Misc;

namespace KlonsF.Classes
{
    public class MasterEntry
    {
        [XmlAttribute]
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Descr { get; set; }
        public string ConnStr { get; set; }
        public string Path { get; set; }

        public MasterEntry()
        {
            Clear();
        }
        public MasterEntry(MasterEntry me)
        {
            CopyFrom(me);
        }

        public void Clear()
        {
            Name = "";
            FileName = "";
            Descr = "";
            ConnStr = "";
            Path = "";
        }
        public void CopyFrom(MasterEntry me)
        {
            Name = me.Name;
            FileName = me.FileName;
            Descr = me.Descr;
            ConnStr = me.ConnStr;
            Path = me.Path;
        }
        public bool Equals(MasterEntry me)
        {
            return Name == me.Name &&
                FileName == me.FileName &&
                Descr == me.Descr &&
                ConnStr == me.ConnStr &&
                Path == me.Path;
        }

    }

    public class ConnectionStringTemplate
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Template { get; set; }
    }

    public class MasterList
    {
        public BindingList<ConnectionStringTemplate> TemplateList = new BindingList<ConnectionStringTemplate>();
        public BindingList<MasterEntry> ConnectionList = new BindingList<MasterEntry>();

        public MasterEntry GetMasterEntryByName(string name)
        {
            foreach (var me in ConnectionList)
            {
                if (me.Name == name) return me;
            }
            return null;
        }
        public string GetTemplateByName(string name)
        {
            foreach (var te in TemplateList)
            {
                if (te.Name == name) return te.Template;
            }
            return null;
        }

        public string[] GetTemplateNames()
        {
            int k = TemplateList.Count;
            string[] connStrNames = new string[k];
            for (int i = 0; i < k; i++)
                connStrNames[i] = TemplateList[i].Name;
            Array.Sort(connStrNames);
            return connStrNames;
        }

        public static MasterList LoadList(string filename)
        {
            MasterList list = new MasterList();
            if (!File.Exists(filename)) return list;
            XmlSerializer xs = null;
            FileStream fs = null;
            try
            {
                //xs = new XmlSerializer(typeof(MasterList));
                xs = Utils.CreateDefaultXmlSerializer(typeof(MasterList));
                fs = new FileStream(filename, FileMode.Open);
                list = (MasterList)xs.Deserialize(fs);
                return list;
            }
            catch (Exception)
            {
                //LogError(e.Message);
                list = new MasterList();
                return list;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        public void SaveList(string filename)
        {
            //XmlSerializer xs = new XmlSerializer(typeof(MasterList));
            XmlSerializer xs = Utils.CreateDefaultXmlSerializer(typeof(MasterList));
            TextWriter wr = null;
            try
            {
                wr = new StreamWriter(filename);
                xs.Serialize(wr, this);
            }
            catch (Exception)
            {
                //LogError(e.Message);
            }
            finally
            {
                if (wr != null) wr.Close();
            }
        }

    }
}
