# Учёт доходов самозанятых

## ЗАДАНИЕ

Разработать объектно‑ориентированное решение для учёта доходов самозанятого с поддержкой аналитики.
Обязательно должны быть тесты и документация.
Необходимо фиксировать дату дохода, сумму дохода, от кого получено.
Аналитики: сколько всего было дохода в месяц, какой будет налог на доход от физических и юридических лиц и общая сумма налога, прибыль.


```mermaid
classDiagram
    class PayerType {
        <<enum>>
        INDIVIDUAL
        LEGAL_ENTITY
    }

    class Payer {
        <<abstract>>
        +PayerType Type
    }

    class LegalEntityPayer {
        +string name
        +PayerType type
    }

    class IndividualPayer {
        +string name
        +PayerType type
    }

    class Income {
        +DateTime date
        +double amount
        +Payer payer
        +double getTaxRate() double
        +double calculateTax() double
    }

    class IncomeRegistry {
        +List~Income~ Incomes
        +void AddIncome(Income income)
        +List~Income~ getIncomesByMonth(int year, int month)
        +double getTotalIncomeByMonth(int year, int month)
        +double getTaxByMonth(int year, int month)
        +double getProfitByMonth(int year, int month)
    }

    Payer <|-- LegalEntityPayer
    Payer <|-- IndividualPayer
    Income --> Payer
    IncomeRegistry --> Income
```
