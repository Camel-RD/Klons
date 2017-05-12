using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KlonsLIB.Data
{
  public class JoinViewRowPropertyDescriptor : PropertyDescriptor
  {
    private Type ColType;
    private int ColIndex;
    private bool ColIsReadOnly;

    public override Type ComponentType
    {
      get
      {
        return typeof (JoinViewRow);
      }
    }

    public override Type PropertyType
    {
      get
      {
        return this.ColType;
      }
    }

    public override bool IsReadOnly
    {
      get
      {
        return this.ColIsReadOnly;
      }
    }

    public JoinViewRowPropertyDescriptor(string ColumnName, int ColumnIndex, Type ColumnType, bool ColumnIsReadOnly)
      : base(ColumnName, (Attribute[]) null)
    {
      this.ColIndex = ColumnIndex;
      this.ColType = ColumnType;
      this.ColIsReadOnly = ColumnIsReadOnly;
    }

    public override object GetValue(object component)
    {
      return ((JoinViewRow) component).get_Item(this.ColIndex);
    }

    public override void ResetValue(object component)
    {
    }

    public override void SetValue(object component, object value)
    {
      ((JoinViewRow) component).set_Item(this.ColIndex, RuntimeHelpers.GetObjectValue(value));
    }

    public override bool CanResetValue(object component)
    {
      return false;
    }

    public override bool ShouldSerializeValue(object component)
    {
      return false;
    }
  }
}
