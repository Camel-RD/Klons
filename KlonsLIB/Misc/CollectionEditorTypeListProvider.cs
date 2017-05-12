using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlonsLIB.Misc
{
    public interface ICollectionEditorTypeListProvider
    {
        Type[] GetTypesForCollectionEditor(string propname);
    }
}
