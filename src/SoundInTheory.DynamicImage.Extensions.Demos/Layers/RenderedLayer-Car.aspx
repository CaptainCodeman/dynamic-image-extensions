﻿<%@ Page Language="C#" %>
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
				<sitdap:RenderedLayer Width="600" Height="600" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="45" Pitch="10" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="0" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="45" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="90" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="135" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="180" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="225" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="270" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>

		<sitdap:DynamicImage runat="server">
			<Layers>
				<sitdap:RenderedLayer Width="400" Height="300" SourceFileName="~/Assets/Models/3ds/85-nissan-fairlady.3ds">
					<Camera>
						<sitdap:AutoCamera Yaw="315" />
					</Camera>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>
    </div>
    </form>
</body>
</html>