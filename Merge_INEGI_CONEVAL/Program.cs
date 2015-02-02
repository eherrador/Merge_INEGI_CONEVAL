using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MapeoINEGI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string agebs;
			string datoCONEVAL;
			StringBuilder sb = new StringBuilder ();
			int numAgebs = 0;

			//Usuarios ▸ /Users/eherrador/Desktop/GFK/GeoJSON/Claves Agebs ZM/
			string conevalPath = @"/Users/eherrador/Desktop/GFK/Base de datos Pobreza - CONEVAL/";
			string agebsPath = @"/Users/eherrador/Desktop/GFK/GeoJSON/Claves Agebs ZM/";

			string fileConeval = @"RezagoSocialCONEVAL.txt";
			string fileAGEB = @"TodaslasCiudades.txt";
			string geoJsonFile = @"DatosFiltradosCONEVAL.txt";

			try {
				using (StreamReader streamAgebs = new StreamReader(agebsPath + fileAGEB))
				{
					agebs = streamAgebs.ReadToEnd();
					Console.WriteLine("Se leyo la lista de Agebs...");

					using (StreamReader streamCONEVAL = new StreamReader(conevalPath + fileConeval ))
					{
						Console.WriteLine("Se leyerón los datos de CONEVAL...");
						while((datoCONEVAL = streamCONEVAL.ReadLine()) != null)
						{
							string[] datos = datoCONEVAL.Split(',');
							if (agebs.Contains(datos[0])) {
								Console.WriteLine ("Se encontro: " + datos[0]);
								sb.AppendLine(datoCONEVAL);
								numAgebs++;

							}
							else {
								Console.WriteLine("No se encontro la ageb # " + datos[0]);
							}
						}
					}
				}

				Console.WriteLine("=============================");

				using (StreamWriter outfile = new StreamWriter(conevalPath + geoJsonFile))
				{
					outfile.Write(sb.ToString());
				}

				Console.WriteLine("Se encontraron " + numAgebs + " agebs");
				Console.WriteLine("Proceso terminado...");
				Console.ReadLine();
			}
			catch (Exception e) {

				Console.WriteLine (e.Message);
			}
		}
	}
}
