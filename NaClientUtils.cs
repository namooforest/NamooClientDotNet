using Namoo.Client.Forms;
using Namoo.Controls.FormControl;
using Namoo.Frame.DTO;
using Namoo.Worker.Message;
using System;
using System.Collections.Generic;
using System.Data;

namespace Namoo.Client
{
    public static class NaClientUtils
    {
        static NaBaseFormHelper _helper = new NaBaseFormHelper();
        public static DataTable SelectNonTrx(NaConnector conn, string sSqlGroupId, string sSqlId, Dictionary<string, object> dicParam = null)
        {
            {
                try
                {
                    Dictionary<string, object> dicParameter = new Dictionary<string, object>();
                    dicParameter.Add("CONN_NAME", conn.ConnectorName);
                    dicParameter.Add("SQL_GROUP_ID", sSqlGroupId);
                    dicParameter.Add("SQL_ID", sSqlId);
                    dicParameter.Add("PARAMETERS", dicParam);

                    NaWorkerReq req = new NaWorkerReq("Namoo.Server.Common.ExecuteSelectQuery", dicParameter, conn);
                    NaWorkerRes res = _helper.CallWorker(req);
                    if (res.IsSuccess)
                    {
                        return res.GetResponseData<DataTable>("RESULT");
                    }
                    else
                    {
                        NaMsgBox.Alert("오류", res.Message);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
