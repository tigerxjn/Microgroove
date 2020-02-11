using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroGroove.Models;
using Newtonsoft.Json;

namespace MicroGroove
{
    public class CreateOrder
    {
        // Store the fileRecord
        static FileRecord fileRecord = new FileRecord();

        // Store the orderRecords reprented by "O", could be more than 1 so use list
        static List<OrderRecord> orderRecords = new List<OrderRecord>();

        // Store the detailed information of 1 orderRecord
        static OrderRecord orderRecord = new OrderRecord();

        // Store the items into a list
        static List<Items> items = new List<Items>();

        // Stores the ender information of each fileRecord
        static Ender ender = new Ender();
        public static FileRecord CreateOrderController(string inputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                // Or log the error
                Console.WriteLine("File does not exsit");
                return new FileRecord();
            }


            int orderCount = 0;

            try
            {


                // read all lines in the source path
                List<string> lines = File.ReadAllLines(inputFilePath).ToList();

                foreach (var line in lines)
                {
                    switch (GetType(line))
                    {
                        case "F":
                            var fileArr = line.Split(',');
                            fileRecord.date = fileArr[1].Substring(1, fileArr[1].Length - 2);
                            fileRecord.type = fileArr[2].Substring(1, fileArr[2].Length - 2);
                            break;

                        case "O":
                            /* The tricky part here is there could be multiple "O" which means there will be multiple 
                             * orders. My logic here is: if there are only 1 "O", the orderResults will only add 1 orderResult
                             * at the end of the for-loop; if there are more than 1 "O", whenever meet the second "O" or any "O" 
                             * that is after the first "O", i will add the exsiting OrderResult to the list and reset the 
                             * orderResult for further use.
                            */
                            orderCount++;
                            if (orderCount > 1)
                            {
                                orderRecords.Add(new OrderRecord(orderRecord));
                                orderRecord = new OrderRecord();
                                items.Clear();
                            }

                            var orderArr = line.Split(',');
                            orderRecord.date = orderArr[1].Substring(1, orderArr[1].Length - 2);
                            orderRecord.code = orderArr[2].Substring(1, orderArr[2].Length - 2);
                            orderRecord.number = orderArr[3].Substring(1, orderArr[3].Length - 2);
                            break;

                        case "B":
                            Buyer buyer = new Buyer();
                            var buyArr = line.Split(',');
                            buyer.name = buyArr[1].Substring(1, buyArr[1].Length - 2);
                            buyer.street = buyArr[2].Substring(1, buyArr[2].Length - 2);
                            buyer.zip = buyArr[3].Substring(1, buyArr[3].Length - 2);
                            orderRecord.buyer = buyer;
                            break;

                        case "L":
                            Items item = new Items();
                            var itemArr = line.Split(',');
                            item.sku = itemArr[1].Substring(1, itemArr[1].Length - 2);
                            item.qty = int.Parse(itemArr[2].Substring(1, itemArr[2].Length - 2));
                            items.Add(item);
                            orderRecord.Items = items;
                            break;

                        case "T":
                            Timings timings = new Timings();
                            var timingsArr = line.Split(',');
                            timings.start = int.Parse(timingsArr[1].Substring(1, timingsArr[1].Length - 2));
                            timings.start = int.Parse(timingsArr[2].Substring(1, timingsArr[2].Length - 2));
                            timings.gap = int.Parse(timingsArr[3].Substring(1, timingsArr[3].Length - 2));
                            timings.offset = int.Parse(timingsArr[4].Substring(1, timingsArr[4].Length - 2));
                            timings.pause = int.Parse(timingsArr[5].Substring(1, timingsArr[5].Length - 2));
                            orderRecord.timings = timings;
                            break;

                        case "E":
                            var enderArr = line.Split(',');
                            ender.process = int.Parse(enderArr[1].Substring(1, enderArr[1].Length - 2));
                            ender.paid = int.Parse(enderArr[2].Substring(1, enderArr[2].Length - 2));
                            ender.created = int.Parse(enderArr[2].Substring(1, enderArr[2].Length - 2));
                            break;
                        default:
                            Console.WriteLine("Invalid Input file");
                            break;
                    }
                }

                orderRecords.Add(orderRecord);
                fileRecord.orders = orderRecords;
                fileRecord.Ender = ender;
            }
            catch (Exception e)
            {
                // Should implement some real log mechanism
                Console.WriteLine(e.ToString());
            }

            return fileRecord;
        }

        static void Main()
        {
            // to verify, please prepare a input file locally and rewrite the inputPath and outputPath
            // result can be verified in nodepad through format json

            string inputPath = @"C:\stringText\test.txt";

            string result = JsonConvert.SerializeObject(CreateOrderController(inputPath));

            string outputPath = @"C:\stringText\output_test.txt";
            if (!File.Exists(outputPath))
            {
                var f = File.Create(outputPath);
                f.Close();
            }

            File.WriteAllText(outputPath, result);

        }
        private static string GetType(string line)
        {
            return line.Substring(1, 1);
        }
    }
}
