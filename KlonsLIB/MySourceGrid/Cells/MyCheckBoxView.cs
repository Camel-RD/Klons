using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceGrid.Cells.Views;
using SourceGrid;

namespace KlonsLIB.MySourceGrid.Cells
{
	/// <summary>
	/// Summary description for VisualModelCheckBox.
	/// </summary>
	[Serializable]
	public class MyCheckBoxView : Cell
	{
		public new readonly static MyCheckBoxView Default = new MyCheckBoxView();
		public readonly static MyCheckBoxView MiddleLeftAlign;


		static MyCheckBoxView()
		{
			MiddleLeftAlign = new MyCheckBoxView();
			MiddleLeftAlign.CheckBoxAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			MiddleLeftAlign.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
		}

		public MyCheckBoxView()
		{
		}

		public MyCheckBoxView(MyCheckBoxView p_Source) : base(p_Source)
		{
			m_CheckBoxAlignment = p_Source.m_CheckBoxAlignment;
			ElementCheckBox = (DevAge.Drawing.VisualElements.ICheckBox)ElementCheckBox.Clone();
		}

		private DevAge.Drawing.ContentAlignment m_CheckBoxAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

		public DevAge.Drawing.ContentAlignment CheckBoxAlignment
		{
			get { return m_CheckBoxAlignment; }
			set { m_CheckBoxAlignment = value; }
		}

		protected override void PrepareView(CellContext context)
		{
			base.PrepareView(context);

			PrepareVisualElementCheckBox(context);
		}

		protected override IEnumerable<DevAge.Drawing.VisualElements.IVisualElement> GetElements()
		{
			if (ElementCheckBox != null)
				yield return ElementCheckBox;

			foreach (DevAge.Drawing.VisualElements.IVisualElement v in GetBaseElements())
				yield return v;
		}
		private IEnumerable<DevAge.Drawing.VisualElements.IVisualElement> GetBaseElements()
		{
			return base.GetElements();
		}

		private DevAge.Drawing.VisualElements.ICheckBox mElementCheckBox = new MyCheckBoxVisualElement();

		public DevAge.Drawing.VisualElements.ICheckBox ElementCheckBox
		{
			get { return mElementCheckBox; }
			set { mElementCheckBox = value; }
		}


		protected virtual void PrepareVisualElementCheckBox(CellContext context)
		{
			ElementCheckBox.AnchorArea = new DevAge.Drawing.AnchorArea(CheckBoxAlignment, false);

            SourceGrid.Cells.Models.ICheckBox checkBoxModel = (SourceGrid.Cells.Models.ICheckBox)context.Cell.Model.FindModel(typeof(SourceGrid.Cells.Models.ICheckBox));
            SourceGrid.Cells.Models.CheckBoxStatus checkBoxStatus = checkBoxModel.GetCheckBoxStatus(context);

			if (context.CellRange.Contains(context.Grid.MouseCellPosition))
			{
				if (checkBoxStatus.CheckEnable)
					ElementCheckBox.Style = DevAge.Drawing.ControlDrawStyle.Hot;
				else
					ElementCheckBox.Style = DevAge.Drawing.ControlDrawStyle.Disabled;
			}
			else
			{
				if (checkBoxStatus.CheckEnable)
					ElementCheckBox.Style = DevAge.Drawing.ControlDrawStyle.Normal;
				else
					ElementCheckBox.Style = DevAge.Drawing.ControlDrawStyle.Disabled;
			}

			ElementCheckBox.CheckBoxState = checkBoxStatus.CheckState;

			ElementText.Value = checkBoxStatus.Caption;

			var elementCheckBox = (MyCheckBoxVisualElement)ElementCheckBox;
			elementCheckBox.Font = GetDrawingFont(context.Grid);
			elementCheckBox.ForeColor = ForeColor;
		}

		public override object Clone()
		{
			return new MyCheckBoxView(this);
		}
	}
}
