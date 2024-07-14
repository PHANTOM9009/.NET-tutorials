using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADODotNet_Connected_Arch
{
    internal class EmployeeDA
    {
        internal EmployeeDA() 
        {

        }

        internal void InsertEmployee()
        {
            int id;
            string name;
            int designationId;
            int departmentId;
            //
            Console.WriteLine("Enter Employee records");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter DesignationId");
            designationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            departmentId = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "insert into Employee values(" 
                + id  + ", '" 
                + name + "'," 
                + designationId + ", " 
                + departmentId 
                + ")",objSqlCon);
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record added successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be added.");

            }
        }

        internal void UpdateEmployee()
        {
            int id;
            string name;
            int designationId;
            int departmentId;
            //
            Console.WriteLine("Enter Employee records to Edit");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            name = Console.ReadLine();
            Console.WriteLine("Enter DesignationId");
            designationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            departmentId = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "update Employee set name='" + name 
                + "', designationId=" + designationId 
                + ", departmentId=" + departmentId 
                + " where id=" + id
                , objSqlCon);
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record updated successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be updated.");
            }
        }

        internal void DeleteEmployee()
        {
            int id;
            //
            Console.WriteLine("Enter Employee Id to Delete a record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "delete Employee where id=" + id, objSqlCon);
            objSqlCon.Open();
            int noOfRowsAffected = objSqlCom.ExecuteNonQuery();
            objSqlCon.Close();
            if (noOfRowsAffected > 0)
            {
                Console.WriteLine("Record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record couldn't be deleted.");
            }
        }

        internal void SearchEmployee()
        {
            int id;
            //
            Console.WriteLine("Enter Employee Id to Search the record.");
            Console.WriteLine("Enter Id");
            id = Convert.ToInt32(Console.ReadLine());
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "select * from Employee where id=" + id, objSqlCon);
            objSqlCon.Open();
            SqlDataReader objSqlDataReader = objSqlCom.ExecuteReader();
            //
            if (objSqlDataReader.HasRows == true)
            {
                while (objSqlDataReader.Read())
                {
                    Console.WriteLine("Id: {0}, Name: {1}, DesignationId: {2}, DepartmentId: {3}"
                        , objSqlDataReader[0], objSqlDataReader[1]
                        , objSqlDataReader[2], objSqlDataReader[3]);
                }
            }
            else
            {
                Console.WriteLine("Record couldn't be found.");
            }
            objSqlCon.Close();
        }

        internal void ListEmployees()
        {
            Console.WriteLine("-----List of Employees-----");
            //
            SqlConnection objSqlCon = new SqlConnection(
                "server=.;database=GEP;integrated security=true");
            SqlCommand objSqlCom = new SqlCommand(
                "select * from Employee", objSqlCon);
            objSqlCon.Open();
            SqlDataReader objSqlDataReader = objSqlCom.ExecuteReader();
            DataTable objDT;
            //
            if (objSqlDataReader.HasRows == true)
            {
                objDT = new DataTable();
                objDT.Load(objSqlDataReader);
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, DesignationId: {2}, DepartmentId: {3}"
                        , objDT.Rows[i][0], objDT.Rows[i][1]
                        , objDT.Rows[i][2], objDT.Rows[i][3]);
                }
            }
            else
            {
                Console.WriteLine("Records not found.");
            }
            objSqlCon.Close();
        }

    }
}
