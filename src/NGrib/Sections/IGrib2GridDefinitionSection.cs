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

namespace NGrib.Sections
{
    public interface IGrib2GridDefinitionSection
    {
        float Altitude { get; }
        int Angle { get; }
        string CheckSum { get; }
        float Dstart { get; }
        float Dx { get; }
        float Dy { get; }
        float EarthRadius { get; }
        float Factor { get; }
        int Gdtn { get; }
        string getShapeName();
        int Iolon { get; }
        float J { get; }
        float K { get; }
        float La1 { get; }
        float La2 { get; }
        float Lad { get; }
        float Lap { get; }
        float Latin1 { get; }
        float Latin2 { get; }
        float Lo1 { get; }
        float Lo2 { get; }
        float Lop { get; }
        float Lov { get; }
        float M { get; }
        float MajorAxis { get; }
        int Method { get; }
        float MinorAxis { get; }
        int Mode { get; }
        int N { get; }
        int N2 { get; }
        int N3 { get; }
        string Name { get; }
        float Nb { get; }
        int Nd { get; }
        int Ni { get; }
        float Nr { get; }
        int NumberPoints { get; }
        int Nx { get; }
        int Ny { get; }
        int Olon { get; }
        int Order { get; }
        float PoleLat { get; }
        float PoleLon { get; }
        int Position { get; }
        int ProjectionCenter { get; }
        int Resolution { get; }
        float Rotationangle { get; }
        int ScanMode { get; }
        int Shape { get; }
        int Source { get; }
        float SpLat { get; }
        float SpLon { get; }
        int Subdivisionsangle { get; }
        float Xo { get; }
        float Xp { get; }
        float Yo { get; }
        float Yp { get; }
    }
}
