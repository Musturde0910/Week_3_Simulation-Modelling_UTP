using System.Collections.Generic;

public class CustomerQueue
{
    private Queue<Customer> queue = new Queue<Customer>();

    public void PushCustomer(Customer customer)
    {
        queue.Enqueue(customer);
    }

    public Customer PopCustomer()
    {
        if (queue.Count > 0)
            return queue.Dequeue();
        else
            return null;
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }

    public int NumCustomers()
    {
        return queue.Count;
    }
}
