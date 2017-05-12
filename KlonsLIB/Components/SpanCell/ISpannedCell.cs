using System.Windows.Forms;

namespace KlonsLIB.Components.SpanCell
{
    public interface ISpannedCell
    {
        int ColumnSpan { get; }
        int RowSpan { get; }
        DataGridViewCell OwnerCell { get; }
    }
}