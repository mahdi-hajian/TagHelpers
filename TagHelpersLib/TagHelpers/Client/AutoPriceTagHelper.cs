using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersLib.TagHelpers.Client
{

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class AutoPriceTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        public string Make { get; set; }

        [HtmlAttributeName("is-https")]
        public string Model { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //output.Content.SetHtmlContent("hello i am auto-price tag and model is: "+ Model);
            output.Content.SetContent("Is https: "+ ViewContext.HttpContext.Request.IsHttps);
            output.Content.SetContent("Is https: "+ ViewContext.HttpContext.Request.IsHttps + " and path is: "+ ViewContext.ExecutingFilePath);
        }
    }
}
