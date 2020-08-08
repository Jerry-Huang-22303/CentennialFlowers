using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace CentennialFlowers
{
    class Program
    {
        static void Main(string[] args)
        {
            Save();
            ReadKey();

            Read();
            ReadKey();
        }

        static void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream("orders.bin", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            WriteLine("Enter the Number of Orders to process:");
            int numberOfOrders = int.Parse(ReadLine());

            Order[] orders = new Order[numberOfOrders];

            for (int i = 0; i < numberOfOrders; i++)

            {
                
                    WriteLine("Enter the Details of the Order {0}", i + 1);

                    Order orderOne = new Order();
                bool isValid = false;
                while (!isValid)
                {
                    try
                    {
                        Write(" - Order Number: ");
                        orderOne.OrderNumber = int.Parse(ReadLine());
                        isValid = true;
                    }
                    catch 
                    {
                        WriteLine("Please enter a valid number");
                    }
                }

                

                Write(" - Customer Name: ");
                    orderOne.CustomerName = ReadLine();

                    Write(" - Arrangement: ");
                    orderOne.Arrangement = ReadLine();

                 isValid = false;
                while (!isValid)
                {
                    try
                    {
                        Write(" - Quantity: ");
                        orderOne.Quantity = int.Parse(ReadLine());
                        isValid = true;
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message + "Please enter a valid number");
                    }
                }

                isValid = false;
                while(!isValid)
                {
                    try
                    {
                        Write(" - Unit Price: ");
                        orderOne.UnitPrice = double.Parse(ReadLine());
                        isValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid, please enter again");
                    }
                }

                    

                    orders[i] = orderOne;
              
            }

            formatter.Serialize(streamWriter.BaseStream, orders);

            streamWriter.Close();
            fileStream.Close();

            WriteLine("Number of Order(s) saved: {0} - File Name: {1} !", numberOfOrders, Path.GetFileName(fileStream.Name));


        }
        static void Read()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream("orders.bin  ", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            Order[] orders;

            // orders = serializer.Deserialize<Order[]>(streamReader.ReadToEnd());
            orders = (Order[])formatter.Deserialize(streamReader.BaseStream);

            int orderIndex = 0;
            double totalPriceSum = 0;

            foreach (Order orderOne in orders)
            {
                orderIndex++;
                                WriteLine("Order {0} Information", orderIndex);
                WriteLine("--------------------");
                WriteLine("Order Number: {0}", orderOne.OrderNumber);
                WriteLine("Customer Name: {0}", orderOne.CustomerName);
                WriteLine("Arrangement: {0}", orderOne.Arrangement);
                WriteLine("Quantity: {0}", orderOne.Quantity);
                WriteLine("UnitPrice: {0:C}", orderOne.UnitPrice);
                WriteLine("Total Price: {0:C}", orderOne.TotalPrice);
                totalPriceSum += orderOne.TotalPrice;
            }

                streamReader.Close();
            fileStream.Close();

            WriteLine("--------------------");
            WriteLine("Total Number of Orders: {0}", orders.Length);
            WriteLine("Grand Total Price: {0:C}", totalPriceSum);
        }
    }
}
