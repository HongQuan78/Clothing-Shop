namespace Clothing_shop
{
    partial class DashBoard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Tho = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbAmountMonth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbAmountDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbdoanhthu = new System.Windows.Forms.Label();
            this.viewOrders = new System.Windows.Forms.DataGridView();
            this.timeFilter = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Tho);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 34);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(13, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1239, 533);
            this.panel2.TabIndex = 1;
            // 
            // Tho
            // 
            this.Tho.AutoSize = true;
            this.Tho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tho.Location = new System.Drawing.Point(518, 8);
            this.Tho.Name = "Tho";
            this.Tho.Size = new System.Drawing.Size(169, 20);
            this.Tho.TabIndex = 0;
            this.Tho.Text = "Thống kê doanh thu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbAmountMonth);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbAmountDate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lbdoanhthu);
            this.panel3.Controls.Add(this.viewOrders);
            this.panel3.Controls.Add(this.timeFilter);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(5, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 473);
            this.panel3.TabIndex = 12;
            // 
            // lbAmountMonth
            // 
            this.lbAmountMonth.AutoSize = true;
            this.lbAmountMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmountMonth.Location = new System.Drawing.Point(219, 62);
            this.lbAmountMonth.Name = "lbAmountMonth";
            this.lbAmountMonth.Size = new System.Drawing.Size(20, 18);
            this.lbAmountMonth.TabIndex = 16;
            this.lbAmountMonth.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tổng doanh thu theo tháng";
            // 
            // lbAmountDate
            // 
            this.lbAmountDate.AutoSize = true;
            this.lbAmountDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmountDate.Location = new System.Drawing.Point(219, 93);
            this.lbAmountDate.Name = "lbAmountDate";
            this.lbAmountDate.Size = new System.Drawing.Size(20, 18);
            this.lbAmountDate.TabIndex = 14;
            this.lbAmountDate.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tổng doanh thu trong ngày";
            // 
            // lbdoanhthu
            // 
            this.lbdoanhthu.AutoSize = true;
            this.lbdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdoanhthu.Location = new System.Drawing.Point(135, 26);
            this.lbdoanhthu.Name = "lbdoanhthu";
            this.lbdoanhthu.Size = new System.Drawing.Size(20, 18);
            this.lbdoanhthu.TabIndex = 12;
            this.lbdoanhthu.Text = "...";
            // 
            // viewOrders
            // 
            this.viewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewOrders.Location = new System.Drawing.Point(3, 138);
            this.viewOrders.Name = "viewOrders";
            this.viewOrders.Size = new System.Drawing.Size(582, 318);
            this.viewOrders.TabIndex = 0;
            // 
            // timeFilter
            // 
            this.timeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeFilter.Location = new System.Drawing.Point(465, 112);
            this.timeFilter.Name = "timeFilter";
            this.timeFilter.Size = new System.Drawing.Size(120, 20);
            this.timeFilter.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tổng doanh thu";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(3, 62);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(618, 394);
            this.chart.TabIndex = 14;
            this.chart.Text = "Thống kê doanh thu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Thống kê doanh thu theo ngày ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.chart);
            this.panel4.Location = new System.Drawing.Point(602, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 473);
            this.panel4.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Thống kê doanh thu trong năm";
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 594);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Tho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbAmountMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbAmountDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbdoanhthu;
        private System.Windows.Forms.DataGridView viewOrders;
        private System.Windows.Forms.DateTimePicker timeFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}