using DevExpress.XtraBars;
using Namoo.Frame.DataObject.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Namoo.Client
{
    public class NaClientManager
    {
        internal static string MainTabName = "MainTab";
        internal static string MainFormName = "Main";

        private static readonly Lazy<NaClientManagerWinForm> _iWinFrom = new Lazy<NaClientManagerWinForm>(() => new NaClientManagerWinForm());
        private static readonly Lazy<NaClientManagerXtraForm> _iXtraForm = new Lazy<NaClientManagerXtraForm>(() => new NaClientManagerXtraForm());

        #region ▼▼▼ Static wrapper mehtods ▼▼▼
        // Winform Menu Load
        public static void LoadMenu(MenuStrip menu, List<NA_MENU> data) => _iWinFrom.Value.LoadMenu(menu, data);
        public static void LoadMenu(MenuStrip menu, DataTable data) => _iWinFrom.Value.LoadMenu(menu, data);

        // DevExpress Menu Load
        public static void LoadMenu(Bar bar, List<NA_MENU> data) => _iXtraForm.Value.LoadMenu(bar, data);
        public static void SetDevExpDefaultStyle() => _iXtraForm.Value.SetDevExpDefaultStyle();
        #endregion ▲▲▲ Static wrapper mehtods ▲▲▲
    }
}
