<%@ Page Title="Home page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LMS_Project._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div id="demo" class="carousel slide" data-slide-to="carousel">
                <!-- indicators -->
                <ul class="carousel-indicators">
                    <li data-target="#demo" data-slide-to="0" class="active"></li>
                    <li data-target="#demo" data-slide-to="1"></li>
                    <li data-target="#demo" data-slide-to="2"></li>
                </ul>

                <!-- SlideSHow -->
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="Slideimg/slider1.jpg" alt="Mumbai" width="1200px" height="575px" />
                    </div>
                    <div class="carousel-item ">
                        <img src="Slideimg/slide1.jpg" alt="Pune" width="1200px" height="575px" />
                    </div>
                    <div class="carousel-item ">
                        <img src="Slideimg/slider2.jpg" alt="Nagpur" width="1200px" height="575px" />
                    </div>
                </div>
                <!-- Left and Right controls -->
                <a class="carousel-control-prev" href="#demo" data-slide="prev">
                    <span class="carousel-control-prev-icon"></span>
                </a>
                <a class="carousel-control-next" href="#demo" data-slide="next">
                    <span class="carousel-control-next-icon"></span>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <h2>TITLE HEADING</h2>
                <h5>Title Description, Dec 7,2024</h5>
                <div class="fakeimg">Fake Image</div>
                <p>Some text...</p>
                <p>lorea jasdjbaa dbasb dasd asdas dsad asdsa dasd as dsad</p>
                <br />
                <h2>TITLE HEADING</h2>
                <h5>Title Description, Dec 7,2024</h5>
                <div class="fakeimg">Fake Image</div>
                <p>Some text...</p>
                <p>lorea jasdjbaa dbasb dasd asdas dsad asdsa dasd as dsad</p>
            </div>
        </div>

        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Black Friday Deal</div>
                            <div class="card-body">
                                <img src="" class="img-responsive" style="width: 100%" alt="img1" />
                            </div>
                            <div class="panel-footer">Buy asdaksdad</div>
                        </div>
                    </div>
                    <div class="col-sm-4"> 
                        <div class="panel panel-primary">
                            <div class="panel-heading">Black Friday Deal</div>
                            <div class="card-body">
                                <img src="" class="img-responsive" style="width: 100%" alt="img1" />
                            </div>
                            <div class="panel-footer">Buy asdaksdad</div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Black Friday Deal</div>
                            <div class="card-body">
                                <img src="" class="img-responsive" style="width: 100%" alt="img1" />
                            </div>
                            <div class="panel-footer">Buy asdaksdad</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
