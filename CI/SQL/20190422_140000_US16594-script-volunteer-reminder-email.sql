USE MinistryPlatform
GO

DECLARE @VolunteerReminderEmailTemplateID int = 2060; -- Selected manually after checking all environments
DECLARE @GoLocalContact int = 7542465;

IF NOT EXISTS (SELECT 1 FROM dp_Communications WHERE Communication_ID = @VolunteerReminderEmailTemplateID)
BEGIN
	SET IDENTITY_INSERT dp_Communications ON
	INSERT INTO [dbo].[dp_Communications]
           ([Communication_ID]
		   ,[Author_User_ID]
           ,[Subject]
           ,[Body]
           ,[Domain_ID]
           ,[Start_Date]
           ,[Communication_Status_ID]
           ,[From_Contact]
           ,[Reply_to_Contact]
           ,[Template]
           ,[Active])
     VALUES
           (@VolunteerReminderEmailTemplateID
		   ,5 -- Church Administrator
           ,'GO Local Project Details - It''s Almost Here!'
           ,'<tag-doctype "-="" "http:="" 1.0="" dtd="" en"="" html="" public="" strict="" tr="" w3c="" www.w3.org="" xhtml="" xhtml1="" xhtml1-strict.dtd"=""></tag-doctype>
<tag-html xmlns="http://www.w3.org/1999/xhtml" xmlns:o="urn:schemas-microsoft-com:office:office"
          xmlns:v="urn:schemas-microsoft-com:vml">
    <tag-head><title></title>
        <style id="hs-inline-css"
               type="text/css"> /*&lt;![CDATA[*/ /* everything in this node will be inlined */ /* ==== Page Styles ==== */
        body, #backgroundTable {
            background-color: #f2f2f2; /* Use body to determine background color */
            font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif;
        }

        #templateTable {
            width: 600px;
            background-color: #ffffff;
            -webkit-font-smoothing: antialiased;
        }

        h1, .h1, h2, .h2, h3, .h3, h4, .h4, h5, .h5, h6, .h6 {
            display: block;
            font-weight: bold;
            line-height: 100%;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
        }

        h1, .h1 {
            font-size: 26px;
        }

        h2, .h2 {
            font-size: 20px;
        }

        h3, .h3 {
            font-size: 15px;
        }

        h4, .h4 {
            font-size: 13px;
        }

        h5, .h5 {
            font-size: 11px;
        }

        h6, .h6 {
            font-size: 10px;
        }

        /* ==== Header Styles ==== */
        #headerTable {
            background-color: #f2f2f2;
            color: #444444;
            font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif;
            font-size: 10px;
            line-height: 120%;
            text-align: right;
            border-collapse: separate !important;
            padding-right: 30px;
        }

        #headerTable a:link, #headerTable a:visited, /* Yahoo! Mail Override */
        #headerTable a .yshortcuts /* Yahoo! Mail Override */
        {
            font-weight: normal;
            text-decoration: underline;
        }

        /* ==== Template Wrapper Styles ==== */
        #contentCell {
            padding: 10px 20px;
            background-color: #f2f2f2;
        }

        #contentTableOuter {
            border-collapse: separate !important;
            background-color: #ffffff;
            box-shadow: 0px 1px rgba(0, 0, 0, 0.1);
            padding: 30px;
        }

        #contentTableInner {
            width: 600px;
        }

        /* ==== Body Styles ==== */
        .bodyContent {
            color: #444444;
            font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif;
            font-size: 12px;
            line-height: 150%;
            text-align: left;
        }

        /* ==== Column Styles ==== */
        table.columnContentTable {
            border-collapse: separate !important;
            border-spacing: 0;
            background-color: #ffffff;
        }

        td.columnContent {
            color: #444444;
            font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif;
            font-size: 12px;
            line-height: 120%;
            padding-top: 20px;
            padding-right: 20px;
            padding-bottom: 20px;
            padding-left: 20px;
        }

        /* ==== Footer Styles ==== */
        #footerTable {
            background-color: #f2f2f2;
        }

        #footerTable a {
            color: #999999;
        }

        #footerTable {
            color: #999999;
            font-family: ''Helvetica Neue'', Helvetica, Arial, sans-serif;
            font-size: 12px;
            line-height: 120%;
            padding-top: 20px;
            padding-right: 20px;
            padding-bottom: 20px;
            padding-left: 20px;
            text-align: center;
        }

        #footerTable a:link, #footerTable a:visited, /* Yahoo! Mail Override */
        #footerTable a .yshortcuts /* Yahoo! Mail Override */
        {
            font-weight: normal;
            text-decoration: underline;
        }

        .hs-image-social-sharing-24 {
            max-width: 24px;
            max-height: 24px;
        }

        /* ==== Standard Resets ==== */
        .ExternalClass {
            width: 100%;
        }

        /* Force HM to display emails at full width */
        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
            line-height: 100%;
        }

        /* Force HM to display normal line spacing */
        body, table, td, p, a, li, blockquote {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        /* Prevent WebKit and Windows mobile changing default text sizes */
        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        /* Remove spacing between tables in Outlook 2007 and up */
        img {
            vertical-align: bottom;
            -ms-interpolation-mode: bicubic;
        }

        /* Allow smoother rendering of resized image in Internet Explorer */ /* Reset Styles */
        body {
            margin: 0;
            padding: 0;
        }

        table {
            border-collapse: collapse !important;
        }

        body, #backgroundTable, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        a:link, a:visited {
            border-bottom: none;
        }

        /* iOS automatically adds a link to addresses */ /* Style the footer with the same color as the footer text */
        #footer a {
            color: #999999;;
            -webkit-text-size-adjust: none;
            text-decoration: underline;
            font-weight: normal
        }

        /*]]&gt;*/ </style>
        <style type="text/css"> /*&lt;![CDATA[*/ /* ==== Mobile Styles ==== */ /* Constrain email width for small screens */
        @media screen and (max-width: 650px) {
            table#backgroundTable {
                width: 95% !important;
            }

            table#templateTable {
                max-width: 600px !important;
                width: 100% !important;
            }

            table#contentTableInner {
                max-width: 600px !important;
                width: 100% !important;
            }

            /* Makes image expand to take 100% of width*/
            img {
                width: 100% !important;
                height: auto !important;
            }

            #contentCell {
                padding: 10px 10px !important;
            }

            #headerTable {
                padding-right: 15.0px !important;
            }

            #contentTableOuter {
                padding: 15.0px !important;
            }
        }

        @media only screen and (max-width: 480px) {
            /* ==== Client-Specific Mobile Styles ==== */
            body, table, td, p, a, li, blockquote {
                -webkit-text-size-adjust: none !important;
            }

            /* Prevent Webkit platforms from changing default text sizes */
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            /* Prevent iOS Mail from adding padding to the body */
            /* ==== Mobile Reset Styles ==== */
            td#bodyCell {
                padding: 10px !important;
            }

            /* ==== Mobile Template Styles ==== */
            table#templateTable {
                max-width: 600px !important;
                width: 100% !important;
            }

            table#contentTableInner {
                max-width: 600px !important;
                width: 100% !important;
            }

            /* ==== Image Alignment Styles ==== */
            h1, .h1 {
                font-size: 26px !important;
                line-height: 125% !important;
            }

            h2, .h2 {
                font-size: 20px !important;
                line-height: 125% !important;
            }

            h3, .h3 {
                font-size: 15px !important;
                line-height: 125% !important;
            }

            h4, .h4 {
                font-size: 13px !important;
                line-height: 125% !important;
            }

            h5, .h5 {
                font-size: 11px !important;
                line-height: 125% !important;
            }

            h6, .h6 {
                font-size: 10px !important;
                line-height: 125% !important;
            }

            .hide {
                display: none !important;
            }

            /* Hide to save space */
            /* ==== Body Styles ==== */
            td.bodyContent {
                font-size: 16px !important;
                line-height: 145% !important;
            }

            /* ==== Footer Styles ==== */
            td#footerTable {
                padding-left: 0px !important;
                padding-right: 0px !important;
                font-size: 12px !important;
                line-height: 145% !important;
            }

            /* ==== Image Alignment Styles ==== */
            table.alignImageTable {
                width: 100% !important;
            }

            td.imageTableTop {
                display: none !important; /*padding-top: 10px !important;*/
            }

            td.imageTableRight {
                display: none !important;
            }

            td.imageTableBottom {
                padding-bottom: 10px !important;
            }

            td.imageTableLeft {
                display: none !important;
            }

            /* ==== Column Styles ==== */
            td.column {
                display: block !important;
                width: 100% !important;
                padding-top: 0 !important;
                padding-right: 0 !important;
                padding-bottom: 0 !important;
                padding-left: 0 !important;
            }

            td.columnContent {
                font-size: 14px !important;
                line-height: 145% !important;
                padding-top: 10px !important;
                padding-right: 10px !important;
                padding-bottom: 10px !important;
                padding-left: 10px !important;
            }

            #contentCell {
                padding: 10px 0px !important;
            }

            #headerTable {
                padding-right: 15.0px !important;
            }

            #contentTableOuter {
                padding: 15.0px !important;
            }
        }

        /*]]&gt;*/ </style>
    </tag-head>
    <tag-body bgcolor="#f2f2f2" class="" height="100%" leftmargin="0" marginheight="0" marginwidth="0" offset="0"
              style="background-color:#f2f2f2; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; height:100% !important; margin:0; padding:0; width:100% !important"
              topmargin="0" width="100%">
        <table align="center" bgcolor="#f2f2f2" border="0" cellpadding="0" cellspacing="0" height="100%"
               id="backgroundTable"
               style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important; background-color:#f2f2f2; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; height:100% !important; margin:0; padding:0; width:100% !important"
               width="100%">
            <tbody>
            <tr>
                <td align="center" height="100%" id="bodyCell"
                    style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; height:100% !important; margin:0; padding:0; width:100% !important"
                    valign="top" width="100%">
                    <table bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0" id="templateTable"
                           style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important; width:600px; background-color:#ffffff; -webkit-font-smoothing:antialiased"
                           width="600">
                        <tbody>
                        <tr>
                            <td align="center"
                                style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt"
                                valign="top">
                                <div class="header-container-wrapper"></div>
                                <table align="right" bgcolor="#f2f2f2" border="0" cellpadding="0" cellspacing="0"
                                       id="headerTable"
                                       style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; background-color:#f2f2f2; color:#444444; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:10px; line-height:120%; text-align:right; border-collapse:separate !important; padding-right:30px"
                                       width="100%">
                                    <tbody>
                                    <tr>
                                        <td align="left" class="bodyContent" colspan="12"
                                            style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; color:#444444; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:12px; line-height:150%; text-align:left"
                                            valign="top" width="100%">
                                            <table border="0" cellpadding="0" cellspacing="0"
                                                   class="templateColumnWrapper"
                                                   style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important"
                                                   width="100%">
                                                <tbody>
                                                <tr>
                                                    <td align="left" class=" column" colspan="12"
                                                        style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; width:100.0%; text-align:left; padding:0; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:12px; line-height:1.5em; color:#444444"
                                                        valign="top" width="100.0%">
                                                        <div class="widget-span widget-type-email_view_as_web_page "
                                                             data-widget-type="email_view_as_web_page" style=""></div>
                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#f2f2f2" id="contentCell"
                                style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspface:0pt; pading:10px 20px; background-color:#f2f2f2"
                                valign="top">
                                <table bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0"
                                       id="contentTableOuter"
                                       style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:separate !important; background-color:#ffffff; box-shadow:0px 1px rgba(0, 0, 0, 0.1); padding:30px; border:1px solid #cccccc; border-bottom:1px solid #acacac"
                                       width="100%">
                                    <tbody>
                                    <tr>
                                        <td align="center"
                                            style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt"
                                            valign="top">
                                            <div class="body-container-wrapper"></div>
                                            <table border="0" cellpadding="0" cellspacing="0" id="contentTableInner"
                                                   style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important; width:600px"
                                                   width="600">
                                                <tbody>
                                                <tr>
                                                    <td align="left" class="bodyContent" colspan="12"
                                                        style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; color:#444444; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:12px; line-height:150%; text-align:left"
                                                        valign="top" width="100%">
                                                        <table border="0" cellpadding="0" cellspacing="0"
                                                               class="templateColumnWrapper"
                                                               style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important"
                                                               width="100%">
                                                            <tbody>
                                                            <tr>
                                                                <td align="left" class=" column" colspan="12"
                                                                    style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; width:100.0%; text-align:left; padding:0; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:12px; line-height:1.5em; color:#444444"
                                                                    valign="top" width="100.0%">
                                                                    <div class="widget-span widget-type-logo "
                                                                         data-widget-type="logo" style="">
                                                                        <div class="layout-widget-wrapper"></div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="bodyContent" colspan="12"
                                                        style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; color:#444444; font-family:''Helvetica Neue'', Helvetica, Arial, sans-serif; font-size:12px; line-height:150%; text-align:left"
                                                        valign="top" width="100%">
                                                        <table border="0" cellpadding="0" cellspacing="0"
                                                               class="templateColumnWrapper"
                                                               style="-webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; mso-table-lspace:0pt; mso-table-rspace:0pt; border-collapse:collapse !important"
                                                               width="100%">
                                                            <tbody>
                                                            <tr>
                                                                <td align="left" class=" column" colspan="12"
                                                                    style="text-size-adjust: 100%; width: 100%; text-align: left; padding: 0px; line-height: 1.5em;"
                                                                    valign="top" width="100.0%">
                                                                    <div class="widget-span widget-type-email_body "
                                                                         data-widget-type="email_body" style="">
                                                                        <div class="hs_cos_wrapper hs_cos_wrapper_widget hs_cos_wrapper_type_rich_text"
                                                                             data-hs-cos-general-type="widget"
                                                                             data-hs-cos-type="rich_text"
                                                                             id="hs_cos_wrapper_hs_email_body"
                                                                             style="line-height: inherit;"><p 1.5;"=""
                                                                            100%;="" 1em;="" arial,="" font-size:=""
                                                                            helvetica="" helvetica,="" inherit;=""
                                                                            line-height:="" margin-bottom:="" neue",=""
                                                                            sans-serif;="" style="color: inherit;
                                                                            font-family: " text-size-adjust:=""> </p>
                                                                            <span style="color: inherit; font-family: helvetica; font-size: 15px;"> <img
                                                                                    align="center" alt="go local"
                                                                                    src="https://images.ctfassets.net/y3a9myzsdjan/1h47WCAdyUYw5xcANlCNEQ/57714653355bd7240b992a68a208b816/GoLocal_Letterhead_new-01.jpg"
                                                                                    style="vertical-align:bottom; -ms-interpolation-mode:bicubic; width:600px; max-width:600px; margin:0px auto"
                                                                                    width="600"/> </span>
                                                                            <p 1.5;"="" 100%;="" 1em;="" arial,=""
                                                                            font-size:="" helvetica="" helvetica,=""
                                                                            inherit;="" line-height:=""
                                                                            margin-bottom:="" neue",="" sans-serif;=""
                                                                            style="color: inherit; font-family: "
                                                                            text-size-adjust:=""> </p> <p align="left"
                                                                                                          dir="ltr"
                                                                                                          style="line-height: 1.5;">
                                                                                <font face="helvetica">
                                                                                    <span style="font-size: 15px;">
                                                                                        Hello Most Amazing GO Local teammate!
                                                                                    </span>
                                                                                </font></p>

                                                                            <p align="left" dir="ltr"
                                                                                                                                  style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                                <u><b>What are the details of the day?</b></u><br>
                                                                                <i>Because we are a team and we want to look like a team, arrive wearing a white t-shirt or sweatshirt.  It''s a tradition so don''t be the weenie in green!</i>
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            <i><b>There is NO launch service so you’ll go directly to our project site.</b></i>
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            <u><b>What''s my project?</b></u><br>
                                                                            Your project is: [Organization] - [Project_Name] on [Project_Date] from [Project_Start_Time] to [Project_End_Time].
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            You''ll be [Project_Description]
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            A great way to prepare for the day is to go online and Google search the organization to learn more about what they do and to pray for them.
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            <u><b>Where''s my project?</b></u><br>
Your project site is located at [Project_Address]. When you arrive on site, please park [Project_Parking_Location].

                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                                Check in <b>FIRST</b> to let your Project Leader know you are here and ready to GO!
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            <u><b>Who am I serving with?</b></u><br>
                                                                            Your Project Leader(s) are:<br>
                                                                            [Project_Leader_Names]

                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            Please only call them in case of emergency.
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            If you signed up your spouse, kids or friends on the same form, this is your official email for all of them.
                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            <u><b>Is that it?</b></u><br>
                                                                            We think that''s everything you need to know for GO Local 2019. Can''t wait for you to join us as we blitz our city with compassion!

                                                                            </span>
                                                                            </font></p>

                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            Excited to serve with you,
                                                                            </span>
                                                                            </font></p>
                                                                            <p align="left" dir="ltr"
                                                                               style="line-height: 1.5;"><font
                                                                                    face="helvetica"> <span
                                                                                    style="font-size: 15px;">
                                                                            GO Local 2019 Leadership
                                                                            </span>
                                                                            </font></p>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            </tbody>
        </table>
    </tag-body>
    <br/></tag-html>
'
           ,1
           ,'04/01/2019'
           ,1 --Draft Communication Status
           ,@GoLocalContact -- Will be overridden with primary contact on project group
           ,@GoLocalContact -- Will be overridden with primary contact on project group
           ,1
           ,1)
	SET IDENTITY_INSERT dp_Communications OFF
END