#pragma checksum "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Admins\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "341cf637b49fb4406719f6400e00bd7bbeb35039"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admins_Statistics), @"mvc.1.0.view", @"/Views/Admins/Statistics.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"341cf637b49fb4406719f6400e00bd7bbeb35039", @"/Views/Admins/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"051ada23fc91e6cf2a913b8d6d1ad5d57230128e", @"/Views/_ViewImports.cshtml")]
    public class Views_Admins_Statistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Admins\Statistics.cshtml"
  
    ViewData["Title"] = "Statistics screen";
    Layout = "~/Views/Shared/_LoggedInAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""playlist-section spad"">
    <div class=""container-fluid"">
        <div class=""section-title"">
            <h2> Statistics Page </h2>
        </div>
        <div class=""clearfix""></div>
        <div class=""row"">
            <div class=""col-lg-6"">
                <div class=""section-title"">
                    <h5>Let's see what's happening in BeatFeed</h5>
                </div>
            </div>
            <div class=""clearfix""></div>
            <div id=""AllPlaylists"" class=""row playlist-area"">
                <h3>
                    Artist in BeatFeed By Genre
                    <div id=""graph1""></div>
                </h3>
                <h3>
                    number of concerts for each city
                    <div id=""graph2""></div>
                </h3>
            </div>
        </div>
</section>



");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script src=""https://d3js.org/d3.v5.min.js""></script>

    <script>
        var width = 900, height = 700;
        var colors = d3.scaleOrdinal(d3.schemePastel1);
        var svg = d3.select(""#graph1"").append(""svg"")
            .attr(""width"", width).attr(""height"", height);
        var details = ");
#nullable restore
#line 44 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Admins\Statistics.cshtml"
                  Write(Html.Raw(@ViewBag.genres));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var data = d3.pie().sort(null).value(function (d) { return d.Count;})(details);
        var segments = d3.arc()
            .innerRadius(0)
            .outerRadius(200)
            .padAngle(.05)
            .padRadius(50);
        var sections = svg.append(""g"").attr(""transform"", ""translate(250,250)"")
            .selectAll(""path"").data(data);
        sections.enter().append(""path"").attr(""d"", segments)
            .attr(""fill"", function (d) { return colors(d.data.Count); });
        var content = d3.select(""g"").selectAll(""text"").data(data);
        var legends = svg.append(""g"").attr(""transform"", ""translate(500,100)"")
            .selectAll("".legends"").data(data);
        var legend = legends.enter().append(""g"")
            .classed(""legends"", true)
            .attr(""transform"", function (d, i) { return ""translate(0,"" + (i + 1) * 30 + "")""; });
        legend.append(""rect"")
            .attr(""width"", 20)
            .attr(""height"", 20)
            .attr(""fill"", function (d) { ret");
                WriteLiteral(@"urn colors(d.data.Count); });
        legend.append(""text"")
            .text(function (d) { return d.data.Count + "" from "" + d.data.Genre; })
            .classed(""text"", true)
            .attr(""x"", 30)
            .attr(""y"", 14);
    </script>

    <script>
        var width = 900, height = 700;
        var colors = d3.scaleOrdinal(d3.schemePastel1);
        var svg = d3.select(""#graph2"").append(""svg"")
            .attr(""width"", width).attr(""height"", height);
        var details = ");
#nullable restore
#line 77 "C:\Users\רותם\Source\Repos\1\BeatFeed\BeatFeed\Views\Admins\Statistics.cshtml"
                  Write(Html.Raw(@ViewBag.places));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        var data = d3.pie().sort(null).value(function (d) { return d.Count;})(details);
        var segments = d3.arc()
            .innerRadius(0)
            .outerRadius(200)
            .padAngle(.05)
            .padRadius(50);
        var sections = svg.append(""g"").attr(""transform"", ""translate(250,250)"")
            .selectAll(""path"").data(data);
        sections.enter().append(""path"").attr(""d"", segments)
            .attr(""fill"", function (d) { return colors(d.data.Count); });
        var content = d3.select(""g"").selectAll(""text"").data(data);
        var legends = svg.append(""g"").attr(""transform"", ""translate(500,100)"")
            .selectAll("".legends"").data(data);
        var legend = legends.enter().append(""g"")
            .classed(""legends"", true)
            .attr(""transform"", function (d, i) { return ""translate(0,"" + (i + 1) * 30 + "")""; });
        legend.append(""rect"")
            .attr(""width"", 20)
            .attr(""height"", 20)
            .attr(""fill"", function (d) { ret");
                WriteLiteral("urn colors(d.data.Count); });\r\n        legend.append(\"text\")\r\n            .text(function (d) { return d.data.Count + \" from \" + d.data.City; })\r\n            .classed(\"text\", true)\r\n            .attr(\"x\", 30)\r\n            .attr(\"y\", 14);\r\n    </script>\r\n\r\n");
            }
            );
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
