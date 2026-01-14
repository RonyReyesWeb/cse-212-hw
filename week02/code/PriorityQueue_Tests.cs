using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue items from a queue with different priorities.
    // Expected Result: Items are returned from highest to lowest priority. Empty queue throws exception.
    // Defect(s) Found: Dequeue did not always return the highest priority item first.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        var item1 = pq.Dequeue();
        Assert.AreEqual("High", item1);

        var item2 = pq.Dequeue();
        Assert.AreEqual("Medium", item2);

        var item3 = pq.Dequeue();
        Assert.AreEqual("Low", item3);

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue(), "The queue is empty.");
    }


    [TestMethod]
    // Scenario: Dequeue items from a queue with multiple priorities, including two items with the same highest priority.
    // Expected Result: Highest priority items come out first; ties follow FIFO. Dequeueing from empty queue throws an exception.
    // Defect(s) Found: Dequeue did not handle FIFO order for items with same priority.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Item1", 5);
        pq.Enqueue("Item2", 10);
        pq.Enqueue("Item3", 10);
        pq.Enqueue("Item4", 3);

        var first = pq.Dequeue();
        Assert.AreEqual("Item2", first);

        var second = pq.Dequeue();
        Assert.AreEqual("Item3", second);

        var third = pq.Dequeue();
        Assert.AreEqual("Item1", third);

        var fourth = pq.Dequeue();
        Assert.AreEqual("Item4", fourth);

        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue(), "The queue is empty.");
    }

}