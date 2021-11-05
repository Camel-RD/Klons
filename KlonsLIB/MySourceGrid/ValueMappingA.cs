using System;
using System.Collections;
using DevAge.ComponentModel;
using DevAge.ComponentModel.Validator;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
	public class ValueMappingA
	{
		public ValueMappingA()
		{
		}

		public ValueMappingA(IValidator validator, IList list, string keypropname, 
            string valueproname, MyGridRowPropEditorBase gridrow)
		{
			DataList = list;
			KeyPropertyName = keypropname;
		    ValuePropertyName = valueproname;
            m_gridrow = gridrow;

            if (validator != null)
				BindValidator(validator);
		}

		public void BindValidator(IValidator p_Validator)
		{
			p_Validator.ConvertingValueToDisplayString += new ConvertingObjectEventHandler(p_Validator_ConvertingValueToDisplayString);
			p_Validator.ConvertingObjectToValue += new ConvertingObjectEventHandler(p_Validator_ConvertingObjectToValue);
			p_Validator.ConvertingValueToObject += new ConvertingObjectEventHandler(p_Validator_ConvertingValueToObject);
		}

		public void UnBindValidator(IValidator p_Validator)
		{
			p_Validator.ConvertingValueToDisplayString -= new ConvertingObjectEventHandler(p_Validator_ConvertingValueToDisplayString);
			p_Validator.ConvertingObjectToValue -= new ConvertingObjectEventHandler(p_Validator_ConvertingObjectToValue);
			p_Validator.ConvertingValueToObject -= new ConvertingObjectEventHandler(p_Validator_ConvertingValueToObject);
		}

		private System.Collections.IList m_List;
	    private string m_KeyPropertyName = null;
        private string m_ValuePropertyName = null;
        private MyGridRowPropEditorBase m_gridrow = null;

        public System.Collections.IList DataList
		{
			get{return m_List;}
			set{m_List = value;}
		}

	    public string KeyPropertyName
	    {
	        get { return m_KeyPropertyName; }
            set { m_KeyPropertyName = value; }
	    }
        public string ValuePropertyName
        {
            get { return m_ValuePropertyName; }
            set { m_ValuePropertyName = value; }
        }

        private bool m_bThrowErrorIfNotFound = true;

		public bool ThrowErrorIfNotFound
		{
			get{return m_bThrowErrorIfNotFound;}
			set{m_bThrowErrorIfNotFound = value;}
		}

	    private bool GetProperty(object obj, string propname, out object value)
	    {
	        value = null;
            if (obj == null || string.IsNullOrEmpty(propname)) return false;
	        try
	        {
	            var propdef = obj.GetType().GetProperty(propname);
	            if (propdef == null) return false;
	            value = propdef.GetValue(obj, null);
	            return true;
	        }
	        catch
	        {
	            
	        }
	        return true;
	    }

	    private int FindValue(IList list, string propname, object value)
	    {
            if (list == null || list.Count == 0 || string.IsNullOrEmpty(propname)) return -1;
	        object o1;
            for (int i = 0; i < list.Count; i++)
            {
                var o2 = list[i];
                if (o2 == null) continue;
                if (!GetProperty(list[i], propname, out o1)) continue;
                var t1 = o1.GetType();
                var t2 = value.GetType();
                if (object.Equals(o1, value))
                    return i;
            }
	        return -1;
	    }

        private void p_Validator_ConvertingValueToDisplayString(object sender, ConvertingObjectEventArgs e)
	    {
	        if (m_List == null || m_List.Count == 0) return;
            if(m_gridrow != null && m_gridrow.NoData)
            {
                e.Value = null;
                e.ConvertingStatus = ConvertingStatus.Completed;
                return;
            }
            int k = FindValue(m_List, m_KeyPropertyName, e.Value);
            if (k < 0)
                k = m_List.IndexOf(e.Value);
            if (k >= 0)
	        {
	            object o1;
                bool ret = GetProperty(m_List[k], m_ValuePropertyName, out o1);
	            if (ret)
	            {
	                e.Value = o1;
                    e.ConvertingStatus = ConvertingStatus.Completed;
	            }
	            else if (m_bThrowErrorIfNotFound)
	                e.ConvertingStatus = ConvertingStatus.Error;
	        }
            else
	        {
	            if (m_bThrowErrorIfNotFound)
	                e.ConvertingStatus = ConvertingStatus.Error;
	        }
	    }

	    private void p_Validator_ConvertingObjectToValue(object sender, ConvertingObjectEventArgs e)
		{
            if (m_List == null || m_List.Count == 0) return;
            int k = FindValue(m_List, m_KeyPropertyName, e.Value);
            if (k < 0)
                k = FindValue(m_List, m_ValuePropertyName, e.Value);
            if (k < 0)
                k = m_List.IndexOf(e.Value);
            if (k >= 0)
	        {
	            object o1;
	            bool ret = GetProperty(m_List[k], m_KeyPropertyName, out o1);
                if (ret)
                {
                    e.Value = o1;
                    e.ConvertingStatus = ConvertingStatus.Completed;
                }
                else if (m_bThrowErrorIfNotFound)
                    e.ConvertingStatus = ConvertingStatus.Error;
            }
            else
	        {
                if (m_bThrowErrorIfNotFound)
	                e.ConvertingStatus = ConvertingStatus.Error;
	        }
		}

		private void p_Validator_ConvertingValueToObject(object sender, ConvertingObjectEventArgs e)
		{
            if (m_List == null || m_List.Count == 0) return;
            int k = FindValue(m_List, m_KeyPropertyName, e.Value);
		    if (k >= 0)
		    {
		        e.Value = m_List[k];
		        e.ConvertingStatus = ConvertingStatus.Completed;
		    }
		    else
		    {
		        if (m_bThrowErrorIfNotFound)
		            e.ConvertingStatus = ConvertingStatus.Error;
		    }
		}
	}
}
