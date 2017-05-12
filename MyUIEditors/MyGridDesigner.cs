using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MyUIEditors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class MyGridDesigner : ControlDesigner, IServiceProvider
    {
        private DesignerVerbCollection verbs;

        public MyGridDesigner()
        {
            AutoResizeHandles = true;
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            return this.GetService(serviceType);
        }

        protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
            e.Graphics.DrawRectangle(
                new Pen(new SolidBrush(Color.White), 2),
                0, 0, 
                this.Control.Size.Width,
                this.Control.Size.Height);
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                {
                    verbs = new DesignerVerbCollection()
                    {
                        new DesignerVerb("Edit rows", OnEditRows),
                        new DesignerVerb("Edit shared editors", OnEditSharedEditors)
                    };
                }
                return verbs;
            }
        }

        private void OnEditRows(object sender, EventArgs e)
        {
            PropertyDescriptor propdef = TypeDescriptor.GetProperties(Control)["RowList"];
            if (propdef == null) return;

            UITypeEditor editor = (UITypeEditor)propdef.GetEditor(typeof(UITypeEditor));
            RuntimeServiceProvider serviceProvider = 
                new RuntimeServiceProvider(this.Control, this.Component, propdef);
            editor.EditValue(serviceProvider, serviceProvider, propdef.GetValue(this.Control));
        }
        private void OnEditSharedEditors(object sender, EventArgs e)
        {
            PropertyDescriptor propdef = TypeDescriptor.GetProperties(Control)["RowTemplateList"];
            if (propdef == null) return;

            UITypeEditor editor = (UITypeEditor)propdef.GetEditor(typeof(UITypeEditor));
            RuntimeServiceProvider serviceProvider =
                new RuntimeServiceProvider(this.Control, this.Component, propdef);
            editor.EditValue(serviceProvider, serviceProvider, propdef.GetValue(this.Control));
        }

    }


    public class RuntimeServiceProvider : IServiceProvider, ITypeDescriptorContext, IWindowsFormsEditorService
    {
        private Control _Control = null;
        private IComponent _Component = null;
        private PropertyDescriptor _PropertyDescriptor = null;
        public RuntimeServiceProvider(Control control, IComponent component, PropertyDescriptor propertydescriptor)
        {
            this._Control = control;
            this._Component = component;
            this._PropertyDescriptor = propertydescriptor;
        }

        #region IServiceProvider Members

        object IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(IWindowsFormsEditorService))
            {
                return this;
            }
            else if (_Component != null && _Component.Site != null)
            {
                return _Control.Site.GetService(serviceType);
            }
            return null;
        }

        #endregion

        #region ITypeDescriptorContext Members

        public void OnComponentChanged()
        {
        }

        public IContainer Container
        {
            get
            {
                return _Control.Container;
            }
        }

        public bool OnComponentChanging()
        {
            return true; // true to keep changes, otherwise false
        }

        public object Instance
        {
            get { return _Control; }
        }

        public PropertyDescriptor PropertyDescriptor
        {
            get { return _PropertyDescriptor; }
        }

        #endregion

        void IWindowsFormsEditorService.CloseDropDown()
        {
        }

        void IWindowsFormsEditorService.DropDownControl(Control control)
        {
        }

        DialogResult IWindowsFormsEditorService.ShowDialog(Form dialog)
        {
            IUIService uiSvc = this._Component.Site.GetService(typeof(IUIService)) as IUIService;
            if (uiSvc != null)
            {
                return uiSvc.ShowDialog(dialog);
            }
            else
            {
                return dialog.ShowDialog(this._Component as IWin32Window);
            }
        }


    }
}
