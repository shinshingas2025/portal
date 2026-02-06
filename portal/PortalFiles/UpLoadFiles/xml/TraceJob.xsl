<?xml version="1.0" encoding="Big5"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output method="html" encoding="Big5" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>
					<xsl:value-of select="TraceJob/JobName"/>
				</title>
			</head>
			<body>
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="TraceJob">
		<table bgcolor="#ffffff" width="100%" align="center" border="1">
			<tr>
				<td width="10%">工作追蹤單</td>
				<td width="2%"/>
				<td>
					<xsl:value-of select="JobName"/>
				</td>
			</tr>
			<tr>
				<td width="10%">起始日期</td>
				<td width="2%"/>
				<td>
					<xsl:value-of select="StartDate"/>
				</td>
			</tr>
			<tr>
				<td width="10%">結束日期</td>
				<td width="2%"/>
				<td>
					<xsl:value-of select="EndDate"/>
				</td>
			</tr>
		</table>
		<table width="100%" bgcolor="#ffffff" align="center" border="1">
			<tr>
				<th width="8%">項次</th>
				<th width="13%">項目</th>
				<th width="62%">處理情形</th>
				<th width="10%">預計完成日</th>
				<th width="7%">負責人</th>
			</tr>
			<xsl:apply-templates/>
		</table>
	</xsl:template>
	<xsl:template match="JobName">
	</xsl:template>
	<xsl:template match="StartDate">
	</xsl:template>
	<xsl:template match="EndDate">
	</xsl:template>
	<xsl:template match="TraceJob/Description">
	</xsl:template>
	<xsl:template match="Remark">
	</xsl:template>
	<xsl:template match="JobEntity">
		<xsl:if test="Status[text()='已完成']">
			<tr bgcolor="#80b080">
				<td align="center">
					<xsl:value-of select="EntitySequence"/>
				</td>
				<td>
					<a name="{EntitySequence[text()]}">
						<xsl:value-of select="EntityTitle"/>
					</a>
				</td>
				<td>
					<table width="100%" cellpadding="1" cellspacing="1" border="1" style="border-collapse: collapse">
						<xsl:for-each select="Process">
							<tr>
								<xsl:apply-templates select="."/>
							</tr>
						</xsl:for-each>
					</table>
				</td>
				<td align="center">
					<xsl:value-of select="EndDate"/>
				</td>
				<td align="center">
					<xsl:value-of select="Manager"/>
				</td>
			</tr>
		</xsl:if>
		<xsl:if test="Status[text()='未完成']">
			<tr>
				<td align="center">
					<xsl:value-of select="EntitySequence"/>
				</td>
				<td>
					<a name="{EntitySequence[text()]}">
						<xsl:value-of select="EntityTitle"/>
					</a>
				</td>
				<td>
					<table width="100%" cellpadding="1" cellspacing="1" border="1" style="border-collapse: collapse">
						<xsl:for-each select="Process">
							<tr>
								<xsl:apply-templates select="."/>
							</tr>
						</xsl:for-each>
					</table>
				</td>
				<td align="center">
					<xsl:value-of select="EndDate"/>
				</td>
				<td align="center">
					<xsl:value-of select="Manager"/>
				</td>
			</tr>
		</xsl:if>
	</xsl:template>
	<xsl:template match="Process">
		<td width="4%" align="center">
			<xsl:value-of select="ProcessSequence"/>.
		</td>
		<td>
			<pre>
				<xsl:apply-templates select="Description"/>
			</pre>
		</td>
	</xsl:template>
	<xsl:template match="Description/LinkType">
		<b>
			<xsl:value-of select="."/>
		</b>
	</xsl:template>
</xsl:stylesheet>
