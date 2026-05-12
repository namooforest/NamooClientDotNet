using Namoo.Client.Forms.Popup;
using Namoo.Frame.Message;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Namoo.Client.Forms
{
    public class NaBaseFormHelper : INaBaseForm
    {

        public NaWorkerRes CallWorker(NaWorkerReq spec)
        {
            try
            {
                ProgressForm form = new ProgressForm(spec);
                form.StartPosition = FormStartPosition.CenterParent;

                // 현재 활성화된 폼을 부모로 지정하여 중앙에 표시
                Form owner = Form.ActiveForm;
                if (owner != null)
                    form.ShowDialog(owner);
                else
                    form.ShowDialog();

                return form.GetResponseWorker();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public NaWorkerRes CallWorker(string sWorkerName)
        {
            NaWorkerReq req = new NaWorkerReq(sWorkerName);
            return CallWorker(req);
        }

        public NaWorkerRes CallWorker(string sWorkerName, Dictionary<string, object> dicParam)
        {
            NaWorkerReq req = new NaWorkerReq(sWorkerName, dicParam);
            return CallWorker(req);
        }
    }
}
