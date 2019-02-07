﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PasswordGenerator.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random password</title>
    <link rel="stylesheet" href="/CSS/Main.css"/>
    <link rel='shortcut icon' href="/favicon.ico" type="image/x-icon" />
</head>
<body>    
    <div id="page_container"> 
    <form id="form1" runat="server">
        <div>
            <h1>Passwords you can memorize</h1>            
            <asp:TableCell><div class="usernameandpassword"><asp:Label ID="lblPassword" runat="server" Text=""></asp:Label></div></asp:TableCell>      
            <h2>How to use memorable passwords</h2>
            <p>The idea behind these passwords is that <b>longer</b> passwords <b>that you can remember</b> are better than shorter passwords that are harder to remember.</p>
            <p>Pick a password from the above list, and make up a sentence or a story with those words that you can remember.</p>
            <p>Feel free to mix the order of the words, or add your own.</p>
            <p>To increase security, capitalize one or more words, or change the special character between the words.</p>
            <br /><br />
            <h1>Complex passwords for password managers</h1>            
            <asp:TableCell><div class="usernameandpassword" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: 10pt;"><asp:Label ID="lblComplexPasswords" runat="server" Text=""></asp:Label></div></asp:TableCell>      
            <h2>How to use complex passwords</h2>
            <p>Use these with a password manager system, such as <a href="https://www.lastpass.com/">LastPass</a>, or <a href="https://keepass.info/">KeePass</a>. Don't try to memorize these, they are meant to be either copied and pasted, or automatically submitted via a password manager program or browser add-in.</p>
        </div>
    </form>
    </div>
</body>
</html>