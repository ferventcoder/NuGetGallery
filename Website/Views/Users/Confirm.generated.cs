﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17020
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuGetGallery.Views.Users
{
    using NuGetGallery;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Users/Confirm.cshtml")]
    public class Confirm : System.Web.Mvc.WebViewPage<EmailConfirmationModel>
    {
        public Confirm()
        {
        }
        public override void Execute()
        {



#line 2 "..\..\Views\Users\Confirm.cshtml"

            Layout = "~/Views/Shared/TwoColumnLayout.cshtml";



#line default
#line hidden
            WriteLiteral("\r\n");


            DefineSection("LeftNav", () =>
            {

                WriteLiteral("\r\n        <img src=\"");



#line 7 "..\..\Views\Users\Confirm.cshtml"
                Write(Links.Content.Images.newAccountGraphic_png);


#line default
#line hidden
                WriteLiteral("\" style=\"padding-left:50px\" alt=\"New Account Image\"/>\r\n");


            });

            WriteLiteral("                \r\n\r\n");


            DefineSection("ContentHeader", () =>
            {

                WriteLiteral("\r\n    <span class=\"right\"><img src=\"");



#line 11 "..\..\Views\Users\Confirm.cshtml"
                Write(Links.Content.Images.required_png);


#line default
#line hidden
                WriteLiteral("\" alt=\"Required\" /></span>\r\n    <h2>Confirm registration</h2>\r\n");


            });

            WriteLiteral("\r\n\r\n<div class=\"zone-messages description\">\r\n");



#line 16 "..\..\Views\Users\Confirm.cshtml"
            if (Model.SuccessfulConfirmation)
            {


#line default
#line hidden
                WriteLiteral("        <div class=\"message message-Information\">\r\n");



#line 18 "..\..\Views\Users\Confirm.cshtml"
                if (Model.ConfirmingNewAccount)
                {


#line default
#line hidden
                    WriteLiteral("                ");

                    WriteLiteral(" Account registration completed!\r\n");



#line 20 "..\..\Views\Users\Confirm.cshtml"
                }
                else
                {


#line default
#line hidden
                    WriteLiteral("                ");

                    WriteLiteral(" Email address change confirmed!\r\n");



#line 23 "..\..\Views\Users\Confirm.cshtml"
                }


#line default
#line hidden
                WriteLiteral("        </div>\r\n");



#line 25 "..\..\Views\Users\Confirm.cshtml"
                if (Model.ConfirmingNewAccount)
                {


#line default
#line hidden
                    WriteLiteral("            <p>\r\n                Click on the Log On link to logon to the site.\r\n" +
                    "            </p>\r\n");



                    WriteLiteral("            <p>\r\n                You may now upload packages and make your mark i" +
                    "n \r\n                the community.\r\n            </p>\r\n");



#line 33 "..\..\Views\Users\Confirm.cshtml"
                }
                else
                {


#line default
#line hidden
                    WriteLiteral("            <p>\r\n                Your email address is now updated.\r\n            " +
                    "</p>\r\n");



#line 38 "..\..\Views\Users\Confirm.cshtml"
                }
            }
            else
            {


#line default
#line hidden
                WriteLiteral("        <div class=\"message critical message\">\r\n            Could not confirm you" +
                "r email address.\r\n        </div>\r\n");



                WriteLiteral("        <p>\r\n            Make sure you clicked on the confirmation URL in the ema" +
                "il we sent.\r\n        </p>\r\n");



#line 47 "..\..\Views\Users\Confirm.cshtml"
            }


#line default
#line hidden
            WriteLiteral("</div>");


        }
    }
}
#pragma warning restore 1591
