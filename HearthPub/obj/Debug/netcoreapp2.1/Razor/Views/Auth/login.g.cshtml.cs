#pragma checksum "/Users/elegano/Desktop/HearthPub/HearthPub/HearthPub/Views/Auth/login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f080dab9cd587efac872d4a5e5452bd21c815409"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_login), @"mvc.1.0.view", @"/Views/Auth/login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Auth/login.cshtml", typeof(AspNetCore.Views_Auth_login))]
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
#line 1 "/Users/elegano/Desktop/HearthPub/HearthPub/HearthPub/Views/_ViewImports.cshtml"
using HearthPub;

#line default
#line hidden
#line 2 "/Users/elegano/Desktop/HearthPub/HearthPub/HearthPub/Views/_ViewImports.cshtml"
using HearthPub.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f080dab9cd587efac872d4a5e5452bd21c815409", @"/Views/Auth/login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d5c53f3d16464d203bc7dbe5714630191c994b6", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 21, true);
            WriteLiteral("<script>\r\n    alert(\'");
            EndContext();
            BeginContext(22, 15, false);
#line 2 "/Users/elegano/Desktop/HearthPub/HearthPub/HearthPub/Views/Auth/login.cshtml"
      Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(37, 51, true);
            WriteLiteral("\');\r\n    window.location.href=\"../Home\";\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
