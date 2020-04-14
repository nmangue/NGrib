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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NGrib.Grib2.CodeTables
{
	[SuppressMessage("ReSharper", "IdentifierTypo")]
	[SuppressMessage("ReSharper", "CommentTypo")]
	[SuppressMessage("ReSharper", "StringLiteralTypo")]
	public readonly struct Center
	{
		public int Id { get; }
		public string Name { get; }

		private Center(int id, string name = null)
		{
			Id = id;
			Name = name;
		}

		public bool Equals(Center other) => Id == other.Id;

		public override bool Equals(object obj) => obj is Center other && Equals(other);

		public override int GetHashCode() => Id.GetHashCode();

		public static Center GetCenterById(int centerId)
		{
			var centers = AllCenters.Where(c => c.Id == centerId).ToArray();
			return centers.Any() ? centers[0] : new Center(centerId);
		}

		///<summary>WMO Secretariat (0)</summary>
		public static Center WmoSecretariat { get; } = new Center(0, "WMO Secretariat");

		///<summary>Melbourne (1)</summary>
		public static Center Melbourne { get; } = new Center(1, "Melbourne");

		///<summary>Melbourne (2)</summary>
		public static Center Melbourne2 { get; } = new Center(2, "Melbourne");

		///<summary>Melbourne (3)</summary>
		public static Center Melbourne3 { get; } = new Center(3, "Melbourne");

		///<summary>Moscow (4)</summary>
		public static Center Moscow { get; } = new Center(4, "Moscow");

		///<summary>Moscow (5)</summary>
		public static Center Moscow5 { get; } = new Center(5, "Moscow");

		///<summary>Moscow (6)</summary>
		public static Center Moscow6 { get; } = new Center(6, "Moscow");

		///<summary>US National Weather Service, National Centers for Environmental Prediction (NCEP) (7)</summary>
		public static Center UsNcep { get; } = new Center(7,
			"US National Weather Service, National Centers for Environmental Prediction (NCEP)");

		///<summary>US National Weather Service Telecommunications Gateway (NWSTG) (8)</summary>
		public static Center UsNwstg { get; } =
			new Center(8, "US National Weather Service Telecommunications Gateway (NWSTG)");

		///<summary>US National Weather Service - Other (9)</summary>
		public static Center UsNwsOther { get; } = new Center(9, "US National Weather Service - Other");

		///<summary>Cairo (RSMC) (10)</summary>
		public static Center Cairo { get; } = new Center(10, "Cairo (RSMC)");

		///<summary>Cairo (RSMC) (11)</summary>
		public static Center CairoReserved { get; } = new Center(11, "Cairo (RSMC)");

		///<summary>Dakar (RSMC) (12)</summary>
		public static Center Dakar { get; } = new Center(12, "Dakar (RSMC)");

		///<summary>Dakar (RSMC) (13)</summary>
		public static Center DakarReserved { get; } = new Center(13, "Dakar (RSMC)");

		///<summary>Nairobi (RSMC) (14)</summary>
		public static Center Nairobi { get; } = new Center(14, "Nairobi (RSMC)");

		///<summary>Nairobi (RSMC) (15)</summary>
		public static Center NairobiReserved { get; } = new Center(15, "Nairobi (RSMC)");

		///<summary>Casablanca (RSMC) (16)</summary>
		public static Center Casablanca { get; } = new Center(16, "Casablanca (RSMC)");

		///<summary>Tunis (RSMC) (17)</summary>
		public static Center Tunis { get; } = new Center(17, "Tunis (RSMC)");

		///<summary>Tunis-Casablanca (RSMC) (18)</summary>
		public static Center TunisCasablanca { get; } = new Center(18, "Tunis-Casablanca (RSMC)");

		///<summary>Tunis-Casablanca (RSMC) (19)</summary>
		public static Center TunisCasablancaReserved { get; } = new Center(19, "Tunis-Casablanca (RSMC)");

		///<summary>Las Palmas (20)</summary>
		public static Center LasPalmas { get; } = new Center(20, "Las Palmas");

		///<summary>Algiers (RSMC) (21)</summary>
		public static Center Algiers { get; } = new Center(21, "Algiers (RSMC)");

		///<summary>ACMAD (22)</summary>
		public static Center Acmad { get; } = new Center(22, "ACMAD");

		///<summary>Mozambique (NMC) (23)</summary>
		public static Center Mozambique { get; } = new Center(23, "Mozambique (NMC)");

		///<summary>Pretoria (RSMC) (24)</summary>
		public static Center Pretoria { get; } = new Center(24, "Pretoria (RSMC)");

		///<summary>La Réunion (RSMC) (25)</summary>
		public static Center LaReunion { get; } = new Center(25, "La Réunion (RSMC)");

		///<summary>Khabarovsk (RSMC) (26)</summary>
		public static Center Khabarovsk { get; } = new Center(26, "Khabarovsk (RSMC)");

		///<summary>Khabarovsk (RSMC) (27)</summary>
		public static Center KhabarovskReserved { get; } = new Center(27, "Khabarovsk (RSMC)");

		///<summary>New Delhi (RSMC) (28)</summary>
		public static Center NewDelhi { get; } = new Center(28, "New Delhi (RSMC)");

		///<summary>New Delhi (RSMC) (29)</summary>
		public static Center NewDelhiReserved { get; } = new Center(29, "New Delhi (RSMC)");

		///<summary>Novosibirsk (RSMC) (30)</summary>
		public static Center Novosibirsk { get; } = new Center(30, "Novosibirsk (RSMC)");

		///<summary>Novosibirsk (RSMC) (31)</summary>
		public static Center NovosibirskReserved { get; } = new Center(31, "Novosibirsk (RSMC)");

		///<summary>Tashkent (RSMC) (32)</summary>
		public static Center Tashkent { get; } = new Center(32, "Tashkent (RSMC)");

		///<summary>Jeddah (RSMC) (33)</summary>
		public static Center Jeddah { get; } = new Center(33, "Jeddah (RSMC)");

		///<summary>Tokyo (RSMC), Japan Meteorological Agency (34)</summary>
		public static Center Tokyo { get; } = new Center(34, "Tokyo (RSMC), Japan Meteorological Agency");

		///<summary>Tokyo (RSMC), Japan Meteorological Agency (35)</summary>
		public static Center TokyoReserved { get; } = new Center(35, "Tokyo (RSMC), Japan Meteorological Agency");

		///<summary>Bangkok (36)</summary>
		public static Center Bangkok { get; } = new Center(36, "Bangkok");

		///<summary>Ulaanbaatar (37)</summary>
		public static Center Ulaanbaatar { get; } = new Center(37, "Ulaanbaatar");

		///<summary>Beijing (RSMC) (38)</summary>
		public static Center Beijing { get; } = new Center(38, "Beijing (RSMC)");

		///<summary>Beijing (RSMC) (39)</summary>
		public static Center BeijingReserved { get; } = new Center(39, "Beijing (RSMC)");

		///<summary>Seoul (40)</summary>
		public static Center Seoul { get; } = new Center(40, "Seoul");

		///<summary>Buenos Aires (RSMC) (41)</summary>
		public static Center BuenosAires { get; } = new Center(41, "Buenos Aires (RSMC)");

		///<summary>Buenos Aires (RSMC) (42)</summary>
		public static Center BuenosAiresReserved { get; } = new Center(42, "Buenos Aires (RSMC)");

		///<summary>Brasilia (RSMC) (43)</summary>
		public static Center Brasilia { get; } = new Center(43, "Brasilia (RSMC)");

		///<summary>Brasilia (RSMC) (44)</summary>
		public static Center BrasiliaReserved { get; } = new Center(44, "Brasilia (RSMC)");

		///<summary>Santiago (45)</summary>
		public static Center Santiago { get; } = new Center(45, "Santiago");

		///<summary>Brazilian Space Agency ­ - INPE (46)</summary>
		public static Center BrazilianSpaceAgencyInpe { get; } = new Center(46, "Brazilian Space Agency ­ - INPE");

		///<summary>Colombia (NMC) (47)</summary>
		public static Center Colombia { get; } = new Center(47, "Colombia (NMC)");

		///<summary>Ecuador (NMC) (48)</summary>
		public static Center Ecuador { get; } = new Center(48, "Ecuador (NMC)");

		///<summary>Peru (NMC) (49)</summary>
		public static Center Peru { get; } = new Center(49, "Peru (NMC)");

		///<summary>Venezuela (Bolivarian Republic of) (NMC) (50)</summary>
		public static Center Venezuela { get; } = new Center(50, "Venezuela (Bolivarian Republic of) (NMC)");

		///<summary>Miami (RSMC) (51)</summary>
		public static Center Miami { get; } = new Center(51, "Miami (RSMC)");

		///<summary>Miami (RSMC), National Hurricane Center (52)</summary>
		public static Center MiamiNhc { get; } = new Center(52, "Miami (RSMC), National Hurricane Center");

		///<summary>Montreal (RSMC) (53)</summary>
		public static Center Montreal { get; } = new Center(53, "Montreal (RSMC)");

		///<summary>Montreal (RSMC) (54)</summary>
		public static Center MontrealReserved { get; } = new Center(54, "Montreal (RSMC)");

		///<summary>San Francisco (55)</summary>
		public static Center SanFrancisco { get; } = new Center(55, "San Francisco");

		///<summary>ARINC Center (56)</summary>
		public static Center ArincCenter { get; } = new Center(56, "ARINC Center");

		///<summary>U.S. Air Force - Air Force Global Weather Central (57)</summary>
		public static Center UsAfGwc { get; } = new Center(57, "U.S. Air Force - Air Force Global Weather Central");

		///<summary>Fleet Numerical Meteorology and Oceanography Center, Monterey, CA, USA (58)</summary>
		public static Center CaFnmoc { get; } =
			new Center(58, "Fleet Numerical Meteorology and Oceanography Center, Monterey, CA, USA");

		///<summary>The NOAA Forecast Systems Laboratory, Boulder, CO, USA (59)</summary>
		public static Center UsNoaaForecastSystemsLaboratory { get; } =
			new Center(59, "The NOAA Forecast Systems Laboratory, Boulder, CO, USA");

		///<summary>United States National Center for Atmospheric Research (NCAR) (60)</summary>
		public static Center UsNcar { get; } =
			new Center(60, "United States National Center for Atmospheric Research (NCAR)");

		///<summary>Service ARGOS - Landover (61)</summary>
		public static Center ArgosLandover { get; } = new Center(61, "Service ARGOS - Landover");

		///<summary>U.S. Naval Oceanographic Office (62)</summary>
		public static Center UsNoo { get; } = new Center(62, "U.S. Naval Oceanographic Office");

		///<summary>International Research Institute for Climate and Society (IRI ) (63)</summary>
		public static Center Iri { get; } =
			new Center(63, "International Research Institute for Climate and Society (IRI )");

		///<summary>Honolulu (RSMC) (64)</summary>
		public static Center Honolulu { get; } = new Center(64, "Honolulu (RSMC)");

		///<summary>Darwin (RSMC) (65)</summary>
		public static Center Darwin { get; } = new Center(65, "Darwin (RSMC)");

		///<summary>Darwin (RSMC) (66)</summary>
		public static Center DarwinReserved { get; } = new Center(66, "Darwin (RSMC)");

		///<summary>Melbourne (RSMC) (67)</summary>
		public static Center Melbourne67 { get; } = new Center(67, "Melbourne (RSMC)");

		///<summary>Wellington (RSMC) (69)</summary>
		public static Center Wellington { get; } = new Center(69, "Wellington (RSMC)");

		///<summary>Wellington (RSMC) (70)</summary>
		public static Center WellingtonReserved { get; } = new Center(70, "Wellington (RSMC)");

		///<summary>Nadi (RSMC) (71)</summary>
		public static Center Nadi { get; } = new Center(71, "Nadi (RSMC)");

		///<summary>Singapore (72)</summary>
		public static Center Singapore { get; } = new Center(72, "Singapore");

		///<summary>Malaysia (NMC) (73)</summary>
		public static Center Malaysia { get; } = new Center(73, "Malaysia (NMC)");

		///<summary>UK Meteorological Office - ­ Exeter (RSMC) (74)</summary>
		public static Center UkMeteorologicalOffice { get; } = new Center(74, "UK Meteorological Office - ­ Exeter (RSMC)");

		///<summary>UK Meteorological Office - ­ Exeter (RSMC) (75)</summary>
		public static Center UkMeteorologicalOfficeReserved { get; } =
			new Center(75, "UK Meteorological Office - ­ Exeter (RSMC)");

		///<summary>Moscow (RSMC) (76)</summary>
		public static Center Moscow76 { get; } = new Center(76, "Moscow (RSMC)");

		///<summary>Offenbach (RSMC) (78)</summary>
		public static Center Offenbach { get; } = new Center(78, "Offenbach (RSMC)");

		///<summary>Offenbach (RSMC) (79)</summary>
		public static Center OffenbachReserved { get; } = new Center(79, "Offenbach (RSMC)");

		///<summary>Rome (RSMC) (80)</summary>
		public static Center Rome { get; } = new Center(80, "Rome (RSMC)");

		///<summary>Rome (RSMC) (81)</summary>
		public static Center RomeReserved { get; } = new Center(81, "Rome (RSMC)");

		///<summary>Norrköping (82)</summary>
		public static Center Norrkoping { get; } = new Center(82, "Norrköping");

		///<summary>Norrköping (83)</summary>
		public static Center NorrkopingReserved { get; } = new Center(83, "Norrköping");

		///<summary>Toulouse (RSMC) (84)</summary>
		public static Center Toulouse { get; } = new Center(84, "Toulouse (RSMC)");

		///<summary>Toulouse (RSMC) (85)</summary>
		public static Center Toulouse85 { get; } = new Center(85, "Toulouse (RSMC)");

		///<summary>Helsinki (86)</summary>
		public static Center Helsinki { get; } = new Center(86, "Helsinki");

		///<summary>Belgrade (87)</summary>
		public static Center Belgrade { get; } = new Center(87, "Belgrade");

		///<summary>Oslo (88)</summary>
		public static Center Oslo { get; } = new Center(88, "Oslo");

		///<summary>Prague (89)</summary>
		public static Center Prague { get; } = new Center(89, "Prague");

		///<summary>Episkopi (90)</summary>
		public static Center Episkopi { get; } = new Center(90, "Episkopi");

		///<summary>Ankara (91)</summary>
		public static Center Ankara { get; } = new Center(91, "Ankara");

		///<summary>Frankfurt/Main (92)</summary>
		public static Center FrankfurtMain { get; } = new Center(92, "Frankfurt/Main");

		///<summary>London (WAFC) (93)</summary>
		public static Center London { get; } = new Center(93, "London (WAFC)");

		///<summary>Copenhagen (94)</summary>
		public static Center Copenhagen { get; } = new Center(94, "Copenhagen");

		///<summary>Rota (95)</summary>
		public static Center Rota { get; } = new Center(95, "Rota");

		///<summary>Athens (96)</summary>
		public static Center Athens { get; } = new Center(96, "Athens");

		///<summary>European Space Agency (ESA) (97)</summary>
		public static Center Esa { get; } = new Center(97, "European Space Agency (ESA)");

		///<summary>European Center for Medium Range Weather Forecasts (ECMWF) (RSMC) (98)</summary>
		public static Center Ecmwf { get; } =
			new Center(98, "European Center for Medium Range Weather Forecasts (ECMWF) (RSMC)");

		///<summary>De Bilt (99)</summary>
		public static Center DeBilt { get; } = new Center(99, "De Bilt");

		///<summary>Brazzaville (100)</summary>
		public static Center Brazzaville { get; } = new Center(100, "Brazzaville");

		///<summary>Abidjan (101)</summary>
		public static Center Abidjan { get; } = new Center(101, "Abidjan");

		///<summary>Libya (NMC) (102)</summary>
		public static Center Libya { get; } = new Center(102, "Libya (NMC)");

		///<summary>Madagascar (NMC) (103)</summary>
		public static Center Madagascar { get; } = new Center(103, "Madagascar (NMC)");

		///<summary>Mauritius (NMC) (104)</summary>
		public static Center Mauritius { get; } = new Center(104, "Mauritius (NMC)");

		///<summary>Niger (NMC) (105)</summary>
		public static Center Niger { get; } = new Center(105, "Niger (NMC)");

		///<summary>Seychelles (NMC) (106)</summary>
		public static Center Seychelles { get; } = new Center(106, "Seychelles (NMC)");

		///<summary>Uganda (NMC) (107)</summary>
		public static Center Uganda { get; } = new Center(107, "Uganda (NMC)");

		///<summary>United Republic of Tanzania (NMC) (108)</summary>
		public static Center Tanzania { get; } = new Center(108, "United Republic of Tanzania (NMC)");

		///<summary>Zimbabwe (NMC) (109)</summary>
		public static Center Zimbabwe { get; } = new Center(109, "Zimbabwe (NMC)");

		///<summary>Hong-Kong, China (110)</summary>
		public static Center HongKong { get; } = new Center(110, "Hong-Kong, China");

		///<summary>Afghanistan (NMC) (111)</summary>
		public static Center Afghanistan { get; } = new Center(111, "Afghanistan (NMC)");

		///<summary>Bahrain (NMC) (112)</summary>
		public static Center Bahrain { get; } = new Center(112, "Bahrain (NMC)");

		///<summary>Bangladesh (NMC) (113)</summary>
		public static Center Bangladesh { get; } = new Center(113, "Bangladesh (NMC)");

		///<summary>Bhutan (NMC) (114)</summary>
		public static Center Bhutan { get; } = new Center(114, "Bhutan (NMC)");

		///<summary>Cambodia (NMC) (115)</summary>
		public static Center Cambodia { get; } = new Center(115, "Cambodia (NMC)");

		///<summary>Democratic People's Republic of Korea (NMC) (116)</summary>
		public static Center DprKorea { get; } = new Center(116, "Democratic People's Republic of Korea (NMC)");

		///<summary>Islamic Republic of Iran (NMC) (117)</summary>
		public static Center Iran { get; } = new Center(117, "Islamic Republic of Iran (NMC)");

		///<summary>Iraq (NMC) (118)</summary>
		public static Center Iraq { get; } = new Center(118, "Iraq (NMC)");

		///<summary>Kazakhstan (NMC) (119)</summary>
		public static Center Kazakhstan { get; } = new Center(119, "Kazakhstan (NMC)");

		///<summary>Kuwait (NMC) (120)</summary>
		public static Center Kuwait { get; } = new Center(120, "Kuwait (NMC)");

		///<summary>Kyrgyzstan (NMC) (121)</summary>
		public static Center Kyrgyzstan { get; } = new Center(121, "Kyrgyzstan (NMC)");

		///<summary>Lao People's Democratic Republic (NMC) (122)</summary>
		public static Center Laos { get; } = new Center(122, "Lao People's Democratic Republic (NMC)");

		///<summary>Macao, China (123)</summary>
		public static Center Macao { get; } = new Center(123, "Macao, China");

		///<summary>Maldives (NMC) (124)</summary>
		public static Center Maldives { get; } = new Center(124, "Maldives (NMC)");

		///<summary>Myanmar (NMC) (125)</summary>
		public static Center Myanmar { get; } = new Center(125, "Myanmar (NMC)");

		///<summary>Nepal (NMC) (126)</summary>
		public static Center Nepal { get; } = new Center(126, "Nepal (NMC)");

		///<summary>Oman (NMC) (127)</summary>
		public static Center Oman { get; } = new Center(127, "Oman (NMC)");

		///<summary>Pakistan (NMC) (128)</summary>
		public static Center Pakistan { get; } = new Center(128, "Pakistan (NMC)");

		///<summary>Qatar (NMC) (129)</summary>
		public static Center Qatar { get; } = new Center(129, "Qatar (NMC)");

		///<summary>Yemen (NMC) (130)</summary>
		public static Center Yemen { get; } = new Center(130, "Yemen (NMC)");

		///<summary>Sri Lanka, (NMC) (131)</summary>
		public static Center SriLanka { get; } = new Center(131, "Sri Lanka, (NMC)");

		///<summary>Tajikistan (NMC) (132)</summary>
		public static Center Tajikistan { get; } = new Center(132, "Tajikistan (NMC)");

		///<summary>Turkmenistan (NMC) (133)</summary>
		public static Center Turkmenistan { get; } = new Center(133, "Turkmenistan (NMC)");

		///<summary>United Arab Emirates (NMC) (134)</summary>
		public static Center Emirates { get; } = new Center(134, "United Arab Emirates (NMC)");

		///<summary>Uzbekistan, (NMC) (135)</summary>
		public static Center Uzbekistan { get; } = new Center(135, "Uzbekistan, (NMC)");

		///<summary>Viet Nam (NMC) (136)</summary>
		public static Center Vietnam { get; } = new Center(136, "Viet Nam (NMC)");

		///<summary>Bolivia (Plurinational State of) (NMC) (140)</summary>
		public static Center Bolivia { get; } = new Center(140, "Bolivia (Plurinational State of) (NMC)");

		///<summary>Guyana (NMC) (141)</summary>
		public static Center Guyana { get; } = new Center(141, "Guyana (NMC)");

		///<summary>Paraguay (NMC) (142)</summary>
		public static Center Paraguay { get; } = new Center(142, "Paraguay (NMC)");

		///<summary>Suriname (NMC) (143)</summary>
		public static Center Suriname { get; } = new Center(143, "Suriname (NMC)");

		///<summary>Uruguay (NMC) (144)</summary>
		public static Center Uruguay { get; } = new Center(144, "Uruguay (NMC)");

		///<summary>French Guyana (145)</summary>
		public static Center FrenchGuyana { get; } = new Center(145, "French Guyana");

		///<summary>Brazilian Navy Hydrographic Center (146)</summary>
		public static Center BrNhc { get; } = new Center(146, "Brazilian Navy Hydrographic Center");

		///<summary>National Commission on Space Activities  (CONAE) - Argentina (147)</summary>
		public static Center ArConaz { get; } =
			new Center(147, "National Commission on Space Activities  (CONAE) - Argentina");

		///<summary>Antigua and Barbuda (NMC) (150)</summary>
		public static Center AntiguaBarbuda { get; } = new Center(150, "Antigua and Barbuda (NMC)");

		///<summary>Bahamas (NMC) (151)</summary>
		public static Center Bahamas { get; } = new Center(151, "Bahamas (NMC)");

		///<summary>Barbados (NMC) (152)</summary>
		public static Center Barbados { get; } = new Center(152, "Barbados (NMC)");

		///<summary>Belize (NMC) (153)</summary>
		public static Center Belize { get; } = new Center(153, "Belize (NMC)");

		///<summary>British Caribbean Territories Center (154)</summary>
		public static Center Caribbean { get; } = new Center(154, "British Caribbean Territories Center");

		///<summary>San José (155)</summary>
		public static Center SanJose { get; } = new Center(155, "San José");

		///<summary>Cuba (NMC) (156)</summary>
		public static Center Cuba { get; } = new Center(156, "Cuba (NMC)");

		///<summary>Dominica (NMC) (157)</summary>
		public static Center Dominica { get; } = new Center(157, "Dominica (NMC)");

		///<summary>Dominican Republic (NMC) (158)</summary>
		public static Center DominicanRepublic { get; } = new Center(158, "Dominican Republic (NMC)");

		///<summary>El Salvador (NMC) (159)</summary>
		public static Center ElSalvador { get; } = new Center(159, "El Salvador (NMC)");

		///<summary>US NOAA/NESDIS  (160)</summary>
		public static Center UsNoaaNesdis { get; } = new Center(160, "US NOAA/NESDIS ");

		///<summary>US NOAA Office of Oceanic and Atmospheric Research (161)</summary>
		public static Center UsNoaaOar { get; } = new Center(161, "US NOAA Office of Oceanic and Atmospheric Research");

		///<summary>Guatemala (NMC) (162)</summary>
		public static Center Guatemala { get; } = new Center(162, "Guatemala (NMC)");

		///<summary>Haiti (NMC) (163)</summary>
		public static Center Haiti { get; } = new Center(163, "Haiti (NMC)");

		///<summary>Honduras (NMC) (164)</summary>
		public static Center Honduras { get; } = new Center(164, "Honduras (NMC)");

		///<summary>Jamaica (NMC) (165)</summary>
		public static Center Jamaica { get; } = new Center(165, "Jamaica (NMC)");

		///<summary>Mexico City (166)</summary>
		public static Center MexicoCity { get; } = new Center(166, "Mexico City");

		///<summary>Curaçao and Sint Maarten (NMC) (167)</summary>
		public static Center CuracaoSintMaarten { get; } = new Center(167, "Curaçao and Sint Maarten (NMC)");

		///<summary>Nicaragua (NMC) (168)</summary>
		public static Center Nicaragua { get; } = new Center(168, "Nicaragua (NMC)");

		///<summary>Panama (NMC) (169)</summary>
		public static Center Panama { get; } = new Center(169, "Panama (NMC)");

		///<summary>Saint Lucia (NMC) (170)</summary>
		public static Center SaintLucia { get; } = new Center(170, "Saint Lucia (NMC)");

		///<summary>Trinidad and Tobago (NMC) (171)</summary>
		public static Center TrinidadTobago { get; } = new Center(171, "Trinidad and Tobago (NMC)");

		///<summary>French Departments in RA IV (172)</summary>
		public static Center FrenchDepartments { get; } = new Center(172, "French Departments in RA IV");

		///<summary>US National Aeronautics and Space Administration (NASA) (173)</summary>
		public static Center UsNasa { get; } = new Center(173, "US National Aeronautics and Space Administration (NASA)");

		///<summary>Integrated System Data Management/Marine Environmental Data Service (ISDM/MEDS) - Canada (174)</summary>
		public static Center CaIsdmMeds { get; } = new Center(174,
			"Integrated System Data Management/Marine Environmental Data Service (ISDM/MEDS) - Canada");

		///<summary>University Corporation for Atmospheric Research (UCAR) - United States (175)</summary>
		public static Center UsUcar { get; } =
			new Center(175, "University Corporation for Atmospheric Research (UCAR) - United States");

		///<summary>Cooperative Institute for Meteorological Satellite Studies (CIMSS) - United States (176)</summary>
		public static Center UsCimss { get; } = new Center(176,
			"Cooperative Institute for Meteorological Satellite Studies (CIMSS) - United States");

		///<summary>NOAA National Ocean Service - United States (177)</summary>
		public static Center UsNoaaNos { get; } = new Center(177, "NOAA National Ocean Service - United States");

		///<summary>Cook Islands (NMC) (190)</summary>
		public static Center CookIslands { get; } = new Center(190, "Cook Islands (NMC)");

		///<summary>French Polynesia (NMC) (191)</summary>
		public static Center FrenchPolynesia { get; } = new Center(191, "French Polynesia (NMC)");

		///<summary>Tonga (NMC) (192)</summary>
		public static Center Tonga { get; } = new Center(192, "Tonga (NMC)");

		///<summary>Vanuatu (NMC) (193)</summary>
		public static Center Vanuatu { get; } = new Center(193, "Vanuatu (NMC)");

		///<summary>Brunei Darussalam (NMC) (194)</summary>
		public static Center BruneiDarussalam { get; } = new Center(194, "Brunei Darussalam (NMC)");

		///<summary>Indonesia (NMC) (195)</summary>
		public static Center Indonesia { get; } = new Center(195, "Indonesia (NMC)");

		///<summary>Kiribati (NMC) (196)</summary>
		public static Center Kiribati { get; } = new Center(196, "Kiribati (NMC)");

		///<summary>Federated States of Micronesia (NMC) (197)</summary>
		public static Center Micronesia { get; } = new Center(197, "Federated States of Micronesia (NMC)");

		///<summary>New Caledonia (NMC) (198)</summary>
		public static Center NewCaledonia { get; } = new Center(198, "New Caledonia (NMC)");

		///<summary>Niue (199)</summary>
		public static Center Niue { get; } = new Center(199, "Niue");

		///<summary>Papua New Guinea (NMC) (200)</summary>
		public static Center PapuaNewGuinea { get; } = new Center(200, "Papua New Guinea (NMC)");

		///<summary>Philippines (NMC) (201)</summary>
		public static Center Philippines { get; } = new Center(201, "Philippines (NMC)");

		///<summary>Samoa (NMC) (202)</summary>
		public static Center Samoa { get; } = new Center(202, "Samoa (NMC)");

		///<summary>Solomon Islands (NMC) (203)</summary>
		public static Center SolomonIslands { get; } = new Center(203, "Solomon Islands (NMC)");

		///<summary>National Institute of Water and Atmospheric Research (NIWA - New Zealand) (204)</summary>
		public static Center NzNiwa { get; } =
			new Center(204, "National Institute of Water and Atmospheric Research (NIWA - New Zealand)");

		///<summary>Frascati (ESA/ESRIN) (210)</summary>
		public static Center Frascati { get; } = new Center(210, "Frascati (ESA/ESRIN)");

		///<summary>Lanion (211)</summary>
		public static Center Lanion { get; } = new Center(211, "Lanion");

		///<summary>Lisboa (212)</summary>
		public static Center Lisboa { get; } = new Center(212, "Lisboa");

		///<summary>Reykjavik (213)</summary>
		public static Center Reykjavik { get; } = new Center(213, "Reykjavik");

		///<summary>Madrid (214)</summary>
		public static Center Madrid { get; } = new Center(214, "Madrid");

		///<summary>Zürich (215)</summary>
		public static Center Zurich { get; } = new Center(215, "Zürich");

		///<summary>Service ARGOS - Toulouse (216)</summary>
		public static Center ToulouseArgos { get; } = new Center(216, "Service ARGOS - Toulouse");

		///<summary>Bratislava (217)</summary>
		public static Center Bratislava { get; } = new Center(217, "Bratislava");

		///<summary>Budapest (218)</summary>
		public static Center Budapest { get; } = new Center(218, "Budapest");

		///<summary>Ljubljana (219)</summary>
		public static Center Ljubljana { get; } = new Center(219, "Ljubljana");

		///<summary>Warsaw (220)</summary>
		public static Center Warsaw { get; } = new Center(220, "Warsaw");

		///<summary>Zagreb (221)</summary>
		public static Center Zagreb { get; } = new Center(221, "Zagreb");

		///<summary>Albania (NMC) (222)</summary>
		public static Center Albania { get; } = new Center(222, "Albania (NMC)");

		///<summary>Armenia (NMC) (223)</summary>
		public static Center Armenia { get; } = new Center(223, "Armenia (NMC)");

		///<summary>Austria (NMC) (224)</summary>
		public static Center Austria { get; } = new Center(224, "Austria (NMC)");

		///<summary>Azerbaijan (NMC) (225)</summary>
		public static Center Azerbaijan { get; } = new Center(225, "Azerbaijan (NMC)");

		///<summary>Belarus (NMC) (226)</summary>
		public static Center Belarus { get; } = new Center(226, "Belarus (NMC)");

		///<summary>Belgium (NMC) (227)</summary>
		public static Center Belgium { get; } = new Center(227, "Belgium (NMC)");

		///<summary>Bosnia and Herzegovina (NMC) (228)</summary>
		public static Center BosniaHerzegovina { get; } = new Center(228, "Bosnia and Herzegovina (NMC)");

		///<summary>Bulgaria (NMC) (229)</summary>
		public static Center Bulgaria { get; } = new Center(229, "Bulgaria (NMC)");

		///<summary>Cyprus (NMC) (230)</summary>
		public static Center Cyprus { get; } = new Center(230, "Cyprus (NMC)");

		///<summary>Estonia (NMC) (231)</summary>
		public static Center Estonia { get; } = new Center(231, "Estonia (NMC)");

		///<summary>Georgia (NMC) (232)</summary>
		public static Center Georgia { get; } = new Center(232, "Georgia (NMC)");

		///<summary>Dublin (233)</summary>
		public static Center Dublin { get; } = new Center(233, "Dublin");

		///<summary>Israel (NMC) (234)</summary>
		public static Center Israel { get; } = new Center(234, "Israel (NMC)");

		///<summary>Jordan (NMC) (235)</summary>
		public static Center Jordan { get; } = new Center(235, "Jordan (NMC)");

		///<summary>Latvia (NMC) (236)</summary>
		public static Center Latvia { get; } = new Center(236, "Latvia (NMC)");

		///<summary>Lebanon (NMC) (237)</summary>
		public static Center Lebanon { get; } = new Center(237, "Lebanon (NMC)");

		///<summary>Lithuania (NMC) (238)</summary>
		public static Center Lithuania { get; } = new Center(238, "Lithuania (NMC)");

		///<summary>Luxembourg (239)</summary>
		public static Center Luxembourg { get; } = new Center(239, "Luxembourg");

		///<summary>Malta (NMC) (240)</summary>
		public static Center Malta { get; } = new Center(240, "Malta (NMC)");

		///<summary>Monaco (241)</summary>
		public static Center Monaco { get; } = new Center(241, "Monaco");

		///<summary>Romania (NMC) (242)</summary>
		public static Center Romania { get; } = new Center(242, "Romania (NMC)");

		///<summary>Syrian Arab Republic (NMC) (243)</summary>
		public static Center Syria { get; } = new Center(243, "Syrian Arab Republic (NMC)");

		///<summary>The former Yugoslav Republic of Macedonia (NMC) (244)</summary>
		public static Center NorthMacedonia { get; } = new Center(244, "The former Yugoslav Republic of Macedonia (NMC)");

		///<summary>Ukraine (NMC) (245)</summary>
		public static Center Ukraine { get; } = new Center(245, "Ukraine (NMC)");

		///<summary>Republic of Moldova (NMC) (246)</summary>
		public static Center Moldova { get; } = new Center(246, "Republic of Moldova (NMC)");

		///<summary>Operational Programme for the Exchange of weather RAdar information (OPERA) - EUMETNET (247)</summary>
		public static Center EumetnetOpera { get; } = new Center(247,
			"Operational Programme for the Exchange of weather RAdar information (OPERA) - EUMETNET");

		///<summary>Montenegro (NMC) (248)</summary>
		public static Center Montenegro { get; } = new Center(248, "Montenegro (NMC)");

		///<summary>COnsortium for Small scale MOdelling (COSMO) (250)</summary>
		public static Center Cosmo { get; } = new Center(250, "COnsortium for Small scale MOdelling (COSMO)");

		///<summary>Meteorological Cooperation on Operational NWP (MetCoOp) (251)</summary>
		public static Center MetCoOp { get; } = new Center(251, "Meteorological Cooperation on Operational NWP (MetCoOp)");

		///<summary>Max Planck Institute for Meteorology (MPI-M) (252)</summary>
		public static Center MpiM { get; } = new Center(252, "Max Planck Institute for Meteorology (MPI-M)");

		///<summary>EUMETSAT Operation Center (254)</summary>
		public static Center Eumetsat { get; } = new Center(254, "EUMETSAT Operation Center");

		public static IReadOnlyCollection<Center> AllCenters = new List<Center>
		{
			WmoSecretariat,
			Melbourne,
			Melbourne2,
			Melbourne3,
			Moscow,
			Moscow5,
			Moscow6,
			UsNcep,
			UsNwstg,
			UsNwsOther,
			Cairo,
			CairoReserved,
			Dakar,
			DakarReserved,
			Nairobi,
			NairobiReserved,
			Casablanca,
			Tunis,
			TunisCasablanca,
			TunisCasablancaReserved,
			LasPalmas,
			Algiers,
			Acmad,
			Mozambique,
			Pretoria,
			LaReunion,
			Khabarovsk,
			KhabarovskReserved,
			NewDelhi,
			NewDelhiReserved,
			Novosibirsk,
			NovosibirskReserved,
			Tashkent,
			Jeddah,
			Tokyo,
			TokyoReserved,
			Bangkok,
			Ulaanbaatar,
			Beijing,
			BeijingReserved,
			Seoul,
			BuenosAires,
			BuenosAiresReserved,
			Brasilia,
			BrasiliaReserved,
			Santiago,
			BrazilianSpaceAgencyInpe,
			Colombia,
			Ecuador,
			Peru,
			Venezuela,
			Miami,
			MiamiNhc,
			Montreal,
			MontrealReserved,
			SanFrancisco,
			ArincCenter,
			UsAfGwc,
			CaFnmoc,
			UsNoaaForecastSystemsLaboratory,
			UsNcar,
			ArgosLandover,
			UsNoo,
			Iri,
			Honolulu,
			Darwin,
			DarwinReserved,
			Melbourne67,
			Wellington,
			WellingtonReserved,
			Nadi,
			Singapore,
			Malaysia,
			UkMeteorologicalOffice,
			UkMeteorologicalOfficeReserved,
			Moscow76,
			Offenbach,
			OffenbachReserved,
			Rome,
			RomeReserved,
			Norrkoping,
			NorrkopingReserved,
			Toulouse,
			Toulouse85,
			Helsinki,
			Belgrade,
			Oslo,
			Prague,
			Episkopi,
			Ankara,
			FrankfurtMain,
			London,
			Copenhagen,
			Rota,
			Athens,
			Esa,
			Ecmwf,
			DeBilt,
			Brazzaville,
			Abidjan,
			Libya,
			Madagascar,
			Mauritius,
			Niger,
			Seychelles,
			Uganda,
			Tanzania,
			Zimbabwe,
			HongKong,
			Afghanistan,
			Bahrain,
			Bangladesh,
			Bhutan,
			Cambodia,
			DprKorea,
			Iran,
			Iraq,
			Kazakhstan,
			Kuwait,
			Kyrgyzstan,
			Laos,
			Macao,
			Maldives,
			Myanmar,
			Nepal,
			Oman,
			Pakistan,
			Qatar,
			Yemen,
			SriLanka,
			Tajikistan,
			Turkmenistan,
			Emirates,
			Uzbekistan,
			Vietnam,
			Bolivia,
			Guyana,
			Paraguay,
			Suriname,
			Uruguay,
			FrenchGuyana,
			BrNhc,
			ArConaz,
			AntiguaBarbuda,
			Bahamas,
			Barbados,
			Belize,
			Caribbean,
			SanJose,
			Cuba,
			Dominica,
			DominicanRepublic,
			ElSalvador,
			UsNoaaNesdis,
			UsNoaaOar,
			Guatemala,
			Haiti,
			Honduras,
			Jamaica,
			MexicoCity,
			CuracaoSintMaarten,
			Nicaragua,
			Panama,
			SaintLucia,
			TrinidadTobago,
			FrenchDepartments,
			UsNasa,
			CaIsdmMeds,
			UsUcar,
			UsCimss,
			UsNoaaNos,
			CookIslands,
			FrenchPolynesia,
			Tonga,
			Vanuatu,
			BruneiDarussalam,
			Indonesia,
			Kiribati,
			Micronesia,
			NewCaledonia,
			Niue,
			PapuaNewGuinea,
			Philippines,
			Samoa,
			SolomonIslands,
			NzNiwa,
			Frascati,
			Lanion,
			Lisboa,
			Reykjavik,
			Madrid,
			Zurich,
			ToulouseArgos,
			Bratislava,
			Budapest,
			Ljubljana,
			Warsaw,
			Zagreb,
			Albania,
			Armenia,
			Austria,
			Azerbaijan,
			Belarus,
			Belgium,
			BosniaHerzegovina,
			Bulgaria,
			Cyprus,
			Estonia,
			Georgia,
			Dublin,
			Israel,
			Jordan,
			Latvia,
			Lebanon,
			Lithuania,
			Luxembourg,
			Malta,
			Monaco,
			Romania,
			Syria,
			NorthMacedonia,
			Ukraine,
			Moldova,
			EumetnetOpera,
			Montenegro,
			Cosmo,
			MetCoOp,
			MpiM,
			Eumetsat,
		};
	}
}