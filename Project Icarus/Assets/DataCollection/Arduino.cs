using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Arduino : MonoBehaviour {

	//to build the delay before starting for arduino to start up.
	public bool wait = true; 
	//Recieves the data into string array. 
	private string[] Recieved;
	private int LimitData = 10; // What second to save data. 
	
	
	SerialPort stream = new SerialPort("COM3", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
	public int GSR = 0;
	public int BPM = 0;
	public int TOB = 0; //Time of the last beat. in miliseconds

	//Pathway
	private string filename;



	// Use this for initialization
	void Start () {
		//getting files in directory
		var info = new DirectoryInfo(Application.dataPath + @"/Data/");
		var fileInfo = info.GetFiles();
		//foreach (var file in fileInfo) Debug.Log(file);

		//getting level name
		filename = Application.loadedLevelName;
		Debug.Log("Length of fileINfo " + fileInfo.Length);
		filename = filename + "" + ((fileInfo.Length)+1) + ".xml";

		//Debug.Log (filename);


		stream.Open(); //Open the Serial Stream.
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Debug.Log (Time.time);
		if(wait)
		{
		Delay ();
		}
		else
		{
			if (Time.timeSinceLevelLoad>LimitData)
			{
			string value = stream.ReadLine(); //Read the information
			Recieved = value.Split(','); //My arduino script returns a 4 part value (IE: GSR ,12, BPM ,30)
			//Debug.Log(Recieved[0]);Debug.Log(Recieved[1]);Debug.Log(Recieved[2]);Debug.Log(Recieved[3]);


			// assigning the values
			bool BGSR = int.TryParse(Recieved[1], out GSR);
			bool BBPM = int.TryParse(Recieved[3], out BPM);
			bool BTOB = int.TryParse(Recieved[5], out TOB);

			if( !BGSR || !BBPM || !BTOB)
			{
				//Debug.Log("At time: " + Time.timeSinceLevelLoad + "one of the values was not a number");
			}


			//writes to XML document b 


			stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

				LimitData = LimitData+1;
				WriteToXml();

			}
		}



	}
	void Delay()
	{
			if(Time.time > 10)
			{
				wait = false;
			}
	}

	public void WriteToXml()
	{
		
//		string filepath = Application.dataPath + @"/Data/xmldata2.xml";
//		Debug.Log (filepath);
		string filepath = Application.dataPath + (@"/Data/" + filename + ".xml") ;
		XmlDocument xmlDoc = new XmlDocument();
		
		if(File.Exists (filepath))
		{
			//Debug.Log("im inside load part trying to write new value");
			xmlDoc.Load(filepath);
			
			XmlElement elmRoot = xmlDoc.DocumentElement; // create the rotation node.
			xmlDoc.AppendChild(elmRoot); // make the transform node the parent.

			XmlNode TimeStamp = xmlDoc.CreateElement("Time"); // create the x node.
			TimeStamp.InnerText = "" + Time.timeSinceLevelLoad; // apply to the node text the values of the variable.

			XmlNode valueGSR = xmlDoc.CreateElement("GSR"); // create the x node.
			valueGSR.InnerText = Recieved[1]; // apply to the node text the values of the variable.
			
			XmlNode valueBPM = xmlDoc.CreateElement("BPM"); // create the y node.
			valueBPM.InnerText = Recieved[3]; // apply to the node text the values of the variable.

			XmlNode valueTOB = xmlDoc.CreateElement("TOB"); // create the y node.
			valueTOB.InnerText = Recieved[5]; // apply to the node text the values of the variable.


			elmRoot.AppendChild(TimeStamp);
			TimeStamp.AppendChild(valueGSR); // make the rotation node the parent.
			TimeStamp.AppendChild(valueBPM); // make the rotation node the parent.
			TimeStamp.AppendChild(valueTOB); // make the rotation node the parent.

			xmlDoc.Save(filepath); // save file.

		}
		else
		{
			//Debug.Log("im inside write scripted trying to make new file");
			
			XmlElement elmRoot = xmlDoc.CreateElement("User"); // create the rotation node.
			xmlDoc.AppendChild(elmRoot); // make the transform node the parent.
			
			XmlNode TimeStamp = xmlDoc.CreateElement("Time"); // create the x node.
			TimeStamp.InnerText = "" + Time.timeSinceLevelLoad; // apply to the node text the values of the variable.
			
			XmlNode valueGSR = xmlDoc.CreateElement("GSR"); // create the x node.
			valueGSR.InnerText = Recieved[1]; // apply to the node text the values of the variable.
			
			XmlNode valueBPM = xmlDoc.CreateElement("BPM"); // create the y node.
			valueBPM.InnerText = Recieved[3]; // apply to the node text the values of the variable.

			XmlNode valueTOB = xmlDoc.CreateElement("TOB"); // create the y node.
			valueTOB.InnerText = Recieved[5]; // apply to the node text the values of the variable.
			
			elmRoot.AppendChild(TimeStamp);
			TimeStamp.AppendChild(valueGSR); // make the rotation node the parent.
			TimeStamp.AppendChild(valueBPM); // make the rotation node the parent.
			TimeStamp.AppendChild(valueTOB); // make the rotation node the parent.
			
			
			xmlDoc.Save(filepath); // save file.

		}
	}

	public static string SecondsToString(float sec)
	{
		float minutes = sec / 60;
		float seconds = sec % 60;
		
		return string.Format("{0:00}:{20:00}", minutes, seconds);
	}
}
