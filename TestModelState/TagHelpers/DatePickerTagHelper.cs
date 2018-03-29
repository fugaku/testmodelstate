using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace TestModelState.TagHelpers
{
    public class DatePickerTagHelper : TagHelper
    {
        IHtmlGenerator generator;
        public DatePickerTagHelper(IHtmlGenerator generator)
        {
            this.generator = generator;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeName("value")]
        public string Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            var value = Value;
            var format = "yyyy-MM-dd";
            if (string.IsNullOrEmpty(value))
            {
                if (For != null && For.Model != null)
                {
                    var dt = DateTime.Parse(For.Model.ToString());
                    value = dt.ToString(format);
                }
            }
            var textbox = generator.GenerateTextBox(ViewContext, For.ModelExplorer, For.Name, value, format, null);
            textbox.Attributes["value"] = value;
            textbox.AddCssClass("form-control");
            output.Content.AppendHtml(textbox);
        }
    }
}
