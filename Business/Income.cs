namespace Business;

/// <summary>
/// Класс Дохода. Представляет запись о дате, сумме и плательщике.
/// </summary>
public class Income
{
    /// <summary>
    /// Дата получения дохода.
    /// </summary>
    public DateTime date { get; init; }

    private double field;

    /// <summary>
    /// Сумма дохода (должна быть больше нуля).
    /// </summary>
    /// <exception cref="ArgumentException">Бросается при значении 0.</exception>
    public double amount
    {
        get { return field; }
        init
        {
            if (value <= 0)
                throw new ArgumentException("Value must be greater than zero");
            field = value;
        }
    }

/// <summary>
    /// Плательщик, от которого получен доход.
    /// </summary>
    public Payer payer { get; init; }

    /// <summary>
    /// Возвращает налоговую ставку в зависимости от типа плательщика.
    /// </summary>
    /// <returns>0.04 для физлиц, 0.06 для юрлиц.</returns>
    public double getTaxRate()
    {
        double taxRate = 1.0;
    
        if (payer.Type == PayerType.INDIVIDUAL)
            taxRate = 0.04;

        if (payer.Type == PayerType.LEGAL_ENTITY)
            taxRate = 0.06;
        
        return taxRate;
    }

    /// <summary>
    /// Рассчитывает сумму налога на доход.
    /// </summary>
    /// <returns>Сумму налога: amount * 0.04 для физлиц, amount * 0.06 для юрлиц.</returns>
    public double calculateTax()
    {
        double tax = amount;
        
        if (payer.Type == PayerType.INDIVIDUAL)
        {
            tax = tax * 0.04;
        }
        if (payer.Type == PayerType.LEGAL_ENTITY)
        {
            tax = tax * 0.06;
        }
        return tax;
    }
}