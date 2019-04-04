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
    public class TabTagHelper : TagHelper
    {
        [HtmlAttributeName("Active-page")]
        public string ActivePage { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["ActivePage"] = ActivePage;
            output.TagName = "div";
            output.PreContent.SetHtmlContent("<h3>Silicon valley camp</h3><ul class='nav nav-tabs'>");
            output.PostContent.SetHtmlContent("</ul><br />");
        }
    }
}
