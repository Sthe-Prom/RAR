using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using rar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace rar.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        //Private Fields
        private IUrlHelperFactory urlHelperFactory;

        //Constructor
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }


        //Public Properties
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PaginationHeader PageModel { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();


        //Properties -> TAG ATTRIBUTES
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //Methods
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder results = new TagBuilder("div");

            for (int i = 1; i < PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                //URL values for routing (in>coming and out<going requests)
                PageUrlValues["Page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());
                results.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(results.InnerHtml);
        }
    }
}