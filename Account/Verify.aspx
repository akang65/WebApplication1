<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="WebApplication1.Account.Verify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm OTP</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="../plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../styles/css/adminlte.min.css" />

</head>
<body class="hold-transition login-page">
     <form id="form1" runat="server" method="post">
    <div class="login-box">
        <div class="login-logo">
            <a href="index.aspx"><b>Cab</b>Booking</a>
        </div>
        <!-- /.login-logo -->
        <div class="card">
            <div class="card-body login-card-body">
                <p class="login-box-msg">OTP Verification</p>

            
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TextBoxOTP" runat="server" TextMode="Number" class="form-control" placeholder="Enter OTP" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="ButtonVerify" runat="server" class="btn btn-primary btn-block" Text="Verify" />
                        </div>
                        <!-- /.col -->
                    </div>
              
                         <p class="mt-3 mb-1">
                    <asp:Button ID="ButtonResendOTP" runat="server" Text="Resend OTP" class="invisible"  OnClick="ButtonResendOTP_Click" />
                </p> 
               <p class="mt-3 mb-1">
                   <asp:Label ID="ctn" runat="server"></asp:Label>
                </p>
              
                
            </div>
            <!-- /.login-card-body -->
        </div>
    </div>
         </form>
    <!-- /.login-box -->
    <!-- jQuery -->
    <script src="../styles/customJS/OTPtimer.js"></script>
    <script src="../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../stylesjs/adminlte.min.js"></script>
</body>
</html>

