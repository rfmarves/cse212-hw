using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Createa a queue with the following people and priorities: Bob (2), Tim (5), Sue (3), Peter (5) and
    // run until the queue is empty
    // Expected Result: Tim, Peter, Sue, Bob
    // Defect(s) Found: 
    public void TestPriorityQueue_FiniteQueueOneRepeat()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Bob", 2);
        pq.Enqueue("Tim", 5);
        pq.Enqueue("Sue", 3);
        pq.Enqueue("Peter", 5);

        var expectedResult = new List<string> { "Tim", "Peter", "Sue", "Bob" };

        int i = 0;
        while (pq.Length > 0)
        {
            if (i >= expectedResult.Count)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = pq.Dequeue();
            Assert.AreEqual(expectedResult[i], person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected an exception to be thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Createa a queue with the following people and priorities: Bob (1), Jane (1), Tim (2), Sue (3), Peter (4),
    // then, dequeue 2 people, then add Joe with priority 2, and Ann with priority 5, run until the queue is empty
    // Expected Result: Tim, Peter, Sue, Bob
    // Defect(s) Found: 
    public void TestPriorityQueue_FiveWithTwoRemoveTwoAdd()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Bob", 1);
        pq.Enqueue("Jane", 1);
        pq.Enqueue("Tim", 2);
        pq.Enqueue("Sue", 3);
        pq.Enqueue("Peter", 4);

        var expectedResult = new List<string> { "Peter", "Sue", "Ann", "Tim", "Joe", "Bob", "Jane" };

        int i = 0;
        for(; i < 2; i++)
        {
            var person = pq.Dequeue();
            Assert.AreEqual(expectedResult[i], person);
        }

        pq.Enqueue("Joe", 2);
        pq.Enqueue("Ann", 5);

        while (pq.Length > 0)
        {
            if (i >= expectedResult.Count)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = pq.Dequeue();
            Assert.AreEqual(expectedResult[i], person);
            i++;
        }
    }
}