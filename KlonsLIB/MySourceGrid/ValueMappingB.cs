using System;
using System.Data;
using System.Collections;
using DevAge.ComponentModel;
using DevAge.ComponentModel.Validator;
using KlonsLIB.MySourceGrid.GridRows;

namespace KlonsLIB.MySourceGrid
{
	public class ValueMappingB
	{
		public ValueMappingB()
		{
		}

		public ValueMappingB(IValidator validator, MyGridRowPropEditorBase gridrow)
		{
            gridRow = gridrow;
            if (validator != null)
				BindValidator(validator);
		}

        private MyGridRowPropEditorBase gridRow = null;

        public void BindValidator(IValidator p_Validator)
		{
            p_Validator.ConvertingValueToDisplayString += p_Validator_ConvertingValueToDisplayString;
			p_Validator.ConvertingObjectToValue += p_Validator_ConvertingObjectToValue;
			p_Validator.ConvertingValueToObject += p_Validator_ConvertingValueToObject;
		}

		public void UnBindValidator(IValidator p_Validator)
		{
			p_Validator.ConvertingValueToDisplayString -= p_Validator_ConvertingValueToDisplayString;
			p_Validator.ConvertingObjectToValue -= p_Validator_ConvertingObjectToValue;
			p_Validator.ConvertingValueToObject -= p_Validator_ConvertingValueToObject;
		}

        private bool HasCustomConversion()
        {
            var ics = gridRow as ICustomConversionSupport;
            if (ics == null) return false;
            return ics.CustomConversions;
        }

        private void p_Validator_ConvertingValueToDisplayString(object sender, ConvertingObjectEventArgs e)
	    {
            if (gridRow.NoData)
            {
                e.Value = null;
                e.ConvertingStatus = ConvertingStatus.Completed;
                return;
            }

            if (!HasCustomConversion()) return;
            gridRow.Grid.OnConvertingValueToDisplayString(gridRow, e);
            //e.ConvertingStatus = ConvertingStatus.Error;
	    }

	    private void p_Validator_ConvertingObjectToValue(object sender, ConvertingObjectEventArgs e)
		{
            if (!HasCustomConversion()) return;
            gridRow.Grid.OnConvertingObjectToValue(gridRow, e);
        }

        private void p_Validator_ConvertingValueToObject(object sender, ConvertingObjectEventArgs e)
		{
            if (!HasCustomConversion()) return;
            gridRow.Grid.OnConvertingValueToObject(gridRow, e);
        }
    }
}
