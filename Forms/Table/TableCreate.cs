using Namoo.Controls.DevExp.ExtMethods;
using Namoo.Worker.Message;
using System;

namespace Namoo.Client.Forms.Table
{
    public partial class TableCreate : NaBaseXtraForm
    {
        public TableCreate()
        {
            InitializeComponent();
            this.Load += TableCreate_Load;
        }

        private void TableCreate_Load(object sender, EventArgs e)
        {
            SetColumnListGrid();
            SetTableDefineGrid();

            this.picExecute.Click += PicExecute_Click;
            this.picAdd.Click += PicAdd_Click;
            this.picRemove.Click += PicRemove_Click;
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PicRemove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PicExecute_Click(object sender, EventArgs e)
        {
            NaWorkerReq spec = new NaWorkerReq("");
            CallWorker(spec);
        }

        private void SetColumnListGrid()
        {
            gvColumn.InitReadOnlyGridView();
            gvColumn.AddCheckColumn("CHK", "", "Y", "N");
            gvColumn.AddTextColumn("COLUMN_NAME", "컬럼명");
            gvColumn.AddTextColumn("COLUMN_TYPE", "컬럼타입");
            gvColumn.AddTextColumn("COLUMN_DESC", "컬럼설명");
        }
        private void SetTableDefineGrid()
        {
            gvTable.InitReadOnlyGridView();
            gvTable.AddCheckColumn("CHK", "", "Y", "N");
            gvTable.AddCheckColumn("COLUMN_PK", "PK", "Y", "N");
            gvTable.AddTextColumn("COLUMN_NAME", "컬럼명");
            gvTable.AddTextColumn("COLUMN_TYPE", "컬럼타입");
            gvTable.AddCheckColumn("COLUMN_NULLABLE", "NULLABLE", "Y", "N");
            gvTable.AddTextColumn("COLUMN_DESC", "컬럼설명");
            gvTable.AddTextColumn("FK_TABLE_NAME", "외래키 테이블명");
            gvTable.AddTextColumn("FK_COLUMN_NAME", "외래키 컬럼명");
        }
    }
}
