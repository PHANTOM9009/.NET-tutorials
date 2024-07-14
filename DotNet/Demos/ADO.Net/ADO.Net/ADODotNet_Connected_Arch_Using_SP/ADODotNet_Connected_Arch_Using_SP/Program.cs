namespace ADODotNet_Connected_Arch_Using_SP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Employee Management System -----");
            //
            char choice;
            try
            {
                EmployeeDA objEmployeeDA = new EmployeeDA();
                do
                {
                    Console.WriteLine("Enter 1 to Add, 2 to Edit, 3 to Delete, 4 to Search, 5 to List and 6 to Exit");
                    int operation;
                    operation = Convert.ToInt32(Console.ReadLine());
                    //
                    switch (operation)
                    {
                        case 1:
                            //Add Employee
                            objEmployeeDA.InsertEmployee();
                            break;
                        case 2:
                            //Update Employee
                            objEmployeeDA.UpdateEmployee();
                            break;
                        case 3:
                            //Delete Employee
                            objEmployeeDA.DeleteEmployee();
                            break;
                        case 4:
                            //Search Employee
                            objEmployeeDA.SearchEmployee();
                            break;
                        case 5:
                            //List Employees
                            objEmployeeDA.ListEmployees();
                            break;
                        case 6:
                            //Exit
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please enter correct option.");
                            break;
                    }
                    Console.WriteLine("Do you wish to continue? Press 'y' to continue or any other key to exit.");
                    choice = Convert.ToChar(Console.ReadLine());

                } while (choice == 'y');

            }
            catch (Exception objEx)
            {
                Console.WriteLine(objEx.Message);
            }
        }
    }
}
