<%@ Control Language="vb" AutoEventWireup="false" Codebehind="DailySchedule.ascx.vb" Inherits="ASPNET.StarterKit.Portal.AuditSystem.Control.DailySchedule" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<iframe src='DesktopModules/AuditSystem/DailyScheduleFrame.aspx?sid=<%=Request.Params("sid")%>&amp;mid=<%=ModuleId%>&amp;tabid=<%=tabid%>&amp;tabindex=<%=tabindex%>' name="TestIFrame" FRAMEBORDER="1" width="100%" height="380">
</iframe>
