using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using Namoo.Frame;
using Namoo.Frame.DataObject.Entity;
using Namoo.Frame.NaExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Namoo.Client.FormBase
{
    internal class NaClientManagerXtraForm
    {
        internal void SetDevExpDefaultStyle()
        {
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

            WindowsFormsSettings.DefaultFont = new Font("맑은 고딕", 9F, FontStyle.Regular);
            WindowsFormsSettings.DefaultMenuFont = new Font("맑은 고딕", 9F);

            try
            {
                WindowsFormsSettings.ForceDirectXPaint();
            }
            catch
            {
                // 일부 런타임/원격 환경에서 선택 기능
            }
        }

        /// <summary>메뉴 생성</summary>
        internal void LoadMenu(Bar bar, List<NA_MENU> data)
        {
            DataTable dt = NaFunctions.ConvertObjectToDataTable(data);
            LoadMenuStrip(bar, dt);
        }

        private void LoadMenuStrip(Bar bar, DataTable data, BarItem parentItem = null)
        {
            #region ▼▼▼ Validation ▼▼▼
            // 컬럼 확인은 최초 1회(Root 메뉴를 등록할 때)만 한다.
            if (parentItem == null)
            {
                string[] requiredFileds = { "PARENT_MENU_ID", "MENU_ID", "MENU_NAME", "PROGRAM_ID", "DISPLAY_SEQ" };
                foreach (DataColumn col in data.Columns)
                {
                    if (requiredFileds.Contains(col.ColumnName))
                        requiredFileds = requiredFileds.Where(o => o != col.ColumnName).ToArray();
                }

                if (requiredFileds != null && requiredFileds.Length > 0)
                    throw new NaException("필수 컬럼이 없습니다.\n{0}", string.Join(", ", requiredFileds));

                // 빈 값 확인
                if (data.Select("MENU_ID IS NULL OR MENU_ID = ''").Length > 0)
                    throw new NaException("메뉴ID는 비어있으면 아니되옵니다.");
            }
            #endregion ▲▲▲ Validation ▲▲▲

            #region ▼▼▼ 메뉴 등록 ▼▼▼
            DataRow[] drMenuList = null;
            if (parentItem == null)
            {
                // Root 메뉴 등록
                drMenuList = data.Select("PARENT_MENU_ID IS NULL OR PARENT_MENU_ID = ''", "DISPLAY_SEQ, MENU_ID");
                if (drMenuList == null || drMenuList.Length == 0)
                    throw new NaException("최상위 메뉴가 하나도 없습니다.");
            }
            else
            {
                // 자식 메뉴 등록
                drMenuList = data.Select(string.Format("PARENT_MENU_ID = '{0}'", parentItem.Name), "DISPLAY_SEQ, MENU_ID");
                if (drMenuList == null || drMenuList.Length == 0)
                    return;
            }

            foreach (DataRow drMenu in drMenuList)
            {
                string sMenuId = Convert.ToString(drMenu["MENU_ID"]);
                string sMenuName = drMenu["MENU_NAME"] == DBNull.Value ? Convert.ToString(drMenu["MENU_ID"]) : Convert.ToString(drMenu["MENU_NAME"]);
                int iChildMenuCnt = data.Select(string.Format("PARENT_MENU_ID = '{0}'", sMenuId), "DISPLAY_SEQ, MENU_ID").Length;
                BarItem item = null;
                if (iChildMenuCnt > 0)
                    item = new BarSubItem();
                else
                    item = new BarButtonItem();

                item.Caption = sMenuName;
                item.Name = drMenu["MENU_ID"].ToString();
                item.Tag = drMenu;
                //item.Click += MenuClick;
                if (parentItem == null)
                    bar.AddItem(item);
                else
                    ((BarSubItem)parentItem).AddItem(item);

                // 자식 메뉴 등록
                LoadMenuStrip(bar, data, item);
            }
            #endregion ▲▲▲ 메뉴 등록 ▲▲▲

            #region ▼▼▼ 이벤트 등록 ▼▼▼
            bar.Manager.ItemClick += new ItemClickEventHandler(BarMenu_ItemClick);
            #endregion ▼▼▼ 이벤트 등록 ▼▼▼
        }

        /// <summary>메인Tab을 반환</summary>
        private XtraTabControl GetMainXtraTab()
        {
            Control ctlMain = Application.OpenForms[NaClientManager.MainFormName];

            List<Control> ctrls = NaClientUtils.GetControlsByName(ctlMain, NaClientManager.MainTabName, false);
            if (ctrls == null)
            {
                return null;
            }
            else
            {
                var list = ctrls.Where(c => c.GetType() == typeof(XtraTabControl));
                if (list.Count() > 1)
                    throw new NaException("MainTab이 여러개 발견되었습니다. 메인텝이 어떤건지 모르겠어요.");

                XtraTabControl tabMain = (XtraTabControl)list.ToList()[0];
                return tabMain;
            }
        }

        /// <summary>MainTab 생성</summary>
        private XtraTabControl CreateMainXtraTab()
        {
            XtraTabControl tabMain = new XtraTabControl();
            tabMain.Name = NaClientManager.MainTabName;
            Application.OpenForms[NaClientManager.MainFormName].Controls.Add(tabMain);
            tabMain.BringToFront();
            tabMain.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            tabMain.Dock = DockStyle.Fill;
            tabMain.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
            tabMain.CloseButtonClick += TabMain_CloseButtonClick;
            //tabMain.MouseClick += TabMain_MouseClick;

            return tabMain;
        }

        /// <summary>Menu ID에 해당하는 XtraTabPage 반환</summary>
        private XtraTabPage GetXtraTabPage(string sMenuId)
        {
            XtraTabControl tab = GetMainXtraTab();
            if (tab == null)
                tab = CreateMainXtraTab();

            foreach (XtraTabPage page in tab.TabPages)
                if (page.Name.Equals(sMenuId))
                    return page;

            return null;
        }

        #region ▼▼▼ Event Methods ▼▼▼
        private void BarMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarItem item = e.Item;
            DataRow dr = (DataRow)item.Tag;
            string sPgmId = dr["PROGRAM_ID"] == DBNull.Value ? string.Empty : dr["PROGRAM_ID"].ToString();
            string sPgmPath = dr["PROGRAM_PATH"] == DBNull.Value ? string.Empty : dr["PROGRAM_PATH"].ToString();
            if (string.IsNullOrEmpty(sPgmId) || string.IsNullOrEmpty(sPgmPath))
                return;

            try
            {
                XtraTabPage page = GetXtraTabPage(dr["MENU_ID"].ToString());

                // 이미 열려있는 페이지가 있으면 열린 페이지를 활성화,
                // 없으면 생성.
                if (page == null)
                {
                    Assembly ass = Assembly.LoadFile(NaSystem.GetWorkPath() + "\\" + dr["DLL_NAME"].ToString());
                    Form frm = (Form)ass.CreateInstance(sPgmPath);
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;

                    page = new XtraTabPage();
                    page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    page.Name = dr["MENU_ID"].ToString();
                    page.Text = dr["MENU_NAME"].ToString();
                    page.Tag = dr;
                    page.Controls.Add(frm);

                    GetMainXtraTab().TabPages.Add(page);
                    GetMainXtraTab().SelectedTabPage = page;

                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
                else
                {
                    GetMainXtraTab().SelectedTabPage = page;
                }
            }
            catch (Exception ex)
            {
                throw new NaException("화면을 여는 중 에러가 발생했습니다.", ex);
            }
        }

        private void TabMain_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            XtraTabControl tabControl = sender as XtraTabControl;
            XtraTabPage page = arg.Page as XtraTabPage;

            if (page != null)
            {
                // 1. 페이지 내의 모든 Form 찾아서 닫기
                IEnumerable<Form> forms = NaClientUtils.GetControlsByType<Form>(page, true);
                if (forms != null)
                {
                    foreach (Form f in forms)
                    {
                        f.Close();
                    }
                }

                // 2. 탭 페이지 제거
                tabControl.TabPages.Remove(page);

                // 3. (선택사항) 모든 탭이 닫히면 탭 컨트롤 자체를 제거하거나 숨길지 결정
                // if (tabControl.TabPages.Count == 0)
                //    _parentControl.Controls.Remove(tabControl);
            }
        }
        #endregion ▲▲▲ Event Methods ▲▲▲
    }
}
