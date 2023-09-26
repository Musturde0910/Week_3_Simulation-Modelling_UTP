using System;

class Program
{
    static void Main()
    {
        int MaxSimTime = 8 * 60;
        int queueSize = 10;
        double serviceTime = 5.0;
        double timeCustomerArrival = 10.0;

        Staff staff = new Staff();
        CustomerQueue customerQueue = new CustomerQueue();
        Random random = new Random();

        int numPrint = 0;
        int totalNumPrint = 0;

        for (int time = 0; time < MaxSimTime; time++)
        {
            // Customer arrival
            if (time % timeCustomerArrival == 0)
            {
                Customer customer = new Customer();
                customer.CustomerId = totalNumPrint++;
                customerQueue.PushCustomer(customer);
                Console.WriteLine($"Customer {customer.CustomerId} enters.");
            }

            // Check if printer is free and there are customers in the queue
            if (staff.IsPrinterFree && !customerQueue.IsEmpty())
            {
                Customer customerToPrint = customerQueue.PopCustomer();
                staff.Print(customerToPrint);
                staff.MoveToCashier(customerToPrint);
                numPrint++;
                Console.WriteLine($"Customer {customerToPrint.CustomerId} begins printing.");
            }

            // Simulate service time
            if (!staff.IsPrinterFree)
            {
                serviceTime -= 1.0;
                if (serviceTime <= 0.0)
                {
                    staff.ReceivePayment(null); // Null customer as printing is completed
                    serviceTime = 5.0; // Reset service time
                    Console.WriteLine("Customer leaves after payment.");
                }
            }
        }

        Console.WriteLine("Total customers printed: "+ numPrint);
    }
}
