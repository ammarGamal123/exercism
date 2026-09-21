using System.IO.Pipelines;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float result = 0;

        if (balance < 0.00000000000m)
            result = 3.213f;
        else if (balance < 1000.00000000000000m)
            result = 0.5f;
        else if (balance >= 1000.000000000000m && balance < 5000.0000000000000m)
            result = 1.621f;
        else
            result = 2.475f;

        return result;
    }


    public static decimal Interest(decimal balance)
    {
        float rate = 0;
        decimal result = 0;

        if (balance < 0.00000000000m)
        {
            rate = 3.213f;
            result = (decimal)rate * (balance /100m);
        }
        else if (balance < 1000.00000000000000m)
        {
            rate = 0.5f;
            result = (decimal)rate * (balance /100m);
        }
        else if (balance >= 1000.000000000000m && balance < 5000.0000000000000m)
        {
            rate = 1.621f;
            result = (decimal)rate * (balance /100m);
        }
        else
        {
            rate = 2.475f;
            result = (decimal)rate * (balance /100m);
        }

        return result;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        decimal annualBalance = 0;
        float rate = 0;
        decimal result = 0;

        if (balance < 0.00000000000m)
        {
            rate = 3.213f;
            result = (decimal)rate * (balance / 100m);
        }
        else if (balance < 1000.00000000000000m)
        {
            rate = 0.5f;
            result = (decimal)rate * (balance / 100m);
        }
        else if (balance >= 1000.000000000000m && balance < 5000.0000000000000m)
        {
            rate = 1.621f;
            result = (decimal)rate * (balance / 100m);
        }
        else
        {
            rate = 2.475f;
            result = (decimal)rate * (balance / 100m);
        }
        annualBalance = result + balance;
        return annualBalance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (targetBalance <= balance) return 0;

        decimal annualBalance = 0;
        float rate = 0;
        decimal result = 0;
        int neededYears = 1;

        if (balance < 0.00000000000m)
        {
            rate = 3.213f;
            result = (decimal)rate * (balance / 100m);
        }
        else if (balance < 1000.00000000000000m)
        {
            rate = 0.5f;
            result = (decimal)rate * (balance / 100m);
        }
        else if (balance >= 1000.000000000000m && balance < 5000.0000000000000m)
        {
            rate = 1.621f;
            result = (decimal)rate * (balance / 100m);
        }
        else
        {
            rate = 2.475f;
            result = (decimal)rate * (balance / 100m);
        }
        annualBalance = result + balance;
        // neededYears = ((int)Math.Ceiling(targetBalance) - (int)Math.Ceiling(balance)) / (int)Math.Ceiling(result);
        
        while (annualBalance < targetBalance)
        {
            if (balance < 0.00000000000m)
            {
                rate = 3.213f;
                result = (decimal)rate * (balance / 100m);
            }
            else if (balance < 1000.00000000000000m)
            {
                rate = 0.5f;
                result = (decimal)rate * (balance / 100m);
            }
            else if (balance >= 1000.000000000000m && balance < 5000.0000000000000m)
            {
                rate = 1.621f;
                result = (decimal)rate * (balance / 100m);
            }
            else
            {
                rate = 2.475f;
                result = (decimal)rate * (balance / 100m);
            }
            
            ++neededYears;
            balance = annualBalance;
            result = (decimal)rate * (balance / 100m);
            annualBalance += result;
        }

        return neededYears;
    }
}
