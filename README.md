# 🏠 個人房貸試算器 💰

一個使用 C# Windows Forms 開發的個人房屋貸款試算工具，可快速計算每月還款金額、利息與本金分攤等關鍵數據，協助使用者評估房貸負擔。

## ✨ 功能特色

- **房屋總價輸入** — 以新台幣 (TWD) 輸入房屋總價
- **自備款設定** — 支援兩種模式：
  - 百分比 (%) 模式
  - 固定金額 (TWD) 模式
- **貸款利率** — 輸入年利率，自動換算月利率
- **貸款年限** — 自訂貸款期限（年）
- **寬限期** — 可選擇是否啟用寬限期，寬限期間僅繳利息
- **計算結果一覽**：
  - 貸款總金額
  - 每月應繳金額
  - 首期利息
  - 首期本金
  - 總利息支出
  - 總還款金額
- **視窗大小切換** — 可透過選單切換「自動調整大小」與「手動調整大小」模式

## 🔧 系統需求

- **作業系統**：Windows
- **框架**：[.NET 10](https://dotnet.microsoft.com/)
- **IDE**：[Visual Studio 2022](https://visualstudio.microsoft.com/) 或更新版本

## 🚀 使用方式

### 方法一：透過 Visual Studio 開啟

1. Clone 此專案：
   ```bash
   git clone https://github.com/400Ping/MortgageCalculator.git
   ```
2. 使用 Visual Studio 開啟 `MortgageCalculator.slnx`
3. 按下 `F5` 或點擊「啟動」即可執行

### 方法二：透過 .NET CLI 執行

1. Clone 此專案：
   ```bash
   git clone https://github.com/400Ping/MortgageCalculator.git
   ```
2. 進入專案目錄並執行：
   ```bash
   cd MortgageCalculator/MortgageCalculator
   dotnet run
   ```

## 📖 操作說明

1. 輸入 **房屋總價**
2. 選擇自備款模式（百分比或固定金額），並輸入對應數值
3. 輸入 **貸款利率**（年利率 %）
4. 輸入 **貸款年限**
5. 如需寬限期，勾選「寬限期」並輸入年數
6. 點擊 **📊 計算** 按鈕，結果將顯示於右側面板

## 🧮 計算公式

本工具採用 **本息均攤法（等額本息）** 計算每月還款金額：

$$M = P \times \frac{r(1+r)^n}{(1+r)^n - 1}$$

其中：
- $M$ = 每月還款金額
- $P$ = 貸款本金
- $r$ = 月利率（年利率 ÷ 12 ÷ 100）
- $n$ = 還款月數（貸款年限 × 12 − 寬限期月數）

> 寬限期間僅需繳納利息（$P \times r$），不攤還本金。

## 📁 專案結構

```
MortgageCalculator/
├── MortgageCalculator.slnx          # Solution 檔案
└── MortgageCalculator/
    ├── MortgageCalculator.csproj    # 專案設定檔
    ├── Program.cs                   # 應用程式進入點
    ├── Form1.cs                     # 主表單邏輯（計算、驗證）
    ├── Form1.Designer.cs            # 表單 UI 配置
    └── Form1.resx                   # 表單資源檔
```

## 📝 License

此專案僅供學術作業使用。
