/*Purpose: demonstrate creating an object array from file data
 * Input: NamesAndGrades
 * Output: Array Data
 * Author: Jen
 * Date: Nov 7 2022
 * 
 * 
 * 
 * 
 * 
 * 
 */




using OOP_for_the_first_time;
using System.ComponentModel;
using System.Windows.Markup;

namespace ObjectArray
{
    internal class Program
    {   //class level vars
        static string headerColumn1,  /***name***///
               headerColumn2;      /***grade**///
        static void Main(string[] args)
        {  
            const int PhysicalSize = 25;
            StudentData[] students = new StudentData[PhysicalSize];
            const string PathAndFile = @"insert the path"; /**NamesAndGrades.csvFile Uploade**/
            int logicalSize,
                grade = 100;
            string name = "WonderWoman";

            if (File.Exists(PathAndFile))
            {
                try 
                {
                    //load it up
                    logicalSize = LoadArrayFromFile(students, PhysicalSize, PathAndFile);
                    DisplayArray(students, logicalSize);
                    //add a new object to the array
                    logicalSize = AddObjectToArray(students, logicalSize, name, grade);
                    Console.WriteLine();
                    DisplayArray(students, logicalSize);
                    WriteArrayToFile(students, logicalSize, PathAndFile);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
               
            }
            else
            { 
                Console.WriteLine($"The file, {PathAndFile}, doesn't exist");
            }


            Console.ReadLine(); 
        }//end of main

        static int LoadArrayFromFile(StudentData[] students, int size, string filename)
        {
            int grade,
                logicalSize = -1; /****this accounts for the header row*****/
            string name,
                input;
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(filename);
                while ((input = reader.ReadLine()) != null && logicalSize < size)
                {
                    string[] parts = input.Split(',');
                    if (logicalSize < 0)
                    {
                        headerColumn1 = parts[0];
                        headerColumn2 = parts[1];
                    }
                    else
                    { 
                        //store the data into an array element
                        name = parts[0];
                        grade = int.Parse(parts[1]);
                        students[logicalSize] = new StudentData(name,grade);
                    }
                    logicalSize++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERROR: {ex.Message}");
            }
            finally
            {
                reader.Close();
            }
            return logicalSize;
               
        
        }////end of LoadArray
        static void DisplayArray(StudentData[] students, int size)
        {
            //display the column headers
            Console.WriteLine($"{headerColumn1, -20}{headerColumn2, -5}");
            //loop
            for (int index = 0; index < size; index++)
            {
                Console.WriteLine($"{students[index].Name,-20}{students[index].Grade,3}");
            }
        }///end of DisplayArray

        static int AddObjectToArray(StudentData[] students, int size, string name, int grade)
        {
            students[size] = new StudentData(name, grade);
            return ++size;   

        }//end of AddObjectToArray

        static void WriteArrayToFile(StudentData[] students, int size, string filename)
        {
            string output;
            StreamWriter writer = null;
            try
            {
                writer = File.CreateText(filename);
                output = $"{headerColumn1}, {headerColumn2}";
                writer.WriteLine(output);
                ///loop thru the array

                for (int index = 0; index < size; index++)
                {
                    output = $"{students[index].Name}, {students[index].Grade}";
                    writer.WriteLine(output);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"ERROR: {ex.Message}");
            }
            finally
            {
                writer.Close();
            }
        }///end of WriteArrayToFile




    }
}