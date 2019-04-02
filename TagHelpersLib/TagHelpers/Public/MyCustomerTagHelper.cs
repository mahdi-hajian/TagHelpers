using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpersLib.model;

namespace TagHelpersLib.TagHelpers.Public
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("my-customer")]
    public class MyCustomerTagHelper : TagHelper
    {
        public person person { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string path = @"E:\MyProject\WebAppTagHelper\WebAppTagHelper\wwwroot\Template\HTMLPage1.html";
            StreamReader streamReader = new StreamReader(path);
            string content = await streamReader.ReadToEndAsync();
            content = content.Replace("[name]", person.Name).Replace("[family]",person.Family);
            output.Content.SetHtmlContent(content);
        }
    }
}
