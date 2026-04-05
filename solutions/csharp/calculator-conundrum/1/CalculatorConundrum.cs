
using Xunit.Sdk;

public static class SimpleCalculator
{
    
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            if (operation == null)
                throw new ArgumentNullException();
            else if (operation == "")
                throw new ArgumentException();
            else if (operation == "*" || operation == "/" || operation == "+")
            {
                if (operand2 == 0 && operation == "/")
                {
                    return "Division by zero is not allowed.";
                }
                else if (operation == "+")
                    return $"{operand1} {operation} {operand2} = {operand1 + operand2}";
                else if (operation == "*")
                    return $"{operand1} {operation} {operand2} = {operand1 * operand2}";
                else if (operation == "/")
                    return $"{operand1} {operation} {operand2} = {operand1 / operand2}";
                else throw new ArgumentOutOfRangeException();
            }
            else
                throw new ArgumentOutOfRangeException();
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw new ArgumentOutOfRangeException( $"Number is out of range:{e.Message}");
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException("operation can't be null");
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("operation can't be empty");
        }
    }
}
