/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Negative value passed
        // Expected Result: Max queue set to 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(-1);
        if (cs._maxSize == 10) {
            Console.WriteLine("Test 1 Passed: Max queue set to 10");
        } else {
            Console.WriteLine("Test 1 Failed: Max queue not set to 10");
        }

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Zero value passed
        // Expected Result: Max queue should be set to 10
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(0);
        if (cs2._maxSize == 10) {
            Console.WriteLine("Test 2 Passed: Max queue set to 10");
        } else {
            Console.WriteLine("Test 2 Failed: Max queue not set to 10");
        }

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Positive value passed
        // Expected Result: Max queue should be set to the passed value
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(5);
        if (cs3._maxSize == 5) {
            Console.WriteLine("Test 3 Passed: Max queue set to 5");
        } else {
            Console.WriteLine("Test 3 Failed: Max queue not set to 5");
        }

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add new customer to the queue
        // Expected Result: Customer should be added to the queue
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(3);
        cs4.AddNewCustomer();
        if (cs4._queue.Count == 1) {
            Console.WriteLine("Test 4 Passed: Customer added to the queue");
        } else {
            Console.WriteLine("Test 4 Failed: Customer not added to the queue");
        }

        // Test 5
        // Scenario: Attempt to add customer when queue is full
        // Expected Result: Customer should not be added to the queue
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(1);
        cs5.AddNewCustomer();
        try {
            cs5.AddNewCustomer();
            if (cs5._queue.Count == 1) {
                Console.WriteLine("Test 5 Passed: Customer not added to the queue when full");
            } else {
                Console.WriteLine("Test 5 Failed: Customer added to the queue when it should not have been");
            }
        } catch (Exception ex) {
            Console.WriteLine($"Test 5 Passed, Expected Exception: {ex.Message}");
        } 
        
        Console.WriteLine("=================");

        // Test 6
        // Scenario: ServeCustomer from the queue
        // Expected Result: Customer should be displayed and removed from the queue
        Console.WriteLine("Test 6");
        var cs6 = new CustomerService(2);
        cs6.AddNewCustomer();
        cs6.AddNewCustomer();
        cs6.ServeCustomer();
        if (cs6._queue.Count == 1) {
            Console.WriteLine("Test 6 Passed: Customer served and removed from the queue");
        } else {
            Console.WriteLine("Test 6 Failed: Customer not served or removed from the queue");
        }

        // Test 7
        // Scenario: ServeCustomer from an empty queue
        // Expected Result: Should handle gracefully without throwing an exception
        Console.WriteLine("Test 7");
        var cs7 = new CustomerService(1);
        try {
            cs7.ServeCustomer();
            Console.WriteLine("Test 7 Passed: Handled empty queue gracefully");
        } catch (Exception ex) {
            Console.WriteLine($"Test 7 Failed: Exception thrown - {ex.Message}");
        }

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}