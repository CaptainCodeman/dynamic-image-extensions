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
				<sitdap:RenderedLayer Width="600" Height="300" BackgroundColour="LightBlue" LightingEnabled="false">
					<Source>
						<sitdap:InlineSceneSource>
							<Meshes>
						<sitdap:Mesh Positions="-10,15,-5 10,15,0 -10,0,-5 10,0,0" Normals="0,0,1 0,0,1 0,0,1 0,0,1" TextureCoordinates="0,0 1,0 0,1 1,1" Indices="0,1,2 2,1,3">
							<Material TextureFileName="~/Assets/Photos/Koala.jpg" DiffuseColor="White" />
						</sitdap:Mesh>
						<sitdap:Mesh Positions="5,0,-2 10,10,0 15,0,-2" Indices="0,1,2">
							<Material DiffuseColor="Blue" />
						</sitdap:Mesh>
							</Meshes>
						</sitdap:InlineSceneSource>
					</Source>
				</sitdap:RenderedLayer>
			</Layers>
		</sitdap:DynamicImage>
    </div>
    </form>
</body>
</html>