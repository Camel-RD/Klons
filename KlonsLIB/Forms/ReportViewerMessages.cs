using Microsoft.Reporting.WinForms;

namespace KlonsLIB.Forms
{
    public class ReportViewerMessages : IReportViewerMessages3
    {

        public string CancelLinkText => "Atcelt";
        public string ExportDialogCancelButton => "Atcelt";
        public string ExportDialogStatusText => null;
        public string ExportDialogTitle => "Eksportēt";
        public string FalseBooleanToolTip => "Nav";

        public string TotalPages(int pageCount, PageCountMode pageCountMode)
        {
            return null;
        }

        public string TrueBooleanToolTip => "Ir";
        public string AllFilesFilter => null;

        public string CredentialMissingUserNameError(string dataSourcePrompt)
        {
            return null;
        }

        public string DateToolTip => "Datums";
        public string ExportErrorTitle => "Kļūda eksportējot";
        public string FloatToolTip => "Decimālskaitlis";

        public string GetLocalizedNameForRenderingExtension(string format)
        {
            return null;
        }

        public string HyperlinkErrorTitle => "Kļūda";
        public string IntToolTip => "Int";
        public string MessageBoxTitle => "Klons";

        public string ParameterMissingSelectionError(string parameterPrompt)
        {
            return null;
        }

        public string ParameterMissingValueError(string parameterPrompt)
        {
            return null;
        }

        public string ProcessingStopped => null;
        public string PromptAreaErrorTitle => "Kļūda";
        public string StringToolTip => "Texts";
        public string BackButtonToolTip => "Atpakaļ";
        public string BackMenuItemText => "Atpakaļ";
        public string ChangeCredentialsText => null;
        public string CurrentPageTextBoxToolTip => "Pašreizējā lapa";
        public string DocumentMapButtonToolTip => "Dokumentu izkārtojums";
        public string DocumentMapMenuItemText => DocumentMapButtonToolTip;
        public string ExportButtonToolTip => "Eksportēt";
        public string ExportMenuItemText => ExportButtonToolTip;
        public string FalseValueText => null;
        public string FindButtonText => "Meklēt";
        public string FindButtonToolTip => FindButtonText;
        public string FindNextButtonText => "Meklēt nākošo";
        public string FindNextButtonToolTip => FindNextButtonText;
        public string FirstPageButtonToolTip => "Pirmā lapa";
        public string LastPageButtonToolTip => "Pēdējā lapa";
        public string NextPageButtonToolTip => "Nākošā lapa";
        public string NoMoreMatches => "Nekas nav atrasts";
        public string NullCheckBoxText => null;
        public string NullCheckBoxToolTip => null;
        public string NullValueText => null;
        public string PageOf => "lapa no";
        public string PageSetupButtonToolTip => "Lapas uzstādijumi";
        public string PageSetupMenuItemText => PageSetupButtonToolTip;
        public string ParameterAreaButtonToolTip => null;
        public string PasswordPrompt => null;
        public string PreviousPageButtonToolTip => "Iepriekšējā lapa";
        public string PrintButtonToolTip => "Drukāt";
        public string PrintLayoutButtonToolTip => "Drukas izklājums";
        public string PrintLayoutMenuItemText => PrintLayoutButtonToolTip;
        public string PrintMenuItemText => PrintButtonToolTip;
        public string ProgressText => null;
        public string RefreshButtonToolTip => "Atsvaidzināt";
        public string RefreshMenuItemText => RefreshButtonToolTip;
        public string SearchTextBoxToolTip => "Meklēt";
        public string SelectAValue => "Iezīmēt";
        public string SelectAll => "Iezīmēt visu";
        public string StopButtonToolTip => null;
        public string StopMenuItemText => null;
        public string TextNotFound => "Teksts netika atrasts";
        public string TotalPagesToolTip => "Lapu kopskaits";
        public string TrueValueText => null;
        public string UserNamePrompt => "Lietotāja vārds";
        public string ViewReportButtonText => "Rādīt atskaiti";
        public string ViewReportButtonToolTip => ViewReportButtonText;
        public string ZoomControlToolTip => "Palielināt";
        public string ZoomMenuItemText => ZoomControlToolTip;
        public string ZoomToPageWidth => "Visā platumā";
        public string ZoomToWholePage => "Rādīt visu lapu";
        public string FoundResultText => "Atrasts teksts";
    }
}
