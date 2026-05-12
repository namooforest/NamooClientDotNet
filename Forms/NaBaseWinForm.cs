using Namoo.Frame.Message;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Namoo.Client.Forms
{
    public partial class NaBaseWinForm : Form, INaBaseForm
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 부모(Owner)가 있고, 내 아이콘이 아직 설정되지 않았을 때만 상속
            if (this.Owner != null && this.Icon == null)
                this.Icon = this.Owner.Icon;
        }

        public NaWorkerRes CallWorker(string workerName)
        {
            NaWorkerReq req = new NaWorkerReq(workerName);
            return new NaBaseFormHelper().CallWorker(req);
        }

        public NaWorkerRes CallWorker(string sWorkerName, Dictionary<string, object> dicParam)
        {
            NaWorkerReq req = new NaWorkerReq(sWorkerName, dicParam);
            return new NaBaseFormHelper().CallWorker(req);
        }

        public NaWorkerRes CallWorker(NaWorkerReq spec) => new NaBaseFormHelper().CallWorker(spec);
    }
}
