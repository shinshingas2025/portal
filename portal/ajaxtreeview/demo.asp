<html>
	<head>
		<title>Simple Ajax TreeView</title>
		<script language="javascript" src="ajax.js"></script>
		<script language="javascript" src="scripts.js"></script>
		<style>
		    div#TreeView1 a{color:blue;font-family:verdana;font-size:10pt;}
		    div#TreeView1 a:link{text-decoration:none;}
		    div#TreeView1 a:hover{text-decoration:underline;}
		    div#TreeView1 a:visited{text-decoration:none;}
		</style>
	</head>
	<body>
		<h2>Simple Ajax TreeView</h2>		
		<table>
			<tr>
				<td valign="top">
					<div id="TreeView1"></div>
				</td>
				<td valign="top">
					<div id="Loading" style="color:blue;display:none;">Loading...</div>
				</td>
			</tr>
		</table>
		<script>
			window.onload = function(){
				buildTree('TreeView1');
			}
		</script>
	</body>
</html>
