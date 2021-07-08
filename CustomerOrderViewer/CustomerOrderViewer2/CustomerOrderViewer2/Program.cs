using System;
using CustomerOrderViewer2.Repository;

namespace CustomerOrderViewer2
{
    class Program
    {
        private static string _connectionString = "Data Source=localhost,1433;Initial Catalog=CustomerOrderViewer;User ID=sa;Password=MyBigPassword1!";
        private static readonly CustomerOrderCommand _customerOrderCommand = new CustomerOrderCommand(_connectionString);
        private static readonly CustomerCommand _customerCommand = new CustomerCommand(_connectionString);
        private static readonly ItemCommand _itemCommand = new ItemCommand(_connectionString);
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("What is your username?");
                string userId = Console.ReadLine();
                bool continueManaging = true;

                do
                {
                    int option = GetIntSelectionGeq0("1 - Show All | 2 - Upsert Customer Order | 3 - Delete Customer Order | 4 - Exit");

                    if (option == 1)
                    {
                        ShowAll();
                    }
                    else if (option == 2)
                    {
                        UpsertCustomerOrder(userId);
                    }
                    else if (option == 3)
                    {
                        DeleteCustomerOrder(userId);
                    }
                    else if (option == 4)
                    {
                        continueManaging = false;
                    }
                    else
                    {
                        Console.WriteLine("Option not valid");
                    }
                } while (continueManaging);
            } catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.ToString());
            }
        }

        public static void ShowAll()
        {
            Console.WriteLine("{0} All Customer Orders: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCustomerOrders();

            Console.WriteLine("{0} All Customers: {1}", Environment.NewLine, Environment.NewLine);
            DisplayCustomers();

            Console.WriteLine("{0} All Items: {1}", Environment.NewLine, Environment.NewLine);
            DisplayItems();

            Console.WriteLine();
        }
        public static void DisplayCustomerOrders()
        {
            var orders = _customerOrderCommand.GetList();
            foreach(var order in orders)
            {
                Console.WriteLine(
                    "{0}: Full Name: {1} {2} (Id {3}) - purchaged {4} for {5:C} (Id {6})",
                    order.CustomerOrderId,
                    order.FirstName,
                    order.LastName,
                    order.CustomerId,
                    order.Description,
                    order.Price,
                    order.ItemId
                );
            }
        }

        public static void DisplayCustomers()
        {
            var customers = _customerCommand.GetList();
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    "{0}: First Name: {1}, Middle Name: {2}, Last Name: {3}, Age {4}",
                    customer.CustomerId,
                    customer.FirstName,
                    customer.MiddleName ?? "N/A",
                    customer.LastName,
                    customer.Age
                );
            }
        }
        public static void DisplayItems()
        {
            var items = _itemCommand.GetList();
            foreach(var item in items)
            {
                Console.WriteLine("{0}: Description: {1}, Price {2}", item.ItemId, item.Description, item.Price);
            }
        }

        public static void UpsertCustomerOrder(string userId)
        {
            Console.WriteLine("Note: For updating insert existing CustomeOrderId, for new entries enter -1");

            int customerOrderId = GetIntSelectionGeq0("Enter CustomerOrderId");
            int customerId = GetIntSelectionGeq0("Enter CustomerId");
            int itemId = GetIntSelectionGeq0("Enter ItemId");

            _customerOrderCommand.Upsert(customerOrderId, customerId, itemId, userId);
        }

        public static void DeleteCustomerOrder(string userId)
        {
            int customerOrderId = GetIntSelectionGeq0("Enter CustomerOrderId");

            _customerOrderCommand.Delete(customerOrderId, userId);
        }

        private static int GetIntSelectionGeq0(string message)
        {
            int i = -1;
            string input = string.Empty;
            bool success = false;
            while (i < 0)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                success = Int32.TryParse(input, out i);
                if (!success)
                {
                    Console.WriteLine("'{0}' is not a valid choice", input);
                }
                else if (i < 0)
                {
                    Console.WriteLine("'{0}' is not a valid choice as it must be >= 0", input);
                }
            }

            return i;
        }
    }
}
