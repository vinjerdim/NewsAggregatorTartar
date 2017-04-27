<%@ Page Title="News Aggregator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsTartar._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <form method="post" action="">
        <table>
            <tr>
                <td>Input text</td>
                <td><input type="text" name="keyword" autocomplete="off"></td>
            </tr>
            <tr>
                <td rowspan="3">Select algorithm</td>
                <td><input type="radio" name="algorithm" value="1" checked>KMP</td>
            </tr>
            <tr>
                <td><input type="radio" name="algorithm" value="2">Boyer-Moore</td>
            </tr>
            <tr>
                <td><input type="radio" name="algorithm" value="3">RegEx</td>
            </tr>
            <tr>
                <td colspan="2"><input type="submit" value="SEARCH"></td>
            </tr>
        </table>
    </form>
    <asp:GridView ID="antara" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="90%">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr><td><%#Eval("PublishDate")%></td></tr>
                        <tr><td><%#Eval("Title")%></td></tr>
                        <tr><td><%#Eval("Description")%></td></tr>
                        <tr><td><a href=<%#Eval("Link")%>><%#Eval("Link")%></a></td></tr>
                        <tr><td><%#Eval("Content")%></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="detik" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="90%">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr><td><%#Eval("PublishDate")%></td></tr>
                        <tr><td><%#Eval("Title")%></td></tr>
                        <tr><td><%#Eval("Description")%></td></tr>
                        <tr><td><a href=<%#Eval("Link")%>><%#Eval("Link")%></a></td></tr>
                        <tr><td><%#Eval("Content")%></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="tempo" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="90%">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr><td><%#Eval("PublishDate")%></td></tr>
                        <tr><td><%#Eval("Title")%></td></tr>
                        <tr><td><%#Eval("Description")%></td></tr>
                        <tr><td><a href=<%#Eval("Link")%>><%#Eval("Link")%></a></td></tr>
                        <tr><td><%#Eval("Content")%></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="viva" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="90%">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr><td><%#Eval("PublishDate")%></td></tr>
                        <tr><td><%#Eval("Title")%></td></tr>
                        <tr><td><%#Eval("Description")%></td></tr>
                        <tr><td><a href=<%#Eval("Link")%>><%#Eval("Link")%></a></td></tr>
                        <tr><td><%#Eval("Content")%></td></tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
