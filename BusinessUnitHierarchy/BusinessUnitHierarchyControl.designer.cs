namespace BusinessUnitHierarchy
{
    partial class BusinessUnitHierarchyControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessUnitHierarchyControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGenerateBU = new System.Windows.Forms.ToolStripButton();
            this.tvBusinessUnits = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvTeams = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTeams = new System.Windows.Forms.Label();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUsers = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.tssSeparator1,
            this.btnGenerateBU});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1450, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnGenerateBU
            // 
            this.btnGenerateBU.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBU.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateBU.Image")));
            this.btnGenerateBU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateBU.Name = "btnGenerateBU";
            this.btnGenerateBU.Size = new System.Drawing.Size(247, 28);
            this.btnGenerateBU.Text = "Load Business Unit Hierarchy";
            this.btnGenerateBU.Click += new System.EventHandler(this.btnGenerateBU_Click);
            // 
            // tvBusinessUnits
            // 
            this.tvBusinessUnits.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.tvBusinessUnits.ImageIndex = 0;
            this.tvBusinessUnits.ImageList = this.imageList1;
            this.tvBusinessUnits.Location = new System.Drawing.Point(11, 72);
            this.tvBusinessUnits.Margin = new System.Windows.Forms.Padding(2);
            this.tvBusinessUnits.Name = "tvBusinessUnits";
            this.tvBusinessUnits.SelectedImageIndex = 0;
            this.tvBusinessUnits.Size = new System.Drawing.Size(350, 570);
            this.tvBusinessUnits.TabIndex = 5;
            this.tvBusinessUnits.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBusinessUnits_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ico_business.gif");
            // 
            // lvTeams
            // 
            this.lvTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvTeams.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.lvTeams.FullRowSelect = true;
            this.lvTeams.GridLines = true;
            this.lvTeams.Location = new System.Drawing.Point(938, 72);
            this.lvTeams.Margin = new System.Windows.Forms.Padding(2);
            this.lvTeams.MultiSelect = false;
            this.lvTeams.Name = "lvTeams";
            this.lvTeams.Scrollable = false;
            this.lvTeams.Size = new System.Drawing.Size(500, 570);
            this.lvTeams.TabIndex = 13;
            this.lvTeams.UseCompatibleStateImageBehavior = false;
            this.lvTeams.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Team Name";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Team Type";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Administrator";
            this.columnHeader5.Width = 240;
            // 
            // lblTeams
            // 
            this.lblTeams.AutoSize = true;
            this.lblTeams.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.lblTeams.Location = new System.Drawing.Point(935, 40);
            this.lblTeams.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(49, 16);
            this.lblTeams.TabIndex = 14;
            this.lblTeams.Text = "Teams";
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvUsers.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F);
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(432, 72);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(450, 570);
            this.lvUsers.TabIndex = 15;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Full Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "E - Mail";
            this.columnHeader2.Width = 290;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(429, 40);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(44, 16);
            this.lblUsers.TabIndex = 16;
            this.lblUsers.Text = "Users";
            // 
            // BusinessUnitHierarchyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.lblTeams);
            this.Controls.Add(this.lvTeams);
            this.Controls.Add(this.tvBusinessUnits);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "BusinessUnitHierarchyControl";
            this.Size = new System.Drawing.Size(1450, 650);
            this.Load += new System.EventHandler(this.BusinessUnitHierarchyControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TreeView tvBusinessUnits;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton btnGenerateBU;
        private System.Windows.Forms.ListView lvTeams;
        private System.Windows.Forms.Label lblTeams;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
