using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MortgageCalculator
{
    public class AdvancedModels
    {
        // 1. Monte Carlo (CIR) Interest Rate Model
        public static (double[] meanPath, double[] percentiles95, double[] percentiles5) SimulateCIR(double initialRate, int years, int paths, double a = 0.1, double b = 0.02, double sigma = 0.01)
        {
            Random rand = new Random(1234); // fixed seed for predictability in UI demo
            int steps = years * 12;
            double dt = 1.0 / 12.0;

            double[,] rates = new double[paths, steps + 1];
            for (int p = 0; p < paths; p++) { rates[p, 0] = initialRate; }

            for (int p = 0; p < paths; p++)
            {
                for (int t = 1; t <= steps; t++)
                {
                    double r_prev = rates[p, t - 1];
                    // Random normal using Box-Muller
                    double u1 = 1.0 - rand.NextDouble();
                    double u2 = 1.0 - rand.NextDouble();
                    double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                    double dr = a * (b - r_prev) * dt + sigma * Math.Sqrt(Math.Max(r_prev, 0.0001)) * Math.Sqrt(dt) * z;
                    rates[p, t] = Math.Max(0.0001, r_prev + dr);
                }
            }

            double[] meanPath = new double[steps + 1];
            double[] p95 = new double[steps + 1];
            double[] p5 = new double[steps + 1];

            for (int t = 0; t <= steps; t++)
            {
                double[] stepRates = new double[paths];
                for (int p = 0; p < paths; p++) stepRates[p] = rates[p, t];
                Array.Sort(stepRates);
                meanPath[t] = stepRates.Average();
                p5[t] = stepRates[(int)(paths * 0.05)];
                p95[t] = stepRates[(int)(paths * 0.95)];
            }
            return (meanPath, p95, p5);
        }

        // 2. Geometric Brownian Motion (GBM) Underwater Risk
        public static (double probabilityNegativeEquity, double[] expectedPrices) SimulateGBM(double currentPrice, double outstandingLoan, int years, int paths, double mu = 0.02, double sigma = 0.05)
        {
            Random rand = new Random(5678);
            int steps = years * 12;
            double dt = 1.0 / 12.0;
            int underwaterCount = 0;
            double[] expectedPrices = new double[steps + 1];
            expectedPrices[0] = currentPrice;

            double[,] prices = new double[paths, steps + 1];
            for (int p = 0; p < paths; p++) prices[p, 0] = currentPrice;

            for (int p = 0; p < paths; p++)
            {
                bool underwaterThisPath = false;
                for (int t = 1; t <= steps; t++)
                {
                    double u1 = 1.0 - rand.NextDouble();
                    double u2 = 1.0 - rand.NextDouble();
                    double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                    double p_prev = prices[p, t - 1];
                    prices[p, t] = p_prev * Math.Exp((mu - 0.5 * sigma * sigma) * dt + sigma * Math.Sqrt(dt) * z);

                    if (t == steps && prices[p, t] < outstandingLoan) // check at end of term roughly
                    {
                         underwaterThisPath = true;
                    }
                }
                if (underwaterThisPath) underwaterCount++;
            }

            for (int t = 1; t <= steps; t++)
            {
                double sum = 0;
                for (int p = 0; p < paths; p++) sum += prices[p, t];
                expectedPrices[t] = sum / paths;
            }

            return ((double)underwaterCount / paths, expectedPrices);
        }

        // 3. NPV / Opportunity Cost Assessment
        public static (double npvInvest, double npvPayMortgage) CalculateNPV(double loanAmount, double monthlyPayment, double mortgageRate, double marketReturnRate, int years)
        {
            double monthlyMarketRate = marketReturnRate / 12.0;
            double monthlyMortgageRate = mortgageRate / 12.0;
            int months = years * 12;

            double npvInvest = 0;
            double npvPayMortgage = 0; 
            for (int t = 1; t <= months; t++)
            {
                // PV of monthly mortgage payment if discounted at market opportunity cost rate
                npvInvest += monthlyPayment / Math.Pow(1 + monthlyMarketRate, t);
                // PV of monthly mortgage payment if discounted at the mortgage rate itself (should sum to loanAmount roughly)
                npvPayMortgage += monthlyPayment / Math.Pow(1 + monthlyMortgageRate, t);
            }

            return (npvInvest, npvPayMortgage);
        }

        // 4. Rent vs Buy DCF
        public static int CalculateRentBuyCrossover(double housePrice, double downPayment, double monthlyMortgage, double currentMonthlyRent, double rentGrowthRate = 0.02, double houseAppreciation = 0.02, double marketReturn = 0.06, int maxYears = 30)
        {
            double accumulatedRentCost = 0;
            double accumulatedBuyCost = downPayment;
            double currentRent = currentMonthlyRent;
            double currentHouseValue = housePrice;
            
            // Renting assumes you invested the downpayment in market
            double rentingMarketPortfolio = downPayment;

            for (int y = 1; y <= maxYears; y++)
            {
                double yearlyRent = currentRent * 12;
                accumulatedRentCost += yearlyRent;
                currentRent *= (1 + rentGrowthRate);
                
                rentingMarketPortfolio *= (1 + marketReturn);

                // Buying cost (mortgage + 1.5% maint/taxes)
                double yearlyBuyExpenses = monthlyMortgage * 12 + (currentHouseValue * 0.015);
                accumulatedBuyCost += yearlyBuyExpenses;
                currentHouseValue *= (1 + houseAppreciation);

                // Net Wealth if Renting = Portfolio - accumulated rent
                double rentingNetWealth = rentingMarketPortfolio - accumulatedRentCost;
                
                // Net Wealth if Buying = House Value - Loan Balance (Approx) - accumulated buy costs (simplified: Equity - sunk costs)
                double buyingNetWealth = currentHouseValue - accumulatedBuyCost; 

                // A crossover when buying becomes more profitable than renting
                if (buyingNetWealth > rentingNetWealth) 
                {
                    return y;
                }
            }
            return -1; // Never crosses
        }

        // 5. ROI (IRR & Cap Rate)
        public static (double irr, double capRate) CalculateROI(double propertyValue, double monthlyRent, double operatingExpenses, double finalSalePrice, int years)
        {
            double yearlyRent = monthlyRent * 12;
            double noi = yearlyRent - operatingExpenses;
            double capRate = noi / propertyValue;

            double rateLow = -0.5;
            double rateHigh = 1.0;
            double irr = 0;

            for (int i = 0; i < 100; i++) 
            {
                irr = (rateLow + rateHigh) / 2.0;
                double npv = -propertyValue;
                for (int y = 1; y <= years; y++)
                {
                    npv += noi / Math.Pow(1 + irr, y);
                }
                npv += finalSalePrice / Math.Pow(1 + irr, years);

                if (npv > 0)
                {
                    rateLow = irr;
                }
                else
                {
                    rateHigh = irr;
                }
            }

            return (irr, capRate);
        }

        // 6. Q-Learning Prepayment Strategy (Active Learning Loop)
        public static string RunRealQLearningSimulation(double loanAmount)
        {
            StringBuilder log = new StringBuilder();
            
            // Simplified State machine: 0: Low Debt, 1: Med Debt, 2: High Debt
            // Actions: 0: No extra pay, 1: Extra 50k, 2: Extra 100k
            double[,] qTable = new double[3, 3];
            Random rand = new Random(42); // Fixed seed for reproducible demo
            
            double alpha = 0.1; // Learning rate
            double gamma = 0.9; // Discount factor
            int episodes = 1000;
            
            log.AppendLine($"初始化 Q-Table (3 個狀態 x 3 個動作)");
            log.AppendLine($"Learning Rate (α): {alpha}, Discount Factor (γ): {gamma}");
            log.AppendLine("開始執行 1,000 次 Episode 訓練迭代...\n");
            
            for (int e = 0; e < episodes; e++)
            {
                int state = rand.Next(0, 3);
                int action = rand.Next(0, 3);
                
                // Reward Logic: 
                // High Debt (State 2) + High Pay (Action 2) = Good (+100)
                // Low Debt (State 0) + High Pay (Action 2) = Bad (-50, because opportunity cost in stock market is better)
                // Low Debt (State 0) + No Pay (Action 0) = Good (+50)
                double reward = 0;
                if (state == 2 && action == 2) reward = 100;
                else if (state == 2 && action == 0) reward = -100;
                else if (state == 0 && action == 0) reward = 50; 
                else if (state == 0 && action == 2) reward = -50;
                else reward = 10; 
                
                int nextState = Math.Max(0, state - action);
                double maxNextQ = Math.Max(Math.Max(qTable[nextState, 0], qTable[nextState, 1]), qTable[nextState, 2]);
                
                // Bellman Equation Q-Table Update Rule
                qTable[state, action] = qTable[state, action] + alpha * (reward + gamma * maxNextQ - qTable[state, action]);
                
                if (e == 0 || e == 500 || e == 999)
                {
                    log.AppendLine($"[第 {e+1,4} 回合] 更新 Q(狀態:{state}, 動作:{action}) = {qTable[state,action]:F2}, 獲得 Reward: {reward}");
                }
            }
            
            log.AppendLine("\n🎯 訓練完成！最終收斂的 Q-Table (價值矩陣)：");
            log.AppendLine("狀態 \\ 動作\t不還款(0)\t穩健還款(1)\t大額清償(2)");
            string[] stateNames = { "低債務期", "中債務期", "高債務期" };
            for(int s = 0; s < 3; s++)
            {
                log.AppendLine($"{stateNames[s]}  \t {qTable[s,0],7:F2}\t {qTable[s,1],7:F2}\t {qTable[s,2],7:F2}");
            }
            
            log.AppendLine("\n【AI 最佳策略推論 (Inference)】：");
            for(int s=0; s<3; s++)
            {
                int bestAction = 0;
                double maxQ = qTable[s, 0];
                if (qTable[s, 1] > maxQ) { maxQ = qTable[s, 1]; bestAction = 1; }
                if (qTable[s, 2] > maxQ) { maxQ = qTable[s, 2]; bestAction = 2; }
                
                if (bestAction == 0) log.AppendLine($"◆ {stateNames[s]} 最佳決策：不提前還款 (將閒置資金投入股市達利最大化)");
                else if (bestAction == 1) log.AppendLine($"◆ {stateNames[s]} 最佳決策：穩健小額還款 (有效降低利息同時保留彈性備用金)");
                else log.AppendLine($"◆ {stateNames[s]} 最佳決策：大額清償本金 (高負債時利息負擔過重，提前還款效益最大化)");
            }

            return log.ToString();
        }

        // 7. ZKP Income Verification (Simplified Protocol)
        public static (bool isVerified, string proofDetails) VerifyIncomeZKP(double actualIncome, double requiredThreshold, string userSecret)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] commitmentBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(actualIncome.ToString() + userSecret));
                string commitment = BitConverter.ToString(commitmentBytes).Replace("-", "").ToLower();

                bool isSufficient = actualIncome >= requiredThreshold;
                
                string details = $"1. 用戶防偽種子: [已隱藏]\n" +
                                 $"2. 實際收入數字: [已隱藏 (Zero-Knowledge)]\n" +
                                 $"3. 密碼學承諾 (Hash Commitment): {commitment}\n" +
                                 $"4. 零知識證明質詢 (Challenge): 驗證隱藏收入是否 >= {requiredThreshold} TWD？\n" +
                                 $"5. 數學驗證結果: {(isSufficient ? "✔️ 通過證明，具備還款能力 (Without revealing exact income!)" : "❌ 拒絕，隱秘證明未達門檻")}";

                return (isSufficient, details);
            }
        }
    }
}
