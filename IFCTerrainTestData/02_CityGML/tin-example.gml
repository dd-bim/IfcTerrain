<?xml version="1.0" encoding="utf-8"?>
<CityModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.opengis.net/citygml/2.0"
	xmlns:xAL="urn:oasis:names:tc:ciq:xsdschema:xAL:2.0" xmlns:xlink="http://www.w3.org/1999/xlink"
	xmlns:gml="http://www.opengis.net/gml" xmlns:dem="http://www.opengis.net/citygml/relief/2.0"
	xmlns:bldg="http://www.opengis.net/citygml/building/2.0"
	xsi:schemaLocation="http://www.opengis.net/citygml/building/2.0 ../../CityGML/building.xsd http://www.opengis.net/citygml/relief/2.0 ../../CityGML/relief.xsd">
	<gml:name>Simple terrain in CityGML</gml:name>
	<gml:boundedBy>
		<gml:Envelope srsDimension="3" srsName="urn:ogc:def:crs,crs:EPSG::25832,crs:EPSG::5783">
			<gml:lowerCorner>659762 191310 469.229</gml:lowerCorner>
			<gml:upperCorner>663110 193916 669.231</gml:upperCorner>
		</gml:Envelope>
	</gml:boundedBy>	
	<cityObjectMember>
		<dem:ReliefFeature gml:id="GML_6bb30328-7599-4500-90ef-766fde6aa67b">
			<gml:name>Sample TIN </gml:name>
			<dem:lod>1</dem:lod>
			<dem:reliefComponent>
				<dem:TINRelief gml:id="GML_4eb161b0-aa7e-4087-937c-5c4c427c7fc9">
					<gml:name>TIN</gml:name>
					<dem:lod>1</dem:lod>
					<dem:tin>
						<gml:TriangulatedSurface gml:id="ground">
							<gml:trianglePatches>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660498 192196 669.231 659762 191342 469.229 660880 191580 469.23 660498 192196 669.231</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>659762 191342 469.229 661198 191314 473.348 660880 191580 469.23 659762 191342 469.229</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660498 192196 669.231 659846 192090 570.952 659762 191342 469.229 660498 192196 669.231</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660880 191580 469.23 661544 191310 515.777 661256 192472 669.231 660880 191580 469.23</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660326 192906 569.233 659846 192090 570.952 660498 192196 669.231 660326 192906 569.233</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660880 191580 469.23 661198 191314 473.348 661544 191310 515.777 660880 191580 469.23</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660494 193544 516.617 659846 192090 570.952 660326 192906 569.233 660494 193544 516.617</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>661256 192472 669.231 662114 192558 666.814 662198 193446 581.147 661256 192472 669.231</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660326 192906 569.233 661256 192472 669.231 660494 193544 516.617 660326 192906 569.233</gml:posList>
										</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>663004 193592 590.816 663110 193562 581.412 662160 193916 474.141 663004 193592 590.816</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>662198 193446 581.147 663004 193592 590.816 662160 193916 474.141 662198 193446 581.147</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>662198 193446 581.147 662114 192558 666.814 663004 193592 590.816 662198 193446 581.147</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660494 193544 516.617 662198 193446 581.147 662160 193916 474.141 660494 193544 516.617</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>

								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>662114 192558 666.814 663110 193562 581.412 663004 193592 590.816 662114 192558 666.814</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>

								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>

											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>

								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660494 193544 516.617 661256 192472 669.231 662198 193446 581.147 660494 193544 516.617</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>661256 192472 669.231 661544 191310 515.777 662114 192558 666.814 661256 192472 669.231</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
												<gml:posList>660498 192196 669.231 661256 192472 669.231 660326 192906 569.233 660498 192196 669.231</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>660498 192196 669.231 660880 191580 469.23 661256 192472 669.231 660498 192196 669.231</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
								<gml:Triangle>
									<gml:exterior>
										<gml:LinearRing>
											<gml:posList>662114 192558 666.814 661544 191310 515.777 663110 193562 581.412 662114 192558 666.814</gml:posList>
											</gml:LinearRing>
									</gml:exterior>
								</gml:Triangle>
							</gml:trianglePatches>
						</gml:TriangulatedSurface>
					</dem:tin>
				</dem:TINRelief>
			</dem:reliefComponent>
		</dem:ReliefFeature>
	</cityObjectMember>
</CityModel>
