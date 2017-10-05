namespace Polygon {
    partial class UserForm {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.verticesDataGridView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculateAreaButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.verticesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // verticesDataGridView
            // 
            this.verticesDataGridView.AllowUserToResizeRows = false;
            this.verticesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.verticesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.verticesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.verticesDataGridView.MultiSelect = false;
            this.verticesDataGridView.Name = "verticesDataGridView";
            this.verticesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.verticesDataGridView.Size = new System.Drawing.Size(243, 490);
            this.verticesDataGridView.TabIndex = 0;
            this.verticesDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.verticesDataGridView_CellBeginEdit);
            this.verticesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.verticesDataGridView_CellEndEdit);
            this.verticesDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.verticesDataGridView_RowsAdded);
            this.verticesDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.verticesDataGridView_RowsRemoved);
            this.verticesDataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.verticesDataGridView_RowValidating);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // calculateAreaButton
            // 
            this.calculateAreaButton.Location = new System.Drawing.Point(12, 508);
            this.calculateAreaButton.Name = "calculateAreaButton";
            this.calculateAreaButton.Size = new System.Drawing.Size(123, 23);
            this.calculateAreaButton.TabIndex = 1;
            this.calculateAreaButton.Text = "Вычислить площадь ";
            this.calculateAreaButton.UseVisualStyleBackColor = true;
            this.calculateAreaButton.Click += new System.EventHandler(this.calculateAreaButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.outputLabel.Location = new System.Drawing.Point(12, 534);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(243, 13);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.Text = "-";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 556);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.calculateAreaButton);
            this.Controls.Add(this.verticesDataGridView);
            this.Name = "UserForm";
            this.Text = "2D-Многоугольник";
            ((System.ComponentModel.ISupportInitialize)(this.verticesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView verticesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button calculateAreaButton;
        private System.Windows.Forms.Label outputLabel;
    }
}

