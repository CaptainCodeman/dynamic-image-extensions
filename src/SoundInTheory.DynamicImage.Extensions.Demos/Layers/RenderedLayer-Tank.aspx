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
				<sitdap:RenderedLayer Width="600" Height="600" SourceFileName="~/Assets/Models/Obj/Tank.obj" ReverseWindingOrder="true">
					<Camera>
						<sitdap:AutoCamera Zoom="1" Yaw="45" Pitch="20" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>
    </div>
    </form>
</body>
</html>