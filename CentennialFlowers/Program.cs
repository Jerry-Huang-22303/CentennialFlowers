using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using static System.Console;
using System.Web.Script.Serialization;

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
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            FileStream fileStream = new FileStream("order.json", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            Order orderOne = new Order();

            WriteLine("Enter the Details of the Order");

            Write(" - Order Number: ");
            orderOne.OrderNumber = int.Parse(ReadLine());

            Write(" - Customer Name: ");
            orderOne.CustomerName = ReadLine();

            Write(" - Arrangement: ");
            orderOne.Arrangement = ReadLine();

            Write(" - Quantity: ");
            orderOne.Quantity = int.Parse(ReadLine());

            Write(" - Unit Price: ");
            orderOne.UnitPrice = double.Parse(ReadLine());

            streamWriter.Write(serializer.Serialize(orderOne));

            streamWriter.Close();
            fileStream.Close();

            WriteLine("Order information has been saved to {0} !", Path.GetFileName(fileStream.Name));
        }

        static void Read()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            FileStream fileStream = new FileStream("order.json", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            Order orderOne = new Order();

            orderOne = serializer.Deserialize<Order>(streamReader.ReadToEnd());

            WriteLine("Order Information");
            WriteLine("--------------------");
            WriteLine("Order Number: {0}", orderOne.OrderNumber);
            WriteLine("Customer Name: {0}", orderOne.CustomerName);
            WriteLine("Arrangement: {0}", orderOne.Arrangement);
            WriteLine("Quantity: {0}", orderOne.Quantity);
            WriteLine("UnitPrice: {0:C}", orderOne.UnitPrice);
            WriteLine("Total Price: {0:C}", orderOne.TotalPrice);

            streamReader.Close();
            fileStream.Close();
        }
    }
}
