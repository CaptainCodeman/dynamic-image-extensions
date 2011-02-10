<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Rendered Layer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="1024" Height="768" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>
    </div>
    </form>
</body>
</html>