def main():
    print("=========================================")
    print("      Python 財務建議小幫手 (Financial Advisor)")
    print("=========================================")
    print("這是一個簡單的財務狀況診斷與投資複利計算器。\n")
    
    try:
        inc = input("請輸入您的『每月總收入』 (TWD) [預設: 50000]: ")
        exp = input("請輸入您的『每月總支出』 (包含房貸/租金) (TWD) [預設: 30000]: ")
        
        monthly_income = float(inc) if inc.strip() else 50000
        monthly_expense = float(exp) if exp.strip() else 30000
    except ValueError:
        print("您輸入的不是有效的數字格式，程式結束。")
        return
        
    cash_flow = monthly_income - monthly_expense
    
    print("\n----------------【 診斷報告 】----------------")
    if cash_flow <= 0:
         print("⚠️ 警告：您的現金流為負或打平！")
         print("   強烈建議立刻檢視您的非必要開銷（例如：娛樂、訂閱制、奢侈品外食等）。")
         print("   請確保收入能大於支出，否則您的負債會越滾越大。")
    else:
         print(f"✅ 恭喜！您每月有 {cash_flow:,.0f} TWD 的「自由現金流」。")
         
    emergency_fund = monthly_expense * 6
    print(f"\n【緊急預備金建議】")
    print(f"根據您的開銷水準，建議您在流動性高的活存活儲帳戶中，保留至少 6 個月的生活費：")
    print(f"👉 目標水位：{emergency_fund:,.0f} TWD")
    
    if cash_flow > 0:
        print(f"\n----------------【 複利理財推算 】----------------")
        print(f"(假設您具備 {emergency_fund:,.0f} TWD 預備金後，將現金流投入合理避險標的)")
        
        investable = cash_flow * 0.7 
        print(f"假設您將每月自由現金流的 70% (約 {investable:,.0f} TWD) 投入 ETF 大盤...")
        print("保守估計長期年化報酬率為 6%：\n")
        
        future_val_10 = 0
        future_val_20 = 0
        monthly_rate = 0.06 / 12
        for m in range(1, 20*12 + 1):
            future_val_20 = future_val_20 * (1 + monthly_rate) + investable
            if m == 10*12:
                future_val_10 = future_val_20
                
        print(f"▶️ 透過時間與複利的力量，10 年後，您的投資資產將成長至約: {future_val_10:,.0f} TWD")
        print(f"▶️ 持續堅持，20 年後，您的投資資產將呈現指數性成長約至: {future_val_20:,.0f} TWD")
        print("\n結論：良好的規劃能善用金錢的時間價值，祝您財務自由！")

if __name__ == "__main__":
    main()
