namespace MortgageCalculator
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

        private TextBox txtHousePrice;
        private TextBox txtDownPaymentPercent;
        private TextBox txtDownPaymentAmount;
        private TextBox txtInterestRate;
        private TextBox txtLoanTerm;
        private TextBox txtGracePeriod;
        private RadioButton rbtnDownPaymentPercent;
        private RadioButton rbtnDownPaymentAmount;
        private Label lblTotalLoan;
        private Label lblMonthlyPayment;
        private Label lblFirstInterest;
        private Label lblFirstPrincipal;
        private Label lblTotalInterest;
        private Label lblTotalRepayment;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnCalculate = new Button();
            panelInput = new Panel();
            txtHousePrice = new TextBox();
            rbtnDownPaymentPercent = new RadioButton();
            txtDownPaymentPercent = new TextBox();
            rbtnDownPaymentAmount = new RadioButton();
            txtDownPaymentAmount = new TextBox();
            txtInterestRate = new TextBox();
            txtLoanTerm = new TextBox();
            chkGracePeriod = new CheckBox();
            txtGracePeriod = new TextBox();
            panelOutput = new Panel();
            lblTotalLoanLabel = new Label();
            lblTotalLoan = new Label();
            lblMonthlyPaymentLabel = new Label();
            lblMonthlyPayment = new Label();
            lblFirstInterestLabel = new Label();
            lblFirstInterest = new Label();
            lblFirstPrincipalLabel = new Label();
            lblFirstPrincipal = new Label();
            lblTotalInterestLabel = new Label();
            lblTotalInterest = new Label();
            lblTotalRepaymentLabel = new Label();
            lblTotalRepayment = new Label();
            titleLabel = new Label();
            panelInput.SuspendLayout();
            panelOutput.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(52, 73, 94);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(217, 37);
            label1.TabIndex = 0;
            label1.Text = "房屋總價 (TWD):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(52, 73, 94);
            label2.Location = new Point(20, 55);
            label2.Name = "label2";
            label2.Size = new Size(107, 37);
            label2.TabIndex = 2;
            label2.Text = "自備款:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(52, 73, 94);
            label3.Location = new Point(20, 195);
            label3.Name = "label3";
            label3.Size = new Size(243, 37);
            label3.TabIndex = 7;
            label3.Text = "貸款利率 (% 年率):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(52, 73, 94);
            label4.Location = new Point(20, 239);
            label4.Name = "label4";
            label4.Size = new Size(186, 37);
            label4.TabIndex = 9;
            label4.Text = "貸款年限 (年):";
            // 
            // label5
            // 
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 0;
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(46, 204, 113);
            btnCalculate.Cursor = Cursors.Hand;
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(20, 345);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(300, 45);
            btnCalculate.TabIndex = 13;
            btnCalculate.Text = "📊 計算";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += BtnCalculate_Click;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(236, 240, 241);
            panelInput.BorderStyle = BorderStyle.FixedSingle;
            panelInput.Controls.Add(label1);
            panelInput.Controls.Add(txtHousePrice);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(rbtnDownPaymentPercent);
            panelInput.Controls.Add(txtDownPaymentPercent);
            panelInput.Controls.Add(rbtnDownPaymentAmount);
            panelInput.Controls.Add(txtDownPaymentAmount);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(txtInterestRate);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(txtLoanTerm);
            panelInput.Controls.Add(chkGracePeriod);
            panelInput.Controls.Add(txtGracePeriod);
            panelInput.Controls.Add(btnCalculate);
            panelInput.Location = new Point(12, 143);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(493, 417);
            panelInput.TabIndex = 1;
            panelInput.Paint += panelInput_Paint;
            // 
            // txtHousePrice
            // 
            txtHousePrice.BorderStyle = BorderStyle.FixedSingle;
            txtHousePrice.Font = new Font("Segoe UI", 10F);
            txtHousePrice.Location = new Point(243, 18);
            txtHousePrice.Name = "txtHousePrice";
            txtHousePrice.Size = new Size(202, 43);
            txtHousePrice.TabIndex = 1;
            txtHousePrice.TextChanged += TxtInput_TextChanged;
            // 
            // rbtnDownPaymentPercent
            // 
            rbtnDownPaymentPercent.AutoSize = true;
            rbtnDownPaymentPercent.Checked = true;
            rbtnDownPaymentPercent.Font = new Font("Segoe UI", 9F);
            rbtnDownPaymentPercent.Location = new Point(144, 78);
            rbtnDownPaymentPercent.Name = "rbtnDownPaymentPercent";
            rbtnDownPaymentPercent.Size = new Size(161, 36);
            rbtnDownPaymentPercent.TabIndex = 3;
            rbtnDownPaymentPercent.TabStop = true;
            rbtnDownPaymentPercent.Text = "百分比 (%)";
            rbtnDownPaymentPercent.CheckedChanged += RbtnDownPaymentPercent_CheckedChanged;
            // 
            // txtDownPaymentPercent
            // 
            txtDownPaymentPercent.Font = new Font("Segoe UI", 10F);
            txtDownPaymentPercent.Location = new Point(319, 71);
            txtDownPaymentPercent.Name = "txtDownPaymentPercent";
            txtDownPaymentPercent.Size = new Size(126, 43);
            txtDownPaymentPercent.TabIndex = 4;
            txtDownPaymentPercent.TextChanged += TxtInput_TextChanged;
            // 
            // rbtnDownPaymentAmount
            // 
            rbtnDownPaymentAmount.AutoSize = true;
            rbtnDownPaymentAmount.Font = new Font("Segoe UI", 9F);
            rbtnDownPaymentAmount.Location = new Point(144, 127);
            rbtnDownPaymentAmount.Name = "rbtnDownPaymentAmount";
            rbtnDownPaymentAmount.Size = new Size(169, 36);
            rbtnDownPaymentAmount.TabIndex = 5;
            rbtnDownPaymentAmount.Text = "金額 (TWD)";
            rbtnDownPaymentAmount.CheckedChanged += RbtnDownPaymentPercent_CheckedChanged;
            // 
            // txtDownPaymentAmount
            // 
            txtDownPaymentAmount.Enabled = false;
            txtDownPaymentAmount.Font = new Font("Segoe UI", 10F);
            txtDownPaymentAmount.Location = new Point(319, 127);
            txtDownPaymentAmount.Name = "txtDownPaymentAmount";
            txtDownPaymentAmount.Size = new Size(126, 43);
            txtDownPaymentAmount.TabIndex = 6;
            txtDownPaymentAmount.TextChanged += TxtInput_TextChanged;
            // 
            // txtInterestRate
            // 
            txtInterestRate.Font = new Font("Segoe UI", 10F);
            txtInterestRate.Location = new Point(269, 189);
            txtInterestRate.Name = "txtInterestRate";
            txtInterestRate.Size = new Size(176, 43);
            txtInterestRate.TabIndex = 8;
            txtInterestRate.TextChanged += TxtInput_TextChanged;
            // 
            // txtLoanTerm
            // 
            txtLoanTerm.Font = new Font("Segoe UI", 10F);
            txtLoanTerm.Location = new Point(269, 236);
            txtLoanTerm.Name = "txtLoanTerm";
            txtLoanTerm.Size = new Size(176, 43);
            txtLoanTerm.TabIndex = 10;
            txtLoanTerm.TextChanged += TxtInput_TextChanged;
            // 
            // chkGracePeriod
            // 
            chkGracePeriod.AutoSize = true;
            chkGracePeriod.Font = new Font("Segoe UI", 10F);
            chkGracePeriod.Location = new Point(20, 289);
            chkGracePeriod.Name = "chkGracePeriod";
            chkGracePeriod.Size = new Size(190, 41);
            chkGracePeriod.TabIndex = 11;
            chkGracePeriod.Text = "寬限期 (年):";
            chkGracePeriod.CheckedChanged += ChkGracePeriod_CheckedChanged;
            // 
            // txtGracePeriod
            // 
            txtGracePeriod.Enabled = false;
            txtGracePeriod.Font = new Font("Segoe UI", 10F);
            txtGracePeriod.Location = new Point(269, 289);
            txtGracePeriod.Name = "txtGracePeriod";
            txtGracePeriod.Size = new Size(176, 43);
            txtGracePeriod.TabIndex = 12;
            txtGracePeriod.TextChanged += TxtInput_TextChanged;
            // 
            // panelOutput
            // 
            panelOutput.BackColor = Color.White;
            panelOutput.BorderStyle = BorderStyle.FixedSingle;
            panelOutput.Controls.Add(lblTotalLoanLabel);
            panelOutput.Controls.Add(lblTotalLoan);
            panelOutput.Controls.Add(lblMonthlyPaymentLabel);
            panelOutput.Controls.Add(lblMonthlyPayment);
            panelOutput.Controls.Add(lblFirstInterestLabel);
            panelOutput.Controls.Add(lblFirstInterest);
            panelOutput.Controls.Add(lblFirstPrincipalLabel);
            panelOutput.Controls.Add(lblFirstPrincipal);
            panelOutput.Controls.Add(lblTotalInterestLabel);
            panelOutput.Controls.Add(lblTotalInterest);
            panelOutput.Controls.Add(lblTotalRepaymentLabel);
            panelOutput.Controls.Add(lblTotalRepayment);
            panelOutput.Location = new Point(579, 143);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new Size(452, 305);
            panelOutput.TabIndex = 2;
            // 
            // lblTotalLoanLabel
            // 
            lblTotalLoanLabel.AutoSize = true;
            lblTotalLoanLabel.Font = new Font("Segoe UI", 9F);
            lblTotalLoanLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblTotalLoanLabel.Location = new Point(20, 20);
            lblTotalLoanLabel.Name = "lblTotalLoanLabel";
            lblTotalLoanLabel.Size = new Size(144, 32);
            lblTotalLoanLabel.TabIndex = 0;
            lblTotalLoanLabel.Text = "貸款總金額:";
            // 
            // lblTotalLoan
            // 
            lblTotalLoan.AutoSize = true;
            lblTotalLoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalLoan.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalLoan.Location = new Point(175, 15);
            lblTotalLoan.Name = "lblTotalLoan";
            lblTotalLoan.Size = new Size(0, 37);
            lblTotalLoan.TabIndex = 1;
            // 
            // lblMonthlyPaymentLabel
            // 
            lblMonthlyPaymentLabel.AutoSize = true;
            lblMonthlyPaymentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMonthlyPaymentLabel.ForeColor = Color.FromArgb(231, 76, 60);
            lblMonthlyPaymentLabel.Location = new Point(20, 55);
            lblMonthlyPaymentLabel.Name = "lblMonthlyPaymentLabel";
            lblMonthlyPaymentLabel.Size = new Size(198, 37);
            lblMonthlyPaymentLabel.TabIndex = 2;
            lblMonthlyPaymentLabel.Text = "每月應繳金額:";
            // 
            // lblMonthlyPayment
            // 
            lblMonthlyPayment.AutoSize = true;
            lblMonthlyPayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMonthlyPayment.ForeColor = Color.FromArgb(231, 76, 60);
            lblMonthlyPayment.Location = new Point(224, 55);
            lblMonthlyPayment.Name = "lblMonthlyPayment";
            lblMonthlyPayment.Size = new Size(0, 41);
            lblMonthlyPayment.TabIndex = 3;
            // 
            // lblFirstInterestLabel
            // 
            lblFirstInterestLabel.AutoSize = true;
            lblFirstInterestLabel.Font = new Font("Segoe UI", 9F);
            lblFirstInterestLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblFirstInterestLabel.Location = new Point(20, 104);
            lblFirstInterestLabel.Name = "lblFirstInterestLabel";
            lblFirstInterestLabel.Size = new Size(119, 32);
            lblFirstInterestLabel.TabIndex = 4;
            lblFirstInterestLabel.Text = "首期利息:";
            // 
            // lblFirstInterest
            // 
            lblFirstInterest.AutoSize = true;
            lblFirstInterest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFirstInterest.ForeColor = Color.FromArgb(44, 62, 80);
            lblFirstInterest.Location = new Point(170, 100);
            lblFirstInterest.Name = "lblFirstInterest";
            lblFirstInterest.Size = new Size(0, 37);
            lblFirstInterest.TabIndex = 5;
            // 
            // lblFirstPrincipalLabel
            // 
            lblFirstPrincipalLabel.AutoSize = true;
            lblFirstPrincipalLabel.Font = new Font("Segoe UI", 9F);
            lblFirstPrincipalLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblFirstPrincipalLabel.Location = new Point(20, 152);
            lblFirstPrincipalLabel.Name = "lblFirstPrincipalLabel";
            lblFirstPrincipalLabel.Size = new Size(119, 32);
            lblFirstPrincipalLabel.TabIndex = 6;
            lblFirstPrincipalLabel.Text = "首期本金:";
            // 
            // lblFirstPrincipal
            // 
            lblFirstPrincipal.AutoSize = true;
            lblFirstPrincipal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFirstPrincipal.ForeColor = Color.FromArgb(44, 62, 80);
            lblFirstPrincipal.Location = new Point(170, 147);
            lblFirstPrincipal.Name = "lblFirstPrincipal";
            lblFirstPrincipal.Size = new Size(0, 37);
            lblFirstPrincipal.TabIndex = 7;
            // 
            // lblTotalInterestLabel
            // 
            lblTotalInterestLabel.AutoSize = true;
            lblTotalInterestLabel.Font = new Font("Segoe UI", 9F);
            lblTotalInterestLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblTotalInterestLabel.Location = new Point(20, 195);
            lblTotalInterestLabel.Name = "lblTotalInterestLabel";
            lblTotalInterestLabel.Size = new Size(144, 32);
            lblTotalInterestLabel.TabIndex = 8;
            lblTotalInterestLabel.Text = "總利息支出:";
            // 
            // lblTotalInterest
            // 
            lblTotalInterest.AutoSize = true;
            lblTotalInterest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalInterest.ForeColor = Color.FromArgb(189, 195, 199);
            lblTotalInterest.Location = new Point(170, 195);
            lblTotalInterest.Name = "lblTotalInterest";
            lblTotalInterest.Size = new Size(0, 37);
            lblTotalInterest.TabIndex = 9;
            // 
            // lblTotalRepaymentLabel
            // 
            lblTotalRepaymentLabel.AutoSize = true;
            lblTotalRepaymentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalRepaymentLabel.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalRepaymentLabel.Location = new Point(20, 242);
            lblTotalRepaymentLabel.Name = "lblTotalRepaymentLabel";
            lblTotalRepaymentLabel.Size = new Size(169, 37);
            lblTotalRepaymentLabel.TabIndex = 10;
            lblTotalRepaymentLabel.Text = "總還款金額:";
            // 
            // lblTotalRepayment
            // 
            lblTotalRepayment.AutoSize = true;
            lblTotalRepayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalRepayment.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalRepayment.Location = new Point(195, 244);
            lblTotalRepayment.Name = "lblTotalRepayment";
            lblTotalRepayment.Size = new Size(0, 45);
            lblTotalRepayment.TabIndex = 11;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(41, 128, 185);
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(9, 26);
            titleLabel.Margin = new Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1200, 87);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "🏠 個人房貸試算器 💰";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 638);
            Controls.Add(titleLabel);
            Controls.Add(panelInput);
            Controls.Add(panelOutput);
            MaximumSize = new Size(1400, 900);
            MinimumSize = new Size(900, 550);
            Name = "Form1";
            Text = "個人房貸試算器";
            Load += Form1_Load;
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelOutput.ResumeLayout(false);
            panelOutput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnCalculate;
        private Panel panelInput;
        private CheckBox chkGracePeriod;
        private Panel panelOutput;
        private Label lblTotalLoanLabel;
        private Label lblMonthlyPaymentLabel;
        private Label lblFirstInterestLabel;
        private Label lblFirstPrincipalLabel;
        private Label lblTotalInterestLabel;
        private Label lblTotalRepaymentLabel;
        private Label titleLabel;
    }
}
