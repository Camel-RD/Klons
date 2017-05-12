using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using KlonsLIB.Forms;
using KlonsLIB.Misc;

namespace KlonsP.Classes
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
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fd.DefaultExt = "xml";
            fd.Filter = "XML faili (*.xml)|*.xml";
            if (fd.ShowDialog(KlonsData.St.MyMainForm) != DialogResult.OK) return null;
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
        public XmlElement XE(string name, DateTime value)
        {
            return XE(name, value.ToString("yyyy-MM-dd"));
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
        public XmlElement XE(XmlNode parent, string name, DateTime value)
        {
            XmlElement el = XE(name, value);
            parent.AppendChild(el);
            return el;
        }

        public XmlElement XEB(bool condition, XmlNode parent, string name, string text)
        {
            if (!condition) return null;
            return XE(parent, name, text);
        }
        public XmlElement XEB(bool condition, XmlNode parent, string name, decimal value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        public XmlElement XEB(bool condition, XmlNode parent, string name, int value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }
        public XmlElement XEB(bool condition, XmlNode parent, string name, DateTime value)
        {
            if (!condition) return null;
            return XE(parent, name, value);
        }

        public XmlElement XER(XmlNode parent, string name, string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            return XE(parent, name, text);
        }
        public XmlElement XER(XmlNode parent, string name, decimal value)
        {
            if (value == 0.00M) return null;
            return XE(parent, name, value);
        }
        public XmlElement XER(XmlNode parent, string name, int value)
        {
            if (value == 0) return null;
            return XE(parent, name, value);
        }
    }
}
