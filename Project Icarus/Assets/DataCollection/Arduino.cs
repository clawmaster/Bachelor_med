using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class Arduino : MonoBehaviour {

	//to build the delay before starting for arduino to start up.
	public bool wait = true; 
	//Recieves the data into string array. 
	private string[] Recieved;
	private int LimitData = 10; // What second to save data. 
	
	
	SerialPort stream = new SerialPort("COM6", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
	public int GSR = 0;
	public int BPM = 0;
	
	// Use this for initialization
	void Start () {
		stream.Open(); //Open the Serial Stream.
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (Time.time);
		if(wait)
		{
		Delay ();
		}
		else
		{
		string value = stream.ReadLine(); //Read the information
		Recieved = value.Split(','); //My arduino script returns a 2 part value (IE: 12,30,18)
			Debug.Log(Recieved[0]);Debug.Log(Recieved[1]);Debug.Log(Recieved[2]);Debug.Log(Recieved[3]);


			// assigning the values
			bool BGSR = int.TryParse(Recieved[1], out GSR);
			bool BBPM = int.TryParse(Recieved[3], out BPM);

			if( !BGSR || !BBPM )
			{
				Debug.Log("At time: " + Time.time + "one of the values was not a number");
			}


			//writes to XML document


			stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.


		}
		if (Time.time>LimitData)
		{
			LimitData = LimitData+1;
			WriteToXml();
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
		
		string filepath = Application.dataPath + @"/Data/xmldata.xml";
		XmlDocument xmlDoc = new XmlDocument();
		
		if(File.Exists (filepath))
		{
			xmlDoc.Load(filepath);
			
			XmlElement elmRoot = xmlDoc.DocumentElement;
			
			XmlElement elmNew = xmlDoc.CreateElement("magicalDude"); // create the rotation node.

			XmlElement TimeStamp = xmlDoc.CreateElement("Time"); // create the x node.
			TimeStamp.InnerText = SecondsToString(Time.time); // apply to the node text the values of the variable.

			XmlElement valueGSR = xmlDoc.CreateElement("GSR"); // create the x node.
			valueGSR.InnerText = Recieved[1]; // apply to the node text the values of the variable.
			
			XmlElement valueBPM = xmlDoc.CreateElement("BPM"); // create the y node.
			valueBPM.InnerText = Recieved[3]; // apply to the node text the values of the variable.
			
			elmNew.AppendChild(TimeStamp);
			elmNew.AppendChild(valueGSR); // make the rotation node the parent.
			elmNew.AppendChild(valueBPM); // make the rotation node the parent.
			elmRoot.AppendChild(elmNew); // make the transform node the parent.
			
			xmlDoc.Save(filepath); // save file.
		}
		else
		{
			Debug.Log("I CANT FIND THE FILE!!!!!");
		}
	}

	public static string SecondsToString(float sec)
	{
		float minutes = sec / 60;
		float seconds = sec % 60;
		
		return string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
