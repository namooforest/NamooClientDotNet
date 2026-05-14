using Namoo.Client.Worker;
using Namoo.Controls.FormControl;
using Namoo.Frame.DataObject.DTO;
using Namoo.Frame.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace Namoo.Client
{
    public static class NaClientUtils
    {
        #region ■■ Windows(WinForms) 전용 유틸 (Frame에서 이전) ■■

        /// <summary>기본 폰트 (맑은 고딕 10pt)</summary>
        public static readonly Font DefaultFont = new Font("맑은 고딕", 10F);

        /// <summary>특정 타입의 컨트롤을 조회</summary>
        public static IEnumerable<T> GetControlsByType<T>(Control control, bool searchChild = true) where T : class
        {
            foreach (Control child in control.Controls)
            {
                T childOfT = child as T;
                if (childOfT != null)
                    yield return childOfT;

                if (searchChild && child.HasChildren)
                    foreach (T descendant in GetControlsByType<T>(child))
                        yield return descendant;
            }
        }

        /// <summary>이름(Name)을 기준으로 컨트롤 찾기</summary>
        public static List<Control> GetControlsByName(Control control, string sSearchName, bool searchChild = true)
        {
            List<Control> rtList = new List<Control>();
            foreach (Control child in control.Controls)
            {
                if (child.Name.Equals(sSearchName))
                    rtList.Add(child);

                if (child.HasChildren && searchChild)
                {
                    List<Control> liChild = GetControlsByName(child, sSearchName, searchChild);
                    if (liChild != null && liChild.Count > 0)
                        rtList = rtList.Concat(liChild).ToList();
                }
            }

            if (rtList.Count == 0)
                return null;
            return rtList;
        }

        /// <summary>입력한 컨트롤이 속한 최상위 컨트롤을 찾음</summary>
        public static Control GetRootControl(Control control)
        {
            if (control.Parent == null)
                return control;
            return GetRootControl(control.Parent);
        }

        /// <summary>입력한 폰트명이 설치된 폰트인지 여부 반환</summary>
        public static bool IsFontInstalled(string fontName)
        {
            using (var fonts = new InstalledFontCollection())
            {
                return fonts.Families.Any(f => f.Name.Equals(fontName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        /// <summary>
        /// 현재 WinForms 애플리케이션의 메인 폼을 반환합니다. 메시지 루프가 없거나 열린 폼이 없으면 null입니다.
        /// 우선 순위: 이름(Name)이 <c>Main</c>인 폼 → <see cref="Application.OpenForms"/>의 첫 번째 항목.
        /// </summary>
        public static Form GetMainForm()
        {
            if (!Application.MessageLoop)
                return null;

            Form byName = Application.OpenForms["Main"];
            if (byName != null && !byName.IsDisposed)
                return byName;

            if (Application.OpenForms.Count == 0)
                return null;

            Form first = Application.OpenForms[0];
            return (first != null && !first.IsDisposed) ? first : null;
        }

        #region ■■ Konami Sequence ■■
        private static List<Keys> _commandKeys = null;
        private static int _commandPosition = -1;

        public static int Position
        {
            get { return _commandPosition; }
            private set { _commandPosition = value; }
        }

        public static void SetCommandKeys(params Keys[] command)
        {
            _commandKeys = new List<Keys>();
            foreach (Keys k in command)
                _commandKeys.Add(k);
        }

        public static bool CommandInput(Keys key)
        {
            if (_commandKeys[Position + 1] == key)
                Position++;
            else if (Position == 1 && key == Keys.Up)
                { }
            else if (_commandKeys[0] == key)
                Position = 0;
            else
                Position = -1;

            if (Position == _commandKeys.Count - 1)
            {
                Position = -1;
                return true;
            }
            return false;
        }
        #endregion

        #endregion

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

                    NaWorkerReq req = new NaWorkerReq("Namoo.ExecuteSelectQuery", dicParameter, conn);
                    NaWorkerRes res = NaCall.Worker(req);
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
                catch
                {
                    throw;
                }
            }
        }
    }
}
