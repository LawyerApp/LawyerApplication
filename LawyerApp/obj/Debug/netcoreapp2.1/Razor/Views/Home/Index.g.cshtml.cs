#pragma checksum "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "301bfe986b10f8bd20a353e8911eead7e01e66eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\_ViewImports.cshtml"
using LawyerApp.Models;

#line default
#line hidden
#line 2 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\_ViewImports.cshtml"
using LawyerApp;

#line default
#line hidden
#line 3 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"301bfe986b10f8bd20a353e8911eead7e01e66eb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e2e05354d6fe86a2f3c0288f0a5237cf7ad05ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "team", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "practice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "services", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "service", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 151, true);
            WriteLiteral("\r\n<main class=\"index-main\">\r\n    <div id=\"carouselExampleControls\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        <div class=\"carousel-inner\">\r\n");
            EndContext();
#line 7 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               
                bool check = true;
            

#line default
#line hidden
            BeginContext(294, 11, true);
            WriteLiteral("           ");
            EndContext();
#line 10 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
            foreach (Slider item in Model.Sliders)
           {
               if (check)
               {

#line default
#line hidden
            BeginContext(405, 72, true);
            WriteLiteral("                <div class=\"carousel-item active\">\r\n                    ");
            EndContext();
            BeginContext(477, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8c2713b193914e21b145167752f735d2", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 509, "~/Uploads/", 509, 10, true);
#line 15 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 519, item.Img, 519, 9, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(542, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 17 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                   check = false;
               }
               else
               {

#line default
#line hidden
            BeginContext(660, 65, true);
            WriteLiteral("                <div class=\"carousel-item\">\r\n                    ");
            EndContext();
            BeginContext(725, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "178a075f87b6438ab6055bf05b2dd711", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 757, "~/Uploads/", 757, 10, true);
#line 22 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 767, item.Img, 767, 9, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(790, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 24 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               }
           }

#line default
#line hidden
            BeginContext(848, 634, true);
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleControls"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>
    <div class=""main-section"">
        <section class="" main-team"">
            <hr>
            <h2>");
            EndContext();
            BeginContext(1483, 20, false);
#line 39 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
           Write(resource["Our_Team"]);

#line default
#line hidden
            EndContext();
            BeginContext(1503, 40, true);
            WriteLiteral("</h2>\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1544, 33, false);
#line 41 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
           Write(Model.TeamService.TeamDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1577, 32, true);
            WriteLiteral("\r\n            </p>\r\n            ");
            EndContext();
            BeginContext(1609, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c7757cd55654abb919bfd0cbbe3e80a", async() => {
                BeginContext(1655, 16, false);
#line 43 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                                                    Write(resource["More"]);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1675, 94, true);
            WriteLiteral("\r\n        </section>\r\n        <section class=\" main-team\">\r\n            <hr>\r\n            <h2>");
            EndContext();
            BeginContext(1770, 20, false);
#line 47 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
           Write(resource["Services"]);

#line default
#line hidden
            EndContext();
            BeginContext(1790, 40, true);
            WriteLiteral("</h2>\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(1831, 37, false);
#line 49 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
           Write(Model.TeamService.ServicesDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1868, 32, true);
            WriteLiteral("\r\n            </p>\r\n            ");
            EndContext();
            BeginContext(1900, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1350cc82fc2479ba24bf960e4b44cd5", async() => {
                BeginContext(1950, 16, false);
#line 51 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                                                        Write(resource["More"]);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1970, 141, true);
            WriteLiteral("\r\n        </section>\r\n        <section class=\" specific\">\r\n            <div class=\"main-contact\">\r\n                <h4>\r\n                    ");
            EndContext();
            BeginContext(2112, 22, false);
#line 56 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               Write(resource["Contact_Us"]);

#line default
#line hidden
            EndContext();
            BeginContext(2134, 44, true);
            WriteLiteral("\r\n                </h4>\r\n                <p>");
            EndContext();
            BeginContext(2179, 35, false);
#line 58 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
              Write(resource["For_A_Free_Consultation"]);

#line default
#line hidden
            EndContext();
            BeginContext(2214, 22, true);
            WriteLiteral("</p>\r\n                ");
            EndContext();
            BeginContext(2236, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a00a557d01e48188c67b39b9fcb1688", async() => {
                BeginContext(2286, 33, false);
#line 59 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                                                            Write(resource["Schedule_Consultation"]);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2323, 22, true);
            WriteLiteral("\r\n                <h4>");
            EndContext();
            BeginContext(2346, 27, false);
#line 60 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               Write(Model.Contact.ContactNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2373, 51, true);
            WriteLiteral("</h4>\r\n                <span>\r\n                    ");
            EndContext();
            BeginContext(2425, 27, false);
#line 62 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               Write(Model.Contact.ContactAdress);

#line default
#line hidden
            EndContext();
            BeginContext(2452, 72, true);
            WriteLiteral("\r\n                </span>\r\n                <label>\r\n                    ");
            EndContext();
            BeginContext(2525, 17, false);
#line 65 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               Write(resource["Email"]);

#line default
#line hidden
            EndContext();
            BeginContext(2542, 50, true);
            WriteLiteral("\r\n                </label>\r\n                <span>");
            EndContext();
            BeginContext(2593, 26, false);
#line 67 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                 Write(Model.Contact.ContactEmail);

#line default
#line hidden
            EndContext();
            BeginContext(2619, 155, true);
            WriteLiteral("</span>\r\n                <div class=\"clipPath\"></div>\r\n            </div>\r\n            <div class=\"main-areas\">\r\n                <hr>\r\n                <h3>");
            EndContext();
            BeginContext(2775, 29, false);
#line 72 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
               Write(resource["Areas_of_Practice"]);

#line default
#line hidden
            EndContext();
            BeginContext(2804, 29, true);
            WriteLiteral("</h3>\r\n                <ul>\r\n");
            EndContext();
#line 74 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                     foreach (var item in Model.Areas)
                    {

#line default
#line hidden
            BeginContext(2912, 28, true);
            WriteLiteral("                        <li>");
            EndContext();
            BeginContext(2940, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71be0569da73444e8d34157eba7ef399", async() => {
                BeginContext(2989, 9, false);
#line 76 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                                                                       Write(item.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 76 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                                                      WriteLiteral(item.Id);

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
            BeginContext(3002, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 77 "C:\Users\Shamil\Desktop\LawyerAppLast\LawyerApp\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(3032, 86, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n        </section>\r\n    </div>\r\n\r\n</main>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<SharedResource> resource { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591