﻿namespace Clothing_shop
{
    partial class frmHangBiTraLai
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.returns_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_cusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_cusPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_cusAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returns_detail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.returns_id,
            this.returns_cusName,
            this.returns_cusPhone,
            this.returns_cusAddress,
            this.returns_date,
            this.returns_reason,
            this.returns_detail});
            this.dataGridView1.Location = new System.Drawing.Point(12, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(774, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hàng Bị Trả Lại";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xem Chi Tiết";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // returns_id
            // 
            this.returns_id.HeaderText = "ID";
            this.returns_id.Name = "returns_id";
            // 
            // returns_cusName
            // 
            this.returns_cusName.HeaderText = "Tên Khách Hàng";
            this.returns_cusName.Name = "returns_cusName";
            // 
            // returns_cusPhone
            // 
            this.returns_cusPhone.HeaderText = "Số Điện Thoại";
            this.returns_cusPhone.Name = "returns_cusPhone";
            // 
            // returns_cusAddress
            // 
            this.returns_cusAddress.HeaderText = "Địa Chỉ";
            this.returns_cusAddress.Name = "returns_cusAddress";
            // 
            // returns_date
            // 
            this.returns_date.HeaderText = "Ngày Trả Hàng";
            this.returns_date.Name = "returns_date";
            // 
            // returns_reason
            // 
            this.returns_reason.HeaderText = "Lý Do";
            this.returns_reason.Name = "returns_reason";
            // 
            // returns_detail
            // 
            this.returns_detail.HeaderText = "Details";
            this.returns_detail.Name = "returns_detail";
            this.returns_detail.Text = "Chi Tiết";
            // 
            // frmHangBiTraLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 526);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmHangBiTraLai";
            this.Text = "Quản lý cửa hàng ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_cusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_cusPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_cusAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn returns_reason;
        private System.Windows.Forms.DataGridViewButtonColumn returns_detail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}