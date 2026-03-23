namespace TestProject1;

using Business;

public class UnitTest1
{
    [Fact]
    public void IndividualPayerTaxRate_ReturnsFourPercent()
    {
        var payer = new IndividualPayer { name = "Иванов И.И.", Type = PayerType.INDIVIDUAL };
        var income = new Income { date = new DateTime(2026, 3, 23), amount = 10000, payer = payer };
        var taxRate = income.getTaxRate();
        Assert.Equal(0.04, taxRate);
    }

    [Fact]
    public void LegalEntityPayerTaxRate_ReturnsSixPercent()
    {
        var payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY };
        var income = new Income { date = new DateTime(2026, 3, 23), amount = 10000, payer = payer };
        var taxRate = income.getTaxRate();
        Assert.Equal(0.06, taxRate);
    }

    [Fact]
    public void IndividualPayerTaxAmount_ReturnsFourHundred()
    {
        var payer = new IndividualPayer { name = "Иванов И.И.", Type = PayerType.INDIVIDUAL };
        var income = new Income { date = new DateTime(2026, 3, 23), amount = 10000, payer = payer };
        var tax = income.calculateTax();
        Assert.Equal(400, tax);
    }

    [Fact]
    public void LegalEntityPayerTaxAmount_ReturnsSixHundred()
    {
        var payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY };
        var income = new Income { date = new DateTime(2026, 3, 23), amount = 10000, payer = payer };
        var tax = income.calculateTax();
        Assert.Equal(600, tax);
    }

    [Fact]
    public void IncomeAmountZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Income
        {
            date = DateTime.Now,
            amount = 0,
            payer = new IndividualPayer { name = "Test", Type = PayerType.INDIVIDUAL }
        });
    }

    [Fact]
    public void IncomeAmountNegative_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Income
        {
            date = DateTime.Now,
            amount = -100,
            payer = new IndividualPayer { name = "Test", Type = PayerType.INDIVIDUAL }
        });
    }

    [Fact]
    public void RegistryAddIncome_IncreasesCollectionCount()
    {
        var registry = new IncomeRegistry();
        var income = new Income
        {
            date = new DateTime(2026, 3, 23),
            amount = 10000,
            payer = new IndividualPayer { name = "Иванов", Type = PayerType.INDIVIDUAL }
        };
        registry.AddIncome(income);
        Assert.Equal(income, registry.Incomes[0]);
    }

    [Fact]
    public void RegistryMarchIncomes_ReturnsTwoRecords()
    {
        var registry = new IncomeRegistry();
        var income1 = new Income
        {
            date = new DateTime(2026, 3, 15),
            amount = 5000,
            payer = new IndividualPayer { name = "Иванов", Type = PayerType.INDIVIDUAL }
        };
        var income2 = new Income
        {
            date = new DateTime(2026, 3, 23),
            amount = 7000,
            payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY }
        };
        var income3 = new Income
        {
            date = new DateTime(2026, 2, 10),
            amount = 3000,
            payer = new IndividualPayer { name = "Петров", Type = PayerType.INDIVIDUAL }
        };

        registry.AddIncome(income1);
        registry.AddIncome(income2);
        registry.AddIncome(income3);

        var result = registry.getIncomesByMonth(2026, 3);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void RegistryMarchTotalIncome_ReturnsTwelveThousand()
    {
        var registry = new IncomeRegistry();
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 15),
            amount = 5000,
            payer = new IndividualPayer { name = "Иванов", Type = PayerType.INDIVIDUAL }
        });
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 23),
            amount = 7000,
            payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY }
        });
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 2, 10),
            amount = 3000,
            payer = new IndividualPayer { name = "Петров", Type = PayerType.INDIVIDUAL }
        });

        var total = registry.getTotalIncomeByMonth(2026, 3);
        Assert.Equal(12000, total);
    }

    [Fact]
    public void RegistryMarchTotalTax_ReturnsSixHundredTwenty()
    {
        var registry = new IncomeRegistry();
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 15),
            amount = 5000,
            payer = new IndividualPayer { name = "Иванов", Type = PayerType.INDIVIDUAL }
        });
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 23),
            amount = 7000,
            payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY }
        });

        var tax = registry.getTaxByMonth(2026, 3);
        Assert.Equal(620, tax);
    }

    [Fact]
    public void RegistryMarchProfit_ReturnsElevenThousandThreeHundredEighty()
    {
        var registry = new IncomeRegistry();
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 15),
            amount = 5000,
            payer = new IndividualPayer { name = "Иванов", Type = PayerType.INDIVIDUAL }
        });
        registry.AddIncome(new Income
        {
            date = new DateTime(2026, 3, 23),
            amount = 7000,
            payer = new LegalEntityPayer { name = "ООО Ромашка", Type = PayerType.LEGAL_ENTITY }
        });

        var profit = registry.getProfitByMonth(2026, 3);
        Assert.Equal(11380, profit);
    }
}