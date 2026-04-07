namespace MortgageCalculator
{
    public partial class Form1 : Form
    {
        private bool _isAutoSize = true;
        private ToolStripMenuItem _menuItemAutoSize;
        private ToolStripMenuItem _menuItemManualSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateMenuStrip();
            SetAutoSize(true);
            txtHousePrice.TextChanged += FormatNumberTextBox_TextChanged;
            txtDownPaymentAmount.TextChanged += FormatNumberTextBox_TextChanged;
        }

        private void CreateMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.AutoSize = true;

            ToolStripMenuItem viewMenu = new ToolStripMenuItem("檢視(&V)");

            _menuItemAutoSize = new ToolStripMenuItem("自動調整大小(&A)", null, (s, e) => SetAutoSize(true));
            _menuItemAutoSize.Checked = true;

            _menuItemManualSize = new ToolStripMenuItem("手動調整大小(&M)", null, (s, e) => SetAutoSize(false));

            viewMenu.DropDownItems.Add(_menuItemAutoSize);
            viewMenu.DropDownItems.Add(_menuItemManualSize);
            menuStrip.Items.Add(viewMenu);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            Controls.SetChildIndex(menuStrip, 0);
        }

        private void SetAutoSize(bool autoSize)
        {
            _isAutoSize = autoSize;

            if (autoSize)
            {
                // 自動調整大小模式 - 設置為較大的初始尺寸
                MinimumSize = new Size(900, 550);
                MaximumSize = new Size(1400, 900);
                this.Size = new Size(1200, 700);

                _menuItemAutoSize.Checked = true;
                _menuItemManualSize.Checked = false;
            }
            else
            {
                // 手動調整大小模式
                MinimumSize = new Size(600, 400);
                MaximumSize = new Size(0, 0); // 無限制
                this.Size = new Size(1200, 700);

                _menuItemAutoSize.Checked = false;
                _menuItemManualSize.Checked = true;
            }
        }

        private void RbtnDownPaymentPercent_CheckedChanged(object sender, EventArgs e)
        {
            txtDownPaymentPercent.Enabled = rbtnDownPaymentPercent.Checked;
            txtDownPaymentAmount.Enabled = rbtnDownPaymentAmount.Checked;
        }

        private void ChkGracePeriod_CheckedChanged(object sender, EventArgs e)
        {
            txtGracePeriod.Enabled = ((CheckBox)sender).Checked;
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            // Auto-calculate on input change
        }

        private void FormatNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text.Replace(",", "");
                if (decimal.TryParse(text, out decimal value))
                {
                    textBox.TextChanged -= FormatNumberTextBox_TextChanged;
                    int selStart = textBox.SelectionStart;
                    int origLen = textBox.Text.Length;

                    textBox.Text = string.Format("{0:N0}", value);

                    int diff = textBox.Text.Length - origLen;
                    int newStart = selStart + diff;

                    if (newStart < 0) newStart = 0;
                    if (newStart > textBox.Text.Length) newStart = textBox.Text.Length;

                    textBox.SelectionStart = newStart;
                    textBox.TextChanged += FormatNumberTextBox_TextChanged;
                }
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (!decimal.TryParse(txtHousePrice.Text.Replace(",", ""), out decimal housePrice) || housePrice <= 0)
                {
                    MessageBox.Show("請輸入有效的房屋總價", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal downPayment = 0;
                if (rbtnDownPaymentPercent.Checked)
                {
                    if (!decimal.TryParse(txtDownPaymentPercent.Text, out decimal downPaymentPercent) || downPaymentPercent < 0 || downPaymentPercent > 100)
                    {
                        MessageBox.Show("請輸入有效的自備款比例 (0-100)", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    downPayment = housePrice * downPaymentPercent / 100;
                }
                else
                {
                    if (!decimal.TryParse(txtDownPaymentAmount.Text.Replace(",", ""), out downPayment) || downPayment < 0)
                    {
                        MessageBox.Show("請輸入有效的自備款金額", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (downPayment >= housePrice)
                {
                    MessageBox.Show("自備款不能超過或等於房屋總價", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtInterestRate.Text, out decimal annualRate) || annualRate < 0)
                {
                    MessageBox.Show("請輸入有效的貸款利率", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtLoanTerm.Text, out int loanTermYears) || loanTermYears <= 0)
                {
                    MessageBox.Show("請輸入有效的貸款年限", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int gracePeriodMonths = 0;
                if (txtGracePeriod.Enabled)
                {
                    if (!int.TryParse(txtGracePeriod.Text, out int gracePeriodYears) || gracePeriodYears < 0)
                    {
                        MessageBox.Show("請輸入有效的寬限期", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    gracePeriodMonths = gracePeriodYears * 12;
                }

                // Calculate mortgage
                decimal loanAmount = housePrice - downPayment;
                decimal monthlyRate = annualRate / 100 / 12;
                int totalMonths = loanTermYears * 12;
                int repaymentMonths = totalMonths - gracePeriodMonths;

                // Validate repayment months
                if (repaymentMonths <= 0)
                {
                    MessageBox.Show("寬限期不能超過貸款年限", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate monthly payment (only for repayment period)
                decimal monthlyPayment = 0;
                if (repaymentMonths > 0)
                {
                    if (monthlyRate > 0)
                    {
                        decimal raisedToPower = (decimal)Math.Pow((double)(1 + monthlyRate), repaymentMonths);
                        decimal denominator = raisedToPower - 1;

                        if (denominator != 0)
                        {
                            monthlyPayment = loanAmount * monthlyRate * raisedToPower / denominator;
                        }
                        else
                        {
                            monthlyPayment = loanAmount / repaymentMonths;
                        }
                    }
                    else
                    {
                        // No interest, simple division
                        monthlyPayment = loanAmount / repaymentMonths;
                    }
                }
                else
                {
                    MessageBox.Show("無效的還款期限", "計算錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate first month interest and principal
                decimal firstInterest = loanAmount * monthlyRate;
                decimal firstPrincipal = monthlyPayment - firstInterest;

                // Calculate total interest and total repayment
                decimal totalInterest = 0;
                if (gracePeriodMonths > 0)
                {
                    // Grace period: only interest
                    totalInterest = loanAmount * monthlyRate * gracePeriodMonths;
                    // Add interest during repayment period
                    totalInterest += monthlyPayment * repaymentMonths - loanAmount;
                }
                else
                {
                    totalInterest = monthlyPayment * totalMonths - loanAmount;
                }

                decimal totalRepayment = loanAmount + totalInterest;

                // Display results
                lblTotalLoan.Text = loanAmount.ToString("N2");
                lblMonthlyPayment.Text = monthlyPayment.ToString("N2");
                lblFirstInterest.Text = firstInterest.ToString("N2");
                lblFirstPrincipal.Text = firstPrincipal.ToString("N2");
                lblTotalInterest.Text = totalInterest.ToString("N2");
                lblTotalRepayment.Text = totalRepayment.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"計算出錯: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdvanced_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtHousePrice.Text.Replace(",", ""), out decimal housePrice) || housePrice <= 0)
                {
                    MessageBox.Show("請先輸入有效的房屋總價", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal downPayment = 0;
                if (rbtnDownPaymentPercent.Checked)
                {
                    if (decimal.TryParse(txtDownPaymentPercent.Text, out decimal dpPer) && dpPer >= 0 && dpPer <= 100)
                        downPayment = housePrice * dpPer / 100;
                }
                else
                {
                    decimal.TryParse(txtDownPaymentAmount.Text.Replace(",", ""), out downPayment);
                }

                decimal loanAmount = housePrice - downPayment;

                if (!decimal.TryParse(txtInterestRate.Text, out decimal annualRate) || annualRate < 0)
                {
                    MessageBox.Show("請先輸入有效的貸款利率", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!int.TryParse(txtLoanTerm.Text, out int loanTermYears) || loanTermYears <= 0)
                {
                    MessageBox.Show("請先輸入有效的貸款年限", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AdvancedForm advForm = new AdvancedForm((double)housePrice, (double)loanAmount, (double)annualRate, loanTermYears);
                advForm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"無法開啟進階分析: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
