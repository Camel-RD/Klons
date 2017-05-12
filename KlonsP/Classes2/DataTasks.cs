using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KlonsP.DataSets;
using KlonsLIB.Data;

namespace KlonsP.Classes
{
    public static class DataTasks
    {
        public static KlonsData MyData => KlonsData.St;

        public static decimal Round(decimal d, int k)
        {
            return Math.Round(d, k, MidpointRounding.AwayFromZero);
        }

        public static int CountItemsWithErrors()
        {
            return MyData.DataSetKlons.ITEMS.WhereX(d => d.XState == EState.Error).Count();
        }

        public static void SetNewIDs(MyAdapterManager adaptermanager)
        {
            if (adaptermanager.TableNames == null) return;
            SetNewIDs(adaptermanager.TableNames);
        }

        public static void SetNewIDs(params string[] tablenames)
        {
            DataRow[] drs;

            foreach (var tablename in tablenames)
            {
                switch (tablename)
                {
                    case "CAT1":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.CAT1);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.CAT1Row;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_CAT1_ID();
                        }
                        break;
                    case "CATD":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.CATD);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.CATDRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_CATD_ID();
                        }
                        break;
                    case "CATT":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.CATT);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.CATTRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_CATT_ID();
                        }
                        break;
                    case "PLACES":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.PLACES);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.PLACESRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_PLACES_ID();
                        }
                        break;
                    case "DEPARTMENTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.DEPARTMENTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.DEPARTMENTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_DEPARTMENTS_ID();
                        }
                        break;
                    case "ITEMS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.ITEMS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.ITEMSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_ITEMS_ID();
                        }
                        break;
                    case "ITEMS_EVENTS":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.ITEMS_EVENTS);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.ITEMS_EVENTSRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_ITEMS_EVENTS_ID();
                        }
                        break;
                    case "TAXDEPRECYEAR":
                        drs = DataSetHelper.GetNewRows(MyData.DataSetKlons.TAXDEPRECYEAR);
                        foreach (var dr in drs)
                        {
                            var pdr = dr as KlonsPDataSet.TAXDEPRECYEARRow;
                            if (pdr.ID >= 0) continue;
                            pdr.ID = (int)MyData.KlonsQueriesTableAdapter.SP_GEN_TAXDEPRECYEAR_ID();
                        }
                        break;

                }
            }
        }
    }

    public class ErrorInfo
    {
        public string Source { get; set; } = null;
        public string Message { get; set; } = null;
    }

    public class ErrorList : List<ErrorInfo>
    {
        public bool HasErrors { get { return Count > 0; } }

        public ErrorList()
        {
        }

        public ErrorList(string source, string msg)
        {
            AddError(source, msg);
        }

        public void AddError(string source, string msg)
        {
            var ei = new ErrorInfo()
            {
                Source = source,
                Message = msg
            };
            Add(ei);
        }

        public void AddPersonError(int idp, string msg)
        {
            var ei = new ErrorInfo();
            /*
            var table_persons = KlonsData.St.DataSetKlons.PERSONS;
            if (table_persons != null)
            {
                var dr = table_persons.FindByID(idp);
                if (dr != null)
                    ei.Source = string.Format("{0}", dr.ZNAME);
            }
            */
            ei.Message = msg;
            Add(ei);
        }

        public void SetErrorList(ErrorList newlist)
        {
            Clear();
            AddRange(newlist);
        }

        public static ErrorList operator +(ErrorList e1, ErrorList e2)
        {
            if (e1 == null || e2 == null) return e1;
            e1.AddRange(e2);
            return e1;
        }

    }
}
