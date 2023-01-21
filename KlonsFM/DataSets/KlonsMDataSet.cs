using KlonsLIB.Misc;

namespace KlonsFM.DataSets
{


    partial class KlonsMDataSet
    {
        partial class M_ACCOUNTSRow
        {
            public Classes.EAccountType XAccountType
            {
                get => (Classes.EAccountType)TP;
                set => TP = (int)value;
            }
        }


        partial class M_STORESRow
        {
            public Classes.EStoreType XStoreType
            {
                get => (Classes.EStoreType)TP;
                set => TP = (int)value;
            }

            public Classes.EPVNType XStorePVNType
            {
                get => (Classes.EPVNType)PVNTP;
                set => PVNTP = (int)value;
            }
        }

        partial class M_DOCSRow
        {
            public Classes.EDocState XState
            {
                get => (Classes.EDocState)STATE;
                set => STATE = (int)value;
            }

            public Classes.EPVNType XPVNType
            {
                get => (Classes.EPVNType)PVNTYPE;
                set => PVNTYPE = (int)value;
            }

            public Classes.EDocType XDocType
            {
                get => (Classes.EDocType)TP;
                set => TP = (int)value;
            }

            public Classes.EDocType2 XDocType2
            {
                get => (Classes.EDocType2)IDTRANSACTIONTYPE;
                set => IDTRANSACTIONTYPE = (int)value;
            }

            public Classes.EStoreType XStoreInType =>
                    M_STORESRowByFK_M_DOCS_IDSTOREIN1.XStoreType;

            public Classes.EStoreType XStoreOutType =>
                    M_STORESRowByFK_M_DOCS_IDSTOREOUT1.XStoreType;

            public Classes.EPVNType XStoreInPVNType =>
                    M_STORESRowByFK_M_DOCS_IDSTOREIN1.XStorePVNType;

            public Classes.EPVNType XStoreOutPVNType =>
                    M_STORESRowByFK_M_DOCS_IDSTOREOUT1.XStorePVNType;

            public Classes.EAccountingType XAccountingType
            {
                get => (Classes.EAccountingType)ACCOUNTINGTP;
                set => ACCOUNTINGTP = (short)value;
            }

            public bool XDoAutoFinOps
            {
                get => ACCTP1 == 1;
                set => ACCTP1 = (short)(value ? 1 : 0);
            }

            public bool XIncludeInCostCalc
            {
                get => ACCTP2 == 1;
                set => ACCTP2 = (short)(value ? 1 : 0);
            }

            public string DocSrNr => $"{SR.Nz()} {NR.Nz()}".Trim();

            public bool IsOpenForChanges =>
                XState == Classes.EDocState.Melnraksts ||
                XState == Classes.EDocState.Atvērts;
        }

        public partial class M_ROWSRow
        {
            public bool XIsServices => this.M_ITEMSRow.XIsServices;

        }


        public partial class M_ITEMSRow
        {
            public bool XIsServices => this.M_ITEMS_CATRow.XIsServices;

        }

        public partial class M_ITEMS_CATRow
        {
            public Classes.EStoreCalcMethod XMethod
            {
                get => (Classes.EStoreCalcMethod)METHOD;
                set => METHOD = (int)value;
            }

            public bool XIsServices
            {
                get => ISSERVICES == 1;
                set => ISSERVICES = value ? 1 : 0;
            }
        }

        partial class M_PVNRATES2Row
        {
            public Classes.EPVNType XPvnType
            {
                get => (Classes.EPVNType)IDTP;
                set => IDTP = (int)value;
            }

            public Classes.EDocType XDocType
            {
                get => (Classes.EDocType)IDTRTP;
                set => IDTRTP = (int)value;
            }

            public Classes.EAccountsForTemplates XBaseDebFin
            {
                get => (Classes.EAccountsForTemplates)BASE_DEB_FIN;
                set => BASE_DEB_FIN = (int)value;
            }

            public Classes.EAccountsForTemplates XBaseCredFin
            {
                get => (Classes.EAccountsForTemplates)BASE_CRED_FIN;
                set => BASE_CRED_FIN = (int)value;
            }

            public Classes.EAccountsForTemplates XPvnDebFin
            {
                get => (Classes.EAccountsForTemplates)PVN_DEB_FIN;
                set => PVN_DEB_FIN = (int)value;
            }

            public Classes.EAccountsForTemplates XPvnCredFin
            {
                get => (Classes.EAccountsForTemplates)PVN_CRED_FIN;
                set => PVN_CRED_FIN = (int)value;
            }

            public bool XInCurrentMonth
            {
                get => INCURMT == 1;
                set => INCURMT = value ? 1 : 0;
            }

            public bool XChangeSign
            {
                get => CHANGESIGN == 1;
                set => CHANGESIGN = value ? 1 : 0;
            }
        }
    }
}

