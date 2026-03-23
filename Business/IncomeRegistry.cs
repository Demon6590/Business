namespace Business;

public class IncomeRegistry
{
    public List<Income> Incomes { get; }=new List<Income>();
    
    public void AddIncome(Income income)=> Incomes.Add(income);

    public List<Income> getIncomesByMonth(int year, int month)
    {
        List<Income> monthlyIncomes = new List<Income>();
    
        foreach (Income income in Incomes)
        {
            if (income.date.Year == year && income.date.Month == month)
            {
                monthlyIncomes.Add(income);
            }
        }
    
        return monthlyIncomes;
    }
    public double getTotalIncomeByMonth(int year, int month)
    {
        double totalIncome = 0.0;
    
        foreach (Income income in Incomes)
        {
            if (income.date.Year == year && income.date.Month == month)
            {
                totalIncome += income.amount;
            }
        }
        return totalIncome;
    }

    public double getTaxByMonth(int year, int month)
    {
        double tax = 0.0;
        foreach (Income income in Incomes)
        {
            if(income.date.Year == year && income.date.Month == month)
            {
                tax += income.calculateTax();
            }
        }
        return tax;
    }

    public double getProfitByMonth(int year, int month)
    {
        double totalIncome = getTotalIncomeByMonth(year, month);
        double totalTax = getTaxByMonth(year, month);
    
        double profit = totalIncome - totalTax;
        return profit;
    }

}