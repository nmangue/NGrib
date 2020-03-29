/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System.IO;
using NGrib.Grib2.Templates;
using NGrib.Grib2.Templates.GridDefinitions;

namespace NGrib.Grib2.Sections
{
	/// <summary>
	/// Section 3 - Grid Definition Section
	/// </summary>
	public sealed class GridDefinitionSection
	{
		/// <summary>
		/// Length of section in octets.
		/// </summary>
		public long Length { get; }

		/// <summary>
		/// Number of section.
		/// </summary>
		public int Section { get; }

		/// <summary>
		/// Source of grid definition.
		/// </summary>
		public int Source { get; }

		/// <summary>
		/// Number of data points.
		/// </summary>
		public long DataPointsNumber { get; }

		/// <summary>
		/// Number of octets for optional list of numbers defining number of points.
		/// </summary>
		public int OptionalListNumberLength { get; }

		/// <summary>
		/// Interpretation of list of numbers defining number of points.
		/// </summary>
		public int OptionalListInterpretationCode { get; }

		/// <summary>
		/// Grid Definition Template Number
		/// </summary>
		public int TemplateNumber { get; }

		/// <summary>
		/// Grid Definition Template
		/// </summary>
		public GridDefinition GridDefinition { get; }

		private GridDefinitionSection(
			long length,
			int section,
			int source,
			long dataPointsNumber,
			int oLon,
			int ioLon,
			int templateNumber,
			GridDefinition gridDefinition)
		{
			TemplateNumber = templateNumber;
			Length = length;
			Section = section;
			Source = source;
			DataPointsNumber = dataPointsNumber;
			OptionalListNumberLength = oLon;
			OptionalListInterpretationCode = ioLon;
			GridDefinition = gridDefinition;
		}

		internal static GridDefinitionSection BuildFrom(BufferedBinaryReader reader)
		{
			var currentPosition = reader.Position;
			var length = reader.ReadUInt32();

			var section = reader.ReadUInt8(); // This is section 3

			if (section != (int) SectionCode.GridDefinitionSection)
			{
				throw new NoValidGribException("Expected section 3");
			}

			var source = reader.ReadUInt8();

			var numberPoints = reader.ReadUInt32();

			var olLength = reader.ReadUInt8();

			var olInterpretation = reader.ReadUInt8();

			var templateNumber = reader.ReadUInt16();

			var gridDefinition = GridDefinitionFactories.Build(reader, templateNumber);

			// Prevent from over-reading the stream
			reader.Seek(currentPosition + length, SeekOrigin.Begin);

			return new GridDefinitionSection(length, section, source, numberPoints, olLength, olInterpretation,
				templateNumber, gridDefinition);
		}

		private static readonly TemplateFactory<GridDefinition> GridDefinitionFactories =
			new TemplateFactory<GridDefinition>
			{
				{0, r => new LatLonGridDefinition(r)},
				{1, r => new RotatedLatLonGridDefinition(r)},
				{2, r => new StretchedLatLonGridDefinition(r)},
				{3, r => new StretchedRotatedLatLonGridDefinition(r)},
				{10, r => new MercatorGridDefinition(r)},
				{20, r => new PolarStereographicProjectionGridDefinition(r)},
				{30, r => new LambertConformalGridDefinition(r)},
				{31, r => new AlbersEqualAreaGridDefinition(r)},
				{40, r => new GaussianLatLonGridDefinition(r)},
				{41, r => new RotatedGaussianLatLonGridDefinition(r)},
				{42, r => new StretchedGaussianLatLonGridDefinition(r)},
				{43, r => new StretchedRotatedGaussianLatLonGridDefinition(r)},
				{50, r => new SphericalHarmonicCoefficientsGridDefinition(r)},
				{51, r => new RotatedSphericalHarmonicCoefficientsGridDefinition(r)},
				{52, r => new StretchedSphericalHarmonicCoefficientsGridDefinition(r)},
				{53, r => new StretchedRotatedSphericalHarmonicCoefficientsGridDefinition(r)},
				{90, r => new SpaceViewPerspectiveOrOrthographicGridDefinition(r)},
				{100, r => new TriangularGridBasedOnAnIcosahedronGridDefinition(r)},
				{110, r => new EquatorialAzimuthalEquidistantProjectionGridDefinition(r)}
			};
	}
}