#pragma checksum "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17463b9dc4d4395574dc22fb9cd7c9b8cf5bb25d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_CustomerInfo), @"mvc.1.0.razor-page", @"/Pages/CustomerInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/CustomerInfo.cshtml", typeof(AspNetCore.Pages_CustomerInfo), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17463b9dc4d4395574dc22fb9cd7c9b8cf5bb25d", @"/Pages/CustomerInfo.cshtml")]
    public class Pages_CustomerInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(106, 181, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <h1 class=\"display-2\">Informacion del Usuario</h1>\r\n    <table class=\"table\">\r\n        <thead class=\"thead-inverse\">\r\n            <tr>\r\n                <th>");
            EndContext();
            BeginContext(288, 55, false);
#line 10 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.CustomerID));

#line default
#line hidden
            EndContext();
            BeginContext(343, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(371, 56, false);
#line 11 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(427, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(455, 56, false);
#line 12 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.ContactName));

#line default
#line hidden
            EndContext();
            BeginContext(511, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(539, 57, false);
#line 13 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.ContactTitle));

#line default
#line hidden
            EndContext();
            BeginContext(596, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(624, 52, false);
#line 14 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.Country));

#line default
#line hidden
            EndContext();
            BeginContext(676, 27, true);
            WriteLiteral("</th>\r\n                <th>");
            EndContext();
            BeginContext(704, 49, false);
#line 15 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayNameFor(model => model.Customer.City));

#line default
#line hidden
            EndContext();
            BeginContext(753, 121, true);
            WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(875, 59, false);
#line 21 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.CustomerID));

#line default
#line hidden
            EndContext();
            BeginContext(934, 68, true);
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1003, 60, false);
#line 24 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.CompanyName));

#line default
#line hidden
            EndContext();
            BeginContext(1063, 68, true);
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1132, 60, false);
#line 27 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.ContactName));

#line default
#line hidden
            EndContext();
            BeginContext(1192, 68, true);
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1261, 61, false);
#line 30 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.ContactTitle));

#line default
#line hidden
            EndContext();
            BeginContext(1322, 68, true);
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1391, 56, false);
#line 33 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1447, 68, true);
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1516, 53, false);
#line 36 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
               Write(Html.DisplayFor(modelItem => modelItem.Customer.City));

#line default
#line hidden
            EndContext();
            BeginContext(1569, 136, true);
            WriteLiteral(";\r\n                </td>\r\n            </tr>\r\n\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<br />\r\n<h2>Lista de Ordenes del Usuario: </h2>\r\n");
            EndContext();
#line 45 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
 foreach (var item in Model.Orders)
{


#line default
#line hidden
            BeginContext(1747, 24, true);
            WriteLiteral("    <p><b>OrderID: </b> ");
            EndContext();
            BeginContext(1772, 42, false);
#line 48 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                   Write(Html.DisplayFor(modelItem => item.OrderID));

#line default
#line hidden
            EndContext();
            BeginContext(1814, 33, true);
            WriteLiteral("</p>\r\n    <p><b>CustomerID: </b> ");
            EndContext();
            BeginContext(1848, 45, false);
#line 49 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                      Write(Html.DisplayFor(modelItem => item.CustomerID));

#line default
#line hidden
            EndContext();
            BeginContext(1893, 33, true);
            WriteLiteral("</p>\r\n    <p><b>EmployeeID: </b> ");
            EndContext();
            BeginContext(1927, 45, false);
#line 50 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                      Write(Html.DisplayFor(modelItem => item.EmployeeID));

#line default
#line hidden
            EndContext();
            BeginContext(1972, 31, true);
            WriteLiteral("</p>\r\n    <p><b>OrderDate: </b>");
            EndContext();
            BeginContext(2004, 44, false);
#line 51 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                    Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(2048, 34, true);
            WriteLiteral("</p>\r\n    <p><b>RequiredDate: </b>");
            EndContext();
            BeginContext(2083, 47, false);
#line 52 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                       Write(Html.DisplayFor(modelItem => item.RequiredDate));

#line default
#line hidden
            EndContext();
            BeginContext(2130, 33, true);
            WriteLiteral("</p>\r\n    <p><b>ShippedDate: </b>");
            EndContext();
            BeginContext(2164, 46, false);
#line 53 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                      Write(Html.DisplayFor(modelItem => item.ShippedDate));

#line default
#line hidden
            EndContext();
            BeginContext(2210, 29, true);
            WriteLiteral("</p>\r\n    <p><b>ShipVia: </b>");
            EndContext();
            BeginContext(2240, 42, false);
#line 54 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                  Write(Html.DisplayFor(modelItem => item.ShipVia));

#line default
#line hidden
            EndContext();
            BeginContext(2282, 29, true);
            WriteLiteral("</p>\r\n    <p><b>Freight: </b>");
            EndContext();
            BeginContext(2312, 42, false);
#line 55 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                  Write(Html.DisplayFor(modelItem => item.Freight));

#line default
#line hidden
            EndContext();
            BeginContext(2354, 30, true);
            WriteLiteral("</p>\r\n    <p><b>ShipName: </b>");
            EndContext();
            BeginContext(2385, 43, false);
#line 56 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ShipName));

#line default
#line hidden
            EndContext();
            BeginContext(2428, 33, true);
            WriteLiteral("</p>\r\n    <p><b>ShipAddress: </b>");
            EndContext();
            BeginContext(2462, 46, false);
#line 57 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                      Write(Html.DisplayFor(modelItem => item.ShipAddress));

#line default
#line hidden
            EndContext();
            BeginContext(2508, 30, true);
            WriteLiteral("</p>\r\n    <p><b>ShipCity: </b>");
            EndContext();
            BeginContext(2539, 43, false);
#line 58 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ShipCity));

#line default
#line hidden
            EndContext();
            BeginContext(2582, 32, true);
            WriteLiteral("</p>\r\n    <p><b>ShipRegion: </b>");
            EndContext();
            BeginContext(2615, 45, false);
#line 59 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                     Write(Html.DisplayFor(modelItem => item.ShipRegion));

#line default
#line hidden
            EndContext();
            BeginContext(2660, 36, true);
            WriteLiteral("</p>\r\n    <p><b>ShipPostalCode: </b>");
            EndContext();
            BeginContext(2697, 49, false);
#line 60 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                         Write(Html.DisplayFor(modelItem => item.ShipPostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(2746, 33, true);
            WriteLiteral("</p>\r\n    <p><b>ShipCountry: </b>");
            EndContext();
            BeginContext(2780, 46, false);
#line 61 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
                      Write(Html.DisplayFor(modelItem => item.ShipCountry));

#line default
#line hidden
            EndContext();
            BeginContext(2826, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(2834, 12, true);
            WriteLiteral("    <br />\r\n");
            EndContext();
#line 64 "C:\Users\ricar\Documents\GIT\Programacion-Avanzada\NorthWindWeb\Pages\CustomerInfo.cshtml"
}

#line default
#line hidden
            BeginContext(2849, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NorthWindWeb.Pages.CustomerInfoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NorthWindWeb.Pages.CustomerInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<NorthWindWeb.Pages.CustomerInfoModel>)PageContext?.ViewData;
        public NorthWindWeb.Pages.CustomerInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591