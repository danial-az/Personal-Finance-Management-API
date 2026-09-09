namespace Personal_Finance_Management_API.Models;

public sealed class Account
{
    public int Id { get;}
    public string Name { get; init; }
    public decimal Balance { get; private set; }
    public  Currency Currency { get; init; }
    private static int _nextId = 1;
    
    private Account(string name,decimal balance, Currency currency)
    {
        Name = name;
        Id = _nextId++;
        Balance = balance;
        Currency = currency;
    }

    public static OperationResult<Account> Create(string name, decimal balance, Currency currency)
    {
        OperationResult<Account> result;
        if (balance < 0)
        {
            result = OperationResult<Account>.Failure("Balance cannot be negative");
        }
        else
        {
            result = OperationResult<Account>.Success(new Account(name, balance, currency));
        }
        return result;
        
    }
    public OperationResult Deposit(decimal amount)
    {
        OperationResult result;
        if (amount <= 0)
            result = OperationResult.Failure("Amount cannot be negative");
        else
        {
            Balance += amount;
            result = OperationResult.Success();
        }

        return result;
        
    }

    public OperationResult Withdraw(decimal amount)
    {   
        OperationResult result;
        if (amount <= 0)
        {
            result = OperationResult.Failure("Amount cannot be negative");
            
        }
        else if  (amount > Balance)
        {
            result = OperationResult.Failure("Amount cannot be greater than Balance");
        }
        else
        {
            Balance -= amount;
            result = OperationResult.Success();
        }

        return result;
    }
    


}