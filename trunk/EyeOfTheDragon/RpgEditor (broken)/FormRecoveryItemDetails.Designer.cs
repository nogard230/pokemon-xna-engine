namespace RpgEditor
{
    partial class FormRecoveryItemDetails
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbSellPrice = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mtbHealthHealed = new System.Windows.Forms.MaskedTextBox();
            this.mtbPercentHealthHealed = new System.Windows.Forms.MaskedTextBox();
            this.cbCanRevive = new System.Windows.Forms.CheckBox();
            this.mtbLevelsGained = new System.Windows.Forms.MaskedTextBox();
            this.mtbPPRestored = new System.Windows.Forms.MaskedTextBox();
            this.nudMovesPPRestored = new System.Windows.Forms.NumericUpDown();
            this.cbStatusCured = new System.Windows.Forms.ComboBox();
            this.cbCureAllStatuses = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovesPPRestored)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(195, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 51;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Sell Price:";
            // 
            // mtbPrice
            // 
            this.mtbPrice.Location = new System.Drawing.Point(102, 66);
            this.mtbPrice.Mask = "000000";
            this.mtbPrice.Name = "mtbPrice";
            this.mtbPrice.Size = new System.Drawing.Size(100, 20);
            this.mtbPrice.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Price:";
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(102, 40);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(100, 20);
            this.tbType.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Type:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(102, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Name:";
            // 
            // mtbSellPrice
            // 
            this.mtbSellPrice.Location = new System.Drawing.Point(102, 93);
            this.mtbSellPrice.Mask = "000000";
            this.mtbSellPrice.Name = "mtbSellPrice";
            this.mtbSellPrice.Size = new System.Drawing.Size(100, 20);
            this.mtbSellPrice.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Health Healed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Percentage of Health Healed: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Can Revive:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Levels Gained:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "PP Restored:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Moves PP Restored:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(288, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Status Cured:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Cure All Statuses:";
            // 
            // mtbHealthHealed
            // 
            this.mtbHealthHealed.Location = new System.Drawing.Point(366, 14);
            this.mtbHealthHealed.Mask = "00000";
            this.mtbHealthHealed.Name = "mtbHealthHealed";
            this.mtbHealthHealed.Size = new System.Drawing.Size(100, 20);
            this.mtbHealthHealed.TabIndex = 61;
            // 
            // mtbPercentHealthHealed
            // 
            this.mtbPercentHealthHealed.Location = new System.Drawing.Point(366, 39);
            this.mtbPercentHealthHealed.Mask = "00.00";
            this.mtbPercentHealthHealed.Name = "mtbPercentHealthHealed";
            this.mtbPercentHealthHealed.Size = new System.Drawing.Size(100, 20);
            this.mtbPercentHealthHealed.TabIndex = 62;
            // 
            // cbCanRevive
            // 
            this.cbCanRevive.AutoSize = true;
            this.cbCanRevive.Location = new System.Drawing.Point(366, 68);
            this.cbCanRevive.Name = "cbCanRevive";
            this.cbCanRevive.Size = new System.Drawing.Size(15, 14);
            this.cbCanRevive.TabIndex = 63;
            this.cbCanRevive.UseVisualStyleBackColor = true;
            // 
            // mtbLevelsGained
            // 
            this.mtbLevelsGained.Location = new System.Drawing.Point(366, 93);
            this.mtbLevelsGained.Mask = "000";
            this.mtbLevelsGained.Name = "mtbLevelsGained";
            this.mtbLevelsGained.Size = new System.Drawing.Size(100, 20);
            this.mtbLevelsGained.TabIndex = 64;
            // 
            // mtbPPRestored
            // 
            this.mtbPPRestored.Location = new System.Drawing.Point(365, 119);
            this.mtbPPRestored.Mask = "00";
            this.mtbPPRestored.Name = "mtbPPRestored";
            this.mtbPPRestored.Size = new System.Drawing.Size(100, 20);
            this.mtbPPRestored.TabIndex = 65;
            // 
            // nudMovesPPRestored
            // 
            this.nudMovesPPRestored.Location = new System.Drawing.Point(366, 145);
            this.nudMovesPPRestored.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudMovesPPRestored.Name = "nudMovesPPRestored";
            this.nudMovesPPRestored.Size = new System.Drawing.Size(32, 20);
            this.nudMovesPPRestored.TabIndex = 66;
            // 
            // cbStatusCured
            // 
            this.cbStatusCured.FormattingEnabled = true;
            this.cbStatusCured.Location = new System.Drawing.Point(366, 173);
            this.cbStatusCured.Name = "cbStatusCured";
            this.cbStatusCured.Size = new System.Drawing.Size(121, 21);
            this.cbStatusCured.TabIndex = 67;
            // 
            // cbCureAllStatuses
            // 
            this.cbCureAllStatuses.AutoSize = true;
            this.cbCureAllStatuses.Location = new System.Drawing.Point(366, 201);
            this.cbCureAllStatuses.Name = "cbCureAllStatuses";
            this.cbCureAllStatuses.Size = new System.Drawing.Size(15, 14);
            this.cbCureAllStatuses.TabIndex = 68;
            this.cbCureAllStatuses.UseVisualStyleBackColor = true;
            // 
            // FormRecoveryItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 266);
            this.ControlBox = false;
            this.Controls.Add(this.cbCureAllStatuses);
            this.Controls.Add(this.cbStatusCured);
            this.Controls.Add(this.nudMovesPPRestored);
            this.Controls.Add(this.mtbPPRestored);
            this.Controls.Add(this.mtbLevelsGained);
            this.Controls.Add(this.cbCanRevive);
            this.Controls.Add(this.mtbPercentHealthHealed);
            this.Controls.Add(this.mtbHealthHealed);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtbSellPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mtbPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormRecoveryItemDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recovery Item Details";
            ((System.ComponentModel.ISupportInitialize)(this.nudMovesPPRestored)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtbPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mtbHealthHealed;
        private System.Windows.Forms.MaskedTextBox mtbPercentHealthHealed;
        private System.Windows.Forms.CheckBox cbCanRevive;
        private System.Windows.Forms.MaskedTextBox mtbLevelsGained;
        private System.Windows.Forms.MaskedTextBox mtbPPRestored;
        private System.Windows.Forms.NumericUpDown nudMovesPPRestored;
        private System.Windows.Forms.ComboBox cbStatusCured;
        private System.Windows.Forms.CheckBox cbCureAllStatuses;
    }
}