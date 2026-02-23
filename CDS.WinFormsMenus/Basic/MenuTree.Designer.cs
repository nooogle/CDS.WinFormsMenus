namespace CDS.WinFormsMenus.Basic
{
    partial class MenuTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView = new TreeView();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Margin = new Padding(2, 1, 2, 1);
            treeView.Name = "treeView";
            treeView.ShowNodeToolTips = true;
            treeView.Size = new Size(214, 165);
            treeView.TabIndex = 0;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            treeView.KeyPress += treeView_KeyPress;
            // 
            // MenuTree
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(treeView);
            Margin = new Padding(2, 1, 2, 1);
            Name = "MenuTree";
            Size = new Size(214, 165);
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView;
    }
}
