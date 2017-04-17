using System;
using System.Xml;
public class Methods{

	public static void Main(){

		XmlDocument xmlDoc= new XmlDocument(); // Create an XML document object
		xmlDoc.Load("antara.xml"); // Load the XML document from the specified file

		// Get elements
		XmlNodeList example = xmlDoc.GetElementsByTagName("description");

		// Display the results
		for (int i=0;i<20;i++){
			Console.WriteLine("test: " + example[i].InnerText);
		}


	}



}


