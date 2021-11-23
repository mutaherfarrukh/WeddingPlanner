#pragma checksum "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd9a706aaaa894586c7d5a82ee9a7e74eae3f1d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AllWeddings), @"mvc.1.0.view", @"/Views/Home/AllWeddings.cshtml")]
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
#line 1 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd9a706aaaa894586c7d5a82ee9a7e74eae3f1d4", @"/Views/Home/AllWeddings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AllWeddings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container"">
    <h1>Welcome to the Wedding Planner!</h1>
    <div class=""container d-flex justify-around"">
        <a href=""/NewWedding"" class=""btn btn-lg btn-info m-3"">Add A Wedding</a>
        <a href=""/Logout"" class=""btn btn-lg btn-danger m-3"">Logout</a>
    </div>
</div>
<hr noshade>

<div class=""container"">
    <table class=""table"">
        <thead>
            <tr>
                <th>Wedding</th>
                <th>Date</th>
                <th>Guest #</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 25 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
         foreach (Wedding wed in ViewBag.AllWeddings)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n            <!-- these have to line up with the names in the SQL database -->\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 918, "\"", 954, 2);
            WriteAttributeValue("", 925, "/SingleWedding/", 925, 15, true);
#nullable restore
#line 29 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
WriteAttributeValue("", 940, wed.WeddingID, 940, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 29 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                                                       Write(wed.Wedder1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 29 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                                                                      Write(wed.Wedder2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td> \r\n                <td>");
#nullable restore
#line 30 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
               Write(wed.WeddingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                <td>");
#nullable restore
#line 31 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
               Write(wed.Guests.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 34 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                 if (@wed.Planner.UserId == ViewBag.CurrentUser.UserId)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1305, "\"", 1334, 2);
            WriteAttributeValue("", 1312, "/delete/", 1312, 8, true);
#nullable restore
#line 36 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
WriteAttributeValue("", 1320, wed.WeddingID, 1320, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-lg btn-danger\">Delete</a></td> \r\n");
#nullable restore
#line 37 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                }
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                                                        
                else if (@wed.Planner.UserId != ViewBag.CurrentUser.UserId)
                {
                    var rsvp = false;
                    foreach (var user in wed.Guests)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                                                                                                                          
                        if (user.UserID== ViewBag.CurrentUser.UserId)
                        {
                            rsvp = true;
                        }
                    }
                    if (rsvp)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2067, "\"", 2096, 2);
            WriteAttributeValue("", 2074, "/unRSVP/", 2074, 8, true);
#nullable restore
#line 52 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
WriteAttributeValue("", 2082, wed.WeddingID, 2082, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">un-RSVP</a></td>\r\n");
#nullable restore
#line 53 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><a");
            BeginWriteAttribute("href", " href=\"", 2238, "\"", 2265, 2);
            WriteAttributeValue("", 2245, "/RSVP/", 2245, 6, true);
#nullable restore
#line 56 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
WriteAttributeValue("", 2251, wed.WeddingID, 2251, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">RSVP</a></td>\r\n");
#nullable restore
#line 57 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Alex J. Gendal\Documents\Coding Dojo Bootcamp\C#\ORMs\WeddingPlanner\Views\Home\AllWeddings.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591