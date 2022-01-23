/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
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

namespace NGrib.Grib1
{
	public sealed class Grib1WaveSpectra2DDirFreq
	{
		private string version;

		public string Version
		{
			get { return version; }
		}

		// one-offset
		private int directionNumber;

		public int DirectionNumber
		{
			get { return directionNumber; }
		}

		// one-offset
		private int frequencyNumber;

		public int FrequencyNumber
		{
			get { return frequencyNumber; }
		}

		private int numberOfDirections;

		public int NumberOfDirections
		{
			get { return numberOfDirections; }
		}

		private int numberOfFrequencies;

		public int NumberOfFrequencies
		{
			get { return numberOfFrequencies; }
		}

		private int dirScaleFactor;

		public int DirScaleFactor
		{
			get { return dirScaleFactor; }
		}

		private int freqScaleFactor;

		public int FreqScaleFactor
		{
			get { return freqScaleFactor; }
		}

		private double[] directions;

		public double[] Directions
		{
			get { return directions; }
		}

		private double[] frequencies;

		public double[] Frequencies
		{
			get { return frequencies; }
		}

		/// <summary>
		/// The direction [deg].
		/// </summary>
		public double Direction
		{
			get { return directions[directionNumber - 1]; }
		}

		/// <summary>
		/// The frequency [Hz];
		/// </summary>
		public double Frequency
		{
			get { return frequencies[frequencyNumber - 1]; }
		}


		internal Grib1WaveSpectra2DDirFreq(System.IO.Stream raf)
		{
			SupportClass.Skip(raf, 4);

			byte[] ver = GribNumbers.ReadBytes(raf, 4);
			System.Text.Encoding enc = System.Text.Encoding.ASCII;
			version = enc.GetString(ver);

			SupportClass.Skip(raf, 2);

			directionNumber = raf.ReadByte();
			frequencyNumber = raf.ReadByte();
			numberOfDirections = raf.ReadByte();
			numberOfFrequencies = raf.ReadByte();
			dirScaleFactor = GribNumbers.int4(raf);
			freqScaleFactor = GribNumbers.int4(raf);

			SupportClass.Skip(raf, 37);

			directions = new double[numberOfDirections];
			frequencies = new double[numberOfFrequencies];

			for (int i = 0; i < numberOfDirections; i++)
			{
				int val = GribNumbers.int4(raf);
				directions[i] = (double) val / (double) dirScaleFactor;
			}

			for (int i = 0; i < numberOfFrequencies; i++)
			{
				int val = GribNumbers.int4(raf);
				frequencies[i] = (double) val / (double) freqScaleFactor;
			}
		}
	}
}