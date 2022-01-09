<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.register" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Cab| Boking</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../styles/css/adminlte.min.css">
</head>
<body class="hold-transition register-page">
<div class="register-box">
  <div class="register-logo">
    <a href="index.html"><b>Cab</b>Booking</a>
  </div>

  <div class="card">
    <div class="card-body register-card-body">
      <p class="login-box-msg">Register a new membership</p>

      <form id="form1" runat="server">
        <div class="input-group mb-3">
            <!--TextBox password-->
           <asp:TextBox ID="TextBoxFirstName" runat="server" class="form-control" placeholder="First Name" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
          <div class="input-group mb-3">
            <!--TextBox LastName-->
           <asp:TextBox ID="TextBoxLastName" runat="server" class="form-control" placeholder="Last Name" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
           <div class="input-group mb-3">
            <!--TextBox Phone No-->
          <asp:TextBox ID="TextBoxPhoneNumber" runat="server" class="form-control" TextMode="Number" placeholder=" Phone Number"/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
            <!--TextBox Email-->
          <asp:TextBox ID="TextBoxEmail" runat="server" class="form-control" placeholder="Email" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
            <!--TextBox password-->
          <asp:TextBox ID="TextBoxpassword" runat="server" class="form-control" TextMode="Password" placeholder="Password"/>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
            <!--TextBox re password-->
          <asp:TextBox ID="Re_password" runat="server" class="form-control" TextMode="Password" placeholder="Retype password" ValidateRequestMode="Enabled" MaxLength="15" />
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
              <asp:CheckBox id="terms" runat="server" name="terms" value="agree"/>
              <label for="agreeTerms">
               I agree to the <a href="terms.aspx">terms</a>
              </label>
          </div>
          <!-- /.col -->
          <div class="col-4">
            <!--Button register-->
              <asp:Button ID="ButtonRegister" class="btn btn-primary btn-block" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
          </div>
          <!-- /.col -->
        </div>
      </form>

      <div class="social-auth-links text-center">
        <p>- OR -</p>
        <a href="#" class="btn btn-block btn-primary">
          <i class="fab fa-facebook mr-2"></i>
          Sign up using Facebook
        </a>
        <a href="#" class="btn btn-block btn-danger">
          <i class="fab fa-google-plus mr-2"></i>
          Sign up using Google+
        </a>
      </div>

      <a href="login.aspx" class="text-center">I already have a membership</a>
    </div>
    <!-- /.form-box -->
  </div><!-- /.card -->
</div>
<!-- /.register-box -->

<!-- jQuery -->
<script src="../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../styles/js/adminlte.min.js"></script>
</body>
</html>

