namespace Business;

public class Income
{
    public DateTime date { get; init; }

    public double amount
    {
        get{return field;}
        init
        {
            if(value <= 0)
                throw new ArgumentException("Value must be greater than zero");
            field = value;
        }
    }

    public Payer payer { get; init; }

    public double getTaxRate()
    {
        double taxRate = 1.0;
    
        if (payer.Type == PayerType.INDIVIDUAL)
        {
            taxRate = 0.04;
        }
        if (payer.Type == PayerType.LEGAL_ENTITY)
        {
            taxRate = 0.06;
        }
    
        return taxRate;
    }

    public double calculateTax()
    {
        double tax=amount;
        
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