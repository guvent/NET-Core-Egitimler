#pragma checksum "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5ac622f119a1bd9eecdbd5933529694ce603c33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\_ViewImports.cshtml"
using WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5ac622f119a1bd9eecdbd5933529694ce603c33", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2c7435ff51dfd14ed2ac7264e67f57d22f4a0a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Categories</h1>\r\n<hr />\r\n<div class=\"list-group\">\r\n");
#nullable restore
#line 9 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml"
     foreach (var category in Model.Categories)
    {
    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("href", " href=\"", 200, "\"", 248, 2);
            WriteAttributeValue("", 207, "/product/?categoryId=", 207, 21, true);
#nullable restore
#line 12 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml"
WriteAttributeValue("", 228, category.CategoryID, 228, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item\">");
#nullable restore
#line 12 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml"
                                                                               Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 13 "C:\Users\Bulutistan-Yazilim\source\repos\BaseLevel\WebUI\Views\Category\Index.cshtml"
    
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
