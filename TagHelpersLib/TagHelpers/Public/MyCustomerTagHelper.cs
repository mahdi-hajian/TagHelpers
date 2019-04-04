using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpersLib.model;
using Dapper;
using System.Data.SqlClient;

namespace TagHelpersLib.TagHelpers.Public
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("my-customer")]
    public class MyCustomerTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // add a attribute
            TagHelperAttribute tagHelper = new TagHelperAttribute("class", "highlight");
            output.Attributes.Add(tagHelper);

            // find a attribute
            var AttributesId = output.Attributes.Where(c => c.Name == "id" && c.Value.ToString() == "CustomerId").FirstOrDefault();

            // remove a attribute
            if (AttributesId != null)
                output.Attributes.Remove(AttributesId);

            // change tag name from my-customer to div
            //output.TagName = "div";

            output.TagMode = TagMode.StartTagAndEndTag;

            // خود تگ my-customer حذف میشود ولی داخلش هست
            //output.SuppressOutput();

            // clear all attribute
            output.Attributes.Clear();

            var data = await GetPersonsAsync();

            string content = "";
            foreach (var item in data)
            {
                content += $@"<div><label>name:</label>
<label>{item.Name}</label>
<br />
<label>family:</label>
<label>{item.Family}</label>
</div>
<hr />";
            }

            output.Content.SetHtmlContent(content);
        }


        public async Task<List<person>> GetPersonsAsync()
        {
            var Persons = new List<person>();
            //using (System.Data.IDbConnection db = new SqlConnection(@"Data Source=MAHDI-PC;User ID=sa;Password=21m./;Initial Catalog=Dapper_test"))
            using (System.Data.IDbConnection db = new SqlConnection(@"Data Source=192.168.1.4,1433;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=Dapper_test"))
            {
                var data = await db.QueryAsync<person>("select * from Person");
                Persons = data.ToList();
            }

            return Persons;
        }
    }
}
