namespace KGG_1
{
    partial class FormPlot
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
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.labelC = new System.Windows.Forms.Label();
            this.buttonDrawPlot = new System.Windows.Forms.Button();
            this.textBoxBeta = new System.Windows.Forms.TextBox();
            this.labelBeta = new System.Windows.Forms.Label();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.groupBoxPlot = new System.Windows.Forms.GroupBox();
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            this.groupBoxTask = new System.Windows.Forms.GroupBox();
            this.listBoxTask = new System.Windows.Forms.ListBox();
            this.customizedToolTipDrawPlot = new KGG_1.CustomizedToolTip();
            this.groupBoxParameters.SuspendLayout();
            this.groupBoxPlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.groupBoxTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxParameters.AutoSize = true;
            this.groupBoxParameters.Controls.Add(this.textBoxC);
            this.groupBoxParameters.Controls.Add(this.labelC);
            this.groupBoxParameters.Controls.Add(this.buttonDrawPlot);
            this.groupBoxParameters.Controls.Add(this.textBoxBeta);
            this.groupBoxParameters.Controls.Add(this.labelBeta);
            this.groupBoxParameters.Controls.Add(this.textBoxAlpha);
            this.groupBoxParameters.Controls.Add(this.labelAlpha);
            this.groupBoxParameters.Controls.Add(this.textBoxB);
            this.groupBoxParameters.Controls.Add(this.textBoxA);
            this.groupBoxParameters.Controls.Add(this.labelB);
            this.groupBoxParameters.Controls.Add(this.labelA);
            this.groupBoxParameters.Location = new System.Drawing.Point(213, 13);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(565, 57);
            this.groupBoxParameters.TabIndex = 1;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Введите параметры";
            // 
            // textBoxC
            // 
            this.textBoxC.Location = new System.Drawing.Point(188, 17);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(50, 20);
            this.textBoxC.TabIndex = 3;
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(165, 20);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(17, 13);
            this.labelC.TabIndex = 0;
            this.labelC.Text = "C:";
            // 
            // buttonDrawPlot
            // 
            this.buttonDrawPlot.Location = new System.Drawing.Point(401, 15);
            this.buttonDrawPlot.Name = "buttonDrawPlot";
            this.buttonDrawPlot.Size = new System.Drawing.Size(158, 23);
            this.buttonDrawPlot.TabIndex = 6;
            this.buttonDrawPlot.Text = "Построить график";
            this.customizedToolTipDrawPlot.SetToolTip(this.buttonDrawPlot, "Функция");
            this.buttonDrawPlot.UseVisualStyleBackColor = true;
            this.buttonDrawPlot.Click += new System.EventHandler(this.buttonDrawPlot_Click);
            // 
            // textBoxBeta
            // 
            this.textBoxBeta.Location = new System.Drawing.Point(345, 17);
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.Size = new System.Drawing.Size(50, 20);
            this.textBoxBeta.TabIndex = 5;
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(323, 20);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(16, 13);
            this.labelBeta.TabIndex = 0;
            this.labelBeta.Text = "β:";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(267, 17);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(50, 20);
            this.textBoxAlpha.TabIndex = 4;
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(244, 20);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(17, 13);
            this.labelAlpha.TabIndex = 0;
            this.labelAlpha.Text = "α:";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(109, 17);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(50, 20);
            this.textBoxB.TabIndex = 2;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(30, 17);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(50, 20);
            this.textBoxA.TabIndex = 1;
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(86, 20);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(17, 13);
            this.labelB.TabIndex = 0;
            this.labelB.Text = "B:";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(7, 20);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(17, 13);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "A:";
            // 
            // groupBoxPlot
            // 
            this.groupBoxPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPlot.AutoSize = true;
            this.groupBoxPlot.Controls.Add(this.pictureBoxPlot);
            this.groupBoxPlot.Location = new System.Drawing.Point(213, 77);
            this.groupBoxPlot.Name = "groupBoxPlot";
            this.groupBoxPlot.Size = new System.Drawing.Size(562, 483);
            this.groupBoxPlot.TabIndex = 2;
            this.groupBoxPlot.TabStop = false;
            this.groupBoxPlot.Text = "График";
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.BackColor = System.Drawing.Color.White;
            this.pictureBoxPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlot.Location = new System.Drawing.Point(3, 16);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(556, 464);
            this.pictureBoxPlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlot.TabIndex = 0;
            this.pictureBoxPlot.TabStop = false;
            this.pictureBoxPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPlot_Paint);
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add(this.listBoxTask);
            this.groupBoxTask.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size(194, 550);
            this.groupBoxTask.TabIndex = 3;
            this.groupBoxTask.TabStop = false;
            this.groupBoxTask.Text = "Выбор задачи";
            // 
            // listBoxTask
            // 
            this.listBoxTask.FormattingEnabled = true;
            this.listBoxTask.Items.AddRange(new object[] {
            "График функции",
            "Алгоритм Брезенхема",
            "Многоугольники",
            "График поверхности",
            "Удаление невидимых линий"});
            this.listBoxTask.Location = new System.Drawing.Point(6, 19);
            this.listBoxTask.Name = "listBoxTask";
            this.listBoxTask.Size = new System.Drawing.Size(182, 524);
            this.listBoxTask.TabIndex = 0;
            // 
            // customizedToolTipDrawPlot
            // 
            this.customizedToolTipDrawPlot.AutoPopDelay = 10000;
            this.customizedToolTipDrawPlot.AutoSize = false;
            this.customizedToolTipDrawPlot.BorderColor = System.Drawing.Color.Transparent;
            this.customizedToolTipDrawPlot.InitialDelay = 500;
            this.customizedToolTipDrawPlot.OwnerDraw = true;
            this.customizedToolTipDrawPlot.ReshowDelay = 100;
            this.customizedToolTipDrawPlot.Size = new System.Drawing.Size(400, 200);
            // 
            // FormPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 569);
            this.Controls.Add(this.groupBoxTask);
            this.Controls.Add(this.groupBoxPlot);
            this.Controls.Add(this.groupBoxParameters);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormPlot";
            this.Text = "Plot";
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            this.groupBoxPlot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.groupBoxTask.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Button buttonDrawPlot;
        private System.Windows.Forms.TextBox textBoxBeta;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.GroupBox groupBoxPlot;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.PictureBox pictureBoxPlot;
        private System.Windows.Forms.ListBox listBoxTask;
        private CustomizedToolTip customizedToolTipDrawPlot;
    }
}

