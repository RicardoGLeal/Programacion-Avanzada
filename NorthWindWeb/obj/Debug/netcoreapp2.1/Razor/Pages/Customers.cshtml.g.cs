#pragma checksum "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c56be51168200862894a553ae6cac683f11d4a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Customers), @"mvc.1.0.razor-page", @"/Pages/Customers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Customers.cshtml", typeof(AspNetCore.Pages_Customers), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c56be51168200862894a553ae6cac683f11d4a7", @"/Pages/Customers.cshtml")]
    public class Pages_Customers : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./customerinfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
   string country = "f";

#line default
#line hidden
            BeginContext(130, 57, true);
            WriteLiteral("<h1 class=\"display-2\">Customers</h1>\r\n<tbody>\r\n    <ul>\r\n");
            EndContext();
#line 8 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
         foreach (var item in Model.Customers)
        {
            if (country != item.Country)
            {

#line default
#line hidden
            BeginContext(303, 24, true);
            WriteLiteral("                <br />\r\n");
            EndContext();
#line 13 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
                country = item.Country;

#line default
#line hidden
            BeginContext(368, 22, true);
            WriteLiteral("                <b><h>");
            EndContext();
            BeginContext(391, 7, false);
#line 14 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
                 Write(country);

#line default
#line hidden
            EndContext();
            BeginContext(398, 10, true);
            WriteLiteral("</h></b>\r\n");
            EndContext();
#line 15 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
            }

#line default
#line hidden
            BeginContext(423, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(435, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "480d9820aa08445b9718560789d80ab1", async() => {
                BeginContext(496, 4, true);
                WriteLiteral("<li>");
                EndContext();
                BeginContext(501, 46, false);
#line 16 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.ContactName));

#line default
#line hidden
                EndContext();
                BeginContext(547, 5, true);
                WriteLiteral("</li>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 16 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
                                           WriteLiteral(item.CustomerID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(556, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\Customers.cshtml"
        }

#line default
#line hidden
            BeginContext(569, 23, true);
            WriteLiteral("    </ul>\r\n</tbody>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthWindWeb.Pages.CustomersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NorthWindWeb.Pages.CustomersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NorthWindWeb.Pages.CustomersModel>)PageContext?.ViewData;
        public NorthWindWeb.Pages.CustomersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
