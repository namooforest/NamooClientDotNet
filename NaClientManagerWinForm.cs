using Namoo.Frame;
using Namoo.Frame.NaExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Namoo.Client
{
    internal class NaClientManagerWinForm
    {
        private Control _parentControl = null;
        private ContextMenuStrip _context = null;

        /// <summary>메뉴 생성</summary>
        internal void LoadMenu(MenuStrip menu, List<Menu> data)
        {
            DataTable dt = NaFunctions.ConvertObjectToDataTable(data);
            LoadMenuStrip(menu, dt);
        }

        /// <summary>메뉴 생성</summary>
        internal void LoadMenu(MenuStrip menu, DataTable data)
        {
            LoadMenuStrip(menu, data);
        }

        private void LoadMenuStrip(MenuStrip menu, DataTable data, ToolStripMenuItem parentMenu = null)
        {
            #region ■■ Validation ■■
            // 컬럼 확인은 최초 1회(Root 메뉴를 등록할 때)만 한다.
            if (parentMenu == null)
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

                // 부모 컨트롤 확인
                _parentControl = menu.Parent;
            }
            #endregion

            // Root 등록
            if (parentMenu == null)
            {
                DataRow[] drRootMenuList = data.Select("PARENT_MENU_ID IS NULL OR PARENT_MENU_ID = ''", "DISPLAY_SEQ, MENU_ID");
                if (drRootMenuList == null || drRootMenuList.Length == 0)
                    throw new NaException("최상위 메뉴가 하나도 없습니다.");

                foreach (DataRow drRoot in drRootMenuList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = drRoot["MENU_ID"].ToString();
                    item.Text = drRoot["MENU_NAME"] == DBNull.Value ? drRoot["MENU_ID"].ToString() : drRoot["MENU_NAME"].ToString();
                    item.Tag = drRoot;
                    item.Click += MenuClick;
                    menu.Items.Add(item);

                    // 자식 메뉴 등록
                    LoadMenuStrip(menu, data, item);
                }
            }
            else
            {
                // 자식 메뉴 등록
                DataRow[] drMenuList = data.Select(string.Format("PARENT_MENU_ID = '{0}'", parentMenu.Name), "DISPLAY_SEQ, MENU_ID");
                if (drMenuList == null || drMenuList.Length == 0)
                    return;

                foreach (DataRow drMenu in drMenuList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = drMenu["MENU_ID"].ToString();
                    item.Text = drMenu["MENU_NAME"] == DBNull.Value ? drMenu["MENU_ID"].ToString() : drMenu["MENU_NAME"].ToString();
                    item.Tag = drMenu;
                    item.Click += MenuClick;
                    parentMenu.DropDownItems.Add(item);

                    // 자식 메뉴 등록
                    LoadMenuStrip(menu, data, item);
                }
            }
        }

        private void MenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            DataRow dr = (DataRow)item.Tag;
            string sPgmId = dr["PROGRAM_ID"] == DBNull.Value ? string.Empty : dr["PROGRAM_ID"].ToString();
            if (string.IsNullOrEmpty(sPgmId))
                return;

            try
            {
                TabPage page = GetPage(dr["MENU_ID"].ToString());

                // 이미 열려있는 페이지가 있으면 열린 페이지를 활성화,
                // 없으면 생성.
                if (page == null)
                {
                    Assembly ass = Assembly.LoadFile(NaSystem.GetWorkPath() + "\\" + dr["DLL_NAME"].ToString());
                    Form frm = (Form)ass.CreateInstance(sPgmId);
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;

                    page = new TabPage();
                    page.Name = dr["MENU_ID"].ToString();
                    page.Text = dr["MENU_NAME"].ToString();
                    page.Tag = dr;
                    page.Controls.Add(frm);

                    GetMainTab().TabPages.Add(page);
                    GetMainTab().SelectedTab = page;

                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
                else
                {
                    GetMainTab().SelectedTab = page;
                }
            }
            catch (Exception ex)
            {
                throw new NaException("화면을 여는 중 에러가 발생했습니다.", ex);
            }
        }

        private TabControl GetMainTab()
        {
            List<Control> ctrls = NaFunctions.GetControlsByName(_parentControl, "MainTab", false);
            if (ctrls == null)
            {
                return null;
            }
            else
            {
                var list = ctrls.Where(c => c.GetType() == typeof(TabControl));
                if (list.Count() > 1)
                    throw new NaException("MainTab이 여러개 발견되었습니다. 메인텝이 어떤건지 모르겠어요.");

                TabControl tabMain = (TabControl)list.ToList()[0];
                return tabMain;
            }
        }

        private TabControl CreateMainTab()
        {
            TabControl tabMain = new TabControl();
            tabMain.Name = "MainTab";
            _parentControl.Controls.Add(tabMain);
            tabMain.BringToFront();
            tabMain.Dock = DockStyle.Fill;
            tabMain.MouseClick += TabMain_MouseClick;

            return tabMain;
        }

        private TabPage GetPage(string sMenuId)
        {
            TabControl tab = GetMainTab();
            if (tab == null)
                tab = CreateMainTab();

            foreach (TabPage page in tab.TabPages)
                if (page.Name.Equals(sMenuId))
                    return page;

            return null;
        }

        private void TabMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_context == null)
                {
                    _context = new ContextMenuStrip();
                    ToolStripItem closeTab = new ToolStripMenuItem();
                    closeTab.Name = "CloseTab";
                    closeTab.Text = "Close";
                    closeTab.Click += ContextMenuClick;

                    ToolStripItem closeAllTab = new ToolStripMenuItem();
                    closeAllTab.Name = "CloseAllTab";
                    closeAllTab.Text = "Close All";
                    closeAllTab.Click += ContextMenuClick;

                    ToolStripItem closeOtherTab = new ToolStripMenuItem();
                    closeOtherTab.Name = "CloseOtherTab";
                    closeOtherTab.Text = "Close Others";
                    closeOtherTab.Click += ContextMenuClick;

                    _context.Items.Add(closeTab);
                    _context.Items.Add(closeAllTab);
                    _context.Items.Add(closeOtherTab);
                }

                _context.Show(GetMainTab(), e.Location);
            }
        }

        private void ContextMenuClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            TabPage currentPage = GetMainTab().SelectedTab;
            if (item.Name.Equals("CloseTab"))
            {
                IEnumerable<Form> list = NaFunctions.GetControlsByType<Form>(currentPage, true);
                foreach (Form f in list)
                    f.Close();

                GetMainTab().TabPages.Remove(currentPage);
                if (GetMainTab().TabPages.Count == 0)
                    _parentControl.Controls.Remove(GetMainTab());
            }
            else if (item.Name.Equals("CloseAllTab"))
            {
                foreach (TabPage page in GetMainTab().TabPages)
                {
                    IEnumerable<Form> list = NaFunctions.GetControlsByType<Form>(page, true);
                    foreach (Form f in list)
                        f.Close();

                    GetMainTab().TabPages.Remove(page);
                }

                _parentControl.Controls.Remove(GetMainTab());
            }
            else if (item.Name.Equals("CloseOtherTab"))
            {
                foreach (TabPage page in GetMainTab().TabPages)
                {
                    if (page.Name != currentPage.Name)
                    {
                        IEnumerable<Form> list = NaFunctions.GetControlsByType<Form>(page, true);
                        foreach (Form f in list)
                            f.Close();

                        GetMainTab().TabPages.Remove(page);
                    }
                }
            }
        }
    }
}
