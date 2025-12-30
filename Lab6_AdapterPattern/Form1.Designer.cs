namespace Lab6_AdapterPattern
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveText = new System.Windows.Forms.Button();
            this.btnLoadText = new System.Windows.Forms.Button();
            this.btnSaveBin = new System.Windows.Forms.Button();
            this.btnLoadBin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(639, 162);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSaveText
            // 
            this.btnSaveText.Location = new System.Drawing.Point(916, 51);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(123, 34);
            this.btnSaveText.TabIndex = 1;
            this.btnSaveText.Text = "Save Text";
            this.btnSaveText.UseVisualStyleBackColor = true;
            // 
            // btnLoadText
            // 
            this.btnLoadText.Location = new System.Drawing.Point(916, 91);
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(123, 30);
            this.btnLoadText.TabIndex = 2;
            this.btnLoadText.Text = "Load Text";
            this.btnLoadText.UseVisualStyleBackColor = true;
            // 
            // btnSaveBin
            // 
            this.btnSaveBin.Location = new System.Drawing.Point(916, 127);
            this.btnSaveBin.Name = "btnSaveBin";
            this.btnSaveBin.Size = new System.Drawing.Size(123, 34);
            this.btnSaveBin.TabIndex = 3;
            this.btnSaveBin.Text = "Save Binary";
            this.btnSaveBin.UseVisualStyleBackColor = true;
            // 
            // btnLoadBin
            // 
            this.btnLoadBin.Location = new System.Drawing.Point(916, 167);
            this.btnLoadBin.Name = "btnLoadBin";
            this.btnLoadBin.Size = new System.Drawing.Size(123, 36);
            this.btnLoadBin.TabIndex = 4;
            this.btnLoadBin.Text = "Load Binary";
            this.btnLoadBin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 579);
            this.Controls.Add(this.btnLoadBin);
            this.Controls.Add(this.btnSaveBin);
            this.Controls.Add(this.btnLoadText);
            this.Controls.Add(this.btnSaveText);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveText;
        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.Button btnSaveBin;
        private System.Windows.Forms.Button btnLoadBin;
    }
}

