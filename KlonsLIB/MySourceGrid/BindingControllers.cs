using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceGrid;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;
using KlonsLIB.Misc;
using KlonsLIB.Forms;
using System.Reflection;
using KlonsLIB.MySourceGrid.GridRows;
using System.ComponentModel;

namespace KlonsLIB.MySourceGrid
{
    public class BindProperty : ControllerBase
    {
        public BindProperty(string p_PropertyName, object p_LinkObject)
        {
            BindValueAtProperty(p_PropertyName, p_LinkObject);
        }

        public override void OnValueChanged(CellContext sender, EventArgs e)
        {
            base.OnValueChanged(sender, e);
            if (string.IsNullOrEmpty(m_PropertyName) || m_LinkObject == null) return;
            PropertyInfo prop = Utils.GetProp(m_LinkObject.GetType(), m_PropertyName);
            if (prop == null)
            {
                throw new Exception("Property not found");
            }
            object value = sender.Cell.Model.ValueModel.GetValue(sender);
            object oldvalue = prop.GetValue((m_LinkObject), null);
            if (object.Equals(value, oldvalue)) return;
            try
            {
                prop.SetValue(m_LinkObject, value, null);
            }
            catch (Exception ex)
            {
                Form_Error.ShowException(ex, "Ievadīta nnekorekta lauka vērtība.");
            }
            object value2 = prop.GetValue((m_LinkObject), null);
            if (!object.Equals(value, value2))
            {
                sender.Cell.Model.ValueModel.SetValue(sender, value2);
            }
        }

        private string m_PropertyName = null;
        private object m_LinkObject = null;

        protected virtual void BindValueAtProperty(string p_PropertyName, object p_LinkObject)
        {
            m_PropertyName = p_PropertyName;
            m_LinkObject = p_LinkObject;
        }

        protected virtual void UnBindValueAtProperty()
        {
            m_PropertyName = null;
            m_LinkObject = null;
        }
    }


}
