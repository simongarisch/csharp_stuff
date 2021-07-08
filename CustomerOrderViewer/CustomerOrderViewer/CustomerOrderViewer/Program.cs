using CustomerOrderViewer.Repository;
using System;
using System.Linq;
using System.Data.SqlClient;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connectionString = @"Data Source=localhost,1433;Initial Catalog=CustomerOrderViewer;User ID=sa;Password=MyBigPassword1!";
                var customerOrderDetailCommand = new CustomerOrderDetailCommand(connectionString);
                var customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach(var item in customerOrderDetailModels)
                    {
                        Console.WriteLine(
                            "{0}: FullName: {1} {2} (Id: {3}) - purchased {4} for {5:C} (Id: {6})",
                            item.CustomerOrderId,
                            item.FirstName,
                            item.LastName,
                            item.CustomerId,
                            item.Description,
                            item.Price,
                            item.ItemId
                        );
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: {0}", ex.ToString());
            }
        }
    }
}
