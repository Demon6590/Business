namespace Business;

/// <summary>
/// Реестр доходов для хранения и анализа записей о доходах.
/// </summary>
public class IncomeRegistry
{
    /// <summary>
    /// Список всех записей о доходах.
    /// </summary>
    public List<Income> Incomes { get; } = new List<Income>();

    /// <summary>
    /// Добавляет новую запись о доходе в реестр.
    /// </summary>
    /// <param name="income">Запись о доходе для добавления.</param>
    public void AddIncome(Income income) => Incomes.Add(income);

    /// <summary>
    /// Возвращает список доходов за указанный месяц и год.
    /// </summary>
    /// <param name="year">Год.</param>
    /// <param name="month">Месяц (1-12).</param>
    /// <returns>Список доходов за указанный период.</returns>
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

    /// <summary>
    /// Возвращает общую сумму доходов за указанный месяц и год.
    /// </summary>
    /// <param name="year">Год.</param>
    /// <param name="month">Месяц (1-12).</param>
    /// <returns>Общая сумма доходов за период.</returns>
    public double getTotalIncomeByMonth(int year, int month)
    {
        var totalIncome = 0.0;
        var monthlyIncomes = getIncomesByMonth(year, month);

        foreach (Income income in monthlyIncomes)
        {
            totalIncome += income.amount;
        }

        return totalIncome;
    }

    /// <summary>
    /// Рассчитывает общую сумму налога за указанный месяц и год.
    /// </summary>
    /// <param name="year">Год.</param>
    /// <param name="month">Месяц (1-12).</param>
    /// <returns>Общая сумма налога за период.</returns>
    public double getTaxByMonth(int year, int month)
    {
        var tax = 0.0;
        var monthlyIncomes = getIncomesByMonth(year, month);

        foreach (Income income in monthlyIncomes)
        {
            tax += income.calculateTax();
        }

        return tax;
    }

    /// <summary>
    /// Рассчитывает чистую прибыль за указанный месяц и год (доход минус налог).
    /// </summary>
    /// <param name="year">Год.</param>
    /// <param name="month">Месяц (1-12).</param>
    /// <returns>Чистая прибыль за период.</returns>
    public double getProfitByMonth(int year, int month)
    {
        double totalIncome = getTotalIncomeByMonth(year, month);
        double totalTax = getTaxByMonth(year, month);

        double profit = totalIncome - totalTax;
        return profit;
    }
}