using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using DTCMCC_WebApp_Sam.Models;
using System;
using DTCMCC_WebApp_Sam.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DTCMCC_WebApp_Sam.Controllers
{
    public class EmployeeController : Controller
    {
        MyContext myContext;
        public EmployeeController( MyContext myContext)
        {
            this.myContext = myContext;
        }

        //Read
        public IActionResult Index()
        {
            var data = myContext.Employees.Include(x => x.Department).Include(y => y.Jobs).ToList();
            return View(data);
        }

        //Read By ID
        //GET
        public IActionResult Details(int Id, string FirstName)
        {
            //string query = "select * from employees where EmployeeId = @EmployeeId";

            //SqlParameter sqlParameter = new SqlParameter();
            //sqlParameter.ParameterName = "@EmployeeId";
            //sqlParameter.Value = Id;

            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //sqlCommand.Parameters.Add(sqlParameter);

            //try
            //{
            //    sqlConnection.Open();
            //    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            //    {
            //        if (sqlDataReader.HasRows)
            //        {
            //            while (sqlDataReader.Read())
            //            {
            //                ViewData["EmployeeId"] = sqlDataReader[0];
            //                ViewData["FirstName"] = sqlDataReader[1];
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No Data Rows");
            //        }
            //        sqlDataReader.Close();
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}

            return View();
        }


        //GET CREATE
        public IActionResult Create()
        {
           
            //string data_length = "SELECT COUNT(EmployeeId) FROM Employees";
            //int count = 0;

            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        using (SqlCommand dataCount = new SqlCommand(data_length, sqlConnection))
            //        {
            //            sqlConnection.Open();
            //            count = (int)dataCount.ExecuteScalar();
            //        }

            //        ViewData["EmployeeId"] = count + 1;

            //        sqlConnection.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.InnerException);
            //    }
            //}
            return View();
        } 
       

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Add(employee);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //UPDATE GET
        public IActionResult Edit(int Id, string FirstName)
        {
            //string query = "select * from employees where EmployeeId = @EmployeeId";

            //SqlParameter sqlParameterId = new SqlParameter();
            //sqlParameterId.ParameterName = "@EmployeeId";
            //sqlParameterId.Value = Id;

            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //sqlCommand.Parameters.Add(sqlParameterId);

            //try
            //{
            //    sqlConnection.Open();
            //    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            //    {
            //        if (sqlDataReader.HasRows)
            //        {
            //            while (sqlDataReader.Read())
            //            {
            //                ViewData["EmployeeId"] = sqlDataReader[0];
            //                ViewData["FirstName"] = sqlDataReader[1];
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No Data Rows");
            //        }
            //        sqlDataReader.Close();
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}
            return View();
        }

        //UPDATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            //    SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //    sqlCommand.Transaction = sqlTransaction;

            //    try
            //    {
            //        sqlCommand.CommandText = "update Employees " +
            //            "set FirstName = @FirstName where EmployeeId = @EmployeeId";

            //        SqlParameter sqlParameterId = new SqlParameter();
            //        sqlParameterId.ParameterName = "@EmployeeId";
            //        sqlParameterId.Value = employee.EmployeeId;

            //        SqlParameter sqlParameter = new SqlParameter();
            //        sqlParameter.ParameterName = "@FirstName";
            //        sqlParameter.Value = employee.FirstName;

            //        sqlCommand.Parameters.Add(sqlParameterId);
            //        sqlCommand.Parameters.Add(sqlParameter);

            //        sqlCommand.ExecuteNonQuery();
            //        sqlTransaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.InnerException);
            //    }
            //}
            return RedirectToAction(nameof(Index));
        }

        //Delete
        public IActionResult Delete(int? Id, bool? saveChangesError = false)
        {
            //string query = "select * from employees where EmployeeId = @EmployeeId";

            //SqlParameter sqlParameter = new SqlParameter();
            //sqlParameter.ParameterName = "@EmployeeId";
            //sqlParameter.Value = Id;

            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //sqlCommand.Parameters.Add(sqlParameter);

            //try
            //{
            //    sqlConnection.Open();
            //    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            //    {
            //        if (sqlDataReader.HasRows)
            //        {
            //            while (sqlDataReader.Read())
            //            {
            //                ViewData["EmployeeId"] = sqlDataReader[0];
            //                ViewData["FirstName"] = sqlDataReader[1];
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("No Data Rows");
            //        }
            //        sqlDataReader.Close();
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            //string query = "delete from employees where EmployeeId = @EmployeeId";

            //SqlParameter sqlParameter = new SqlParameter();
            //sqlParameter.ParameterName = "@EmployeeId";
            //sqlParameter.Value = Id;

            //sqlConnection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //sqlCommand.Parameters.Add(sqlParameter);
            //try
            //{
            //    sqlConnection.Open();
            //    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}
            return RedirectToAction(nameof(Index));
        }

    }
}
