using Namoo.Worker.Message;
using System.Collections.Generic;

namespace Namoo.Client.Forms
{
    public interface INaBaseForm
    {
        NaWorkerRes CallWorker(string sWorkerName);
        NaWorkerRes CallWorker(string sWorkerName, Dictionary<string, object> dicParam);
        NaWorkerRes CallWorker(NaWorkerReq spec);
    }
}
