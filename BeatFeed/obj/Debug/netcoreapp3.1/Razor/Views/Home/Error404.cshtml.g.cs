#pragma checksum "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Home\Error404.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e82aa9c428dab17e7129ad1f2bbc4056af01213"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error404), @"mvc.1.0.view", @"/Views/Home/Error404.cshtml")]
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
#line 1 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\_ViewImports.cshtml"
using BeatFeed;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\_ViewImports.cshtml"
using BeatFeed.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e82aa9c428dab17e7129ad1f2bbc4056af01213", @"/Views/Home/Error404.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"051ada23fc91e6cf2a913b8d6d1ad5d57230128e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Error404 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Home\Error404.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_LandingLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""intro-section spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6"">
                <div class=""section-title"">
                    <h1>Oops...</h1>
                </div>
            </div>
            <div class=""col-lg-6"">
                <p>
                    Looks like the page your were searching for does not exist :\
                </p>
            </div>
        </div>
    </div>
</section>
");
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
