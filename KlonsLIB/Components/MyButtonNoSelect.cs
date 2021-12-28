using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlonsLIB.Components
{
    public class MyButton: Button
    {
        public MyButton()
        {
        }

        public bool Selectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }
    }
}
