﻿namespace RpgEditor
{
    partial class FormRecoveryItem
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
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(374, 394);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(277, 394);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(180, 394);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // lbDetails
            // 
            this.lbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDetails.Size = new System.Drawing.Size(624, 355);
            // 
            // FormShield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 429);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "FormShield";
            this.Text = "Recovery Items";
            this.ResumeLayout(false);

        }

        #endregion

    }
}