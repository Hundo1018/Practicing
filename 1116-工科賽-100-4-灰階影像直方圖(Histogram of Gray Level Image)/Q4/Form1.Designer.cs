namespace Q4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束離開ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能要求ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.彩色影像與灰階影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.畫出灰階影像直方圖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求最小灰階和最大灰階ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.求出現最多灰階和此機率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案FileToolStripMenuItem,
            this.功能要求ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案FileToolStripMenuItem
            // 
            this.檔案FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem,
            this.結束離開ExitToolStripMenuItem});
            this.檔案FileToolStripMenuItem.Name = "檔案FileToolStripMenuItem";
            this.檔案FileToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.檔案FileToolStripMenuItem.Text = "檔案(File)";
            // 
            // 開啟彩色影像檔OpenColorImageToolStripMenuItem
            // 
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem.Name = "開啟彩色影像檔OpenColorImageToolStripMenuItem";
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem.Text = "開啟彩色影像檔(OpenColorImage)";
            this.開啟彩色影像檔OpenColorImageToolStripMenuItem.Click += new System.EventHandler(this.開啟彩色影像檔OpenColorImageToolStripMenuItem_Click);
            // 
            // 結束離開ExitToolStripMenuItem
            // 
            this.結束離開ExitToolStripMenuItem.Name = "結束離開ExitToolStripMenuItem";
            this.結束離開ExitToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.結束離開ExitToolStripMenuItem.Text = "結束離開(Exit)";
            this.結束離開ExitToolStripMenuItem.Click += new System.EventHandler(this.結束離開ExitToolStripMenuItem_Click);
            // 
            // 功能要求ToolStripMenuItem
            // 
            this.功能要求ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.彩色影像與灰階影像ToolStripMenuItem,
            this.畫出灰階影像直方圖ToolStripMenuItem,
            this.求最小灰階和最大灰階ToolStripMenuItem,
            this.求出現最多灰階和此機率ToolStripMenuItem});
            this.功能要求ToolStripMenuItem.Name = "功能要求ToolStripMenuItem";
            this.功能要求ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.功能要求ToolStripMenuItem.Text = "功能要求";
            // 
            // 彩色影像與灰階影像ToolStripMenuItem
            // 
            this.彩色影像與灰階影像ToolStripMenuItem.Name = "彩色影像與灰階影像ToolStripMenuItem";
            this.彩色影像與灰階影像ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.彩色影像與灰階影像ToolStripMenuItem.Text = "彩色影像與灰階影像";
            this.彩色影像與灰階影像ToolStripMenuItem.Click += new System.EventHandler(this.彩色影像與灰階影像ToolStripMenuItem_Click);
            // 
            // 畫出灰階影像直方圖ToolStripMenuItem
            // 
            this.畫出灰階影像直方圖ToolStripMenuItem.Name = "畫出灰階影像直方圖ToolStripMenuItem";
            this.畫出灰階影像直方圖ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.畫出灰階影像直方圖ToolStripMenuItem.Text = "畫出灰階影像直方圖";
            this.畫出灰階影像直方圖ToolStripMenuItem.Click += new System.EventHandler(this.畫出灰階影像直方圖ToolStripMenuItem_Click);
            // 
            // 求最小灰階和最大灰階ToolStripMenuItem
            // 
            this.求最小灰階和最大灰階ToolStripMenuItem.Name = "求最小灰階和最大灰階ToolStripMenuItem";
            this.求最小灰階和最大灰階ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.求最小灰階和最大灰階ToolStripMenuItem.Text = "求最小灰階和最大灰階";
            this.求最小灰階和最大灰階ToolStripMenuItem.Click += new System.EventHandler(this.求最小灰階和最大灰階ToolStripMenuItem_Click);
            // 
            // 求出現最多灰階和此機率ToolStripMenuItem
            // 
            this.求出現最多灰階和此機率ToolStripMenuItem.Name = "求出現最多灰階和此機率ToolStripMenuItem";
            this.求出現最多灰階和此機率ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.求出現最多灰階和此機率ToolStripMenuItem.Text = "求出現最多灰階和此機率";
            this.求出現最多灰階和此機率ToolStripMenuItem.Click += new System.EventHandler(this.求出現最多灰階和此機率ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(233, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(211, 319);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.ItemColumnSpacing = 100;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(450, 56);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(599, 319);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 433);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(233, 433);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(450, 433);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(687, 433);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 467);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟彩色影像檔OpenColorImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 結束離開ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能要求ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 彩色影像與灰階影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 畫出灰階影像直方圖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求最小灰階和最大灰階ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求出現最多灰階和此機率ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

