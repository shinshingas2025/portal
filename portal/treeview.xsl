<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:output method="xml" indent="no" omit-xml-declaration="yes" />
	<xsl:variable name="images.folder" select="'images'" />	
	<xsl:template match="/">		
		<div>
			<xsl:apply-templates  />
		</div>		
	</xsl:template>
	<xsl:template match="row">
		<xsl:variable name="menu.id" select="col[1]" />
		<xsl:variable name="text" select="col[2]" />
		<xsl:variable name="has.child" select="col[3]" />
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td rowspan="2" width="10" valign="top">
					<img id="I{$menu.id}">
						<xsl:choose>
							<xsl:when test="number($has.child) &gt; 0">
								<xsl:attribute name="src">
									<xsl:value-of select="concat($images.folder,'/plus.gif')"/>
								</xsl:attribute>
								<xsl:attribute name="onclick">
									<xsl:value-of select="concat('loadItems(',$menu.id,')')"/>
								</xsl:attribute>
							</xsl:when>
							<xsl:otherwise>
								<xsl:attribute name="src">
									<xsl:value-of select="concat($images.folder,'/dot.gif')"/>
								</xsl:attribute>
							</xsl:otherwise>
						</xsl:choose>
					</img>
				</td>
				<td nowrap="true">
					<a href="javascript:alert({$menu.id});">
						<xsl:value-of select="$text" />						
					</a>
				</td>
			</tr>
			<tr>
				<td id="C{$menu.id}" style="display:none;"></td>
			</tr>
		</table>
	</xsl:template>	
</xsl:stylesheet>