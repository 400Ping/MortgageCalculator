using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MortgageCalculator
{
    public class AdvancedForm : Form
    {
        private TabControl tabControl;
        
        // Base variables
        private double housePrice;
        private double loanAmount;
        private double mortgageRate;
        private int loanYears;

        // UI Controls for outputs
        private RichTextBox rtbMonteCarlo;
        private RichTextBox rtbGBM;
        private RichTextBox rtbNPV;
        private RichTextBox rtbDCF;
        private RichTextBox rtbROI;
        private RichTextBox rtbQLearning;
        private RichTextBox rtbZKP;
        private RichTextBox rtbAIAdvice;
        
        private PictureBox picChart;
        private double aiChartPrincipal = 0;
        private double aiChartInterest = 0;

        public AdvancedForm(double housePrice, double loanAmount, double ratePercent, int years)
        {
            this.housePrice = housePrice;
            this.loanAmount = loanAmount;
            this.mortgageRate = ratePercent;
            this.loanYears = years;

            InitializeUI();
            RunSimulations();
        }

        private void InitializeUI()
        {
            this.Text = "大師級進階不動產與金融分析";
            this.Size = new Size(950, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Font = new Font("Segoe UI", 10F);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "🚀 進階數學、金融工程與密碼學模型";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.FromArgb(41, 128, 185);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitle);

            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Padding = new Point(6, 4); // Reduce padding
            tabControl.Multiline = true;
            tabControl.Font = new Font("Segoe UI", 9F, FontStyle.Bold); // Reduce font to guarantee fit

            // Create Tabs
            TabPage tab1 = CreateTab("蒙地卡羅(CIR)", out rtbMonteCarlo);
            TabPage tab2 = CreateTab("GBM房產溺水", out rtbGBM);
            TabPage tab3 = CreateTab("NPV/機會成本", out rtbNPV);
            TabPage tab4 = CreateTab("DCF租買抉擇", out rtbDCF);
            TabPage tab5 = CreateTab("投報率(IRR)", out rtbROI);
            TabPage tab6 = CreateTab("強化學習(RL)還款", out rtbQLearning);
            TabPage tab7 = CreateTab("隱私驗證(ZKP)", out rtbZKP);

            TabPage tab8 = new TabPage("AI房貸健康體檢");
            tab8.BackColor = Color.White;
            
            SplitContainer splitAI = new SplitContainer();
            splitAI.Dock = DockStyle.Fill;
            splitAI.Orientation = Orientation.Vertical;
            splitAI.SplitterDistance = 500; 
            
            rtbAIAdvice = new RichTextBox();
            rtbAIAdvice.Dock = DockStyle.Fill;
            rtbAIAdvice.Font = new Font("Consolas", 11F);
            rtbAIAdvice.ReadOnly = true;
            rtbAIAdvice.BackColor = Color.FromArgb(248, 249, 250);
            rtbAIAdvice.BorderStyle = BorderStyle.None;
            
            Panel paddingPanelText = new Panel();
            paddingPanelText.Dock = DockStyle.Fill;
            paddingPanelText.Padding = new Padding(15);
            paddingPanelText.Controls.Add(rtbAIAdvice);
            
            splitAI.Panel1.Controls.Add(paddingPanelText);
            
            picChart = new PictureBox();
            picChart.Dock = DockStyle.Fill;
            picChart.Paint += PicChart_Paint;
            
            splitAI.Panel2.Controls.Add(picChart);
            splitAI.Panel2.BackColor = Color.White;
            splitAI.Panel2.Padding = new Padding(15);
            
            tab8.Controls.Add(splitAI);

            tabControl.TabPages.Add(tab1);
            tabControl.TabPages.Add(tab2);
            tabControl.TabPages.Add(tab3);
            tabControl.TabPages.Add(tab4);
            tabControl.TabPages.Add(tab5);
            tabControl.TabPages.Add(tab6);
            tabControl.TabPages.Add(tab7);
            tabControl.TabPages.Add(tab8);

            // Container Panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(15);
            mainPanel.Controls.Add(tabControl);

            // In WinForms, putting the top control first via BringToFront breaks DockStyle.Fill.
            // We should just ensure lblTitle is added and Docked to Top, then mainPanel is Fill.
            this.Controls.Clear();
            this.Controls.Add(mainPanel); // Fill takes whatever is left
            this.Controls.Add(lblTitle);  // Top docks to top first
        }

        private TabPage CreateTab(string title, out RichTextBox rtb)
        {
            TabPage page = new TabPage(title);
            page.BackColor = Color.White;
            
            rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.Font = new Font("Consolas", 11F);
            rtb.ReadOnly = true;
            rtb.BackColor = Color.FromArgb(248, 249, 250);
            rtb.BorderStyle = BorderStyle.None;
            rtb.Margin = new Padding(10);
            
            Panel paddingPanel = new Panel();
            paddingPanel.Dock = DockStyle.Fill;
            paddingPanel.Padding = new Padding(15);
            paddingPanel.Controls.Add(rtb);

            page.Controls.Add(paddingPanel);
            return page;
        }

        private void RunSimulations()
        {
            try
            {
                RunMonteCarlo();
                RunGBM();
                RunNPV();
                RunDCF();
                RunROI();
                RunQLearning();
                RunZKP();
                RunAIAdvice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("模擬計算失敗: " + ex.Message);
            }
        }

        private void RunMonteCarlo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 蒙地卡羅 (Monte Carlo / CIR) 利率隨機漫步壓測 ===");
            sb.AppendLine("預估長期平均利率: 2.0%, 波動率: 1.0%");
            sb.AppendLine("模擬路徑數: 1000條");
            sb.AppendLine();

            var result = AdvancedModels.SimulateCIR(mortgageRate / 100.0, loanYears, 1000);
            
            sb.AppendLine("【未來利率預測結果 (節錄第 1, 5, 10, 20 年)】");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("年度\t平均預期利率\t95% 悲觀高點\t5% 樂觀低點");
            
            int[] testYears = { 1, 5, 10, 20 };
            foreach(int y in testYears)
            {
                if(y <= loanYears)
                {
                    int month = y * 12;
                    sb.AppendLine($"第{y}年\t{(result.meanPath[month]*100).ToString("F2")}%\t\t{(result.percentiles95[month]*100).ToString("F2")}%\t\t{(result.percentiles5[month]*100).ToString("F2")}%");
                }
            }

            rtbMonteCarlo.Text = sb.ToString();
        }

        private void RunGBM()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 幾何布朗運動 (GBM) 房產溺水負淨值風險模型 ===");
            sb.AppendLine("參數假設 - 每年預期房價漲幅: 2%, 房價波動率: 5%");
            sb.AppendLine("模擬路徑數: 1000條");
            sb.AppendLine();

            var result = AdvancedModels.SimulateGBM(housePrice, loanAmount, loanYears, 1000);
            
            sb.AppendLine($"初始房價: {housePrice:N0} TWD");
            sb.AppendLine($"初始貸款: {loanAmount:N0} TWD");
            sb.AppendLine();
            sb.AppendLine($"【風險評估結果】");
            sb.AppendLine($"房價低於貸款餘額 (溺水) 之機率: {(result.probabilityNegativeEquity * 100).ToString("F2")} %");
            sb.AppendLine();
            sb.AppendLine("【預期房價走勢 (節錄)】");
            int[] testYears = { 5, 10, 20, 30 };
            foreach(int y in testYears)
            {
                if(y <= loanYears)
                {
                    int month = y * 12;
                    sb.AppendLine($"第{y}年 預期平均房價: {result.expectedPrices[month]:N0} TWD");
                }
            }

            rtbGBM.Text = sb.ToString();
        }

        private void RunNPV()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 理論投資分析 (NPV淨現值 / 機會成本評估) ===");
            double marketReturn = 0.06; // 6% market return assumption
            sb.AppendLine($"假設市場股票化報酬率 (機會成本): {marketReturn*100}%");
            sb.AppendLine();

            // Approximate monthly payment to use for calculation
            double monthlyRate = (mortgageRate / 100) / 12;
            int totalMonths = loanYears * 12;
            double monthlyPayment = 0;
            if (monthlyRate > 0)
                monthlyPayment = loanAmount * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) / (Math.Pow(1 + monthlyRate, totalMonths) - 1);
            else
                monthlyPayment = loanAmount / totalMonths;

            var result = AdvancedModels.CalculateNPV(loanAmount, monthlyPayment, mortgageRate, marketReturn, loanYears);

            sb.AppendLine($"每月應繳房貸約為: {monthlyPayment:N0} TWD");
            sb.AppendLine();
            sb.AppendLine("若將「這筆每月還款的現金流」不還貸款，改為投資股市 (6%)，其現值:");
            sb.AppendLine($"投資現值 (Opportunity NPV): {result.npvInvest:N0} TWD");
            sb.AppendLine();
            sb.AppendLine("若照常繳交房貸，其財務現值 (成本):");
            sb.AppendLine($"房貸成本現值 (Mortgage NPV): {result.npvPayMortgage:N0} TWD");
            sb.AppendLine();
            if (Math.Abs(result.npvPayMortgage) < result.npvInvest)
            {
                sb.AppendLine("結論: 理論上，投資股市的數學優勢大於提早還清房貸！");
            }
            else
            {
                sb.AppendLine("結論: 理論上，繳交房貸較為划算，風險也較低。");
            }

            rtbNPV.Text = sb.ToString();
        }

        private void RunDCF()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 現代租買決策數學模型 (DCF現金流貼現資產交叉點) ===");
            double assumedRent = housePrice * 0.02 / 12; // Assume rent is 2% of house price yearly
            sb.AppendLine($"假設以租代買，初始月租金約: {assumedRent:N0} TWD");
            sb.AppendLine("假設參數: 租金年增率 2%, 房價年增率 2%, 大盤投資報酬率 6%");
            sb.AppendLine();

            double downPayment = housePrice - loanAmount;
            
            // Calculate approximate monthly
            double monthlyRate = (mortgageRate / 100) / 12;
            int totalMonths = loanYears * 12;
            double monthlyPayment = loanAmount * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) / (Math.Pow(1 + monthlyRate, totalMonths) - 1);

            int crossoverYear = AdvancedModels.CalculateRentBuyCrossover(housePrice, downPayment, monthlyPayment, assumedRent);

            if(crossoverYear > 0)
            {
                sb.AppendLine($"【分析結果】");
                sb.AppendLine($"在第 {crossoverYear} 年，『買房的總資產淨值』會黃金交叉正式超越『租房並投資大盤的淨資產』！");
                sb.AppendLine("→ 如果您打算住超過這個年限，強烈建議「買房」。");
            }
            else
            {
                sb.AppendLine($"【分析結果】");
                sb.AppendLine($"在 30 年內，租房淨資產皆未被買房超越。");
                sb.AppendLine("→ 由於機會成本及稅費，單純以理財角度而言「租房較佳」。");
            }

            rtbDCF.Text = sb.ToString();
        }

        private void RunROI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 不動產投報率深度運算 (IRR、Cap Rate) ===");
            
            double assumedRent = housePrice * 0.025 / 12; // Assumed 2.5% yield 
            double operatingExpenses = assumedRent * 12 * 0.15; // 15% of rent is expense
            double finalSalePrice = housePrice * Math.Pow(1.02, loanYears); // 2% appreciation

            sb.AppendLine($"假設將此房屋出租，每月租金約收取: {assumedRent:N0} TWD");
            sb.AppendLine($"假設每年維護與稅捐成本約: {operatingExpenses:N0} TWD");
            sb.AppendLine($"預估 {loanYears} 年後售出價格: {finalSalePrice:N0} TWD");
            sb.AppendLine();

            var result = AdvancedModels.CalculateROI(housePrice, assumedRent, operatingExpenses, finalSalePrice, loanYears);

            sb.AppendLine("【投資報酬率指標】");
            sb.AppendLine($"資本化率 (Cap Rate) = 淨營運收入 / 初始房價: {(result.capRate*100).ToString("F2")} %");
            sb.AppendLine($"內部報酬率 (IRR - Internal Rate of Return): {(result.irr*100).ToString("F2")} %");

            rtbROI.Text = sb.ToString();
        }

        private void RunQLearning()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 強化學習 RL (Reinforcement Learning) 提前還款決策樹 ===");
            sb.AppendLine("【RL Q-Learning 演算法動態訓練過程】");
            sb.AppendLine("本程式內建了一個輕量級的 RL Agent，以下為其實際執行『反覆試錯學習與更新 Q-Table』的過程日誌：");
            sb.AppendLine("◆ 狀態 (State)：『低債務期』、『中債務期』、『高債務期』");
            sb.AppendLine("◆ 動作 (Action)：『不提前還款』、『穩健小額還款』、『大額清償』");
            sb.AppendLine("◆ 獎勵機制 (Reward)：根據省下的利息與股市機會成本之差異給予演算法正負報酬。");
            sb.AppendLine();
            
            sb.AppendLine(AdvancedModels.RunRealQLearningSimulation(loanAmount));

            rtbQLearning.Text = sb.ToString();
        }

        private void RunZKP()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== 資安密碼學：零知識證明 (Zero-Knowledge Proof) 收入隱私驗證 ===");
            sb.AppendLine("向銀行證明收入大於放款門檻，卻不需要出示真實所得！");
            sb.AppendLine();

            // Calculate threshold (e.g. Monthly income > 130% of mortgage payment)
            double monthlyRate = (mortgageRate / 100) / 12;
            int totalMonths = loanYears * 12;
            double monthlyPayment = loanAmount * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) / (Math.Pow(1 + monthlyRate, totalMonths) - 1);
            
            double requiredIncomeThreshold = monthlyPayment * 1.3;
            double userActualIncome = monthlyPayment * 2.0; // Simulate user makes 2x
            string secret = "CryptoKey_User_12345";

            var result = AdvancedModels.VerifyIncomeZKP(userActualIncome, requiredIncomeThreshold, secret);

            sb.AppendLine($"假設銀行要求的『月收入放款門檻』: {requiredIncomeThreshold:N0} TWD");
            sb.AppendLine("用戶產生零知識證明...");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine(result.proofDetails);

            rtbZKP.Text = sb.ToString();
        }

        private void RunAIAdvice()
        {
            StringBuilder sb = new StringBuilder();
            
            double ltv = (loanAmount / housePrice) * 100;
            double monthlyRate = (mortgageRate / 100) / 12;
            int totalMonths = loanYears * 12;
            double monthlyPayment = 0;
            if (monthlyRate > 0)
                monthlyPayment = loanAmount * monthlyRate * Math.Pow(1 + monthlyRate, totalMonths) / (Math.Pow(1 + monthlyRate, totalMonths) - 1);
            else
                monthlyPayment = loanAmount / totalMonths;
                
            double totalRepayment = monthlyPayment * totalMonths;
            double totalInterest = totalRepayment - loanAmount;

            aiChartPrincipal = loanAmount;
            aiChartInterest = totalInterest;
            if (picChart != null) picChart.Invalidate();

            sb.AppendLine("📋 您的房貸健康體檢報告\n");
            
            sb.AppendLine("【基本財務診斷】");
            sb.AppendLine($"▶️ 貸款成數 (LTV): {ltv:F1}%");
            if(ltv > 80) sb.AppendLine("   ⚠️ 您的貸款成數較高，槓桿較大，請務必保留6個月以上的生活緊急預備金！");
            else sb.AppendLine("   ✅ 貸款成數處於健康或常規範圍內。");
            
            sb.AppendLine($"▶️ 每月房貸繳款: NT$ {monthlyPayment:N0}");
            sb.AppendLine($"   (請確保佔您每月總收入的 30%~40% 以內，以免引發財務危機)\n");

            sb.AppendLine("【綜合利息分析】");
            sb.AppendLine($"▶️ 您總共跟銀行借了: NT$ {loanAmount:N0}");
            sb.AppendLine($"▶️ 未來 {loanYears} 年要付給銀行的利息總額為: NT$ {totalInterest:N0}");
            
            if(totalInterest > loanAmount)
            {
                 sb.AppendLine("   ⚠️ 注意：經過長期的複利，您的『總利息』已經超越了你借的『本金』了！");
            }
            sb.AppendLine();
            
            sb.AppendLine("💡 【AI 大師決策指南】");
            sb.AppendLine("1. 提早還款策略：右圖為您的利息與本金佔比圓餅圖，如果年終獎金有餘裕，強烈建議可向銀行申請『提前償還本金』，這能大幅削減紅色的龐大總利息。");
            sb.AppendLine("2. 投資機會對比：如果您投資股市(例如ETF大盤)的年化報酬率有自信能長期超過房貸利率，那麼不急著還清房貸，將資金拿去投資滾利可能是較好的資金運用。");
            sb.AppendLine("3. 寬限期地雷：若您目前有使用寬限期，請謹記寬限期結束後，本金攤還會使您的月繳款發生『暴增』，請現在就開始模擬幾年後的生活開銷變化。");

            rtbAIAdvice.Text = sb.ToString();
        }

        private void PicChart_Paint(object sender, PaintEventArgs e)
        {
            if (aiChartPrincipal == 0 && aiChartInterest == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double total = aiChartPrincipal + aiChartInterest;
            float sweepPrincipal = (float)((aiChartPrincipal / total) * 360f);
            float sweepInterest = 360f - sweepPrincipal;

            int padding = 40;
            int diameter = Math.Min(picChart.Width, picChart.Height) - padding * 2;
            
            // Adjust if width is too small
            if (diameter <= 0) return;

            int x = (picChart.Width - diameter) / 2;
            int y = (picChart.Height - diameter) / 2 - 20;

            Rectangle rect = new Rectangle(x, y, diameter, diameter);

            // Draw Pie
            using (Brush bPrin = new SolidBrush(Color.FromArgb(46, 204, 113)))
            using (Brush bInt = new SolidBrush(Color.FromArgb(231, 76, 60)))
            {
                g.FillPie(bPrin, rect, 0, sweepPrincipal);
                g.FillPie(bInt, rect, sweepPrincipal, sweepInterest);
            }

            // Draw Legend and Title
            using (Font titleFont = new Font("Segoe UI", 13F, FontStyle.Bold))
            using (Font legendFont = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(44, 62, 80)))
            {
                string title = "本金與總利息佔比";
                SizeF titleSize = g.MeasureString(title, titleFont);
                g.DrawString(title, titleFont, textBrush, (picChart.Width - titleSize.Width) / 2, 20);

                string prinLegend = $"本金: {(aiChartPrincipal/total*100):F1}% ({aiChartPrincipal:N0} TWD)";
                string intLegend = $"利息: {(aiChartInterest/total*100):F1}% ({aiChartInterest:N0} TWD)";

                int lgndY = y + diameter + 20;
                
                using (Brush bPrinText = new SolidBrush(Color.FromArgb(46, 204, 113)))
                {
                    g.DrawString("■", legendFont, bPrinText, x, lgndY);
                    g.DrawString(prinLegend, legendFont, textBrush, x + 20, lgndY);
                }
                
                using (Brush bIntText = new SolidBrush(Color.FromArgb(231, 76, 60)))
                {
                    g.DrawString("■", legendFont, bIntText, x, lgndY + 25);
                    g.DrawString(intLegend, legendFont, textBrush, x + 20, lgndY + 25);
                }
            }
        }
    }
}
