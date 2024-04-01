<%@ Page Title="Add_publisher" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Add_publisher.aspx.cs" Inherits="LMS_Project.Admin.Add_publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../fontawesome/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css">
    <link href="fontawesome/css/all.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4 border">
                <div class="row">
                    <div class="col-12">
                        <h4>Add Publisher</h4>
                        <div class="form-group">
                            <asp:TextBox ID="txtpublisherID" CssClass="form-control" runat="server" placeholder="Publisher ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="btn_save" ForeColor="Red" ControlToValidate="txtpublisherID" Display="Dynamic" ErrorMessage="*enter valid ID"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPublsiherName" CssClass="form-control" runat="server" placeholder="Publisher Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="btn_save" ErrorMessage="*Enter your name" ControlToValidate="txtPublsiherName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnAdd" ValidationGroup="btn_save" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnupdate" CssClass="btn btn-info" runat="server" Text="Update" OnClick="btnupdate_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-8 border">
                <div class="table table-responsive">
                    <h4>Show all the publisher list:</h4>
                    <asp:Repeater ID="RptPublisher" runat="server" OnItemCommand="RptPublisher_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-hover">
                                <thead class="alert-info">
                                    <tr>
                                        <th><span>Publisher ID</span></th>
                                        <th><span>Publisher Name</span></th>
                                        <th>&nbsp</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("member_id")%></td>
                                <td><%#Eval("membar_name")%></td>
                                <td style="width: 18%">
                                    <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("member_id")%>' CommandName="edit" ToolTip="Edit record">
                                  <span class="fa-stack">
                                      <i class=" fa fa-square fa-stack-2x"> </i>
                                      <i class=" fa fa-pencil fa-stack-1x fa-inverse"> </i>
                                          
                                  </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" class="table-link text-danger" runat="server" CommandArgument='<%#Eval("membar_name")%>' CommandName="delete" Text="Delete" ToolTip="Delete record" OnClientClick="return confirm('Do yo want to delete this record?');">
                                        <span class="fa-stack">
                                            <i class=" fa fa-square fa-stack-2x"> </i>
                                            <i class=" fa fa-trash  fa-stack-1x fa-inverse"> </i>
                                        </span>
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
         </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="row">
                        <div class="col-12">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
