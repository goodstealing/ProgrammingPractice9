﻿namespace Module4
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
            txtRadius = new TextBox();
            txtWidth = new TextBox();
            txtHeight = new TextBox();
            txtSideA = new TextBox();
            txtSideB = new TextBox();
            txtSideC = new TextBox();
            btnCalculate = new Button();
            lblAreaResult = new Label();
            lblPerimeterResult = new Label();
            comboBoxFigure = new ComboBox();
            SuspendLayout();
            // 
            // txtRadius
            // 
            txtRadius.Location = new Point(62, 52);
            txtRadius.Name = "txtRadius";
            txtRadius.PlaceholderText = "Radius";
            txtRadius.Size = new Size(100, 23);
            txtRadius.TabIndex = 1;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(62, 91);
            txtWidth.Name = "txtWidth";
            txtWidth.PlaceholderText = "Width";
            txtWidth.Size = new Size(100, 23);
            txtWidth.TabIndex = 2;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(62, 132);
            txtHeight.Name = "txtHeight";
            txtHeight.PlaceholderText = "Height";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 3;
            // 
            // txtSideA
            // 
            txtSideA.Location = new Point(62, 172);
            txtSideA.Name = "txtSideA";
            txtSideA.PlaceholderText = "Side A";
            txtSideA.Size = new Size(100, 23);
            txtSideA.TabIndex = 4;
            // 
            // txtSideB
            // 
            txtSideB.Location = new Point(62, 212);
            txtSideB.Name = "txtSideB";
            txtSideB.PlaceholderText = "Side B";
            txtSideB.Size = new Size(100, 23);
            txtSideB.TabIndex = 5;
            // 
            // txtSideC
            // 
            txtSideC.Location = new Point(62, 252);
            txtSideC.Name = "txtSideC";
            txtSideC.PlaceholderText = "Side C";
            txtSideC.Size = new Size(100, 23);
            txtSideC.TabIndex = 6;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(73, 293);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(75, 23);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblAreaResult
            // 
            lblAreaResult.AutoSize = true;
            lblAreaResult.Location = new Point(50, 332);
            lblAreaResult.Name = "lblAreaResult";
            lblAreaResult.Size = new Size(0, 15);
            lblAreaResult.TabIndex = 8;
            // 
            // lblPerimeterResult
            // 
            lblPerimeterResult.AutoSize = true;
            lblPerimeterResult.Location = new Point(30, 380);
            lblPerimeterResult.Name = "lblPerimeterResult";
            lblPerimeterResult.Size = new Size(0, 15);
            lblPerimeterResult.TabIndex = 9;
            // 
            // comboBoxFigure
            // 
            comboBoxFigure.FormattingEnabled = true;
            comboBoxFigure.Location = new Point(50, 12);
            comboBoxFigure.Name = "comboBoxFigure";
            comboBoxFigure.Size = new Size(121, 23);
            comboBoxFigure.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 411);
            Controls.Add(comboBoxFigure);
            Controls.Add(lblPerimeterResult);
            Controls.Add(lblAreaResult);
            Controls.Add(btnCalculate);
            Controls.Add(txtSideC);
            Controls.Add(txtSideB);
            Controls.Add(txtSideA);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(txtRadius);
            Name = "Form1";
            Text = "Task1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRadius;
        private TextBox txtWidth;
        private TextBox txtHeight;
        private TextBox txtSideA;
        private TextBox txtSideB;
        private TextBox txtSideC;
        private Button btnCalculate;
        private Label lblAreaResult;
        private Label lblPerimeterResult;
        private ComboBox comboBoxFigure;
    }
}
