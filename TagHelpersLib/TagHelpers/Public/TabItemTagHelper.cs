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
    [RestrictChildren("tab-item")]
    public class TabItemTagHelper : TagHelper
    {
        public string Title { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string activePage = context.Items["ActivePage"] as string;

            if (activePage == Title)
            {
                output.Attributes.Add("class", "active");
            }

            output.TagName = "li";
            string str = string.Format("<a href='#'>{0}</a>", Title);
            output.PostContent.SetHtmlContent(str);
        }
    }
}
