<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LMS_Project.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <%----Bootstrap---%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <%----datatble Css---%>
    <link href="Datatables/css/dataTables.dataTables.min.css" rel="stylesheet" />
    <script src="Datatables/js/dataTables.min.js"></script>
    <%----Fontawesome CSS---%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />
    <%----Jquery js---%>
    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%----Pooper js---%>
    <script src="bootstrap/js/popper.min.js"></script>
    <%----Bootstrap JS---%>
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <%-- sweet alert  --%>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-sm navbar-dark bg-primary">
                <a class="navbar-brand" href="default.aspx">
                    <img src="Logoimg/download.jpg" alt="logo" width="49" height="49" />LMS Application</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span class="navbar-toggle-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="default.aspx"><b>Home</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Library Collection</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Archives</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Publications</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Gallery</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Contact Us</b></a>
                        </li>
                    </ul>
                </div>
                <!-- Navbar Right section-->
                <div class="pmd-navbar-right-icon ml-auto">
                    <a class="btn btn-sm btn-primary" href="Login.aspx">Sign In</a>
                    <%--<a class="btn btn-sm btn-primary" href="index.html">Sign In</a>--%>
                </div>
            </nav>

            <div class="jumbotron text-center alert alert-primary" style="margin-bottom: 0">
                <h1>Library Management System</h1>
                <p>Building community, Inspiring readers, Expanding book access!</p>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-2 border border-info">
                        <h2>Filter</h2>
                        <h5>Category:</h5>
                        <div class="fakeimg">Fake Image</div>
                        <p>Some text about me in culpa quaosdasd/// ....</p>
                        <h3>Some Links</h3>
                        <p>Top Search.</p>
                        <ul class="nav nav-pills flex-column">
                            <li class="nav-item">
                                <a class="nav-link" href="#">Active</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Links</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Links</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Disabled</a>
                            </li>
                        </ul>
                        <hr class="d-sm-block" />
                    </div>
                    <div class="col-sm-10 border border-info">
                        <%--SignUp code here--%>

                        <div class="container mt-3">
                            <h2>Create New Account</h2>
                            <br />
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#signup">Sign Up</a>
                                </li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div id="signup" class="container tab-pane active">
                                    <br />
                                    <h3>Sign Up</h3>
                                    <p></p>
                                    <!-- design Login Form -->
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12 mx-auto">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <img width="150" src="Logoimg/user1.jpg" />
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <h3>Member/User Sign Up</h3>
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <hr />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-3">
                                                                <label>Member ID</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtMemberID" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Full Name</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtFullName" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Enter Full Name" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ControlToValidate="TxtFullName"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <label>Password</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Enter Field Password" ControlToValidate="TxtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>


                                                                <%-- <div class="form-group">
                                                                    <a href="SignUp.aspx">
                                                                        <input type="button" class="btn btn-info btn-lg btn-block" value="Sign Up" /></a>
                                                                </div>--%>
                                                            </div>
                                                            <div class="col-3">
                                                                <label>Date of Birth</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtDOB" CssClass="form-control" placeholder="DOB" TextMode="Date" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Email ID</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtEmail" CssClass="form-control" placeholder="Email ID" TextMode="Email" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Enter valid Email address" ControlToValidate="TxtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Enter valid Email address" ControlToValidate="TxtEmail" Display="Dynamic" ForeColor="Maroon" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <label>Contact No.</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtContactNO" CssClass="form-control" placeholder="Contact No." runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-3">
                                                                <label>State</label>
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
                                                                <label>City</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtCity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Pin</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtPin" CssClass="form-control" placeholder="PIN CODE" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-12">
                                                                <label>Full Address</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="TxtAddress" CssClass="form-control" placeholder="Full Address" runat="server"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-3">
                                                                <div class="form-group">
                                                                    <asp:Button ID="btnSignup" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Sign Up" OnClick="btnSignup_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a href="#"><< Back to Home Screen</a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- form ends here -->
                                </div>
                            </div>
                        </div>
                        <%-- SignUp code end here --%>
                    </div>
                </div>
            </div>

            <br />
            <div class="jumbotron text-center alert alert-danger" style="margin-bottom: 0; border: 2px solid red">
                <p>Footer</p>
                <div class="container">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="footer-pad">
                                <h4>Heading1</h4>
                                <ul class="list-unstyled">
                                    <li><a href="#"></a></li>
                                    <li><a href="#">Payment Center</a></li>
                                    <li><a href="#">News and updates</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="footer-pad">
                                <h4>Heading1</h4>
                                <ul class="list-unstyled">
                                    <li><a href="#"></a></li>
                                    <li><a href="#">Website </a></li>
                                    <li><a href="#">Disclaimer</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <h4>Follow Us</h4>
                            <ul class="list-unstyled">
                                <li><a href="#" title="Facebook"><i class="fa fa-facebook">Facebook</i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 fa-copyright border-dark">
                        <p class="text-center">&copy; CopyRith 2023 - Library Management. All rights reserved.</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
