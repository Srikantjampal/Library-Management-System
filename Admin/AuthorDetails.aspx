<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="AuthorDetails.aspx.cs" Inherits="LMS_Project.Admin.AuthorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../fontawesome/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border">
        <div class="row">
            <div class="col-lg-10 px-lg-4">
                <h4 class="text-base text-primary text-uppercase mb-4 text-center">Add Author Details</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <label>Author ID</label>
                    <asp:TextBox ID="TxtID" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Author ID" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <label>Author Name</label>
                    <asp:TextBox ID="TxtAuthorName" required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Author Name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:Button ID="btnAdd" CssClass="btn btn-success" Height="50px" Width="200px" runat="server" Text="Submit" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnupdate" CssClass="btn btn-info" Height="40px" Width="120px" runat="server" Text="Upadte" OnClick="btnupdate_Click"  Visible="false"/>
                    <asp:Button ID="btncancel" CssClass="btn btn-danger" Height="40px" Width="120px" runat="server" Text="Cancel" OnClick="btncancel_Click" Visible="false"/>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="table-responsive">
                <h4>Author List</h4>
                <hr />
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered table-hover">
                            <thead class="alert-info">
                                <tr>
                                    <th><span>Author ID</span></th>
                                    <th><span>Author Name</span></th>
                                    <th>&nbsp</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("author_id")%></td>
                            <td><%#Eval("author_name")%></td>
                            <td style="width: 10%">
                                <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("author_id")%>' CommandName="edit" ToolTip="Edit record">
                                                 <span class="fa-stack">
                                                     <i class=" fa fa-square fa-stack-2x"> </i>
                                                     <i class=" fa fa-pencil fa-stack-1x fa-inverse"> </i>
                                                 </span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkDelete" class="table-link text-danger" runat="server" CommandArgument='<%#Eval("author_id")%>' CommandName="delete" Text="Delete" ToolTip="Delete record" OnClientClick="return confirm('Do yo want to delete this record?');">
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
            </div>
        </div>
    </div>
</asp:Content>
