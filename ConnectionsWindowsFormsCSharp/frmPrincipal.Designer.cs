namespace ConnectionsWindowsFormsCSharp
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInsert = new Button();
            btnUpdate = new Button();
            btnSelect = new Button();
            btnDelete = new Button();
            tbID = new TextBox();
            lbID = new Label();
            tbNome = new TextBox();
            lbNome = new Label();
            tbTpDocto = new TextBox();
            lbTpDocto = new Label();
            tbDocto = new TextBox();
            lbDocto = new Label();
            tbTelefone = new TextBox();
            lbTelefone = new Label();
            tbSearch = new TextBox();
            lbSearch = new Label();
            btnProcedure = new Button();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(0, 0);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(225, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(432, 0);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(646, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbID
            // 
            tbID.Location = new Point(12, 67);
            tbID.Name = "tbID";
            tbID.Size = new Size(125, 27);
            tbID.TabIndex = 5;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Location = new Point(12, 44);
            lbID.Name = "lbID";
            lbID.Size = new Size(24, 20);
            lbID.TabIndex = 4;
            lbID.Text = "ID";
            // 
            // tbNome
            // 
            tbNome.Location = new Point(12, 125);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(125, 27);
            tbNome.TabIndex = 7;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(12, 102);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(50, 20);
            lbNome.TabIndex = 6;
            lbNome.Text = "Nome";
            // 
            // tbTpDocto
            // 
            tbTpDocto.Location = new Point(12, 184);
            tbTpDocto.Name = "tbTpDocto";
            tbTpDocto.Size = new Size(125, 27);
            tbTpDocto.TabIndex = 9;
            // 
            // lbTpDocto
            // 
            lbTpDocto.AutoSize = true;
            lbTpDocto.Location = new Point(12, 161);
            lbTpDocto.Name = "lbTpDocto";
            lbTpDocto.Size = new Size(70, 20);
            lbTpDocto.TabIndex = 8;
            lbTpDocto.Text = "Tp Docto";
            // 
            // tbDocto
            // 
            tbDocto.Location = new Point(12, 246);
            tbDocto.Name = "tbDocto";
            tbDocto.Size = new Size(125, 27);
            tbDocto.TabIndex = 11;
            // 
            // lbDocto
            // 
            lbDocto.AutoSize = true;
            lbDocto.Location = new Point(12, 223);
            lbDocto.Name = "lbDocto";
            lbDocto.Size = new Size(50, 20);
            lbDocto.TabIndex = 10;
            lbDocto.Text = "Docto";
            // 
            // tbTelefone
            // 
            tbTelefone.Location = new Point(12, 316);
            tbTelefone.Name = "tbTelefone";
            tbTelefone.Size = new Size(125, 27);
            tbTelefone.TabIndex = 13;
            // 
            // lbTelefone
            // 
            lbTelefone.AutoSize = true;
            lbTelefone.Location = new Point(12, 293);
            lbTelefone.Name = "lbTelefone";
            lbTelefone.Size = new Size(66, 20);
            lbTelefone.TabIndex = 12;
            lbTelefone.Text = "Telefone";
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(237, 67);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(125, 27);
            tbSearch.TabIndex = 15;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Location = new Point(237, 44);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(70, 20);
            lbSearch.TabIndex = 14;
            lbSearch.Text = "Pesquisar";
            // 
            // btnProcedure
            // 
            btnProcedure.Location = new Point(646, 102);
            btnProcedure.Name = "btnProcedure";
            btnProcedure.Size = new Size(94, 29);
            btnProcedure.TabIndex = 16;
            btnProcedure.Text = "Procedure";
            btnProcedure.UseVisualStyleBackColor = true;
            btnProcedure.Click += btnProcedure_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 450);
            Controls.Add(btnProcedure);
            Controls.Add(tbSearch);
            Controls.Add(lbSearch);
            Controls.Add(tbTelefone);
            Controls.Add(lbTelefone);
            Controls.Add(tbDocto);
            Controls.Add(lbDocto);
            Controls.Add(tbTpDocto);
            Controls.Add(lbTpDocto);
            Controls.Add(tbNome);
            Controls.Add(lbNome);
            Controls.Add(tbID);
            Controls.Add(lbID);
            Controls.Add(btnDelete);
            Controls.Add(btnSelect);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Name = "frmPrincipal";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private Button btnUpdate;
        private Button btnSelect;
        private Button btnDelete;
        private TextBox tbID;
        private Label lbID;
        private TextBox tbNome;
        private Label lbNome;
        private TextBox tbTpDocto;
        private Label lbTpDocto;
        private TextBox tbDocto;
        private Label lbDocto;
        private TextBox tbTelefone;
        private Label lbTelefone;
        private TextBox tbSearch;
        private Label lbSearch;
        private Button btnProcedure;
    }
}