using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items and verify they are added to the back regardless of priority
    // Expected Result: ToString should show items in order of insertion
    // Defect(s) Found: None - items are correctly added to back
    public void TestPriorityQueue_EnqueueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 2);
        
        Assert.AreEqual("[First (Pri:1), Second (Pri:3), Third (Pri:2)]", 
            priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue should always return highest priority item
    // Expected Result: Items should be dequeued in order of priority (highest first)
    // Defect(s) Found: 
    // 1. Dequeue doesn't remove items from queue
    // 2. Loop in Dequeue misses last item
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority should follow FIFO
    // Expected Result: Items with equal priority should be dequeued in order of insertion
    // Defect(s) Found: Equal priority items not handled in FIFO order due to >= comparison
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);
        priorityQueue.Enqueue("Fourth", 1);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test empty queue behavior
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None - empty queue handling works correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        
        // Test dequeue until empty then dequeue again
        priorityQueue.Enqueue("Test", 1);
        priorityQueue.Dequeue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Complex priority and FIFO interaction
    // Expected Result: Should handle mix of priorities and FIFO correctly
    // Defect(s) Found: Multiple defects in priority and FIFO handling
    public void TestPriorityQueue_ComplexPriorityAndFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Highest priority
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First of priority 2
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second of priority 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First of priority 1
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Second of priority 1
    }
}
