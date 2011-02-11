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
				<sitdap:RenderedLayer Width="600" Height="300" BackgroundColour="LightBlue">
					<Camera>
						<sitdap:PerspectiveCamera Position="6 5 4" LookDirection="-6 -5 -4" />
					</Camera>
					<Source>
						<sitdap:InlineSceneSource>
							<Meshes>
								<sitdap:Mesh Positions="0 0 0  1 0 0  0 1 0  1 1 0  0 0 1  1 0 1  0 1 1  1 1 1"
									Indices="2 3 1  2 1 0  7 1 3  7 5 1  6 5 7  6 4 5  6 2 0  2 0 4  2 7 3  2 6 7  0 1 5  0 5 4">
									<Material DiffuseColor="Red" />
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