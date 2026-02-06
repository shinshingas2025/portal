<%@ Control Language="vb" AutoEventWireup="false" Codebehind="AffairProcessCheckReport.ascx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Control.AffairProcessCheckReport" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<iframe src='DesktopModules/AuditSystem/AffairProcessCheckReportFrame.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>' name="TestIFrame" FRAMEBORDER="1" width="100%" height="380">
</iframe>
