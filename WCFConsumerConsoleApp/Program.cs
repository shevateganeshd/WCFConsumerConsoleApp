using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFConsumerConsoleApp.CustomerServiceReference;

namespace WCFConsumerConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice=1;
            
            while(true)
            {
                Console.WriteLine("...::MENU::...");
                Console.WriteLine("1 Get Customer List");
                Console.WriteLine("2 Get Customer");
                Console.WriteLine("3 Add Customer");
                Console.WriteLine("4 Update Customer");
                Console.WriteLine("5 Delete Customer");
                Console.WriteLine("0 Exit");
                Console.Write("\nEnter Your Choice: ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        CustomerServiceReference.CustomerServiceClient getCustomersServiceClient = new CustomerServiceReference.CustomerServiceClient();
                        //CustomerContract contract = new CustomerContract();
                        List<CustomerContract> getCustomers = getCustomersServiceClient.GetCustomers().ToList();
                        foreach(CustomerContract getCustomer in getCustomers)
                        {
                            Console.WriteLine("Id: "+ getCustomer.Id+" First Name: "+ getCustomer.FirstName+" MiddleName: "+ getCustomer.MiddleName+" Last Name: "+ getCustomer.LastName+" Address: "+ getCustomer.Address+" Email: "+ getCustomer.Email+" Phone: "+ getCustomer.Phone);
                        }
                        Console.WriteLine();
                        break;

                    case 2:
                        CustomerServiceReference.CustomerServiceClient getCustomerServiceClient = new CustomerServiceReference.CustomerServiceClient();
                        //CustomerContract contrac = new CustomerContract();
                        Console.Write("Enter Customer Id : ");
                        int Id = int.Parse(Console.ReadLine());
                        CustomerContract customer = getCustomerServiceClient.GetCustomer(Id);
                        if (customer != null)
                        {
                            Console.WriteLine("Id: " + customer.Id + " First Name: " + customer.FirstName + " MiddleName: " + customer.MiddleName + " Last Name: " + customer.LastName + " Address: " + customer.Address + " Email: " + customer.Email + " Phone: " + customer.Phone+"\n");
                        }
                        break;

                    case 3:
                        CustomerServiceReference.CustomerServiceClient addCustomerServiceClient = new CustomerServiceReference.CustomerServiceClient();
                        CustomerContract addCustomer = new CustomerContract();
                        Console.Write("First Name : ");
                        string firstName = Console.ReadLine();
                        Console.Write("Middle Name : ");
                        string middlestName = Console.ReadLine();
                        Console.Write("Last Name : ");
                        string lastName = Console.ReadLine();
                        Console.Write("Address : ");
                        string address = Console.ReadLine();
                        Console.Write("Email : ");
                        string email = Console.ReadLine();
                        Console.Write("Phone : ");
                        string phone = Console.ReadLine();
                        addCustomer.FirstName = firstName;
                        addCustomer.MiddleName = middlestName;
                        addCustomer.LastName = lastName;
                        addCustomer.Address = address;
                        addCustomer.Email = email;
                        addCustomer.Phone = phone;
                        addCustomerServiceClient.AddCustomer(addCustomer);
                        Console.WriteLine("\nRecord Added Successfully\n");
                        //Console.ReadKey();
                        break;

                    case 4:
                        CustomerServiceReference.CustomerServiceClient updateCustomerServiceClient = new CustomerServiceReference.CustomerServiceClient();
                        CustomerContract updateCustomer = new CustomerContract();
                        Console.Write("Id : ");
                        int updatedId = int.Parse(Console.ReadLine());
                        Console.Write("First Name : ");
                        string updateFirstName = Console.ReadLine();
                        Console.Write("Middle Name : ");
                        string updateMiddlestName = Console.ReadLine();
                        Console.Write("Last Name : ");
                        string updateLastName = Console.ReadLine();
                        Console.Write("Address : ");
                        string updateAddress = Console.ReadLine();
                        Console.Write("Email : ");
                        string updateEmail = Console.ReadLine();
                        Console.Write("Phone : ");
                        string updatePhone = Console.ReadLine();
                        updateCustomer.Id = updatedId;
                        updateCustomer.FirstName = updateFirstName;
                        updateCustomer.MiddleName = updateMiddlestName;
                        updateCustomer.LastName = updateLastName;
                        updateCustomer.Address = updateAddress;
                        updateCustomer.Email = updateEmail;
                        updateCustomer.Phone = updatePhone;
                        updateCustomerServiceClient.UpdateCustomer(updateCustomer);
                        Console.WriteLine("\nRecord Updated Successfully\n");
                        break;

                    case 5:
                        CustomerServiceReference.CustomerServiceClient deleteCustomerServiceClient = new CustomerServiceReference.CustomerServiceClient();
                        Console.Write("Id : ");
                        int deleteId = int.Parse(Console.ReadLine());
                        deleteCustomerServiceClient.DeleteCustomer(deleteId);
                        Console.WriteLine("\nRecord Deleted Successfully\n");
                        break;

                    case 0:
                        return;

                }
            }
        }
    }
}
