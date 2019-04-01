using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersLib.TagHelpers.Client
{

    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class AutoPriceTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        public string Make { get; set; }

        [HtmlAttributeName("model-name")]
        public string Model { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent("salam: "+ Model);
        }
    }
}
