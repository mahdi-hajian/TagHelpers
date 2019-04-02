using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpersLib.model;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace WebAppTagHelper.Pages.Home
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public person Person { get; set; }

        readonly string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Dapper_test";

        public void OnGet()
        {
            using (IDbConnection db = new SqlConnection(Connection))
            {
                //var Persons = db.Query<person>("select * from Person").ToList();

                //person = db.Query<person>("select * from Person where Id=@Id", new {Id = 1 }).SingleOrDefault();

                //string query = "update Person set Name=@Name,Family=@Family";
                //db.Execute(query, person);

                //string query = "delete from Person where Id=@Id";
                //db.Execute(query, new { Id = 1 });
            }
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                using (IDbConnection db = new SqlConnection(Connection))
                {
                    string query = "insert into Person (Name,Family) values (@Name,@Family)";
                    await db.ExecuteAsync(query, Person);
                }
            }
        }
    }
}
