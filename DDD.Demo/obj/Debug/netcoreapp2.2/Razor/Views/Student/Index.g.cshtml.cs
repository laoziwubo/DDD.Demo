#pragma checksum "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17da94c5f8bdc3069193e7d3bf414ae70bb16c92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Index.cshtml", typeof(AspNetCore.Views_Student_Index))]
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
#line 1 "E:\Core\DDD.Demo\DDD.Demo\Views\_ViewImports.cshtml"
using DDD.Demo;

#line default
#line hidden
#line 2 "E:\Core\DDD.Demo\DDD.Demo\Views\_ViewImports.cshtml"
using DDD.Application.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17da94c5f8bdc3069193e7d3bf414ae70bb16c92", @"/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dce26c7a2dca4dbcc3a5fd0052f8a957dcdb9777", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StudentViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml"
 if (Model.Any())
{
    foreach (var m in Model)
    {

#line default
#line hidden
            BeginContext(140, 13, true);
            WriteLiteral("        <div>");
            EndContext();
            BeginContext(154, 6, false);
#line 10 "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml"
        Write(m.Name);

#line default
#line hidden
            EndContext();
            BeginContext(160, 21, true);
            WriteLiteral("</div>\r\n        <div>");
            EndContext();
            BeginContext(182, 11, false);
#line 11 "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml"
        Write(m.BirthDate);

#line default
#line hidden
            EndContext();
            BeginContext(193, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 12 "E:\Core\DDD.Demo\DDD.Demo\Views\Student\Index.cshtml"
    }
}

#line default
#line hidden
            BeginContext(211, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StudentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591