using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace TestModelState.TagHelpers
{
    public class DatePickerTagHelper : TagHelper
    {
        public DatePickerTagHelper(IHtmlGenerator htmlGenerator)
            //: base(htmlGenerator)
        {
            Generator = htmlGenerator;
        }

        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public IHtmlGenerator Generator { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.SuppressOutput();
            var format = "{0:dd/MM/yyyy}";
            var textbox = Generator.GenerateTextBox(ViewContext, For.ModelExplorer, For.Name, For.ModelExplorer.Model, format, null);
            textbox.AddCssClass("form-control");
            output.Content.AppendHtml(textbox);

            //base.For = this.For;
            //base.Process(context, output);

            //output.TagName = "input";
            //output.TagMode = TagMode.StartTagOnly;

            //TagBuilder input = new TagBuilder("input");
            //input.AddCssClass("form-control");
            //output.MergeAttributes(input);
        }
    }
}
