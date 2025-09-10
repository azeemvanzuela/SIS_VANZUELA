namespace WindowsFormsApp1
{
    partial class DGVStudent
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DGVStudents = new System.Windows.Forms.DataGridView();
            this.lblSCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(368, 372);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(128, 372);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(460, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(326, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(117, 20);
            this.txtSearch.TabIndex = 35;
            // 
            // DGVStudents
            // 
            this.DGVStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStudents.Location = new System.Drawing.Point(28, 39);
            this.DGVStudents.Name = "DGVStudents";
            this.DGVStudents.RowHeadersWidth = 51;
            this.DGVStudents.Size = new System.Drawing.Size(509, 313);
            this.DGVStudents.TabIndex = 34;
            this.DGVStudents.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVStudents_CellMouseDoubleClick);
            // 
            // lblSCount
            // 
            this.lblSCount.AutoSize = true;
            this.lblSCount.Location = new System.Drawing.Point(25, 16);
            this.lblSCount.Name = "lblSCount";
            this.lblSCount.Size = new System.Drawing.Size(41, 13);
            this.lblSCount.TabIndex = 39;
            this.lblSCount.Text = "Count: ";
            // 
            // DGVStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 418);
            this.Controls.Add(this.lblSCount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DGVStudents);
            this.Name = "DGVStudent";
            this.Text = "DGVStudent";
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.DataGridView DGVStudents;
        private System.Windows.Forms.Label lblSCount;
    }
}