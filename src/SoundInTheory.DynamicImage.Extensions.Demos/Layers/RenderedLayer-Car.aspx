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
				<sitdap:RenderedLayer Width="600" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.4" Yaw="135" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="0" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="45" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="90" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="135" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="180" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="225" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="270" />
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds" Zoom="1.1" Yaw="315" />
			</Layers>
		</sitdap:DynamicImage>
    </div>
    </form>
</body>
</html>