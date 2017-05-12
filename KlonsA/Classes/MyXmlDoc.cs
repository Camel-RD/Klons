using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsA.Classes
{
    public class MyXmlDoc : XmlDocument
    {
        public MyXmlDoc()
        {
            XmlDeclaration xmldecl = CreateXmlDeclaration("1.0", null, null);
            AppendChild(xmldecl);
        }

        public string Save()
        {
            FileDialog fd = new SaveFileDialog();
            var folder = KlonsData.St.Params.RepFolder;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fd.InitialDirectory = folder;
            fd.DefaultExt = "xml";
            fd.Filter = "XML faili (*.xml)|*.xml";
            if (fd.ShowDialog(KlonsData.St.MyMainForm) != DialogResult.OK) return null;
            KlonsData.St.Params.RepFolder = Path.GetDirectoryName(fd.FileName);
            try
            {
                Save(fd.FileName);
                return fd.FileName;
            }
            catch (Exception e)
            {
                MyException e1 = new MyException("Neizdevās saglabāt atskaiti.", e);
                Form_Error.ShowException(KlonsData.St.MyMainForm, e1);
                return null;
            }
        }

        public string FormatXMLDateTime(DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:00");
        }

        public string FormatXMLDate(DateTime value)
        {
            return value.ToString("yyyy-MM-dd");
        }

        public XmlElement XE(string name, string text)
        {
            XmlElement el = CreateElement(name);
            XmlText tx = CreateTextNode(text);
            el.AppendChild(tx);
            return el;
        }
        public XmlElement XE(string name, decimal value)
        {
            string text = value.ToString("0.00");
            return XE(name, text);
        }
        public XmlElement XE(string name, int value)
        {
            return XE(name, value.ToString());
        }
        public XmlElement XE(string name, DateTime value, bool withtime = false)
        {
            if (withtime)
                return XE(name, FormatXMLDateTime(value));
            else
                return XE(name, FormatXMLDate(value));
        }
        public XmlElement XE(XmlNode parent, string name, string text)
        {
            XmlElement el = XE(name, text);
            parent.AppendChild(el);
            return el;
        }
        public XmlElement XE(XmlNode parent, string name, decimal value)
        {
            XmlElement el = XE(name, value);
            parent.AppendChild(el);
            return el;
        }
        public XmlElement XE(XmlNode parent, string name, int value)
        {
            return XE(parent, name, value.ToString());
        }
        public XmlElement XE(XmlNode parent, string name, DateTime value, bool withtime = false)
        {
            XmlElement el = XE(name, value, withtime);
            parent.AppendChild(el);
            return el;
        }

        public XmlElement XEIF(bool condition, XmlNode parent, string name, string text)
        {
            if (!condition) return null;
            return XE(parent, name, text);
        }
        public XmlElement XEIF(bool condition, XmlNode parent, string name, decimal value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        public XmlElement XEIF(bool condition, XmlNode parent, string name, int value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        public XmlElement XEIF(bool condition, XmlNode parent, string name, DateTime value, bool withtime = false)
        {
            if (!condition) return null;
            return XE(parent, name, value, withtime);
        }

        public XmlElement XENZ(XmlNode parent, string name, string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            return XE(parent, name, text);
        }
        public XmlElement XENZ(XmlNode parent, string name, decimal value)
        {
            if (value == 0.00M) return null;
            return XE(parent, name, value);
        }
        public XmlElement XENZ(XmlNode parent, string name, int value)
        {
            if (value == 0) return null;
            return XE(parent, name, value);
        }
    }
}
