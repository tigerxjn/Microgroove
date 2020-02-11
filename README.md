# Microgroove

This is a simple consoleapp project, after cloning the project, run the CreateOrder.cs should be fine after preparing the inputfile and output path should be fine.

The solution basically contains 2 part:
     1.Models
     2.CreateOrder.cs

The models contains various models to represent for various objects as shown below based on the statesment:

                           csv File
                        /             \
                       /               \
            FileRecord                Ender
          /      \      \
         /        \      \
    List<orders>  Dates  Type
     /   \      \
    /     \      \
  Buyer   Timing  List<Items>
  


However, in the example output, it seems that the Ender is at the same level with List<OrdersRecords> and Dates and types. Thus i am using the ouput example as my standard.
  
The CreateOrder.cs contains a method callled CreateOrderController(string path) that reads all lines from a csv file, which i assume, is VALID and contains all the valid data, i implemented a simple try catch block to avoid any invalid input format data. 

The fuction reads all the lines in csv files and do the json deserilization accordingly and after all, serialize the result and store it as 1 line string to the output.txt files. The input and output path need to be re written.
         
   
