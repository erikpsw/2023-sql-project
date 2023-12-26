namespace expense_app
{
    partial class 管理总页面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.根据费用种类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.根据项目分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(111, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(93, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(792, 317);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理ToolStripMenuItem,
            this.项目管理ToolStripMenuItem,
            this.数据分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1215, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 管理ToolStripMenuItem
            // 
            this.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem";
            this.管理ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.管理ToolStripMenuItem.Text = "报销管理";
            this.管理ToolStripMenuItem.Click += new System.EventHandler(this.管理ToolStripMenuItem_Click);
            // 
            // 项目管理ToolStripMenuItem
            // 
            this.项目管理ToolStripMenuItem.Name = "项目管理ToolStripMenuItem";
            this.项目管理ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.项目管理ToolStripMenuItem.Text = "项目管理";
            this.项目管理ToolStripMenuItem.Click += new System.EventHandler(this.项目管理ToolStripMenuItem_Click);
            // 
            // 数据分析ToolStripMenuItem
            // 
            this.数据分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.根据费用种类ToolStripMenuItem,
            this.根据项目分类ToolStripMenuItem});
            this.数据分析ToolStripMenuItem.Name = "数据分析ToolStripMenuItem";
            this.数据分析ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.数据分析ToolStripMenuItem.Text = "数据分析";
            // 
            // 根据费用种类ToolStripMenuItem
            // 
            this.根据费用种类ToolStripMenuItem.Name = "根据费用种类ToolStripMenuItem";
            this.根据费用种类ToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.根据费用种类ToolStripMenuItem.Text = "根据费用种类";
            this.根据费用种类ToolStripMenuItem.Click += new System.EventHandler(this.根据费用种类ToolStripMenuItem_Click);
            // 
            // 根据项目分类ToolStripMenuItem
            // 
            this.根据项目分类ToolStripMenuItem.Name = "根据项目分类ToolStripMenuItem";
            this.根据项目分类ToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.根据项目分类ToolStripMenuItem.Text = "根据项目分类";
            this.根据项目分类ToolStripMenuItem.Click += new System.EventHandler(this.根据项目分类ToolStripMenuItem_Click);
            // 
            // 管理总页面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 593);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "管理总页面";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 根据费用种类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 根据项目分类ToolStripMenuItem;
    }
}