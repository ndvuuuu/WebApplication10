<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication10.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" > <h2 style="text-align: center;">BIỂU MẪU ĐĂNG KÍ</h2>

         <div>
             <asp:Label ID="lblHoTen" runat="server" Text="">Họ và tên :</asp:Label>
             <asp:TextBox ID="txtBoxHoTen" runat="server"></asp:TextBox>
             <asp:Label ID="lblErrHoTen" runat="server" Text="Label" Visible ="false"></asp:Label>
         </div>
          <div>
             <asp:Label ID="lblEmail" runat="server" Text="">Email :</asp:Label>
             <asp:TextBox ID="txtBoxEmail" runat="server"></asp:TextBox>
             <asp:Label ID="lblErrEmail" runat="server" Text="" Visible ="false"></asp:Label>
          </div>
            <div>
             <asp:Label ID="lblSDT" runat="server" Text="">Số điện thoại :</asp:Label>
             <asp:TextBox ID="txtBoxSDT" runat="server"></asp:TextBox>
             <asp:Label ID="lblErrSDT" runat="server" Text="" Visible ="false"></asp:Label>
          </div>
            <div>
             <asp:Label ID="lblNgaySinh" runat="server" Text="">Ngày sinh :</asp:Label>
             <asp:TextBox ID="txtBoxNgaySinh" runat="server" TextMode="Date"></asp:TextBox>
             <asp:Label ID="lblErrNgaySinh" runat="server" Text="" Visible ="false" ></asp:Label>
          </div>
            <div>
             <asp:Label ID="lblGT" runat="server" Text="">Giới tính :</asp:Label>
 
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="GioiTinh"/>Nam
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="GioiTinh" />Nữ
                 <asp:Label ID="lblErrGT" runat="server" Text="" Visible ="false"></asp:Label>
          </div>
            <div style="margin-bottom :10px ;">
            <asp:DropDownList ID="ddlKhoa" runat="server">
                <asp:ListItem Value="" Text="-- Chọn khóa học --" Disabled="true" Selected="true" />
                <asp:ListItem Value="LTW" Text="Lập trình web" />
                <asp:ListItem Value="LTDD" Text="Lập trình di động" />
                <asp:ListItem Value="TKW" Text="Thiết kế Web" />
                <asp:ListItem Value="CSDL" Text="Cơ sở dữ liệu" />
            </asp:DropDownList>
<asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                     <asp:Label ID="lblErrOption" runat="server" Text="" Visible ="false"></asp:Label>
                </div>
            
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Đăng nhập"  />
                    <asp:Button ID="Button2" runat="server" Text="Đăng ký" OnClick="Button2_Click" />
                </div>
                    <div>
                        <asp:Table ID="Table1" runat="server" BorderWidth="1" GridLines="Both" Width="100%">
                           <asp:TableRow>

                            </asp:TableRow>
                        </asp:Table>
                     </div>
    </form>
    <asp:Label ID="lblDebug" runat="server" ForeColor="Blue" Visible="false"></asp:Label>

</body>
</html>
