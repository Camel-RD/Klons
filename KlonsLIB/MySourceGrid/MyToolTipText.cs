using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SourceGrid;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Models;

namespace KlonsLIB.MySourceGrid
{
    public class MyToolTipModel : IToolTipText
    {
        public string GetToolTipText(CellContext cellContext)
        {
            if (string.IsNullOrEmpty(ToolTipText) && !cellContext.IsEmpty())
                return cellContext.DisplayText;
            return ToolTipText;
        }

        public static string ToolTipText { get; set; } = null;
        public bool MeasureRequired { get; set; } = true;
        public bool ToolTipRequired { get; set; } = false;
    }

    class MyToolTipText : ControllerBase
    {
        public readonly static MyToolTipText Default = new MyToolTipText();

        #region IBehaviorModel Members
        public override void OnMouseEnter(CellContext sender, EventArgs e)
        {
            base.OnMouseEnter(sender, e);

            ApplyToolTipText(sender, e);
        }

        public override void OnMouseLeave(CellContext sender, EventArgs e)
        {
            base.OnMouseLeave(sender, e);

            ResetToolTipText(sender, e);
        }

        public override void OnValueChanged(CellContext sender, EventArgs e)
        {
            base.OnValueChanged(sender, e);

            var myToolTip = (MyToolTipModel)sender.Cell.Model.FindModel(typeof(MyToolTipModel));
            if (myToolTip != null)
                myToolTip.MeasureRequired = true;
        }
        #endregion

        private string mToolTipTitle = string.Empty;
        public string ToolTipTitle
        {
            get { return mToolTipTitle; }
            set { mToolTipTitle = value; }
        }

        private System.Windows.Forms.ToolTipIcon mToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
        public System.Windows.Forms.ToolTipIcon ToolTipIcon
        {
            get { return mToolTipIcon; }
            set { mToolTipIcon = value; }
        }

        private bool mIsBalloon = false;
        public bool IsBalloon
        {
            get { return mIsBalloon; }
            set { mIsBalloon = value; }
        }

        private System.Drawing.Color mBackColor = System.Drawing.Color.Empty;
        public System.Drawing.Color BackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; }
        }
        private System.Drawing.Color mForeColor = System.Drawing.Color.Empty;
        public System.Drawing.Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; }
        }

        protected virtual void ApplyToolTipText(CellContext sender, EventArgs e)
        {
            var toolTip = (IToolTipText)sender.Cell.Model.FindModel(typeof(IToolTipText));
            var myToolTip = (MyToolTipModel)sender.Cell.Model.FindModel(typeof(MyToolTipModel));
            string text = null;

            if (myToolTip != null)
            {
                text = toolTip.GetToolTipText(sender);
                if (myToolTip.MeasureRequired)
                {
                    var sz = sender.Measure(new Size(0, 0));
                    var csz = sender.Grid.RangeToSize(sender.CellRange);
                    myToolTip.MeasureRequired = false;
                    myToolTip.ToolTipRequired = sz.Width > csz.Width;
                    if (!myToolTip.ToolTipRequired) text = null;
                }
                else
                {
                    if(!myToolTip.ToolTipRequired) text = null;
                }
            }
            else if (toolTip != null)
            {
                text = toolTip.GetToolTipText(sender);
                var sz = sender.Measure(new Size(0, 0));
                var csz = sender.Grid.RangeToSize(sender.CellRange);
                if (sz.Width <= csz.Width)
                    text = null;
            }

            if (text != null && text.Length > 0)
            {
                sender.Grid.ToolTipText = text;
                sender.Grid.ToolTip.ToolTipTitle = ToolTipTitle;
                sender.Grid.ToolTip.ToolTipIcon = ToolTipIcon;
                sender.Grid.ToolTip.IsBalloon = IsBalloon;
                if (BackColor.IsEmpty == false)
                    sender.Grid.ToolTip.BackColor = BackColor;
                if (ForeColor.IsEmpty == false)
                    sender.Grid.ToolTip.ForeColor = ForeColor;
            }
        }

        protected virtual void ResetToolTipText(CellContext sender, EventArgs e)
        {
            if (sender.Cell.Model.FindModel(typeof(IToolTipText)) != null)
            {
                sender.Grid.ToolTipText = null;
            }
        }
    }
}
