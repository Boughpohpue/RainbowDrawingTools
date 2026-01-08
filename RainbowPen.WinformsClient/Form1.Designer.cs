namespace RainbowDrawingTools.WinformsClient
{
    partial class Form1
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
            this.drawPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.penSizesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stepsComboBox = new System.Windows.Forms.ComboBox();
            this.orientationsComboBox = new System.Windows.Forms.ComboBox();
            this.fillsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.editColorsButton = new System.Windows.Forms.Button();
            this.drawPolygonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Location = new System.Drawing.Point(12, 12);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(1275, 800);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1293, 789);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(129, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1293, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fill background";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1293, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Draw line";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1293, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1293, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Draw rectangle";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1293, 99);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Draw ellipse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1293, 234);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Fill rectangle";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1293, 263);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Fill ellipse";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // penSizesComboBox
            // 
            this.penSizesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.penSizesComboBox.Location = new System.Drawing.Point(1363, 12);
            this.penSizesComboBox.Name = "penSizesComboBox";
            this.penSizesComboBox.Size = new System.Drawing.Size(59, 23);
            this.penSizesComboBox.TabIndex = 9;
            this.penSizesComboBox.SelectedIndexChanged += new System.EventHandler(this.penSizesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1293, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pen size:";
            // 
            // stepsComboBox
            // 
            this.stepsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stepsComboBox.FormattingEnabled = true;
            this.stepsComboBox.Location = new System.Drawing.Point(1347, 147);
            this.stepsComboBox.Name = "stepsComboBox";
            this.stepsComboBox.Size = new System.Drawing.Size(75, 23);
            this.stepsComboBox.TabIndex = 11;
            // 
            // orientationsComboBox
            // 
            this.orientationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orientationsComboBox.Location = new System.Drawing.Point(1347, 176);
            this.orientationsComboBox.Name = "orientationsComboBox";
            this.orientationsComboBox.Size = new System.Drawing.Size(75, 23);
            this.orientationsComboBox.TabIndex = 12;
            // 
            // fillsComboBox
            // 
            this.fillsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillsComboBox.Location = new System.Drawing.Point(1347, 205);
            this.fillsComboBox.Name = "fillsComboBox";
            this.fillsComboBox.Size = new System.Drawing.Size(75, 23);
            this.fillsComboBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1293, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Step:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1293, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Orient:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1293, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Fill:";
            // 
            // editColorsButton
            // 
            this.editColorsButton.Location = new System.Drawing.Point(1293, 386);
            this.editColorsButton.Name = "editColorsButton";
            this.editColorsButton.Size = new System.Drawing.Size(129, 23);
            this.editColorsButton.TabIndex = 17;
            this.editColorsButton.Text = "Custom pen colors";
            this.editColorsButton.UseVisualStyleBackColor = true;
            this.editColorsButton.Click += new System.EventHandler(this.editColorsButton_Click);
            // 
            // drawPolygonButton
            // 
            this.drawPolygonButton.Location = new System.Drawing.Point(1293, 415);
            this.drawPolygonButton.Name = "drawPolygonButton";
            this.drawPolygonButton.Size = new System.Drawing.Size(129, 23);
            this.drawPolygonButton.TabIndex = 18;
            this.drawPolygonButton.Text = "Draw polygon";
            this.drawPolygonButton.UseVisualStyleBackColor = true;
            this.drawPolygonButton.Click += new System.EventHandler(this.drawPolygonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 821);
            this.Controls.Add(this.drawPolygonButton);
            this.Controls.Add(this.editColorsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fillsComboBox);
            this.Controls.Add(this.orientationsComboBox);
            this.Controls.Add(this.stepsComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.penSizesComboBox);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.drawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rainbow colors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel drawPanel;
        private Button exitButton;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private ComboBox penSizesComboBox;
        private Label label1;
        private ComboBox stepsComboBox;
        private ComboBox orientationsComboBox;
        private ComboBox fillsComboBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button editColorsButton;
        private Button drawPolygonButton;
    }
}