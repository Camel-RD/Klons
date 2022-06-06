using System.Xml.Serialization;

namespace KlonsA.Classes
{
    public partial class NM_dn_dnl
    {
        public NM_dn_dnlPamatdati pamatdati;
        [XmlArrayItem("CertificateData", IsNullable = false)]
        public SRSCertificateDataType[] dati;
    }

    public partial class NM_dn_dnlPamatdati
    {

        [XmlElement(DataType = "integer")]
        public string id;
        public System.DateTime izpildes_laiks;
        public string darba_deveja_nmr_kods;
        public object darba_deveja_nosaukums;
        public string personas_kods;
        [XmlElement(DataType = "date")]
        public System.DateTime izmainas_sakot_ar;
        [XmlIgnore()]
        public bool izmainas_sakot_arSpecified;
        [XmlElement(DataType = "date")]
        public System.DateTime periods_no;
        [XmlIgnore()]
        public bool periods_noSpecified;
        [XmlElement(DataType = "date")]
        public System.DateTime periods_lidz;
        [XmlIgnore()]
        public bool periods_lidzSpecified;
        public System.DateTime sanemsanas_laiks;
        [XmlIgnore()]
        public bool sanemsanas_laiksSpecified;
    }


    public partial class SRSCertificateDataType
    {
        public string RegistrationNumber;
        public string StatusChangeId;
        public string CertificateType;
        public string CertificateFormType;
        public SRSPersonDataType PersonData;
        [XmlElement("DisabilityCause")]
        public SRSDisabilityCauseType[] DisabilityCause;
        public SRSDatePeriodType PeriodDates;
        [XmlElement(DataType = "date")]
        public System.DateTime FirstWorkingDay;
        [XmlIgnore()]
        public bool FirstWorkingDaySpecified;
        [XmlElement(DataType = "date")]
        public System.DateTime ContinueDay;
        [XmlIgnore()]
        public bool ContinueDaySpecified;
        public string PreviousCertificateNumber;
        public SRSStatusInfoType CertificateStatus;
    }

    public partial class SRSPersonDataType
    {
        public string PersonID;
        public string FirstName;
        public string MiddleName;
        public string LastName;
    }

    public partial class SRSDisabilityCauseType
    {
        public string DisabilityCauseText;
    }

    public partial class SRSDatePeriodType
    {
        [XmlElement(DataType = "dateTime")]
        public System.DateTime StartDate;
        [XmlIgnore()]
        public bool StartDateSpecified;
        [XmlElement(DataType = "dateTime")]
        public System.DateTime EndDate;
        [XmlIgnore()]
        public bool EndDateSpecified;
    }

    public partial class SRSStatusInfoType
    {
        public System.DateTime StatusDate;
        [XmlIgnore()]
        public bool StatusDateSpecified;
        public string StatusText;
    }

}