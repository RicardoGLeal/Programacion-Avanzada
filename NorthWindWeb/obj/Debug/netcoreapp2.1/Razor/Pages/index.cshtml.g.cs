#pragma checksum "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1111b7f97adb62f00edc4832690595e41e56584c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_index), @"mvc.1.0.razor-page", @"/Pages/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/index.cshtml", typeof(AspNetCore.Pages_index), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1111b7f97adb62f00edc4832690595e41e56584c", @"/Pages/index.cshtml")]
    public class Pages_index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(160, 321, true);
            WriteLiteral(@"        <div class=""jumbotron"">
        <h1 class=""display-3"">Welcome to Northwind!</h1>
        <p class=""lead"">We supply products to our customers.</p><hr /><p>Our customers include restaurants, hotels, and cruise lines.</p><p><a class=""btn btn-primary"" href=""https://www.asp.net/"">Learn more</a></p>
        <p>Its ");
            EndContext();
            BeginContext(482, 13, false);
#line 12 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\index.cshtml"
          Write(Model.DayName);

#line default
#line hidden
            EndContext();
            BeginContext(495, 20, true);
            WriteLiteral("</p>\r\n        </div>");
            EndContext();
        }
        #pragma warning restore 1998
#line 2 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\index.cshtml"
            
    public string DayName { get; set; }
    public void OnGet()
    {
        Model.DayName = DateTime.Now.ToString("dddd");
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_index> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_index> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_index>)PageContext?.ViewData;
        public Pages_index Model => ViewData.Model;
    }
}
#pragma warning restore 1591
