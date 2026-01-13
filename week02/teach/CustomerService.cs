/// Maintain a Customer Service Queue.  Allows new customers to be 
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        var cs2 = new CustomerService(2);
        Console.WriteLine(cs2);
        // Expected Result: 
        Console.WriteLine("Test 2");

        Console.WriteLine("=================");
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        Console.WriteLine(cs2);

        Console.WriteLine("Test 3");
        Console.WriteLine("=================");
        Console.WriteLine("Test 4: Add customer when queue is full");
        cs2.AddNewCustomer(); // should show error
        Console.WriteLine("Expected: error message displayed");
        Console.WriteLine("=================");


    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// Defines a Customer record for the service queue.
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// Prompt the user for the customer and problem information.  Put the new record into the queue.
    private void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// Dequeue the next customer and display the information.
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}