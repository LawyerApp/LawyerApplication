#pragma checksum "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fad02d0b476b9bcbae8cf3ebe6c99806922e241"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_LawyerAdminPanel_Views_Account_Index), @"mvc.1.0.view", @"/Areas/LawyerAdminPanel/Views/Account/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/LawyerAdminPanel/Views/Account/Index.cshtml", typeof(AspNetCore.Areas_LawyerAdminPanel_Views_Account_Index))]
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
#line 1 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\_ViewImports.cshtml"
using LawyerApp.Areas.LawyerAdminPanel.Models;

#line default
#line hidden
#line 2 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\_ViewImports.cshtml"
using LawyerApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fad02d0b476b9bcbae8cf3ebe6c99806922e241", @"/Areas/LawyerAdminPanel/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c84317fcae242e14145f84bcbfce4e5dcd9250d9", @"/Areas/LawyerAdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_LawyerAdminPanel_Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/datatables/media/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "team", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary text-white col-12 my-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(47, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(53, 88, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02fb91ef6ebd4277ba6cc769342e0c4a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(141, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(146, 164, true);
            WriteLiteral("<header class=\"page-header\">\r\n    <h2>Users</h2>\r\n\r\n    <div class=\"right-wrapper text-right\">\r\n        <ol class=\"breadcrumbs\">\r\n            <li>\r\n                ");
            EndContext();
            BeginContext(310, 114, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4409a181ad714526ba8b69a699103c6d", async() => {
                BeginContext(354, 66, true);
                WriteLiteral("\r\n                    <i class=\"fa fa-home\"></i>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(424, 598, true);
            WriteLiteral(@"
            </li>
            <li><span>Users</span></li>
            <li><span>Index</span></li>
        </ol>

        <a class=""sidebar-right-toggle"" data-open=""sidebar-right""><i class=""fa fa-chevron-left""></i></a>
    </div>
</header>
<div class=""row"">
    <div class=""col"">
        <section class=""card"">
            <header class=""card-header"">
                <div class=""card-actions"">
                    <a href=""#"" class=""card-action card-action-toggle"" data-card-toggle></a>
                </div>

                <h2 class=""card-title"">Users</h2>

                ");
            EndContext();
            BeginContext(1022, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31669a041fed4e33bb6817fcee34e3e3", async() => {
                BeginContext(1117, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1131, 252, true);
            WriteLiteral("\r\n            </header>\r\n            <div class=\"card-body\">\r\n                <table class=\"table table-bordered table-striped mb-0\" id=\"datatable-tabletools\">\r\n                    <thead>\r\n                        <tr>\r\n                            <th>");
            EndContext();
            BeginContext(1384, 40, false);
#line 39 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1424, 183, true);
            WriteLiteral("</th>\r\n                            <th>Password</th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 45 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                         foreach (UserDto item in Model)
                        {

#line default
#line hidden
            BeginContext(1692, 91, true);
            WriteLiteral("                            <tr>\r\n                                <td class=\"teamMembertd\">");
            EndContext();
            BeginContext(1784, 9, false);
#line 48 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                                                    Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1793, 64, true);
            WriteLiteral("</td>\r\n                                <td class=\"teamMembertd\">");
            EndContext();
            BeginContext(1858, 17, false);
#line 49 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                                                    Write(Html.Raw("*****"));

#line default
#line hidden
            EndContext();
            BeginContext(1875, 102, true);
            WriteLiteral("</td>\r\n                                <td class=\"teamMembertd\">\r\n                                    ");
            EndContext();
            BeginContext(1977, 159, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d4122331e4642a481270fd7aa6979b7", async() => {
                BeginContext(2095, 37, true);
                WriteLiteral("<i class=\"fa fa-pencil-square-o\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 51 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2136, 106, true);
            WriteLiteral("\r\n                                    <a href=\"#modalPrimary\" class=\"modal-basic btn btn-danger\" data-id=\"");
            EndContext();
            BeginContext(2243, 7, false);
#line 52 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                                                                                                   Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2250, 126, true);
            WriteLiteral("\" title=\"Delete\"><i class=\"fa fa-trash-o\"></i></a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 55 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2403, 1546, true);
            WriteLiteral(@"                    </tbody>
                </table>
                <div id=""modalPrimary"" class=""modal-block  modal-block-primary mfp-hide"">
                    <section class=""card"">
                        <header class=""card-header"">
                            <h2 class=""card-title"">Are you sure?</h2>
                        </header>
                        <div class=""card-body"">
                            <div class=""modal-wrapper"">
                                <div class=""modal-icon"">
                                    <i class=""fa fa-question-circle""></i>
                                </div>
                                <div class=""modal-text"">
                                    <h4>Delete</h4>
                                    <p>Are you sure that you want to delete this user from list?</p>
                                </div>
                            </div>
                        </div>
                        <footer class=""card-footer"">
                   ");
            WriteLiteral(@"         <div class=""row"">
                                <div class=""col-md-12 text-right"">
                                    <button class=""btn btn-primary modal-confirm"">Confirm</button>
                                    <button class=""btn btn-default modal-dismiss"">Cancel</button>
                                </div>
                            </div>
                        </footer>
                    </section>
                </div>
            </div>
        </section>
    </div>
</div>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3966, 318, true);
                WriteLiteral(@"
    <script>
        var Id;
        var HttpStatusCodes={
            Ok: 200,
            NotFound:404
        }

        $("".modal-basic"").click(function () {
            Id= $(this).attr(""data-id"")
        })
        $("".modal-confirm"").click(function () {
            $.ajax({
                url: """);
                EndContext();
                BeginContext(4285, 30, false);
#line 101 "C:\Users\hp\Desktop\LawyerApp\LawyerApp\Areas\LawyerAdminPanel\Views\Account\Index.cshtml"
                 Write(Url.Action("delete","account"));

#line default
#line hidden
                EndContext();
                BeginContext(4315, 641, true);
                WriteLiteral(@""",
                type: ""POST"",
                dataType: ""JSON"",
                data: {
                    id: Id
                },
                success: function (response) {
                    if (response.status == HttpStatusCodes.Ok) {
                        location.reload();
                    }
                    else {
                        alert(""Some ploblem occured. Please try again. "")
                    }
                },
                error: function () {
                    alert(""Some ploblem occured. Please try again. "")
                }
            })
        })
    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
