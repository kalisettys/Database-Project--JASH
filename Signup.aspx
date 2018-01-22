<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="HousingApp.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $('form').validate();
        $(function () {
            var radioVal = $('#ContentPlaceHolder1_radioList input:checked').val();
            if (radioVal === 'Faculty') {
                $('#gradeDiv').hide();
                $('#vcuNumberDiv').show();
                $('#genderDiv').show();
                $('#ContentPlaceHolder1_vcu').attr("required", "required");
            }
            if (radioVal === 'Student') {
                $('#gradeDiv').show();
                $('#vcuNumberDiv').show();
                $('#genderDiv').show();
                $('#ContentPlaceHolder1_vcu').attr("required", "required");
            }
            if (radioVal === 'Property Manager') {
                $('#gradeDiv').hide();
                $('#vcuNumberDiv').hide();
                $('#genderDiv').hide();
                $('#ContentPlaceHolder1_vcu').removeAttr("required");
            }
            $('#ContentPlaceHolder1_radioList input').change(function () {
                // The one that fires the event is always the
                // checked one; you don't need to test for this
                var selVal = $(this).val();
                if (selVal === 'Faculty')
                {
                    $('#gradeDiv').hide();
                    $('#vcuNumberDiv').show();
                    $('#genderDiv').show();
                    $('#ContentPlaceHolder1_vcu').attr("required", "required");
                }
                if (selVal === 'Student') {
                    $('#gradeDiv').show();
                    $('#vcuNumberDiv').show();
                    $('#genderDiv').show();
                    $('#ContentPlaceHolder1_vcu').attr("required", "required");
                }
                if (selVal === 'Property Manager') {
                    $('#gradeDiv').hide();
                    $('#vcuNumberDiv').hide();
                    $('#genderDiv').hide();
                    $('#ContentPlaceHolder1_vcu').removeAttr("required");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" class="main col-6" tabindex="0" role="main" style="margin-top: 51px;">
        <header class="header-main">
            <div class="hgroup-main">
                <h2>Already have an account? <a href="/login.aspx">Log in here</a></h2>
            </div>
            <h2>
                <asp:Literal ID="ltrError" runat="server" />
            </h2>
            
        </header>

            <legend>Account Information</legend>
            <form id="Form1" action="" name="registration" runat="server">
            <b>Select type of User</b>

                    <asp:RadioButtonList ID="radioList" runat="server">
                        <asp:ListItem Text="Student" Selected="True" />
                        <asp:ListItem Text="Faculty" />
                        <asp:ListItem Text="Property Manager" />
                    </asp:RadioButtonList>

                <div class="clearfix">
                    <div class="field-wrapper fancify col-3 col-fleft fancified">
                        <label for="username">Username *</label>

                        <%--<input type="text" name="username" id="username" maxlength="46" value="" placeholder="Enter a username" required>--%>
                        <asp:TextBox name="username" ID="username" MaxLength="46" runat="server" placeholder="Enter a username" required></asp:TextBox>
                        
                    </div>

                    <!-- Password and Password Confirm fields -->




                    <div class="field-wrapper fancify col-3 col-fright fancified">
                        <label for="password">Password *</label>
                        <asp:TextBox name="password" ID="txtPassword" MaxLength="46" runat="server" required TextMode="Password" placeholder="Password" ></asp:TextBox>

                        


                    </div>


                </div>
                <div class="clearfix">
                </div>


                <fieldset class="dborder-bottom">
                    <legend>Contact Information</legend>
                    <div class="col-3 col-fleft">
                        <div class="field-wrapper fancify fancified">
                            <label for="first_name">First Name *</label>
                            <asp:TextBox ID="first_name" name="first_name" placeholder="Enter your first name" required="" runat="server" />
                        </div>
                        <div class="field-wrapper fancify fancified">
                            <label for="last_name">Last Name *</label>
                            <asp:TextBox runat="server" name="last_name" id="last_name" value="" placeholder="Enter your last name" required="" />
                        </div>

                        <div class="field-wrapper fancify fancified">
                            <label for="email">Email </label>
                            <asp:TextBox runat="server" type="email" name="email" id="email" maxlength="128" placeholder="email@example.com" required="" />
                        </div>
                        <div id="referenced-from-wrapper genderDiv" class="field-wrapper clearfix">
                            <label for="referenced-from">Gender</label>
                            <div class="fancify fancify-select fancified">
                                <span class="faux-select"><span class="value">Please Select</span></span>
                                <%--<select name="referenced_from" id="referenced-from" style="opacity: 0;">
                                    <option value="" selected="">Please Select</option>
                                    <option value="Facebook">Male</option>
                                    <option value="Other">Female</option>
                                </select>--%>
                                <asp:DropDownList ID="referencedfrom" runat="server">
                                    <asp:ListItem Text="Please Select" Value />
                                    <asp:ListItem Text="Male" Value="Male" />
                                    <asp:ListItem Text="Female" Value="Female" />
                                </asp:DropDownList>
                            </div>


                        </div>
                    </div>
                    <div class="field-wrapper col-3 col-fright">

                        <div class="field-wrapper">
                            <label for="phone">Phone Number *</label>
                            <asp:TextBox runat="server"  name="phone" id="phone" required=""/>
                        </div>
                        <div class="field-wrapper" id="gradeDiv">
                            <label for="fax">Grade Level</label>
                            <asp:TextBox runat="server" name="fax" id="fax" />
                        </div>
                        <div class="field-wrapper" id="vcuNumberDiv">
                            <label for="vcu">VCU Number</label>
                            <asp:TextBox runat="server"  name="vcu" id="vcu" required="" />
                        </div>
                    </div>
                </fieldset>
                <div class="field-wrapper page-actions">
                    <asp:Button ID="registerButton" Text="Register" runat="server" CssClass="btn btn-chevronright" OnClick="registerButton_Click"/>
                </div>
            </form>
    </div>
</asp:Content>

