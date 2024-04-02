<%@ Page Title="Member Update" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="UpdateMemberDetails.aspx.cs" Inherits="LMS_Project.Admin.UpdateMemberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <center>
            <hr />
        <div class="row">
            <div class="col-sm-5 border">
                <br />
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="TxtMemberID" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Member ID" ControlToValidate="TxtMemberID" ForeColor="Red" ValidationGroup="btnSearch"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <center>
                        <div class="form-group">
                            <asp:Button ID="btnSearchMember" CssClass="btn btn-success" runat="server" Text="Search" OnClick="btnSearchMember_Click" ValidationGroup="btnSearch" />
                            <asp:Button ID="btnActiveMember" CssClass="btn btn-primary" runat="server" Text="Active" OnClick="btnActiveMember_Click" ValidationGroup="btnSearch" />
                            <asp:Button ID="btnPendingMember" CssClass="btn btn-warning" ForeColor="red" runat="server" Text="Pending" OnClick="btnPendingMember_Click" ValidationGroup="btnSearch" />
                            <asp:Button ID="btnDeactiveMember" CssClass="btn btn-danger" runat="server" Text="Deactive" OnClick="btnDeactiveMember_Click" ValidationGroup="btnSearch" />
                        </div>
                        </center>
                    </div>
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="TxtFullName" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:TextBox ID="TxtDOB" CssClass="form-control" placeholder="DOB" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group">
                            <asp:TextBox ID="TxtContactNO" CssClass="form-control" placeholder="Contact No." runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="TxtEmail" CssClass="form-control" placeholder="Email ID" TextMode="Email" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlState" runat="server">
                                <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh"></asp:ListItem>
                                <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh"></asp:ListItem>
                                <asp:ListItem Text="Assam" Value="Assam"></asp:ListItem>
                                <asp:ListItem Text="Bihar" Value="Bihar"></asp:ListItem>
                                <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh"></asp:ListItem>
                                <asp:ListItem Text="Goa" Value="Goa"></asp:ListItem>
                                <asp:ListItem Text="Gujarat" Value="Gujarat"></asp:ListItem>
                                <asp:ListItem Text="Haryana" Value="Haryana"></asp:ListItem>
                                <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh"></asp:ListItem>
                                <asp:ListItem Text="Jharkhand" Value="Jharkhand"></asp:ListItem>
                                <asp:ListItem Text="Karnataka" Value="Karnataka"></asp:ListItem>
                                <asp:ListItem Text="Kerala" Value="Kerala"></asp:ListItem>
                                <asp:ListItem Text="Maharashtra" Value="Maharashtra"></asp:ListItem>
                                <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh"></asp:ListItem>
                                <asp:ListItem Text="Manipur" Value="Manipur"></asp:ListItem>
                                <asp:ListItem Text="Meghalaya" Value="Meghalaya"></asp:ListItem>
                                <asp:ListItem Text="Mizoram" Value="Mizoram"></asp:ListItem>
                                <asp:ListItem Text="Nagaland" Value="Nagaland"></asp:ListItem>
                                <asp:ListItem Text="Odisha" Value="Odisha"></asp:ListItem>
                                <asp:ListItem Text="Punjab" Value="Punjab"></asp:ListItem>
                                <asp:ListItem Text="Rajasthan" Value="Rajasthan"></asp:ListItem>
                                <asp:ListItem Text="Sikkim" Value="Sikkim"></asp:ListItem>
                                <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu"></asp:ListItem>
                                <asp:ListItem Text="Tripura" Value="Tripura"></asp:ListItem>
                                <asp:ListItem Text="Telangana" Value="Telangana"></asp:ListItem>
                                <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh"></asp:ListItem>
                                <asp:ListItem Text="Uttarakhand" Value="Uttarakhand"></asp:ListItem>
                                <asp:ListItem Text="West Bengal" Value="West Bengal"></asp:ListItem>



                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group">
                            <asp:TextBox ID="TxtCity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="TxtPin" CssClass="form-control" placeholder="PIN CODE" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="TxtAddress" CssClass="form-control" placeholder="Full Address" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        </center>
        <div class="row">
            <div class="col-sm-12">
                <h4>Member List</h4>
                <div class="table table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-sm" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" PageSize="5" OnRowUpdating="GridView1_RowUpdating" Font-Size="10" OnRowDataBound="GridView1_RowDataBound">
                        <HeaderStyle BackColor="#0066FF" Font-Bold="true" ForeColor="white" />
                        <FooterStyle BackColor="#3366CC" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID" >
                                <ItemTemplate >
                                    <asp:Label ID="lblDisplayID" runat="server" Text='<%# Eval("member_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayName" runat="server" Text='<%# Eval("full_name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditName" CssClass="form-control" Text='<%# Eval("full_name") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplaydob" runat="server" Text='<%# Eval("dob") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditdob" CssClass="form-control" Text='<%# Eval("dob") %>' runat="server" TextMode="Date"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayContact" runat="server" Text='<%# Eval("contact_no") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditContact" CssClass="form-control" Text='<%# Eval("contact_no") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditEmail" CssClass="form-control" Text='<%# Eval("email") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayState" runat="server" Text='<%# Eval("state") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>      
                                    <asp:Label ID="lblEditState" runat="server" Text='<%# Eval("state") %>' Visible="false"></asp:Label>                                  
                                    <asp:DropDownList ID="ddlEditState" runat="server">
                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Assam" Value="Assam"></asp:ListItem>
                                        <asp:ListItem Text="Bihar" Value="Bihar"></asp:ListItem>
                                        <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh"></asp:ListItem>
                                        <asp:ListItem Text="Goa" Value="Goa"></asp:ListItem>
                                        <asp:ListItem Text="Gujarat" Value="Gujarat"></asp:ListItem>
                                        <asp:ListItem Text="Haryana" Value="Haryana"></asp:ListItem>
                                        <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Jharkhand" Value="Jharkhand"></asp:ListItem>
                                        <asp:ListItem Text="Karnataka" Value="Karnataka"></asp:ListItem>
                                        <asp:ListItem Text="Kerala" Value="Kerala"></asp:ListItem>
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra"></asp:ListItem>
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Manipur" Value="Manipur"></asp:ListItem>
                                        <asp:ListItem Text="Meghalaya" Value="Meghalaya"></asp:ListItem>
                                        <asp:ListItem Text="Mizoram" Value="Mizoram"></asp:ListItem>
                                        <asp:ListItem Text="Nagaland" Value="Nagaland"></asp:ListItem>
                                        <asp:ListItem Text="Odisha" Value="Odisha"></asp:ListItem>
                                        <asp:ListItem Text="Punjab" Value="Punjab"></asp:ListItem>
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan"></asp:ListItem>
                                        <asp:ListItem Text="Sikkim" Value="Sikkim"></asp:ListItem>
                                        <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu"></asp:ListItem>
                                        <asp:ListItem Text="Tripura" Value="Tripura"></asp:ListItem>
                                        <asp:ListItem Text="Telangana" Value="Telangana"></asp:ListItem>
                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Uttarakhand" Value="Uttarakhand"></asp:ListItem>
                                        <asp:ListItem Text="West Bengal" Value="West Bengal"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayCity" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditCity" CssClass="form-control" Text='<%# Eval("city") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pincode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplaypincode" runat="server" Text='<%# Eval("pincode") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditpincode" CssClass="form-control" Text='<%# Eval("pincode") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayaddress" runat="server" Text='<%# Eval("full_address") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditaddress" CssClass="form-control" Text='<%# Eval("full_address") %>' runat="server"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="account_status" HeaderText="status" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" ToolTip="Edit record" Text="edit" CommandName="edit">
                                 <span class="fa-stack">
                                     <i class=" fa fa-square fa-stack-2x"> </i>
                                     <i class=" fa fa-pencil fa-stack-1x fa-inverse"> </i>
        
                                 </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" class="table-link text-danger" runat="server" Text="Delete" ToolTip="Delete record" OnClientClick="return confirm('Do yo want to delete this record?');" CommandName="Delete">
                                  <span class="fa-stack">
                                      <i class=" fa fa-square fa-stack-2x"> </i>
                                      <i class=" fa fa-trash  fa-stack-1x fa-inverse"> </i>
                                  </span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" class="table-link text-success" runat="server" Text="Update" ToolTip="Update record" CommandName="Update"> 
                                 <span class="fa-stack">
                                     <i class=" fa fa-square fa-stack-2x"> </i>
                                     <i class=" fa fa-spinner fa-stack-1x fa-inverse"> </i>
        
                                 </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" class="table-link text-danger" runat="server" Text="Cancel" ToolTip="Cancel record" CommandName="Cancel">
                                  <span class="fa-stack">
                                      <i class=" fa fa-square fa-stack-2x"> </i>
                                      <i class=" fa fa-time-circle  fa-stack-1x fa-inverse"> </i>
                                  </span>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
